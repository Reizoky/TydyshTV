namespace TheTydyshTV_Bot
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageFight = new System.Windows.Forms.TabPage();
            this.gbBossAutoFight = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudBossAutoFight = new System.Windows.Forms.NumericUpDown();
            this.chbBossAutoFight = new System.Windows.Forms.CheckBox();
            this.chbAutoFight = new System.Windows.Forms.CheckBox();
            this.gbAutoFight = new System.Windows.Forms.GroupBox();
            this.nudMinTournamentFighters = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudAutoFight = new System.Windows.Forms.NumericUpDown();
            this.nudTimeAction = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudDefChanceBlEv = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageServer = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageFight.SuspendLayout();
            this.gbBossAutoFight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBossAutoFight)).BeginInit();
            this.gbAutoFight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinTournamentFighters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoFight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDefChanceBlEv)).BeginInit();
            this.tabPageServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(599, 454);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 407);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(593, 44);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(59, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(177, 34);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.Location = new System.Drawing.Point(356, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(177, 34);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageFight);
            this.tabControl1.Controls.Add(this.tabPageServer);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(593, 398);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageFight
            // 
            this.tabPageFight.AutoScroll = true;
            this.tabPageFight.Controls.Add(this.gbBossAutoFight);
            this.tabPageFight.Controls.Add(this.chbBossAutoFight);
            this.tabPageFight.Controls.Add(this.chbAutoFight);
            this.tabPageFight.Controls.Add(this.gbAutoFight);
            this.tabPageFight.Controls.Add(this.nudTimeAction);
            this.tabPageFight.Controls.Add(this.label2);
            this.tabPageFight.Controls.Add(this.nudDefChanceBlEv);
            this.tabPageFight.Controls.Add(this.label1);
            this.tabPageFight.Location = new System.Drawing.Point(4, 22);
            this.tabPageFight.Name = "tabPageFight";
            this.tabPageFight.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFight.Size = new System.Drawing.Size(585, 372);
            this.tabPageFight.TabIndex = 0;
            this.tabPageFight.Text = "Бой";
            this.tabPageFight.UseVisualStyleBackColor = true;
            // 
            // gbBossAutoFight
            // 
            this.gbBossAutoFight.Controls.Add(this.label4);
            this.gbBossAutoFight.Controls.Add(this.nudBossAutoFight);
            this.gbBossAutoFight.Location = new System.Drawing.Point(10, 189);
            this.gbBossAutoFight.Name = "gbBossAutoFight";
            this.gbBossAutoFight.Size = new System.Drawing.Size(570, 82);
            this.gbBossAutoFight.TabIndex = 8;
            this.gbBossAutoFight.TabStop = false;
            this.gbBossAutoFight.Text = "Бои с боссом во время стрима";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Промежуток между боями";
            // 
            // nudBossAutoFight
            // 
            this.nudBossAutoFight.Location = new System.Drawing.Point(154, 16);
            this.nudBossAutoFight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudBossAutoFight.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudBossAutoFight.Name = "nudBossAutoFight";
            this.nudBossAutoFight.Size = new System.Drawing.Size(120, 20);
            this.nudBossAutoFight.TabIndex = 6;
            this.nudBossAutoFight.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // chbBossAutoFight
            // 
            this.chbBossAutoFight.AutoSize = true;
            this.chbBossAutoFight.Location = new System.Drawing.Point(18, 166);
            this.chbBossAutoFight.Name = "chbBossAutoFight";
            this.chbBossAutoFight.Size = new System.Drawing.Size(265, 17);
            this.chbBossAutoFight.TabIndex = 9;
            this.chbBossAutoFight.Text = "Бои с боссом во время стрима автоматически";
            this.chbBossAutoFight.UseVisualStyleBackColor = true;
            this.chbBossAutoFight.CheckedChanged += new System.EventHandler(this.chbBossAutoFight_CheckedChanged);
            // 
            // chbAutoFight
            // 
            this.chbAutoFight.AutoSize = true;
            this.chbAutoFight.Location = new System.Drawing.Point(9, 62);
            this.chbAutoFight.Name = "chbAutoFight";
            this.chbAutoFight.Size = new System.Drawing.Size(215, 17);
            this.chbAutoFight.TabIndex = 8;
            this.chbAutoFight.Text = "Бои во время стрима автоматически";
            this.chbAutoFight.UseVisualStyleBackColor = true;
            this.chbAutoFight.CheckedChanged += new System.EventHandler(this.chbAutoFight_CheckedChanged);
            // 
            // gbAutoFight
            // 
            this.gbAutoFight.Controls.Add(this.nudMinTournamentFighters);
            this.gbAutoFight.Controls.Add(this.label5);
            this.gbAutoFight.Controls.Add(this.label3);
            this.gbAutoFight.Controls.Add(this.nudAutoFight);
            this.gbAutoFight.Location = new System.Drawing.Point(9, 85);
            this.gbAutoFight.Name = "gbAutoFight";
            this.gbAutoFight.Size = new System.Drawing.Size(570, 75);
            this.gbAutoFight.TabIndex = 7;
            this.gbAutoFight.TabStop = false;
            this.gbAutoFight.Text = "Бои во время стрима";
            // 
            // nudMinTournamentFighters
            // 
            this.nudMinTournamentFighters.Location = new System.Drawing.Point(155, 42);
            this.nudMinTournamentFighters.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMinTournamentFighters.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudMinTournamentFighters.Name = "nudMinTournamentFighters";
            this.nudMinTournamentFighters.Size = new System.Drawing.Size(120, 20);
            this.nudMinTournamentFighters.TabIndex = 8;
            this.nudMinTournamentFighters.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Кол-боев для турнира";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Промежуток между боями";
            // 
            // nudAutoFight
            // 
            this.nudAutoFight.Location = new System.Drawing.Point(154, 16);
            this.nudAutoFight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAutoFight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAutoFight.Name = "nudAutoFight";
            this.nudAutoFight.Size = new System.Drawing.Size(120, 20);
            this.nudAutoFight.TabIndex = 6;
            this.nudAutoFight.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudTimeAction
            // 
            this.nudTimeAction.Location = new System.Drawing.Point(196, 10);
            this.nudTimeAction.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTimeAction.Name = "nudTimeAction";
            this.nudTimeAction.Size = new System.Drawing.Size(120, 20);
            this.nudTimeAction.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Время между действиями";
            // 
            // nudDefChanceBlEv
            // 
            this.nudDefChanceBlEv.Location = new System.Drawing.Point(196, 36);
            this.nudDefChanceBlEv.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDefChanceBlEv.Name = "nudDefChanceBlEv";
            this.nudDefChanceBlEv.Size = new System.Drawing.Size(120, 20);
            this.nudDefChanceBlEv.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Стандартный шанс на блок\\уворот";
            // 
            // tabPageServer
            // 
            this.tabPageServer.Controls.Add(this.groupBox1);
            this.tabPageServer.Controls.Add(this.numericUpDown1);
            this.tabPageServer.Controls.Add(this.textBox2);
            this.tabPageServer.Controls.Add(this.label8);
            this.tabPageServer.Controls.Add(this.label6);
            this.tabPageServer.Location = new System.Drawing.Point(4, 22);
            this.tabPageServer.Name = "tabPageServer";
            this.tabPageServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageServer.Size = new System.Drawing.Size(585, 372);
            this.tabPageServer.TabIndex = 1;
            this.tabPageServer.Text = "Настройки";
            this.tabPageServer.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Шрифт";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выбрать цвет фона";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(153, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Размер текста";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(200, 79);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 20);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "Microsoft Sans Serif";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Location = new System.Drawing.Point(280, 105);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            825,
            0,
            0,
            131072});
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(10, 105);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(236, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Выбрать дополнительный цвет фона";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(44, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Выбрать цвет текста";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(156, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 147);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Цвета";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 454);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageFight.ResumeLayout(false);
            this.tabPageFight.PerformLayout();
            this.gbBossAutoFight.ResumeLayout(false);
            this.gbBossAutoFight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBossAutoFight)).EndInit();
            this.gbAutoFight.ResumeLayout(false);
            this.gbAutoFight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinTournamentFighters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoFight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDefChanceBlEv)).EndInit();
            this.tabPageServer.ResumeLayout(false);
            this.tabPageServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageFight;
        private System.Windows.Forms.TabPage tabPageServer;
        private System.Windows.Forms.NumericUpDown nudTimeAction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDefChanceBlEv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbAutoFight;
        private System.Windows.Forms.GroupBox gbAutoFight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudAutoFight;
        private System.Windows.Forms.GroupBox gbBossAutoFight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudBossAutoFight;
        private System.Windows.Forms.CheckBox chbBossAutoFight;
        private System.Windows.Forms.NumericUpDown nudMinTournamentFighters;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
    }
}