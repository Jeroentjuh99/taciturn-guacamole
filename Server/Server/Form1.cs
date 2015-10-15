using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Server
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void FolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(startInfo: new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = Path.GetDirectoryName(Application.ExecutablePath),
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
            catch (Exception exception)
            {
                System.Diagnostics.Process.Start(startInfo: new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = "C:/",
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
