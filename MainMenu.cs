using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetSpeedTest
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void InternetSpeedTestbtn_Click(object sender, EventArgs e)
        {
            MainMenu.ActiveForm.Hide();
            InternetSpeedTestForm internetSpeedTestForm = new InternetSpeedTestForm();
            internetSpeedTestForm.Show();
        }

        private void NetworkScannerbtn_Click(object sender, EventArgs e)
        {
            MainMenu.ActiveForm.Hide();
            NetworkScannerForm networkScannerForm = new NetworkScannerForm();
            networkScannerForm.Show();
        }
    }
}
