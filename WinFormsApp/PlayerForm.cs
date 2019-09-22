using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class PlayerForm : Form
    {
        public PlayerForm()
        {
            InitializeComponent();
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                cb_playerteam.Items.AddRange(context.Teams.Select(t => t.name).ToArray());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_playername.Text) || String.IsNullOrEmpty(tb_surname.Text) || String.IsNullOrEmpty(cb_playerteam.Text))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else { button1.DialogResult = DialogResult.OK; }
        }
    }
}
