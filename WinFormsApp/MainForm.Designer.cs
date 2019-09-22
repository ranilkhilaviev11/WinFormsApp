namespace WinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menu_panel = new System.Windows.Forms.Panel();
            this.btn_menu_players = new System.Windows.Forms.Button();
            this.btn_menu_teams = new System.Windows.Forms.Button();
            this.main_panel = new System.Windows.Forms.Panel();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.cb_team = new System.Windows.Forms.ComboBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.btnExportWord = new System.Windows.Forms.PictureBox();
            this.btnExportExcel = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.img_logo = new System.Windows.Forms.PictureBox();
            this.menu_panel.SuspendLayout();
            this.main_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportWord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // menu_panel
            // 
            this.menu_panel.BackColor = System.Drawing.SystemColors.Control;
            this.menu_panel.Controls.Add(this.img_logo);
            this.menu_panel.Controls.Add(this.btn_menu_players);
            this.menu_panel.Controls.Add(this.btn_menu_teams);
            this.menu_panel.Location = new System.Drawing.Point(0, 12);
            this.menu_panel.Name = "menu_panel";
            this.menu_panel.Size = new System.Drawing.Size(239, 551);
            this.menu_panel.TabIndex = 0;
            // 
            // btn_menu_players
            // 
            this.btn_menu_players.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_menu_players.Location = new System.Drawing.Point(3, 336);
            this.btn_menu_players.Name = "btn_menu_players";
            this.btn_menu_players.Size = new System.Drawing.Size(233, 49);
            this.btn_menu_players.TabIndex = 1;
            this.btn_menu_players.Text = "Игроки";
            this.btn_menu_players.UseVisualStyleBackColor = true;
            this.btn_menu_players.Click += new System.EventHandler(this.btn_menu_players_Click);
            // 
            // btn_menu_teams
            // 
            this.btn_menu_teams.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_menu_teams.Location = new System.Drawing.Point(3, 281);
            this.btn_menu_teams.Name = "btn_menu_teams";
            this.btn_menu_teams.Size = new System.Drawing.Size(233, 49);
            this.btn_menu_teams.TabIndex = 0;
            this.btn_menu_teams.Text = "Команды";
            this.btn_menu_teams.UseVisualStyleBackColor = true;
            this.btn_menu_teams.Click += new System.EventHandler(this.btn_menu_teams_Click);
            // 
            // main_panel
            // 
            this.main_panel.BackColor = System.Drawing.SystemColors.Control;
            this.main_panel.Controls.Add(this.btnExportWord);
            this.main_panel.Controls.Add(this.btnExportExcel);
            this.main_panel.Controls.Add(this.pictureBox1);
            this.main_panel.Controls.Add(this.btn_add);
            this.main_panel.Controls.Add(this.btn_update);
            this.main_panel.Controls.Add(this.cb_team);
            this.main_panel.Controls.Add(this.btn_delete);
            this.main_panel.Controls.Add(this.dataGridView);
            this.main_panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.main_panel.Location = new System.Drawing.Point(245, 12);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(815, 551);
            this.main_panel.TabIndex = 1;
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Bahnschrift Condensed", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_add.Location = new System.Drawing.Point(452, 511);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(116, 26);
            this.btn_add.TabIndex = 4;
            this.btn_add.Text = "Добавить";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_update.Location = new System.Drawing.Point(574, 511);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(116, 26);
            this.btn_update.TabIndex = 3;
            this.btn_update.Text = "Изменить";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // cb_team
            // 
            this.cb_team.FormattingEnabled = true;
            this.cb_team.Location = new System.Drawing.Point(22, 47);
            this.cb_team.Name = "cb_team";
            this.cb_team.Size = new System.Drawing.Size(174, 21);
            this.cb_team.TabIndex = 2;
            this.cb_team.TextChanged += new System.EventHandler(this.cb_team_TextChanged);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_delete.Location = new System.Drawing.Point(696, 511);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(116, 26);
            this.btn_delete.TabIndex = 1;
            this.btn_delete.Text = "Удалить";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(3, 74);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(809, 422);
            this.dataGridView.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnExportWord
            // 
            this.btnExportWord.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnExportWord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportWord.Image = global::WinFormsApp.Properties.Resources.kisspng_microsoft_word_microsoft_office_365_document_5adabfcd6e74b7_9078824715242853894524;
            this.btnExportWord.Location = new System.Drawing.Point(739, 18);
            this.btnExportWord.Name = "btnExportWord";
            this.btnExportWord.Size = new System.Drawing.Size(52, 50);
            this.btnExportWord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnExportWord.TabIndex = 7;
            this.btnExportWord.TabStop = false;
            this.btnExportWord.Click += new System.EventHandler(this.btnExportWord_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.DarkGreen;
            this.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportExcel.Image = global::WinFormsApp.Properties.Resources.kisspng_microsoft_excel_logo_microsoft_word_microsoft_offi_excel_png_office_xlsx_icon_5ab06a09e26a86_9276767815215109219274;
            this.btnExportExcel.Location = new System.Drawing.Point(681, 18);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(52, 50);
            this.btnExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnExportExcel.TabIndex = 6;
            this.btnExportExcel.TabStop = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::WinFormsApp.Properties.Resources.kuboksport;
            this.pictureBox1.Location = new System.Drawing.Point(372, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // img_logo
            // 
            this.img_logo.Image = global::WinFormsApp.Properties.Resources._1280px_Premier_League_Logo_svg;
            this.img_logo.Location = new System.Drawing.Point(3, 3);
            this.img_logo.Name = "img_logo";
            this.img_logo.Size = new System.Drawing.Size(233, 91);
            this.img_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_logo.TabIndex = 2;
            this.img_logo.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1072, 575);
            this.Controls.Add(this.main_panel);
            this.Controls.Add(this.menu_panel);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "WinFormsApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menu_panel.ResumeLayout(false);
            this.main_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportWord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menu_panel;
        private System.Windows.Forms.Button btn_menu_players;
        private System.Windows.Forms.Button btn_menu_teams;
        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.PictureBox img_logo;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.ComboBox cb_team;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.PictureBox btnExportExcel;
        private System.Windows.Forms.PictureBox btnExportWord;
    }
}

