
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace InternetSpeedTest
{
    public partial class NetworkScannerForm : Form
    {
        // Stores the latest successful scan for PDF reporting
        private bool scanCompleted;
        private List<NetworkDevice> discoveredDevices = new List<NetworkDevice>();
        private NetworkInfo? lastNetworkInfo;
        private DateTime lastScanTime;

        // Windows ARP function
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        private static extern int SendARP(
            uint DestIP,
            uint SrcIP,
            byte[] pMacAddr,
            ref int PhyAddrLen
        );


        public NetworkScannerForm()
        {
            InitializeComponent();

            ScannerResultsTxt.ReadOnly = true;
            ScannerResultsTxt.Font =
                new System.Drawing.Font("Consolas", 10);

            ConvertToPdfbtn.Enabled = false;
        }

        // Stores discovered network devices
        private class NetworkDevice
        {
            public string IPAddress { get; set; } = string.Empty;

            public string MACAddress { get; set; } = string.Empty;

            public string Manufacturer { get; set; } = string.Empty;
        }

        // Stores local network information
        private class NetworkInfo
        {
            public IPAddress LocalIP { get; set; } = IPAddress.None;

            public IPAddress SubnetMask { get; set; } = IPAddress.None;

            public IPAddress NetworkAddress { get; set; } = IPAddress.None;

            public int PrefixLength { get; set; }
        }

        // Detect active network adapter
        private NetworkInfo DetectLocalNetwork()
        {
            foreach (NetworkInterface adapter
                in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (adapter.OperationalStatus !=
                    OperationalStatus.Up)
                    continue;

                if (adapter.NetworkInterfaceType ==
                    NetworkInterfaceType.Loopback ||
                    adapter.NetworkInterfaceType ==
                    NetworkInterfaceType.Tunnel)
                    continue;

                var properties = adapter.GetIPProperties();

                bool hasGateway = properties.GatewayAddresses
                    .Any(g => g.Address.AddressFamily ==
                        System.Net.Sockets.AddressFamily.InterNetwork &&
                        !g.Address.Equals(IPAddress.Any));

                if (!hasGateway)
                    continue;

                foreach (var address in properties.UnicastAddresses)
                {
                    if (address.Address.AddressFamily !=
                        System.Net.Sockets.AddressFamily.InterNetwork)
                        continue;

                    IPAddress ip = address.Address;
                    IPAddress mask = address.IPv4Mask;

                    if (mask == null)
                        continue;

                    byte[] ipBytes = ip.GetAddressBytes();
                    byte[] maskBytes = mask.GetAddressBytes();

                    byte[] networkBytes = new byte[4];

                    for (int i = 0; i < 4; i++)
                    {
                        networkBytes[i] =
                            (byte)(ipBytes[i] & maskBytes[i]);
                    }

                    int prefixLength = 0;

                    foreach (byte b in maskBytes)
                    {
                        for (int bit = 7; bit >= 0; bit--)
                        {
                            if ((b & (1 << bit)) != 0)
                                prefixLength++;
                        }
                    }

                    return new NetworkInfo
                    {
                        LocalIP = ip,
                        SubnetMask = mask,
                        NetworkAddress =
                            new IPAddress(networkBytes),
                        PrefixLength = prefixLength
                    };
                }
            }

            throw new Exception(
                "No active network adapter with an IPv4 gateway was found."
            );
        }

        // Convert an IPv4 address to a numeric value
        private uint IPToUInt(IPAddress address)
        {
            byte[] b = address.GetAddressBytes();

            return ((uint)b[0] << 24) |
                   ((uint)b[1] << 16) |
                   ((uint)b[2] << 8) |
                   b[3];
        }

        // Convert a numeric value back to IPv4
        private IPAddress UIntToIP(uint value)
        {
            return new IPAddress(new byte[]
            {
                (byte)(value >> 24),
                (byte)(value >> 16),
                (byte)(value >> 8),
                (byte)value
            });
        }

        // Retrieve a MAC address using Windows ARP
        private string GetMacAddress(IPAddress ip)
        {
            byte[] mac = new byte[8];
            int length = mac.Length;

            uint destination = BitConverter.ToUInt32(
                ip.GetAddressBytes(), 0);

            int result = SendARP(
                destination,
                0,
                mac,
                ref length
            );

            if (result != 0 || length < 6)
                return "Unavailable";

            return string.Join(":",
                mac.Take(length)
                   .Select(b => b.ToString("X2")));
        }

        // Discover devices on the local network
        private async Task<List<NetworkDevice>>
            ScanNetworkAsync(NetworkInfo network)
        {
            List<NetworkDevice> devices =
                new List<NetworkDevice>();

            uint networkAddress =
                IPToUInt(network.NetworkAddress);

            uint mask = IPToUInt(network.SubnetMask);

            uint broadcastAddress =
                networkAddress | ~mask;

            uint totalAddresses =
                broadcastAddress - networkAddress + 1;

            // Protect against excessively large scans
            if (network.PrefixLength < 20)
            {
                throw new Exception(
                    "Your subnet is larger than the supported scan range. " +
                    "Please use a smaller network range."
                );
            }

            using (SemaphoreSlim semaphore =
                new SemaphoreSlim(64))
            {
                List<Task> tasks = new List<Task>();

                for (uint i = networkAddress + 1;
                     i < broadcastAddress;
                     i++)
                {
                    IPAddress target = UIntToIP(i);

                    if (target.Equals(network.LocalIP))
                        continue;

                    await semaphore.WaitAsync();

                    tasks.Add(Task.Run(() =>
                    {
                        try
                        {
                            string mac = GetMacAddress(target);

                            if (mac != "Unavailable")
                            {
                                lock (devices)
                                {
                                    devices.Add(new NetworkDevice
                                    {
                                        IPAddress = target.ToString(),
                                        MACAddress = mac,
                                        Manufacturer =
                                            GetManufacturer(mac)
                                    });
                                }
                            }
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    }));
                }

                await Task.WhenAll(tasks);
            }

            return devices
                .OrderBy(d => IPToUInt(
                    IPAddress.Parse(d.IPAddress)))
                .ToList();
        }

        // Temporary manufacturer lookup
        // IEEE OUI database integration comes in Step 2
        private string GetManufacturer(string mac)
        {
            return "Unknown";
        }

        // Run Scan button
        private async void RunScanbtn_Click(
            object sender, EventArgs e)
        {
            RunScanbtn.Enabled = false;
            ConvertToPdfbtn.Enabled = false;

            scanCompleted = false;
            discoveredDevices.Clear();
            lastNetworkInfo = null;

            ScannerResultsTxt.Clear();

            ScannerResultsTxt.AppendText(
                "========================================\r\n" +
                "           NETWORK SCANNER\r\n" +
                "========================================\r\n\r\n" +
                "Detecting local network...\r\n"
            );

            try
            {
                NetworkInfo network = DetectLocalNetwork();

                ScannerResultsTxt.AppendText(
                    "Local IP: " + network.LocalIP + "\r\n" +
                    "Subnet Mask: " + network.SubnetMask + "\r\n" +
                    "Network: " + network.NetworkAddress +
                    "/" + network.PrefixLength + "\r\n\r\n" +
                    "Scanning network. Please wait...\r\n\r\n"
                );

                List<NetworkDevice> devices =
                    await ScanNetworkAsync(network);

                // Keep the scan data available for PDF export.
                discoveredDevices = devices;
                lastNetworkInfo = network;
                lastScanTime = DateTime.Now;
                scanCompleted = true;

                ScannerResultsTxt.AppendText(
                    "========================================\r\n" +
                    "          DISCOVERED DEVICES\r\n" +
                    "========================================\r\n\r\n"
                );

                foreach (NetworkDevice device in devices)
                {
                    ScannerResultsTxt.AppendText(
                        "IP Address: " + device.IPAddress + "\r\n" +
                        "MAC Address: " + device.MACAddress + "\r\n" +
                        "Manufacturer: " + device.Manufacturer +
                        "\r\n----------------------------------------\r\n"
                    );
                }

                ScannerResultsTxt.AppendText(
                    "\r\nTotal Devices Found: " +
                    devices.Count +
                    "\r\nScan Status: Completed\r\n"
                );

                ConvertToPdfbtn.Enabled = true;

                MessageBox.Show(
                    "Network scan completed successfully.\n" +
                    "Devices found: " + devices.Count,
                    "Scan Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                ScannerResultsTxt.AppendText(
                    "\r\nSCAN ERROR: " + ex.Message
                );

                MessageBox.Show(
                    ex.Message,
                    "Network Scanner Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                RunScanbtn.Enabled = true;
            }
        }

        // Export the latest successful network scan to PDF
        private void ConvertToPdfbtn_Click(object sender, EventArgs e)
        {
            if (!scanCompleted || lastNetworkInfo == null)
            {
                MessageBox.Show(
                    "Please complete a network scan before exporting.",
                    "No Scan Results",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using SaveFileDialog save = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                FileName = $"NetworkScan_{DateTime.Now:yyyyMMdd_HHmmss}.pdf",
                Title = "Export Network Scan Report",
                DefaultExt = "pdf",
                AddExtension = true
            };

            if (save.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using PdfWriter writer = new PdfWriter(save.FileName);
                using PdfDocument pdf = new PdfDocument(writer);
                using Document document = new Document(pdf);

                PdfFont boldFont =
                    PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                PdfFont normalFont =
                    PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                // Report heading and generation details
                document.Add(
                    new Paragraph("NETWORK SCAN REPORT")
                        .SetFont(boldFont)
                        .SetFontSize(22));

                document.Add(
                    new Paragraph("Network Diagnostics Toolkit")
                        .SetFont(normalFont)
                        .SetFontSize(11));

                document.Add(
                    new Paragraph($"Report Generated: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
                        .SetFont(normalFont));

                document.Add(new Paragraph(" "));

                // Network information
                document.Add(
                    new Paragraph("NETWORK INFORMATION")
                        .SetFont(boldFont)
                        .SetFontSize(15));

                document.Add(
                    new Paragraph($"Local IP Address: {lastNetworkInfo.LocalIP}")
                        .SetFont(normalFont));

                document.Add(
                    new Paragraph($"Subnet Mask: {lastNetworkInfo.SubnetMask}")
                        .SetFont(normalFont));

                document.Add(
                    new Paragraph(
                        $"Network Address: {lastNetworkInfo.NetworkAddress}/{lastNetworkInfo.PrefixLength}")
                        .SetFont(normalFont));

                document.Add(
                    new Paragraph($"Scan Completed: {lastScanTime:dd/MM/yyyy HH:mm:ss}")
                        .SetFont(normalFont));

                document.Add(new Paragraph(" "));

                // Scan summary
                document.Add(
                    new Paragraph("SCAN SUMMARY")
                        .SetFont(boldFont)
                        .SetFontSize(15));

                document.Add(
                    new Paragraph($"Total Devices Discovered: {discoveredDevices.Count}")
                        .SetFont(normalFont));

                document.Add(
                    new Paragraph("Scan Status: Completed")
                        .SetFont(normalFont));

                document.Add(new Paragraph(" "));

                // Discovered device table
                document.Add(
                    new Paragraph("DISCOVERED DEVICES")
                        .SetFont(boldFont)
                        .SetFontSize(15));

                Table table = new Table(4);
                table.SetWidth(UnitValue.CreatePercentValue(100));

                table.AddHeaderCell(
                    new Cell().Add(new Paragraph("No.").SetFont(boldFont)));

                table.AddHeaderCell(
                    new Cell().Add(new Paragraph("IP Address").SetFont(boldFont)));

                table.AddHeaderCell(
                    new Cell().Add(new Paragraph("MAC Address").SetFont(boldFont)));

                table.AddHeaderCell(
                    new Cell().Add(new Paragraph("Manufacturer").SetFont(boldFont)));

                int count = 1;

                foreach (NetworkDevice device in discoveredDevices)
                {
                    table.AddCell(count.ToString());
                    table.AddCell(device.IPAddress);
                    table.AddCell(device.MACAddress);
                    table.AddCell(device.Manufacturer);
                    count++;
                }

                if (discoveredDevices.Count == 0)
                {
                    table.AddCell(
                        new Cell(1, 4).Add(
                            new Paragraph("No devices were discovered during this scan.")
                                .SetFont(normalFont)));
                }

                document.Add(table);

                document.Add(new Paragraph(" "));

                document.Add(
                    new Paragraph("End of Network Scan Report")
                        .SetFont(boldFont)
                        .SetFontSize(10));

                document.Close();

                MessageBox.Show(
                    "Network scan report exported successfully!",
                    "Export Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while exporting the PDF:\n\n" + ex.Message,
                    "PDF Export Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Main Menu button
        private void MainMenu_Click(object sender, EventArgs e)
        {
            Hide();

            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        // Exit button
        private void Exitbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
