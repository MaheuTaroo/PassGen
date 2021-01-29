using System;
using System.Windows.Forms;
namespace PassGen
{
    public partial class Form1 : Form
    {
        const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", numbers = "1234567890", symbols = "!\"#$%&/()=?»@£§€{[]}«+*-<>\\|;:_";
        string conjunction = "", final = "";
        int count = 0;
        public Form1()
        {
            InitializeComponent();
            Icon = Properties.Resources._lock;
            chkLetters.Checked = true;
        }
        private void Chars(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked) count++;
            else count--;

            if (count == 0) ((CheckBox)sender).Checked = true;
        }
        private void PassSelect(object sender, MouseEventArgs e)
        {
            if (lbPasswords.IndexFromPoint(e.Location) == -1) lbPasswords.SelectedIndex = -1;
        }
        private void PassCopy(object sender, MouseEventArgs e)
        {
            if (lbPasswords.SelectedIndex != -1) Clipboard.SetText(lbPasswords.Items[lbPasswords.SelectedIndex].ToString());
            MessageBox.Show("The password was copied to your clipboard!", "Password copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void GeneratePasswords(object sender, EventArgs e)
        {
            lbPasswords.Items.Clear();
            Random r = new Random();
            foreach (CheckBox chk in panel1.Controls)
            {
                if (chk.Checked)
                {
                    conjunction += chk.Text == "Letters" ? letters : chk.Text == "Numbers" ? numbers : symbols;
                }
            }
            for (int pass = 0; pass < nupPassCount.Value; pass++)
            {
                for (int character = 0; character < nupCharCount.Value; character++)
                {
                    final += conjunction[r.Next(0, conjunction.Length)];
                }
                lbPasswords.Items.Add(final);
                final = "";
            }
            conjunction = "";
        }
    }
}