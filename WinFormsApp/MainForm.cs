using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp.Model;
using Xceed.Words.NET;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        bool IsTeam = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                cb_team.Items.AddRange(context.Teams.Select(t => t.name).ToArray());
                List<Team> team = context.Teams.ToList();
                dataGridView.DataSource = team;

            }
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Columns[1].HeaderText = "Название";
            dataGridView.Columns[2].HeaderText = "Очки";
        }

        private void btn_menu_teams_Click(object sender, EventArgs e)
        {
            IsTeam = true;
            UpdateDataGridView();
            btn_add.Enabled = true;
            btn_delete.Enabled = true;
            btn_update.Enabled = true;
            btnExportExcel.Enabled = true;
        }

        private void btn_menu_players_Click(object sender, EventArgs e)
        {
            IsTeam = false;
            UpdateDataGridView();
            btn_add.Enabled = true;
            btn_delete.Enabled = true;
            btn_update.Enabled = true;
            btnExportExcel.Enabled = true;
            btnExportExcel.Visible = true;
        }

        private void cb_team_TextChanged(object sender, EventArgs e)
        {
            btn_add.Enabled = false;
            btn_delete.Enabled = false;
            btn_update.Enabled = false;
            btnExportExcel.Enabled = false;

            using (var context = new ApplicationContext())
            {
                dataGridView.DataSource = context.Players.Where(p => p.Team.name == cb_team.Text).Select(p => new
                {
                    Id = p.Id,
                    Surname = p.Surname,
                    Name = p.Name,
                    IsDeleted = p.IsDeleted
                }).ToList();
            }
            dataGridView.Columns[1].HeaderText = "Фамилия";
            dataGridView.Columns[2].HeaderText = "Имя";
            dataGridView.Columns[3].ReadOnly = true;


        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cb_team.Text))
            {
                if (IsTeam)
                {
                    TeamForm teamForm = new TeamForm();
                    DialogResult result = teamForm.ShowDialog(this);
                    if (result == DialogResult.Cancel)
                        return;
                    Team team = new Team();
                    try
                    {
                        int userVal;
                        if (int.TryParse(teamForm.tb_teampoints.Text, out userVal))
                        {
                            team.name = teamForm.tb_teamname.Text;
                            team.point = userVal;
                            using (var context = new ApplicationContext())
                            {
                                context.Teams.Add(team);
                                context.SaveChanges();
                            }
                        }
                        else { MessageBox.Show("Поле 'Очки' может содержать только цифры!"); }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                else
                {
                    PlayerForm playerForm = new PlayerForm();
                    DialogResult result = playerForm.ShowDialog(this);
                    if (result == DialogResult.Cancel)
                        return;
                    Player player = new Player();
                    try
                    {
                        player.Surname = playerForm.tb_surname.Text;
                        player.Name = playerForm.tb_playername.Text;

                        using (var context = new ApplicationContext())
                        {
                            var teamId = context.Teams.Where(t => t.name == playerForm.cb_playerteam.SelectedItem.ToString()).Select(s => s.Id).First();
                            player.TeamId = teamId;

                            var playersInTeam = context.Players.Where(t => t.TeamId == teamId).Where(p => p.IsDeleted == false).Count();
                            if (playersInTeam == 11)
                                MessageBox.Show("В команде не может быть более 11-ти игроков!");
                            else
                            {
                                context.Players.Add(player);
                                context.SaveChanges();
                                MessageBox.Show("Новый игрок добавлен.");
                            }
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }


                }
                UpdateDataGridView();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cb_team.Text))
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    int index = dataGridView.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;
                    if (IsTeam)
                    {
                        try
                        {
                            using (var context = new ApplicationContext())
                            {
                                Team team = context.Teams.Find(id);
                                TeamForm teamForm = new TeamForm();
                                teamForm.tb_teamname.Text = team.name;
                                teamForm.tb_teampoints.Text = team.point.ToString();

                                DialogResult result = teamForm.ShowDialog(this);
                                if (result == DialogResult.Cancel)
                                    return;

                                int userVal;
                                if (int.TryParse(teamForm.tb_teampoints.Text, out userVal))
                                {
                                    team.name = teamForm.tb_teamname.Text;
                                    team.point = userVal;
                                    context.SaveChanges();
                                }
                                else { MessageBox.Show("Поле 'Очки' может содержать только цифры!"); }

                            }
                            MessageBox.Show("Данные обновлены.");
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                    else
                    {
                        try
                        {
                            using (var context = new ApplicationContext())
                            {
                                Player player = context.Players.Find(id);

                                PlayerForm playerForm = new PlayerForm();
                                playerForm.tb_surname.Text = player.Surname;
                                playerForm.tb_playername.Text = player.Name;
                                var selectedTeam = context.Teams.Where(t => t.Id == player.TeamId).Select(n => n.name).First();
                                playerForm.cb_playerteam.SelectedItem = selectedTeam;
                                playerForm.cb_playerteam.Text = selectedTeam;

                                DialogResult result = playerForm.ShowDialog(this);
                                if (result == DialogResult.Cancel)
                                    return;
                                player.Surname = playerForm.tb_surname.Text;
                                player.Name = playerForm.tb_playername.Text;
                                player.TeamId = context.Teams.Where(t => t.name == playerForm.cb_playerteam.Text).Select(s => s.Id).First();

                                context.SaveChanges();
                            }

                            MessageBox.Show("Данные обновлены.");
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message); }

                    }
                }
                UpdateDataGridView();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int index = dataGridView.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView[0, index].Value.ToString(), out id);
                using (var context = new ApplicationContext())
                {
                    try
                    {
                        if (IsTeam)
                        {
                            Team team = context.Teams.Find(id);
                            context.Teams.Remove(team);
                            context.SaveChanges();

                            MessageBox.Show("Команда удалена.");
                        }
                        else
                        {
                            Player player = context.Players.Find(id);
                            context.Players.Remove(player);
                            context.SaveChanges();
                        }
                        UpdateDataGridView();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }

            }
        }

        private void UpdateDataGridView()
        {
            cb_team.Text = "";
            using (var context = new ApplicationContext())
            {
                if (IsTeam)
                {

                    dataGridView.DataSource = context.Teams.ToList();
                    dataGridView.Columns[1].HeaderText = "Название";
                    dataGridView.Columns[2].HeaderText = "Очки";
                }
                else
                {
                    IsTeam = false;
                    dataGridView.DataSource = context.Players.Select(p => new
                    {
                        Id = p.Id,
                        Surname = p.Surname,
                        Name = p.Name,
                        Team = p.Team.name,
                        IsDeleted = p.IsDeleted
                    }).ToList();
                    dataGridView.Columns[1].HeaderText = "Фамилия";
                    dataGridView.Columns[2].HeaderText = "Имя";
                    dataGridView.Columns[3].HeaderText = "Команда";
                    dataGridView.Columns[4].ReadOnly = true;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                btnExportExcel.Enabled = false;
                btn_add.Enabled = false;
                btn_delete.Enabled = false;
                btn_update.Enabled = false;
                try
                {
                    var result = context.Players.FromSql("Max_Points_Team").Where(p => p.IsDeleted == false).Select(n => new
                    {
                        Id = n.Id,
                        Surname = n.Surname,
                        Name = n.Name,
                        Team = n.Team.name
                    }
                    ).ToList();
                    dataGridView.DataSource = result;
                }
                catch { MessageBox.Show("Убедитесь, что есть лидирующая команда!");
                    btnExportExcel.Enabled = true;
                    btn_add.Enabled = true;
                    btn_delete.Enabled = true;
                    btn_update.Enabled = true;
                }
            }

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb_team.Text == "")
                {
                    if (IsTeam)
                    {

                        using (var context = new ApplicationContext())
                        {
                            List<Team> teamList = context.Teams.Select(t => new Team
                            {
                                Id = t.Id,
                                name = t.name,
                                point = t.point
                            }).ToList();
                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet 1");
                                ws.Cells["A1"].Value = "Id";
                                ws.Cells["B1"].Value = "Название";
                                ws.Cells["C1"].Value = "Очки";
                                ws.Cells["A2"].LoadFromCollection(teamList);
                                ws.Cells["A:AZ"].AutoFitColumns();

                                Directory.CreateDirectory(Environment.CurrentDirectory + "/Excel Export");
                                FileInfo fileInfo = new FileInfo(Environment.CurrentDirectory + "/Excel Export/" + ("Teams " + DateTime.Now.ToShortDateString() + ".xlsx"));
                                pck.SaveAs(fileInfo);
                                MessageBox.Show("Файл успешно экспортирован  по пути: " + fileInfo);
                            }
                        }
                    }
                    else
                    {
                        using (var context = new ApplicationContext())
                        {
                            List<Player> playerList = context.Players.Select(t => new Player
                            {
                                Id = t.Id,
                                Surname = t.Surname,
                                Name = t.Name,
                                TeamId = t.TeamId,
                                IsDeleted = t.IsDeleted
                            }).ToList();
                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet 1");
                                ws.Cells["A1"].Value = "Id";
                                ws.Cells["B1"].Value = "Фамилия";
                                ws.Cells["C1"].Value = "Имя";
                                ws.Cells["D1"].Value = "ID команды";
                                ws.Cells["F1"].Value = "IsDeleted";
                                ws.Cells["A2"].LoadFromCollection(playerList);
                                ws.Cells["A:AZ"].AutoFitColumns();

                                Directory.CreateDirectory(Environment.CurrentDirectory + "/Excel Export");
                                FileInfo fileInfo = new FileInfo(Environment.CurrentDirectory + "/Excel Export/" + ("Players " + DateTime.Now.ToShortDateString() + ".xlsx"));
                                pck.SaveAs(fileInfo);
                                MessageBox.Show("Файл успешно экспортирован  по пути: " + fileInfo);
                            }
                        }
                    }
                }
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnExportWord_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb_team.Text == "")
                {
                    using (var context = new ApplicationContext())
                    {
                        var path = Directory.CreateDirectory(Environment.CurrentDirectory + "/Word Export");
                        if (IsTeam)
                        {
                            string fileInfo = path + "/Teams " + DateTime.Now.ToShortDateString() + ".docx";
                            using (DocX document = DocX.Create(fileInfo))
                            {
                                var teamList = context.Teams.ToList();
                                var t = document.AddTable(teamList.Count() + 1, 3);
                                t.Design = TableDesign.ColorfulGridAccent1;
                                t.Alignment = Alignment.center;
                                t.Rows[0].Cells[0].Paragraphs[0].Append("Id");
                                t.Rows[0].Cells[1].Paragraphs[0].Append("Название");
                                t.Rows[0].Cells[2].Paragraphs[0].Append("Очки");

                                foreach (var team in teamList)
                                {
                                    t.Rows[team.Id].Cells[0].Paragraphs[0].Append(team.Id.ToString());
                                    t.Rows[team.Id].Cells[1].Paragraphs[0].Append(team.name);
                                    t.Rows[team.Id].Cells[2].Paragraphs[0].Append(team.point.ToString());
                                }
                                var p = document.InsertParagraph("Teams");
                                p.SpacingAfter(40d);
                                p.InsertTableAfterSelf(t);
                                document.Save();
                                MessageBox.Show("Файл успешно экспортирован  по пути: " + fileInfo);
                            }
                        }
                        else
                        {
                            string fileInfo = path + "/Players " + DateTime.Now.ToShortDateString() + ".docx";
                            using (DocX document = DocX.Create(fileInfo))
                            {
                                var playerList = context.Players.ToList();
                                var t = document.AddTable(playerList.Count() + 1, 5);
                                t.Design = TableDesign.ColorfulGridAccent1;
                                t.Alignment = Alignment.center;
                                t.Rows[0].Cells[0].Paragraphs[0].Append("Id");
                                t.Rows[0].Cells[1].Paragraphs[0].Append("Фамилия");
                                t.Rows[0].Cells[2].Paragraphs[0].Append("Имя");
                                t.Rows[0].Cells[3].Paragraphs[0].Append("Команда");
                                t.Rows[0].Cells[4].Paragraphs[0].Append("IsDeleted");

                                foreach (var player in playerList)
                                {
                                    t.Rows[player.Id].Cells[0].Paragraphs[0].Append(player.Id.ToString());
                                    t.Rows[player.Id].Cells[1].Paragraphs[0].Append(player.Surname);
                                    t.Rows[player.Id].Cells[2].Paragraphs[0].Append(player.Name);
                                    t.Rows[player.Id].Cells[3].Paragraphs[0].Append(context.Teams.Where(g => g.Id == player.TeamId).Select(a => a.name).First());
                                    t.Rows[player.Id].Cells[4].Paragraphs[0].Append(player.IsDeleted.ToString());
                                }
                                var p = document.InsertParagraph("Players");
                                p.SpacingAfter(40d);
                                p.InsertTableAfterSelf(t);
                                document.Save();
                                MessageBox.Show("Файл успешно экспортирован  по пути: " + fileInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
