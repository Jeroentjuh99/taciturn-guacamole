using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using SharedCode;

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
                try
                {
                    address = IPAddress.Parse(AdressBox.Text);
                }
                catch (Exception pp)
                {
                    address = IPAddress.Parse("127.0.0.1");
                }
            }
            finally
            {
                TcpClient client = new TcpClient(address.ToString(), 56931);
                NetworkStream stream = client.GetStream();
                NetworkManager manager = new NetworkManager(stream);


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
            string[] strings = new string[4];
            string path = Selector1.SelectedText;
            try
            {
                strings = ReadConfig(path);
            }
            catch (Exception)
            {
                CreateOrChangeConfig(path, AdressBox.Text, "null", "0.0", ProgramName.Text);
                strings = ReadConfig(path);
            }
            finally
            {
                AdressBox.Text = strings[0];
                VersionLabel.Text = strings[2];
                ProgramName.Text = strings[4];
                if((strings[4].Trim() != "" )||( strings[4].Trim() != "Program name to launch"))
                {
                    ProgramName.Enabled = true;
                }
                else
                {
                    ProgramName.Enabled = false;
                }
            }
        }

        private void ProgramName_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void CreateOrChangeConfig(string mapName, string address, string mapOnServer, string version,
            string executable)
        {
            try
            {
                File.Delete("/" + mapName + "/CONFIG");
            }
            catch (Exception p)
            {
            }
            finally
            {
                using (StreamWriter sw = File.AppendText("/" + mapName + "/CONFIG"))
                {
                    sw.WriteLine(address);
                    sw.WriteLine(mapOnServer);
                    sw.WriteLine(version);
                    sw.WriteLine(executable);
                }
            }
        }

        private string[] ReadConfig(string mapName)
        {
            string[] returnedValues = System.IO.File.ReadAllLines("/" + mapName + "/CONFIG");
            return returnedValues;
        }
    }
}
