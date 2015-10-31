using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.IO.Compression;
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
            string selected = Selector1.SelectedItem.ToString();
            string[] data = ReadConfig(selected);
            manager.SendMessage(data[1] + '/' + data[2]);
            string[] reply = manager.ReceiveMessage().Split('/');
            if (reply.GetLength(0) == 2)
            {
                SetProgressMax(Convert.ToInt32(reply[0]));
                ReceiveFile(manager, Path.Combine(Application.StartupPath, selected), reply);
            }


        }

        private void ReceiveFile(NetworkManager manager, string path, string[] fileData)
        {
            MessageBox.Show(fileData[1]);
            NetworkStream stream = manager.GetStream();
            int length = Convert.ToInt32(fileData[0]);
            byte[] buffer = new byte[length];
            int received = 0;
            int read = 0;
            int size = 1024;
            int remaining = 0;

            while (received < length)
            {
                remaining = length - received;
                if (remaining < size)
                {
                    size = remaining;
                }
                read = stream.Read(buffer, received, size);
                received += read;
                SetProgress(received);
            }
            string writepath = Path.Combine(path, fileData[1]);
            using (FileStream fStream = new FileStream(writepath, FileMode.Create, FileAccess.ReadWrite, FileShare.None, buffer.Length))
            {
                fStream.Write(buffer, 0, buffer.Length);
            }
            string[] temp = ReadConfig(Selector1.SelectedItem.ToString());
            var a = ProgramLaunchCheckBox.Checked ? ProgramName.Text : "null";
            CreateOrChangeConfig(temp[0], AdressBox.Text, temp[2], fileData[1], a);
            if (fileData[1].EndsWith(".zip"))
            {
                ZipFile.ExtractToDirectory(writepath, path);
                File.Delete(writepath);
            }
            VersionLabel.Text = fileData[1];
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
                catch (Exception)
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

        public void SetProgressMax(Int32 lenght)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    SetProgressMax(lenght);
                }));
            }
            else
            {
                progressBar1.Maximum = lenght;
            }
        }

        public void SetProgress(Int32 lenght)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    SetProgress(lenght);
                }));
            }
            else
            {
                progressBar1.Value = lenght;
            }
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
                    ProgramName.Text = strings[3];
                    if ((strings[3].Trim() != "") || !(strings[3].Trim().Equals("Program name to launch")) || !(strings[3].Equals("null")))
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
                string b = manager.ReceiveMessage();
                if (b.Equals("null"))
                {
                    MessageBox.Show("There are no files to download on this server");
                    Environment.Exit(0);
                }
                string[] array = b.Split('/');

                Form2 input = new Form2(this, array);
                input.Show();
            }

        }

        public void HandleNew(Form2 input, string[] answer)
        {
            MessageBox.Show(answer[0]);
            CreateOrChangeConfig(answer[0], AdressBox.Text, answer[1], "0.0", "null");
            ReloadSelector(answer[0]);
            input.Dispose();
        }

        private void ReloadSelector(string selectedName)
        {
            Selector1.Items.Clear();
            DirectoryInfo[] folders = _dScanner.Scan(Path.GetDirectoryName(Application.ExecutablePath));
            Selector1.Items.Add("New...");
            foreach (var v in folders)
            {
                Selector1.Items.Add(v.Name);
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
            if (address.Equals("IP or DNS"))
            {
                address = "127.0.0.1";
            }
            var tempPath = Path.Combine(Application.StartupPath, mapName);
            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(mapName);
            }
            string path = Path.Combine(tempPath, "config.dat");
            FileStream file = File.Open(path, FileMode.Create, FileAccess.Write);
           
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine(address);
                sw.WriteLine(mapOnServer);
                sw.WriteLine(version);
                sw.WriteLine(executable);
            }
        }

        private string[] ReadConfig(string mapName)
        {
            string path = Path.Combine(Application.StartupPath, mapName, "config.dat");
            string[] returnedValues = File.ReadAllLines(path);
            return returnedValues;
        }

        private void OpenFolder_Click(object sender, EventArgs e)
        {
            if(Selector1.SelectedItem == null)
            _dScanner.OpenFolder(Path.GetDirectoryName(Application.ExecutablePath));
            else
            {
                _dScanner.OpenFolder(Path.Combine(Application.StartupPath, Selector1.SelectedItem.ToString()));
            }
        }
    }
}
