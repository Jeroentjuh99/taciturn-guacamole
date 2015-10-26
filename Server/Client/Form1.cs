using System;
using System.Net;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            IPAddress address = null;
            try
            {
                address = Dns.GetHostAddresses(AdressBox.Text)[0];
            }
            catch (Exception p)
            {
                address = IPAddress.Parse("127.0.0.1");
            }
            finally
            {
                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ProgramName.Enabled = ProgramLaunchCheckBox.Checked;
        }

        private void AdressBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Selector1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProgramName_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
