namespace TheTydyshTV_Bot.Tools.Strawpoll
{
    partial class frmStrawpoll
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Вариант 1");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Вариант 2");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Вариант 3");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Вариант 4");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Вариант 5");
            this.lvVariants = new System.Windows.Forms.ListView();
            this.cmsVariant = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDeleteVariant = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddVariant = new System.Windows.Forms.Button();
            this.tbVariant = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClearVariants = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsVariant.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvVariants
            // 
            this.lvVariants.ContextMenuStrip = this.cmsVariant;
            this.lvVariants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvVariants.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvVariants.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lvVariants.Location = new System.Drawing.Point(3, 3);
            this.lvVariants.MultiSelect = false;
            this.lvVariants.Name = "lvVariants";
            this.lvVariants.Size = new System.Drawing.Size(670, 422);
            this.lvVariants.TabIndex = 0;
            this.lvVariants.UseCompatibleStateImageBehavior = false;
            this.lvVariants.View = System.Windows.Forms.View.List;
            // 
            // cmsVariant
            // 
            this.cmsVariant.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDeleteVariant,
            this.btnClearVariants});
            this.cmsVariant.Name = "cmsVariant";
            this.cmsVariant.Size = new System.Drawing.Size(127, 48);
            // 
            // btnDeleteVariant
            // 
            this.btnDeleteVariant.Name = "btnDeleteVariant";
            this.btnDeleteVariant.Size = new System.Drawing.Size(152, 22);
            this.btnDeleteVariant.Text = "Удалить";
            this.btnDeleteVariant.Click += new System.EventHandler(this.btnDeleteVariant_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lvVariants, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(865, 508);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnAddVariant, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbVariant, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnStart, 0, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(699, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(163, 422);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnAddVariant
            // 
            this.btnAddVariant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddVariant.Location = new System.Drawing.Point(3, 113);
            this.btnAddVariant.Name = "btnAddVariant";
            this.btnAddVariant.Size = new System.Drawing.Size(157, 84);
            this.btnAddVariant.TabIndex = 0;
            this.btnAddVariant.Text = "Добавить";
            this.btnAddVariant.UseVisualStyleBackColor = true;
            this.btnAddVariant.Click += new System.EventHandler(this.btnAddVariant_Click);
            // 
            // tbVariant
            // 
            this.tbVariant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbVariant.Location = new System.Drawing.Point(3, 3);
            this.tbVariant.Multiline = true;
            this.tbVariant.Name = "tbVariant";
            this.tbVariant.Size = new System.Drawing.Size(157, 84);
            this.tbVariant.TabIndex = 1;
            this.tbVariant.Text = "Тут новый вариант";
            this.tbVariant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbVariant.Click += new System.EventHandler(this.tbVariant_Click);
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Location = new System.Drawing.Point(3, 333);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(157, 86);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Пуск";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClearVariants
            // 
            this.btnClearVariants.Name = "btnClearVariants";
            this.btnClearVariants.Size = new System.Drawing.Size(152, 22);
            this.btnClearVariants.Text = "Очистить";
            this.btnClearVariants.Click += new System.EventHandler(this.btnClearVariants_Click);
            // 
            // frmStrawpoll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 508);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmStrawpoll";
            this.Text = "Голосование";
            this.Load += new System.EventHandler(this.frmStrawpoll_Load);
            this.cmsVariant.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvVariants;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnAddVariant;
        private System.Windows.Forms.TextBox tbVariant;
        private System.Windows.Forms.ContextMenuStrip cmsVariant;
        private System.Windows.Forms.ToolStripMenuItem btnDeleteVariant;
        private System.Windows.Forms.ToolStripMenuItem btnClearVariants;
    }
}