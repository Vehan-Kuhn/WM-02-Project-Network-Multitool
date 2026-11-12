namespace InternetSpeedTest
{
    partial class NetworkScannerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RunScanbtn = new Button();
            NetworkScannerlbl = new Label();
            richTextBox1 = new RichTextBox();
            ConvertToPdfbtn = new Button();
            MainMenu = new Button();
            Exitbtn = new Button();
            SuspendLayout();
            // 
            // RunScanbtn
            // 
            RunScanbtn.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RunScanbtn.ForeColor = SystemColors.ActiveCaptionText;
            RunScanbtn.Location = new Point(12, 173);
            RunScanbtn.Name = "RunScanbtn";
            RunScanbtn.Size = new Size(102, 29);
            RunScanbtn.TabIndex = 0;
            RunScanbtn.Text = "Run Scan";
            RunScanbtn.UseVisualStyleBackColor = true;
            // 
            // NetworkScannerlbl
            // 
            NetworkScannerlbl.AutoSize = true;
            NetworkScannerlbl.BackColor = SystemColors.GrayText;
            NetworkScannerlbl.Font = new Font("Arial", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NetworkScannerlbl.ForeColor = SystemColors.Control;
            NetworkScannerlbl.Location = new Point(12, 9);
            NetworkScannerlbl.Name = "NetworkScannerlbl";
            NetworkScannerlbl.Size = new Size(380, 51);
            NetworkScannerlbl.TabIndex = 1;
            NetworkScannerlbl.Text = "Network Scanner";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 208);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(776, 373);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // ConvertToPdfbtn
            // 
            ConvertToPdfbtn.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ConvertToPdfbtn.Location = new Point(120, 173);
            ConvertToPdfbtn.Name = "ConvertToPdfbtn";
            ConvertToPdfbtn.Size = new Size(163, 29);
            ConvertToPdfbtn.TabIndex = 3;
            ConvertToPdfbtn.Text = "Convert to PDF";
            ConvertToPdfbtn.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            MainMenu.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenu.Location = new Point(289, 173);
            MainMenu.Name = "MainMenu";
            MainMenu.Size = new Size(137, 29);
            MainMenu.TabIndex = 4;
            MainMenu.Text = "Main Menu";
            MainMenu.UseVisualStyleBackColor = true;
            MainMenu.Click += MainMenu_Click;
            // 
            // Exitbtn
            // 
            Exitbtn.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Exitbtn.Location = new Point(432, 173);
            Exitbtn.Name = "Exitbtn";
            Exitbtn.Size = new Size(94, 29);
            Exitbtn.TabIndex = 5;
            Exitbtn.Text = "Exit";
            Exitbtn.UseVisualStyleBackColor = true;
            Exitbtn.Click += Exitbtn_Click;
            // 
            // NetworkScannerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            ClientSize = new Size(800, 593);
            Controls.Add(Exitbtn);
            Controls.Add(MainMenu);
            Controls.Add(ConvertToPdfbtn);
            Controls.Add(richTextBox1);
            Controls.Add(NetworkScannerlbl);
            Controls.Add(RunScanbtn);
            ForeColor = SystemColors.ControlText;
            Name = "NetworkScannerForm";
            Text = "Network Scanner Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RunScanbtn;
        private Label NetworkScannerlbl;
        private RichTextBox richTextBox1;
        private Button ConvertToPdfbtn;
        private Button MainMenu;
        private Button Exitbtn;
    }
}