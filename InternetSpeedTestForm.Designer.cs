namespace InternetSpeedTest
{
    partial class InternetSpeedTestForm
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
            btnRunTest = new Button();
            btnExit = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            cbNumberOfTests = new ComboBox();
            cbMinuteIntervals = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            SpeedTestResultsTxt = new RichTextBox();
            lblHeader = new Label();
            button1 = new Button();
            btnCovertpdf = new Button();
            MainMenubtn = new Button();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            lblSubtitle = new Label();
            lblConfiguration = new Label();
            lblResultsHeading = new Label();
            lblTestCountHint = new Label();
            lblIntervalHint = new Label();
            panelHeader = new Panel();
            panelConfiguration = new Panel();
            panelActions = new Panel();
            panelResults = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelHeader.SuspendLayout();
            panelConfiguration.SuspendLayout();
            panelActions.SuspendLayout();
            panelResults.SuspendLayout();
            SuspendLayout();

            // Form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(1100, 790);
            MinimumSize = new Size(980, 680);
            StartPosition = FormStartPosition.CenterScreen;
            Name = "InternetSpeedTestForm";
            Text = "Internet Speed Test";
            ForeColor = Color.FromArgb(226, 232, 240);
            Load += InternetSpeedTest_Load;

            // Header
            panelHeader.BackColor = Color.FromArgb(30, 41, 59);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 145;
            panelHeader.Controls.Add(lblHeader);
            panelHeader.Controls.Add(lblSubtitle);

            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(35, 20);
            lblHeader.Name = "lblHeader";
            lblHeader.Text = "Internet Speed Test";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(148, 163, 184);
            lblSubtitle.Location = new Point(40, 82);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Text = "Measure connection performance using your selected speed-test server.";

            // Configuration panel
            panelConfiguration.BackColor = Color.FromArgb(30, 41, 59);
            panelConfiguration.Location = new Point(35, 165);
            panelConfiguration.Size = new Size(1030, 160);
            panelConfiguration.Name = "panelConfiguration";

            lblConfiguration.AutoSize = true;
            lblConfiguration.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblConfiguration.ForeColor = Color.White;
            lblConfiguration.Location = new Point(22, 15);
            lblConfiguration.Name = "lblConfiguration";
            lblConfiguration.Text = "Test Configuration";

            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(203, 213, 225);
            label1.Location = new Point(25, 58);
            label1.Name = "label1";
            label1.Text = "Number of tests";

            cbNumberOfTests.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNumberOfTests.Font = new Font("Segoe UI", 10F);
            cbNumberOfTests.BackColor = Color.FromArgb(15, 23, 42);
            cbNumberOfTests.ForeColor = Color.White;
            cbNumberOfTests.Location = new Point(25, 88);
            cbNumberOfTests.Name = "cbNumberOfTests";
            cbNumberOfTests.Size = new Size(190, 31);
            cbNumberOfTests.TabIndex = 0;

            lblTestCountHint.AutoSize = true;
            lblTestCountHint.Font = new Font("Segoe UI", 8F);
            lblTestCountHint.ForeColor = Color.FromArgb(148, 163, 184);
            lblTestCountHint.Location = new Point(25, 124);
            lblTestCountHint.Name = "lblTestCountHint";
            lblTestCountHint.Text = "How many tests to perform";

            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(203, 213, 225);
            label2.Location = new Point(260, 58);
            label2.Name = "label2";
            label2.Text = "Interval between tests";

            cbMinuteIntervals.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMinuteIntervals.Font = new Font("Segoe UI", 10F);
            cbMinuteIntervals.BackColor = Color.FromArgb(15, 23, 42);
            cbMinuteIntervals.ForeColor = Color.White;
            cbMinuteIntervals.Location = new Point(260, 88);
            cbMinuteIntervals.Name = "cbMinuteIntervals";
            cbMinuteIntervals.Size = new Size(210, 31);
            cbMinuteIntervals.TabIndex = 1;

            lblIntervalHint.AutoSize = true;
            lblIntervalHint.Font = new Font("Segoe UI", 8F);
            lblIntervalHint.ForeColor = Color.FromArgb(148, 163, 184);
            lblIntervalHint.Location = new Point(260, 124);
            lblIntervalHint.Name = "lblIntervalHint";
            lblIntervalHint.Text = "Minutes between each test";

            // Actions panel
            panelActions.BackColor = Color.FromArgb(15, 23, 42);
            panelActions.Location = new Point(35, 345);
            panelActions.Size = new Size(1030, 65);
            panelActions.Name = "panelActions";

            btnRunTest.BackColor = Color.FromArgb(37, 99, 235);
            btnRunTest.FlatAppearance.BorderSize = 0;
            btnRunTest.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            btnRunTest.FlatStyle = FlatStyle.Flat;
            btnRunTest.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            btnRunTest.ForeColor = Color.White;
            btnRunTest.Location = new Point(0, 8);
            btnRunTest.Name = "btnRunTest";
            btnRunTest.Size = new Size(175, 48);
            btnRunTest.TabIndex = 2;
            btnRunTest.Text = "Run Tests";
            btnRunTest.UseVisualStyleBackColor = false;
            btnRunTest.Cursor = Cursors.Hand;
            btnRunTest.Click += btnRunTest_Click_1;

            btnCovertpdf.BackColor = Color.FromArgb(5, 150, 105);
            btnCovertpdf.FlatAppearance.BorderSize = 0;
            btnCovertpdf.FlatAppearance.MouseOverBackColor = Color.FromArgb(4, 120, 87);
            btnCovertpdf.FlatStyle = FlatStyle.Flat;
            btnCovertpdf.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCovertpdf.ForeColor = Color.White;
            btnCovertpdf.Location = new Point(190, 8);
            btnCovertpdf.Name = "btnCovertpdf";
            btnCovertpdf.Size = new Size(150, 48);
            btnCovertpdf.TabIndex = 3;
            btnCovertpdf.Text = "Export PDF";
            btnCovertpdf.UseVisualStyleBackColor = false;
            btnCovertpdf.Cursor = Cursors.Hand;
            btnCovertpdf.Click += btnCovertpdf_Click;

            MainMenubtn.BackColor = Color.FromArgb(51, 65, 85);
            MainMenubtn.FlatAppearance.BorderSize = 0;
            MainMenubtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(71, 85, 105);
            MainMenubtn.FlatStyle = FlatStyle.Flat;
            MainMenubtn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            MainMenubtn.ForeColor = Color.White;
            MainMenubtn.Location = new Point(355, 8);
            MainMenubtn.Name = "MainMenubtn";
            MainMenubtn.Size = new Size(145, 48);
            MainMenubtn.TabIndex = 4;
            MainMenubtn.Text = "Main Menu";
            MainMenubtn.UseVisualStyleBackColor = false;
            MainMenubtn.Cursor = Cursors.Hand;
            MainMenubtn.Click += MainMenubtn_Click;

            btnExit.BackColor = Color.FromArgb(127, 29, 29);
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(153, 27, 27);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(515, 8);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(105, 48);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Cursor = Cursors.Hand;
            btnExit.Click += btnExit_Click;

            panelActions.Controls.Add(btnRunTest);
            panelActions.Controls.Add(btnCovertpdf);
            panelActions.Controls.Add(MainMenubtn);
            panelActions.Controls.Add(btnExit);

            // Results panel
            panelResults.BackColor = Color.FromArgb(30, 41, 59);
            panelResults.Location = new Point(35, 430);
            panelResults.Size = new Size(1030, 325);
            panelResults.Name = "panelResults";

            lblResultsHeading.AutoSize = true;
            lblResultsHeading.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblResultsHeading.ForeColor = Color.White;
            lblResultsHeading.Location = new Point(20, 15);
            lblResultsHeading.Name = "lblResultsHeading";
            lblResultsHeading.Text = "Test Results";

            SpeedTestResultsTxt.BackColor = Color.FromArgb(15, 23, 42);
            SpeedTestResultsTxt.BorderStyle = BorderStyle.None;
            SpeedTestResultsTxt.Font = new Font("Consolas", 9.5F);
            SpeedTestResultsTxt.ForeColor = Color.FromArgb(226, 232, 240);
            SpeedTestResultsTxt.Location = new Point(20, 55);
            SpeedTestResultsTxt.Name = "SpeedTestResultsTxt";
            SpeedTestResultsTxt.Size = new Size(990, 245);
            SpeedTestResultsTxt.TabIndex = 6;
            SpeedTestResultsTxt.Text = "";

            panelResults.Controls.Add(lblResultsHeading);
            panelResults.Controls.Add(SpeedTestResultsTxt);

            // Retain legacy controls/fields for compatibility; not displayed.
            button1.Visible = false;
            pictureBox1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;

            Controls.Add(panelHeader);
            Controls.Add(panelConfiguration);
            Controls.Add(panelActions);
            Controls.Add(panelResults);

            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelConfiguration.ResumeLayout(false);
            panelConfiguration.PerformLayout();
            panelActions.ResumeLayout(false);
            panelResults.ResumeLayout(false);
            panelResults.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnRunTest;
        private Button btnExit;
        private ComboBox cbNumberOfTests;
        private ComboBox cbMinuteIntervals;
        private Label label1;
        private Label label2;
        private RichTextBox SpeedTestResultsTxt;
        private Label lblHeader;
        private Button button1;
        private Button btnCovertpdf;
        private Button MainMenubtn;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label lblSubtitle;
        private Label lblConfiguration;
        private Label lblResultsHeading;
        private Label lblTestCountHint;
        private Label lblIntervalHint;
        private Panel panelHeader;
        private Panel panelConfiguration;
        private Panel panelActions;
        private Panel panelResults;
    }
}
