namespace InternetSpeedTest
{
    partial class MainMenu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblHeader = new Label();
            Subheaderlbl = new Label();
            InternetSpeedTestbtn = new Button();
            NetworkScannerbtn = new Button();
            InternetSpeedTestlbl = new Label();
            NetworkScannerlbl = new Label();
            lblBrand = new Label();
            lblDescription = new Label();
            lblSpeedDescription = new Label();
            lblScannerDescription = new Label();
            lblFooter = new Label();
            panelHeader = new Panel();
            panelSpeed = new Panel();
            panelScanner = new Panel();
            panelHeader.SuspendLayout();
            panelSpeed.SuspendLayout();
            panelScanner.SuspendLayout();
            SuspendLayout();

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(1100, 700);
            MinimumSize = new Size(950, 620);
            Name = "MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Network Multitool";
            ForeColor = Color.FromArgb(226, 232, 240);

            // Header
            panelHeader.BackColor = Color.FromArgb(30, 41, 59);
            panelHeader.Controls.Add(lblBrand);
            panelHeader.Controls.Add(lblHeader);
            panelHeader.Controls.Add(Subheaderlbl);
            panelHeader.Controls.Add(lblDescription);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 190;

            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblBrand.ForeColor = Color.FromArgb(96, 165, 250);
            lblBrand.Location = new Point(44, 20);
            lblBrand.Name = "lblBrand";
            lblBrand.Text = "NETWORK MULTITOOL  /  IT DIAGNOSTICS";

            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 27F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(40, 53);
            lblHeader.Name = "lblHeader";
            lblHeader.Text = "Network Diagnostics";

