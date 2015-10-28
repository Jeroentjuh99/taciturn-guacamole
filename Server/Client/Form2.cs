using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Form2 : Form
    {
        private Client form;

        public string Foldername
        {
            get { return FolderInput.Text; }
            set { FolderInput.Text = value; }
        }

        public string Selected
        {
            get { return checkedListBox1.SelectedItem.ToString(); }
        }

        public string SelectedItem
        {
            get { return null; }
        }

        public Form2(Client form)
        {
            InitializeComponent();
            this.form = form;
        }

        public string[] show(string[] items)
        {
            checkedListBox1.SelectionMode = SelectionMode.One;
            foreach (var v in items)
            {
                checkedListBox1.Items.Add(v);
            }
            string[] answer = new string[2];
            return answer;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {

        }
    }
}
