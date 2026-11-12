using System.Linq;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;

namespace InternetSpeedTest
{
    public partial class InternetSpeedTestForm : Form
    {
        private bool isTesting = false;

        private readonly List<SpeedTestResult> sessionResults = new List<SpeedTestResult>();

        public InternetSpeedTestForm()
        {
            InitializeComponent();
        }

        private async void btnRunTest_Click_1(object sender, EventArgs e)
        {
            if (isTesting)
                return;

            if (cbNumberOfTests.SelectedItem == null ||
                cbMinuteIntervals.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select both the Number of Tests and Minute Interval.",
                    "Input Missing",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int totalTests = int.Parse(cbNumberOfTests.SelectedItem!.ToString()!);
            int minuteInterval = int.Parse(cbMinuteIntervals.SelectedItem!.ToString()!);

            isTesting = true;
            btnRunTest.Enabled = false;

            sessionResults.Clear();
            SpeedTestResultsTxt.Clear();

            LogColorToUI("=== Starting Bandwidth Test Session ===", Color.Blue);

            for (int i = 1; i <= totalTests; i++)
            {
                LogColorToUI($"Running test {i} of {totalTests}...", Color.DarkOrange);

                SpeedTestResult? result = await Task.Run(() => SpeedtestCLI());

                if (result != null)
                {
                    sessionResults.Add(result);

                    LogColorToUI(
                        $"[SUCCESS] Test {i} -> " +
                        $"Down: {result.Download:F2} Mbps | " +
                        $"Up: {result.Upload:F2} Mbps | " +
                        $"Ping: {result.Ping:F0} ms | " +
                        $"Jitter: {result.Jitter:F2} ms",
                        Color.Green);
                }
                else
                {
                    LogColorToUI(
                        $"[FAILED] Test {i} failed.",
                        Color.Red);
                }

                if (i < totalTests)
                {
                    LogColorToUI(
                        $"Waiting {minuteInterval} minute(s)...",
                        Color.Gray);

                    await Task.Delay(minuteInterval * 60000);
                }
            }

            LogColorToUI("=== Testing Complete ===", Color.Blue);

            btnRunTest.Enabled = true;
            isTesting = false;

            MessageBox.Show(
                $"Testing process finished! Successfully logged {sessionResults.Count} data point(s).",
                "Complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private SpeedTestResult? SpeedtestCLI()
        {
            try
            {
                string cliPath = Path.Combine(Application.StartupPath, "speedtest.exe");

                if (!File.Exists(cliPath))
                {
                    Invoke(new Action(() =>
                        LogColorToUI("speedtest.exe not found.", Color.Red)));

                    return null;
                }

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = cliPath,
                    Arguments = "--format=json --accept-license --accept-gdpr",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process? process = Process.Start(startInfo))
                {
                    if (process == null)
                        return null;

                    string jsonOutput = process.StandardOutput.ReadToEnd();

                    process.WaitForExit();

                    JObject json = JObject.Parse(jsonOutput);

                    return new SpeedTestResult
                    {
                        Timestamp = DateTime.Now,

                        Download = json["download"]?["bandwidth"] != null
                            ? (double)json["download"]!["bandwidth"]! / 125000
                            : 0,

                        Upload = json["upload"]?["bandwidth"] != null
                            ? (double)json["upload"]!["bandwidth"]! / 125000
                            : 0,

                        Ping = json["ping"]?["latency"] != null
                            ? (double)json["ping"]!["latency"]!
                            : 0,

                        Jitter = json["ping"]?["jitter"] != null
                            ? (double)json["ping"]!["jitter"]!
                            : 0
                    };
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                    LogColorToUI($"CLI Error: {ex.Message}", Color.Red)));

                return null;
            }
        }
        private void LogColorToUI(string message, Color colour)
        {
            if (SpeedTestResultsTxt.InvokeRequired)
            {
                SpeedTestResultsTxt.Invoke(new Action(() =>
                    LogColorToUI(message, colour)));

                return;
            }

            SpeedTestResultsTxt.SelectionStart = SpeedTestResultsTxt.TextLength;
            SpeedTestResultsTxt.SelectionLength = 0;
            SpeedTestResultsTxt.SelectionColor = colour;

            SpeedTestResultsTxt.AppendText(
                $"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");

            SpeedTestResultsTxt.SelectionColor = SpeedTestResultsTxt.ForeColor;
            SpeedTestResultsTxt.ScrollToCaret();
        }

        public class SpeedTestResult
        {
            public DateTime Timestamp { get; set; }

            public double Download { get; set; }

            public double Upload { get; set; }

            public double Ping { get; set; }

            public double Jitter { get; set; }

            public double PacketLoss { get; set; }
        }

        private void InternetSpeedTest_Load(object sender, EventArgs e)
        {
            cbNumberOfTests.Items.Clear();

            cbNumberOfTests.Items.AddRange(new object[]
            {
                "1",
                "2",
                "3",
                "5",
                "10",
                "20"
            });

            cbNumberOfTests.SelectedIndex = 0;

            cbMinuteIntervals.Items.Clear();

            cbMinuteIntervals.Items.AddRange(new object[]
            {
                "1",
                "2",
                "3",
                "5",
                "10",
                "15",
                "30",
                "60"
            });

            cbMinuteIntervals.SelectedIndex = 0;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void ExportResultsToPDF()
        {
            if (sessionResults.Count == 0)
            {
                MessageBox.Show("No test results available to export.");
                return;
            }

            SaveFileDialog save = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                FileName = "SpeedTestResults.pdf",
                Title = "Save Test Results"
            };

            if (save.ShowDialog() != DialogResult.OK)
                return;

            PdfWriter writer = new PdfWriter(save.FileName);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            // Fonts
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont normalFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            // Title
            Paragraph title = new Paragraph("Internet Speed Test Report");
            title.SetFont(boldFont);
            title.SetFontSize(20);
            document.Add(title);

            // Date
            Paragraph generated = new Paragraph($"Generated: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            generated.SetFont(normalFont);
            document.Add(generated);

            document.Add(new Paragraph(" "));

            // Table
            Table table = new Table(5);
            table.SetWidth(UnitValue.CreatePercentValue(100));

            table.AddHeaderCell(new Cell().Add(new Paragraph("Test").SetFont(boldFont)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Download").SetFont(boldFont)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Upload").SetFont(boldFont)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Ping").SetFont(boldFont)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Jitter").SetFont(boldFont)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Packet Loss").SetFont(boldFont)));
            int count = 1;

            foreach (SpeedTestResult result in sessionResults)
            {
                table.AddCell(count.ToString());
                table.AddCell($"{result.Download:F2} Mbps");
                table.AddCell($"{result.Upload:F2} Mbps");
                table.AddCell($"{result.Ping:F2} ms");
                table.AddCell($"{result.Jitter:F2} ms");
                table.AddCell($"{result.PacketLoss:F2} %");
                count++;
            }

            document.Add(table);

            document.Add(new Paragraph(" "));

            // Summary Heading
            Paragraph summary = new Paragraph("Session Summary");
            summary.SetFont(boldFont);
            summary.SetFontSize(14);
            document.Add(summary);

            document.Add(new Paragraph($"Total Tests: {sessionResults.Count}").SetFont(normalFont));
            document.Add(new Paragraph($"Average Download: {sessionResults.Average(x => x.Download):F2} Mbps").SetFont(normalFont));
            document.Add(new Paragraph($"Average Upload: {sessionResults.Average(x => x.Upload):F2} Mbps").SetFont(normalFont));
            document.Add(new Paragraph($"Average Ping: {sessionResults.Average(x => x.Ping):F2} ms").SetFont(normalFont));
            document.Add(new Paragraph($"Average Jitter: {sessionResults.Average(x => x.Jitter):F2} ms").SetFont(normalFont));
            document.Add(new Paragraph($"Average Packet Loss: {sessionResults.Average(x => x.PacketLoss):F2} %").SetFont(normalFont));

            

            document.Close();

            MessageBox.Show(
                "PDF exported successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void btnCovertpdf_Click(object sender, EventArgs e)
        {
            ExportResultsToPDF();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MainMenubtn_Click(object sender, EventArgs e)
        {
            InternetSpeedTestForm.ActiveForm.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }
}
