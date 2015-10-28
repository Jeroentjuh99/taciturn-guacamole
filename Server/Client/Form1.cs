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
        readonly DirectoryScanner _dScanner = new DirectoryScanner();

        public Client()
        {
            InitializeComponent();
            ReloadSelector(null);
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            NetworkManager manager = GetManager();
        }

        private NetworkManager GetManager()
        {
            IPAddress address = null;
            NetworkManager manager = new NetworkManager();
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
                try
                {
                    var client = new TcpClient(address.ToString(), 56931);
                    NetworkStream stream = client.GetStream();
                    manager = new NetworkManager(stream);
                }
                catch (Exception)
                {
                    MessageBox.Show("The server is not online!");
                    Environment.Exit(0);
                }   
            }
            return manager;
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
            if (!(Selector1.SelectedItem.ToString().Equals("New...")))
            {
                string[] strings = new string[4];
                string path = Selector1.SelectedItem.ToString();
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
                    if ((strings[4].Trim() != "") || (strings[4].Trim() != "Program name to launch"))
                    {
                        ProgramName.Enabled = true;
                    }
                    else
                    {
                        ProgramName.Enabled = false;
                    }
                }
            }
            else
            {
                NetworkManager manager = GetManager();
                manager.SendMessage("files");
                string[] array = manager.ReceiveMessage().Split('/');
                Form2 input = new Form2(this);
                string[] answer = input.show(array);
                CreateOrChangeConfig(answer[0], AdressBox.Text, answer[1], "0.0", "null");
                ReloadSelector(answer[0]);
            }
        }

        private void ReloadSelector(string selectedName)
        {
            DirectoryInfo[] folders = _dScanner.scan(Path.GetDirectoryName(Application.ExecutablePath));
            Selector1.Items.Add("New...");
            foreach (var V in folders)
            {
                Selector1.Items.Add(V.Name);
            }
            Selector1.SelectedItem = selectedName;
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
            MessageBox.Show(mapName);
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

            MessageBox.Show(mapName);

        }

        private string[] ReadConfig(string mapName)
        {
            string[] returnedValues = System.IO.File.ReadAllLines("/" + mapName + "/CONFIG");
            return returnedValues;
        }

        private void OpenFolder_Click(object sender, EventArgs e)
        {
            if(Selector1.SelectedItem == null)
            _dScanner.OpenFolder(Path.GetDirectoryName(Application.ExecutablePath));
            else
            {
                _dScanner.OpenFolder("/" + Selector1.SelectedItem.ToString());
            }
        }
    }
}
