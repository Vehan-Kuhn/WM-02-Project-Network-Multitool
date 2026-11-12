namespace InternetSpeedTest
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            lblHeader = new Label();
            Subheaderlbl = new Label();
            InternetSpeedTestbtn = new Button();
            NetworkScannerbtn = new Button();
            InternetSpeedTestlbl = new Label();
            NetworkScannerlbl = new Label();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Arial", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(107, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(587, 50);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Network Multitool Main Menu";
            lblHeader.TextAlign = ContentAlignment.TopCenter;
            // 
            // Subheaderlbl
            // 
            Subheaderlbl.AutoSize = true;
            Subheaderlbl.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Subheaderlbl.Location = new Point(261, 59);
            Subheaderlbl.Name = "Subheaderlbl";
            Subheaderlbl.Size = new Size(301, 32);
            Subheaderlbl.TabIndex = 3;
            Subheaderlbl.Text = "Please select an option";
            // 
            // InternetSpeedTestbtn
            // 
            InternetSpeedTestbtn.ForeColor = Color.Black;
            InternetSpeedTestbtn.Image = (Image)resources.GetObject("InternetSpeedTestbtn.Image");
            InternetSpeedTestbtn.Location = new Point(107, 160);
            InternetSpeedTestbtn.Name = "InternetSpeedTestbtn";
            InternetSpeedTestbtn.Size = new Size(221, 118);
            InternetSpeedTestbtn.TabIndex = 4;
            InternetSpeedTestbtn.UseVisualStyleBackColor = true;
            InternetSpeedTestbtn.Click += InternetSpeedTestbtn_Click;
            // 
            // NetworkScannerbtn
            // 
            NetworkScannerbtn.ForeColor = SystemColors.ActiveCaptionText;
            NetworkScannerbtn.Image = (Image)resources.GetObject("NetworkScannerbtn.Image");
            NetworkScannerbtn.Location = new Point(473, 160);
            NetworkScannerbtn.Name = "NetworkScannerbtn";
            NetworkScannerbtn.Size = new Size(221, 118);
            NetworkScannerbtn.TabIndex = 5;
            NetworkScannerbtn.UseVisualStyleBackColor = true;
            NetworkScannerbtn.Click += NetworkScannerbtn_Click;
            // 
            // InternetSpeedTestlbl
            // 
            InternetSpeedTestlbl.AutoSize = true;
            InternetSpeedTestlbl.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InternetSpeedTestlbl.Location = new Point(107, 137);
            InternetSpeedTestlbl.Name = "InternetSpeedTestlbl";
            InternetSpeedTestlbl.Size = new Size(221, 23);
            InternetSpeedTestlbl.TabIndex = 6;
            InternetSpeedTestlbl.Text = "Internet Speed Test tool";
            // 
            // NetworkScannerlbl
            // 
            NetworkScannerlbl.AutoSize = true;
            NetworkScannerlbl.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NetworkScannerlbl.Location = new Point(473, 137);
            NetworkScannerlbl.Name = "NetworkScannerlbl";
            NetworkScannerlbl.Size = new Size(203, 23);
            NetworkScannerlbl.TabIndex = 7;
            NetworkScannerlbl.Text = "Network Scanner Tool";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            ClientSize = new Size(798, 455);
            Controls.Add(NetworkScannerlbl);
            Controls.Add(InternetSpeedTestlbl);
            Controls.Add(NetworkScannerbtn);
            Controls.Add(InternetSpeedTestbtn);
            Controls.Add(Subheaderlbl);
            Controls.Add(lblHeader);
            ForeColor = SystemColors.ButtonFace;
            Name = "MainMenu";
            Text = "Network Multitool Main Menu";
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
    }
}