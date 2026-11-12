
namespace InternetSpeedTest
{
    partial class InternetSpeedTestForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        ///  Clean up any resources being used.
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRunTest = new Button();
            btnExit = new Button();
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnRunTest
            // 
            btnRunTest.Font = new Font("Arial", 12F);
            btnRunTest.ForeColor = SystemColors.ActiveCaptionText;
            btnRunTest.Location = new Point(14, 215);
            btnRunTest.Margin = new Padding(3, 4, 3, 4);
            btnRunTest.Name = "btnRunTest";
            btnRunTest.Size = new Size(114, 43);
            btnRunTest.TabIndex = 0;
            btnRunTest.Text = "Run Tests";
            btnRunTest.UseVisualStyleBackColor = true;
            btnRunTest.Click += btnRunTest_Click_1;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Arial", 12F);
            btnExit.ForeColor = SystemColors.ActiveCaptionText;
            btnExit.Location = new Point(461, 215);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(86, 43);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // cbNumberOfTests
            // 
            cbNumberOfTests.FormattingEnabled = true;
            cbNumberOfTests.Location = new Point(296, 102);
            cbNumberOfTests.Margin = new Padding(3, 4, 3, 4);
            cbNumberOfTests.Name = "cbNumberOfTests";
            cbNumberOfTests.Size = new Size(138, 28);
            cbNumberOfTests.TabIndex = 2;
            // 
            // cbMinuteIntervals
            // 
            cbMinuteIntervals.FormattingEnabled = true;
            cbMinuteIntervals.Location = new Point(296, 162);
            cbMinuteIntervals.Margin = new Padding(3, 4, 3, 4);
            cbMinuteIntervals.Name = "cbMinuteIntervals";
            cbMinuteIntervals.Size = new Size(138, 28);
            cbMinuteIntervals.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(12, 107);
            label1.Name = "label1";
            label1.Size = new Size(148, 23);
            label1.TabIndex = 4;
            label1.Text = "Amount of tests";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(12, 167);
            label2.Name = "label2";
            label2.Size = new Size(148, 23);
            label2.TabIndex = 5;
            label2.Text = "Minute Intervals";
            // 
            // SpeedTestResultsTxt
            // 
            SpeedTestResultsTxt.Location = new Point(14, 265);
            SpeedTestResultsTxt.Margin = new Padding(3, 4, 3, 4);
            SpeedTestResultsTxt.Name = "SpeedTestResultsTxt";
            SpeedTestResultsTxt.Size = new Size(886, 317);
            SpeedTestResultsTxt.TabIndex = 6;
            SpeedTestResultsTxt.Text = "";
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.BackColor = SystemColors.GrayText;
            lblHeader.Font = new Font("Arial", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.ForeColor = SystemColors.ButtonFace;
            lblHeader.Location = new Point(12, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(466, 51);
            lblHeader.TabIndex = 7;
            lblHeader.Text = "Internet Speed Tester";
            // 
            // button1
            // 
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            // 
            // btnCovertpdf
            // 
            btnCovertpdf.Font = new Font("Arial", 12F);
            btnCovertpdf.Location = new Point(134, 214);
            btnCovertpdf.Margin = new Padding(3, 4, 3, 4);
            btnCovertpdf.Name = "btnCovertpdf";
            btnCovertpdf.Size = new Size(172, 43);
            btnCovertpdf.TabIndex = 8;
            btnCovertpdf.Text = "Convert to Pdf";
            btnCovertpdf.UseVisualStyleBackColor = true;
            btnCovertpdf.Click += btnCovertpdf_Click;
            // 
            // MainMenubtn
            // 
            MainMenubtn.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenubtn.Location = new Point(312, 214);
            MainMenubtn.Name = "MainMenubtn";
            MainMenubtn.Size = new Size(143, 44);
            MainMenubtn.TabIndex = 9;
            MainMenubtn.Text = "Main Menu";
            MainMenubtn.UseVisualStyleBackColor = true;
            MainMenubtn.Click += MainMenubtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(667, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(230, 89);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(166, 102);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(165, 162);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 12;
            // 
            // InternetSpeedTestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.GrayText;
            ClientSize = new Size(909, 621);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(MainMenubtn);
            Controls.Add(btnCovertpdf);
            Controls.Add(lblHeader);
            Controls.Add(SpeedTestResultsTxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbMinuteIntervals);
            Controls.Add(cbNumberOfTests);
            Controls.Add(btnExit);
            Controls.Add(btnRunTest);
            Margin = new Padding(3, 4, 3, 4);
            Name = "InternetSpeedTestForm";
            Text = "Internet Speed Tester";
            Load += InternetSpeedTest_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}
