using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheTydyshTV_Bot.Tools.Strawpoll
{
    public partial class frmStrawpoll : Form
    {
        public frmStrawpoll()
        {
            InitializeComponent();
        }

        PrivateFontCollection font = new PrivateFontCollection();
        private void frmStrawpoll_Load(object sender, EventArgs e)
        {
            font.AddFontFile("fonts/Play.ttf");
            int sizeI = 20;
            lvVariants.Font = new Font(font.Families[0], 15);
            btnStart.Font = new Font(font.Families[0], sizeI, FontStyle.Bold);
            btnAddVariant.Font = new Font(font.Families[0], sizeI, FontStyle.Bold);
            tbVariant.Font = new Font(font.Families[0], 10, FontStyle.Bold);
        }

        private void btnAddVariant_Click(object sender, EventArgs e)
        {
            if (lvVariants.Items.Count >= 5)
            {
                MessageBox.Show("Нельзя добавить больше 5 вариантов");
                return;
            }
            if (tbVariant.Text != "")
            {
                lvVariants.Items.Add(tbVariant.Text);
                tbVariant.Clear();
            }
        }

        private void btnDeleteVariant_Click(object sender, EventArgs e)
        {
            lvVariants.Items.RemoveAt(lvVariants.SelectedIndices[0]);
        }

        private void btnClearVariants_Click(object sender, EventArgs e)
        {
            lvVariants.Clear();
        }

        private void tbVariant_Click(object sender, EventArgs e)
        {
            if (tbVariant.Text == "Тут новый вариант")
            {
                tbVariant.Text = "";
            }
        }

        ToolsCore toolsCore;
        private void btnStart_Click(object sender, EventArgs e)
        {
            toolsCore = new ToolsCore();
            List<string> listVariants = new List<string>();
            foreach (ListViewItem lv in lvVariants.Items)
                listVariants.Add(lv.Text);
            frmMain.frmMainWindow.toolsCore.StartStrawpoll(listVariants);
            this.Close();
        }
    }
}
