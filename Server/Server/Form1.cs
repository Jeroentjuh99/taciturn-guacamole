using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using SharedCode;


namespace Server
{
    public partial class Server : Form
    {
        private readonly DirectoryScanner _scanner = new DirectoryScanner();

        public Server()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListenerClass _listenerClass = new ListenerClass(this);
            Thread t = new Thread(_listenerClass.StartThread) {IsBackground = true};
            t.Start();
        }

        public void SetLabelText(string ip, string state, Color color)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate()
                {
                    SetLabelText(ip, state, color);
                }));
            }
            else
            {
                IpLabel.Text = IpLabel.Text + ip;
                ServerStatus.Text = state;
                ServerStatus.ForeColor = color;
            }
        }

        private void FolderButton_Click(object sender, EventArgs e)
        {
            _scanner.OpenFolder(Path.GetDirectoryName(Application.ExecutablePath));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public DirectoryInfo[] ScanFolders()
        {
            return _scanner.Scan(Path.GetDirectoryName(Application.ExecutablePath));
        }
    }
}
