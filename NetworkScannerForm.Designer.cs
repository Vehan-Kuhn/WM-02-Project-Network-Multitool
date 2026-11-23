namespace InternetSpeedTest
{
    partial class NetworkScannerForm
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
            RunScanbtn = new Button();
            NetworkScannerlbl = new Label();
            ScannerResultsTxt = new RichTextBox();
            ConvertToPdfbtn = new Button();
            MainMenu = new Button();
            Exitbtn = new Button();
            lblSubtitle = new Label();
            lblNetworkInfo = new Label();
            lblResultsHeading = new Label();
            lblStatus = new Label();
            panelHeader = new Panel();
            panelActions = new Panel();
            panelResults = new Panel();
            panelHeader.SuspendLayout();
            panelActions.SuspendLayout();
            panelResults.SuspendLayout();
            SuspendLayout();

            // Form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(1100, 760);
            MinimumSize = new Size(950, 650);
            StartPosition = FormStartPosition.CenterScreen;
            Name = "NetworkScannerForm";
            Text = "Network Scanner";
            ForeColor = Color.FromArgb(226, 232, 240);

            // Header
            panelHeader.BackColor = Color.FromArgb(30, 41, 59);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 145;
            panelHeader.Controls.Add(NetworkScannerlbl);
            panelHeader.Controls.Add(lblSubtitle);

            NetworkScannerlbl.AutoSize = true;
            NetworkScannerlbl.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            NetworkScannerlbl.ForeColor = Color.White;
            NetworkScannerlbl.Location = new Point(35, 20);
            NetworkScannerlbl.Name = "NetworkScannerlbl";
            NetworkScannerlbl.Text = "Network Scanner";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(148, 163, 184);
            lblSubtitle.Location = new Point(40, 82);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Text = "Discover devices and inspect the information available on your local network.";

            // Actions panel
            panelActions.BackColor = Color.FromArgb(15, 23, 42);
            panelActions.Location = new Point(35, 165);
            panelActions.Size = new Size(1030, 75);
            panelActions.Name = "panelActions";

            RunScanbtn.BackColor = Color.FromArgb(5, 150, 105);
            RunScanbtn.FlatAppearance.BorderSize = 0;
            RunScanbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(4, 120, 87);
            RunScanbtn.FlatStyle = FlatStyle.Flat;
            RunScanbtn.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            RunScanbtn.ForeColor = Color.White;
            RunScanbtn.Location = new Point(0, 10);
            RunScanbtn.Name = "RunScanbtn";
            RunScanbtn.Size = new Size(175, 48);
            RunScanbtn.TabIndex = 0;
            RunScanbtn.Text = "Start Scan";
            RunScanbtn.UseVisualStyleBackColor = false;
            RunScanbtn.Cursor = Cursors.Hand;
            RunScanbtn.Click += RunScanbtn_Click;

            ConvertToPdfbtn.BackColor = Color.FromArgb(37, 99, 235);
            ConvertToPdfbtn.FlatAppearance.BorderSize = 0;
            ConvertToPdfbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            ConvertToPdfbtn.FlatStyle = FlatStyle.Flat;
            ConvertToPdfbtn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            ConvertToPdfbtn.ForeColor = Color.White;
            ConvertToPdfbtn.Location = new Point(190, 10);
            ConvertToPdfbtn.Name = "ConvertToPdfbtn";
            ConvertToPdfbtn.Size = new Size(160, 48);
            ConvertToPdfbtn.TabIndex = 1;
            ConvertToPdfbtn.Text = "Export PDF";
            ConvertToPdfbtn.UseVisualStyleBackColor = false;
            ConvertToPdfbtn.Cursor = Cursors.Hand;
            ConvertToPdfbtn.Click += ConvertToPdfbtn_Click;

            MainMenu.BackColor = Color.FromArgb(51, 65, 85);
            MainMenu.FlatAppearance.BorderSize = 0;
            MainMenu.FlatAppearance.MouseOverBackColor = Color.FromArgb(71, 85, 105);
            MainMenu.FlatStyle = FlatStyle.Flat;
            MainMenu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            MainMenu.ForeColor = Color.White;
            MainMenu.Location = new Point(365, 10);
            MainMenu.Name = "MainMenu";
            MainMenu.Size = new Size(145, 48);
            MainMenu.TabIndex = 2;
            MainMenu.Text = "Main Menu";
            MainMenu.UseVisualStyleBackColor = false;
            MainMenu.Cursor = Cursors.Hand;
            MainMenu.Click += MainMenu_Click;

            Exitbtn.BackColor = Color.FromArgb(127, 29, 29);
            Exitbtn.FlatAppearance.BorderSize = 0;
            Exitbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(153, 27, 27);
            Exitbtn.FlatStyle = FlatStyle.Flat;
            Exitbtn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Exitbtn.ForeColor = Color.White;
            Exitbtn.Location = new Point(525, 10);
            Exitbtn.Name = "Exitbtn";
            Exitbtn.Size = new Size(110, 48);
            Exitbtn.TabIndex = 3;
            Exitbtn.Text = "Exit";
            Exitbtn.UseVisualStyleBackColor = false;
            Exitbtn.Cursor = Cursors.Hand;
            Exitbtn.Click += Exitbtn_Click;

            panelActions.Controls.Add(RunScanbtn);
            panelActions.Controls.Add(ConvertToPdfbtn);
            panelActions.Controls.Add(MainMenu);
            panelActions.Controls.Add(Exitbtn);

            // Results panel
            panelResults.BackColor = Color.FromArgb(30, 41, 59);
            panelResults.Location = new Point(35, 260);
            panelResults.Size = new Size(1030, 455);
            panelResults.Name = "panelResults";
            panelResults.Padding = new Padding(18);

            lblResultsHeading.AutoSize = true;
            lblResultsHeading.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblResultsHeading.ForeColor = Color.White;
            lblResultsHeading.Location = new Point(20, 15);
            lblResultsHeading.Name = "lblResultsHeading";
            lblResultsHeading.Text = "Scan Results";

            lblNetworkInfo.AutoSize = true;
            lblNetworkInfo.Font = new Font("Segoe UI", 9F);
            lblNetworkInfo.ForeColor = Color.FromArgb(148, 163, 184);
            lblNetworkInfo.Location = new Point(22, 48);
            lblNetworkInfo.Name = "lblNetworkInfo";
            lblNetworkInfo.Text = "Run a scan to view local network and discovered device information.";

            ScannerResultsTxt.BackColor = Color.FromArgb(15, 23, 42);
            ScannerResultsTxt.BorderStyle = BorderStyle.None;
            ScannerResultsTxt.Font = new Font("Consolas", 10F);
            ScannerResultsTxt.ForeColor = Color.FromArgb(226, 232, 240);
            ScannerResultsTxt.Location = new Point(20, 82);
            ScannerResultsTxt.Name = "ScannerResultsTxt";
            ScannerResultsTxt.ReadOnly = true;
            ScannerResultsTxt.Size = new Size(990, 330);
            ScannerResultsTxt.TabIndex = 4;
            ScannerResultsTxt.Text = "";

            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 8.5F);
            lblStatus.ForeColor = Color.FromArgb(148, 163, 184);
            lblStatus.Location = new Point(22, 420);
            lblStatus.Name = "lblStatus";
            lblStatus.Text = "Ready";

            panelResults.Controls.Add(lblResultsHeading);
            panelResults.Controls.Add(lblNetworkInfo);
            panelResults.Controls.Add(ScannerResultsTxt);
            panelResults.Controls.Add(lblStatus);

            Controls.Add(panelHeader);
            Controls.Add(panelActions);
            Controls.Add(panelResults);

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelActions.ResumeLayout(false);
            panelResults.ResumeLayout(false);
            panelResults.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button RunScanbtn;
        private Label NetworkScannerlbl;
        private RichTextBox ScannerResultsTxt;
        private Button ConvertToPdfbtn;
        private Button MainMenu;
        private Button Exitbtn;
        private Label lblSubtitle;
        private Label lblNetworkInfo;
        private Label lblResultsHeading;
        private Label lblStatus;
        private Panel panelHeader;
        private Panel panelActions;
        private Panel panelResults;
    }
}
