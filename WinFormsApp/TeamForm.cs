using System;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class TeamForm : Form
    {
        public TeamForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_teamname.Text))
            {
                MessageBox.Show("Введите название команды!");
            }
            else { button1.DialogResult = DialogResult.OK; }
        }
    }
}