            Subheaderlbl.AutoSize = true;
            Subheaderlbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Subheaderlbl.ForeColor = Color.FromArgb(203, 213, 225);
            Subheaderlbl.Location = new Point(44, 112);
            Subheaderlbl.Name = "Subheaderlbl";
            Subheaderlbl.Text = "Choose a tool to get started";

            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9.5F);
            lblDescription.ForeColor = Color.FromArgb(148, 163, 184);
            lblDescription.Location = new Point(44, 145);
            lblDescription.Name = "lblDescription";
            lblDescription.Text = "Test connection performance and discover devices on your local network.";

            // Speed test card
            panelSpeed.BackColor = Color.FromArgb(30, 41, 59);
            panelSpeed.Location = new Point(65, 245);
            panelSpeed.Name = "panelSpeed";
            panelSpeed.Size = new Size(455, 315);

            InternetSpeedTestlbl.AutoSize = true;
            InternetSpeedTestlbl.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold);
            InternetSpeedTestlbl.ForeColor = Color.White;
            InternetSpeedTestlbl.Location = new Point(28, 30);
            InternetSpeedTestlbl.Name = "InternetSpeedTestlbl";
            InternetSpeedTestlbl.Text = "Internet Speed Test";

            lblSpeedDescription.AutoSize = false;
            lblSpeedDescription.Font = new Font("Segoe UI", 10.5F);
            lblSpeedDescription.ForeColor = Color.FromArgb(203, 213, 225);
            lblSpeedDescription.Location = new Point(32, 92);
            lblSpeedDescription.Name = "lblSpeedDescription";
            lblSpeedDescription.Size = new Size(385, 75);
            lblSpeedDescription.Text = "Measure download and upload throughput, ping, jitter and packet loss using your selected test server.";

            InternetSpeedTestbtn.BackColor = Color.FromArgb(37, 99, 235);
            InternetSpeedTestbtn.FlatAppearance.BorderSize = 0;
            InternetSpeedTestbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            InternetSpeedTestbtn.FlatStyle = FlatStyle.Flat;
            InternetSpeedTestbtn.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            InternetSpeedTestbtn.ForeColor = Color.White;
            InternetSpeedTestbtn.Location = new Point(32, 210);
            InternetSpeedTestbtn.Name = "InternetSpeedTestbtn";
            InternetSpeedTestbtn.Size = new Size(385, 58);
            InternetSpeedTestbtn.TabIndex = 0;
            InternetSpeedTestbtn.Text = "Open Internet Speed Test";
            InternetSpeedTestbtn.UseVisualStyleBackColor = false;
            InternetSpeedTestbtn.Cursor = Cursors.Hand;
            InternetSpeedTestbtn.Click += InternetSpeedTestbtn_Click;

            // Network scanner card
            panelScanner.BackColor = Color.FromArgb(30, 41, 59);
            panelScanner.Location = new Point(580, 245);
            panelScanner.Name = "panelScanner";
            panelScanner.Size = new Size(455, 315);

            NetworkScannerlbl.AutoSize = true;
            NetworkScannerlbl.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold);
            NetworkScannerlbl.ForeColor = Color.White;
            NetworkScannerlbl.Location = new Point(28, 30);
            NetworkScannerlbl.Name = "NetworkScannerlbl";
            NetworkScannerlbl.Text = "Network Scanner";

            lblScannerDescription.AutoSize = false;
            lblScannerDescription.Font = new Font("Segoe UI", 10.5F);
            lblScannerDescription.ForeColor = Color.FromArgb(203, 213, 225);
            lblScannerDescription.Location = new Point(32, 92);
            lblScannerDescription.Name = "lblScannerDescription";
            lblScannerDescription.Size = new Size(385, 75);
            lblScannerDescription.Text = "Scan your local subnet to identify available devices and collect IP, MAC address and manufacturer information.";

            NetworkScannerbtn.BackColor = Color.FromArgb(5, 150, 105);
            NetworkScannerbtn.FlatAppearance.BorderSize = 0;
            NetworkScannerbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(4, 120, 87);
            NetworkScannerbtn.FlatStyle = FlatStyle.Flat;
            NetworkScannerbtn.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            NetworkScannerbtn.ForeColor = Color.White;
            NetworkScannerbtn.Location = new Point(32, 210);
            NetworkScannerbtn.Name = "NetworkScannerbtn";
            NetworkScannerbtn.Size = new Size(385, 58);
            NetworkScannerbtn.TabIndex = 1;
            NetworkScannerbtn.Text = "Open Network Scanner";
            NetworkScannerbtn.UseVisualStyleBackColor = false;
            NetworkScannerbtn.Cursor = Cursors.Hand;
            NetworkScannerbtn.Click += NetworkScannerbtn_Click;

            // Footer
            lblFooter.AutoSize = true;
            lblFooter.Font = new Font("Segoe UI", 9F);
            lblFooter.ForeColor = Color.FromArgb(148, 163, 184);
            lblFooter.Location = new Point(65, 625);
            lblFooter.Name = "lblFooter";
            lblFooter.Text = "NETWORK MULTITOOL  •  IT SUPPORT & TROUBLESHOOTING";

            panelSpeed.Controls.Add(InternetSpeedTestlbl);
            panelSpeed.Controls.Add(lblSpeedDescription);
            panelSpeed.Controls.Add(InternetSpeedTestbtn);
            panelScanner.Controls.Add(NetworkScannerlbl);
            panelScanner.Controls.Add(lblScannerDescription);
            panelScanner.Controls.Add(NetworkScannerbtn);

            Controls.Add(panelHeader);
            Controls.Add(panelSpeed);
            Controls.Add(panelScanner);
            Controls.Add(lblFooter);

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSpeed.ResumeLayout(false);
            panelSpeed.PerformLayout();
            panelScanner.ResumeLayout(false);
            panelScanner.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeader;
        private Label Subheaderlbl;
        private Button InternetSpeedTestbtn;
        private Button NetworkScannerbtn;
        private Label InternetSpeedTestlbl;
        private Label NetworkScannerlbl;
        private Label lblBrand;
        private Label lblDescription;
        private Label lblSpeedDescription;
        private Label lblScannerDescription;
        private Label lblFooter;
        private Panel panelHeader;
        private Panel panelSpeed;
        private Panel panelScanner;
    }
}
