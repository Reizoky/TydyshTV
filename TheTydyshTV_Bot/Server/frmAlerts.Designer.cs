namespace TheTydyshTV_Bot.Server
{
    partial class frmAlerts
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
            this.wbAlerts = new System.Windows.Forms.WebBrowser();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnChangeBgColor = new System.Windows.Forms.Button();
            this.btnViewCode = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // wbAlerts
            // 
            this.wbAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbAlerts.Location = new System.Drawing.Point(103, 3);
            this.wbAlerts.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbAlerts.Name = "wbAlerts";
            this.wbAlerts.ScrollBarsEnabled = false;
            this.wbAlerts.Size = new System.Drawing.Size(374, 351);
            this.wbAlerts.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.wbAlerts, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(480, 357);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnViewCode, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnChangeBgColor, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExit, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(94, 351);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Location = new System.Drawing.Point(3, 283);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 65);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnChangeBgColor
            // 
            this.btnChangeBgColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChangeBgColor.Location = new System.Drawing.Point(3, 3);
            this.btnChangeBgColor.Name = "btnChangeBgColor";
            this.btnChangeBgColor.Size = new System.Drawing.Size(88, 64);
            this.btnChangeBgColor.TabIndex = 1;
            this.btnChangeBgColor.Text = "Выбрать цвет фона";
            this.btnChangeBgColor.UseVisualStyleBackColor = true;
            this.btnChangeBgColor.Click += new System.EventHandler(this.btnChangeBgColor_Click);
            // 
            // btnViewCode
            // 
            this.btnViewCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnViewCode.Location = new System.Drawing.Point(3, 73);
            this.btnViewCode.Name = "btnViewCode";
            this.btnViewCode.Size = new System.Drawing.Size(88, 64);
            this.btnViewCode.TabIndex = 2;
            this.btnViewCode.Text = "Код";
            this.btnViewCode.UseVisualStyleBackColor = true;
            // 
            // frmAlerts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 357);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmAlerts";
            this.Text = "Алерты";
            this.Load += new System.EventHandler(this.frmAlerts_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.WebBrowser wbAlerts;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnViewCode;
        private System.Windows.Forms.Button btnChangeBgColor;
        private System.Windows.Forms.Button btnExit;
    }
}