using System;
using System.Windows.Forms;
using System.Threading;

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
                    _form.HandleNew(this, new[] { FolderInput.Text.Trim(), checkedListBox1.SelectedItem.ToString()});
                }
            }
        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox items = (CheckedListBox)sender;
            if (items.CheckedItems.Count > (1))
            {
                e.NewValue = CheckState.Unchecked;
            }
        }
    }
}
