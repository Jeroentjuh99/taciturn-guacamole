using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Form2 : Form
    {
        private readonly Client _form;

        public Form2(Client form, string[] items)
        {
            InitializeComponent();
            this._form = form;
            FillBox(items);
            checkedListBox1.SelectionMode = SelectionMode.One;
            checkedListBox1.MultiColumn = false;
        }

        private void FillBox(string[] items)
        {
            foreach (var v in items)
            {
                checkedListBox1.Items.Add(v);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!(FolderInput.Text.Trim().Equals("")))
            {
                if (checkedListBox1.CheckedItems.Count == 1)
                {
                    _form.HandleNew(this, new[] {FolderInput.Text.Trim(), checkedListBox1.SelectedItem.ToString()});
                }
                else
                {
                    MessageBox.Show(text: string.Format("You did select {0} items, but only 1 can be selected", checkedListBox1.SelectedItems.Count));
                }
            }
            else
            {
                MessageBox.Show("Please fill in a new folder name");
            }
        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItems.Count > 1)
            {
                checkedListBox1.ClearSelected();
            }
        }
    }
}
