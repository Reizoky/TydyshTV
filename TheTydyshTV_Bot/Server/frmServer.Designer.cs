namespace TheTydyshTV_Bot.Сервер
{
    partial class frmServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServer));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnStartServer = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентАдминаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlServerInfo = new System.Windows.Forms.TabControl();
            this.tabPageConsole = new System.Windows.Forms.TabPage();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.tabPageBattlesInfo = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lbFights = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.tabControlServerInfo.SuspendLayout();
            this.tabPageConsole.SuspendLayout();
            this.tabPageBattlesInfo.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartServer,
            this.настройкиToolStripMenuItem,
            this.клиентАдминаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(665, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnStartServer
            // 
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(115, 20);
            this.btnStartServer.Text = "Включить сервер";
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.OpenServerSettings);
            // 
            // клиентАдминаToolStripMenuItem
            // 
            this.клиентАдминаToolStripMenuItem.Name = "клиентАдминаToolStripMenuItem";
            this.клиентАдминаToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.клиентАдминаToolStripMenuItem.Text = "Клиент Админа";
            this.клиентАдминаToolStripMenuItem.Click += new System.EventHandler(this.OpenAdminClient);
            // 
            // tabControlServerInfo
            // 
            this.tabControlServerInfo.Controls.Add(this.tabPageConsole);
            this.tabControlServerInfo.Controls.Add(this.tabPageBattlesInfo);
            this.tabControlServerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlServerInfo.Location = new System.Drawing.Point(0, 24);
            this.tabControlServerInfo.Name = "tabControlServerInfo";
            this.tabControlServerInfo.SelectedIndex = 0;
            this.tabControlServerInfo.Size = new System.Drawing.Size(665, 364);
            this.tabControlServerInfo.TabIndex = 3;
            // 
            // tabPageConsole
            // 
            this.tabPageConsole.Controls.Add(this.rtbLog);
            this.tabPageConsole.Location = new System.Drawing.Point(4, 22);
            this.tabPageConsole.Name = "tabPageConsole";
            this.tabPageConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConsole.Size = new System.Drawing.Size(657, 338);
            this.tabPageConsole.TabIndex = 0;
            this.tabPageConsole.Text = "Лог Сервера";
            this.tabPageConsole.UseVisualStyleBackColor = true;
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.SystemColors.MenuText;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.ForeColor = System.Drawing.Color.Lime;
            this.rtbLog.Location = new System.Drawing.Point(3, 3);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(651, 332);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // tabPageBattlesInfo
            // 
            this.tabPageBattlesInfo.Controls.Add(this.tableLayoutPanel);
            this.tabPageBattlesInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageBattlesInfo.Name = "tabPageBattlesInfo";
            this.tabPageBattlesInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBattlesInfo.Size = new System.Drawing.Size(657, 338);
            this.tabPageBattlesInfo.TabIndex = 1;
            this.tabPageBattlesInfo.Text = "Инфо о текущих боях";
            this.tabPageBattlesInfo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.lbFights, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(651, 332);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // lbFights
            // 
            this.lbFights.BackColor = System.Drawing.SystemColors.MenuText;
            this.lbFights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFights.ForeColor = System.Drawing.Color.Lime;
            this.lbFights.FormattingEnabled = true;
            this.lbFights.Location = new System.Drawing.Point(3, 3);
            this.lbFights.Name = "lbFights";
            this.lbFights.Size = new System.Drawing.Size(319, 326);
            this.lbFights.TabIndex = 0;
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 388);
            this.Controls.Add(this.tabControlServerInfo);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmServer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сервер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServer_FormClosing);
            this.Load += new System.EventHandler(this.frmServer_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControlServerInfo.ResumeLayout(false);
            this.tabPageConsole.ResumeLayout(false);
            this.tabPageBattlesInfo.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnStartServer;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        public System.Windows.Forms.TabControl tabControlServerInfo;
        public System.Windows.Forms.TabPage tabPageConsole;
        private System.Windows.Forms.TabPage tabPageBattlesInfo;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        public System.Windows.Forms.ListBox lbFights;
        private System.Windows.Forms.ToolStripMenuItem клиентАдминаToolStripMenuItem;
        public System.Windows.Forms.RichTextBox rtbLog;
    }
}