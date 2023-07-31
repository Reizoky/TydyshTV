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

namespace TheTydyshTV_Bot.Alerts
{
    public partial class frmTwoVariants : Form
    {
        Timer timer = new Timer();
        public frmTwoVariants()
        {
            InitializeComponent();
        }

        PrivateFontCollection font = new PrivateFontCollection();
        private void frmTwoVariants_Load(object sender, EventArgs e)
        {
            int size = 11;
            font.AddFontFile("fonts/Play.ttf");
            lbl1.Font = new Font(font.Families[0], size, FontStyle.Bold);
            lbl2.Font = new Font(font.Families[0], size, FontStyle.Bold);
            lbl1Now.Font = new Font(font.Families[0], size, FontStyle.Bold);
            lbl2Now.Font = new Font(font.Families[0], size, FontStyle.Bold);

            timer.Interval = 1000*5; //5 секкунд
            timer.Tick += Timer_Tick;
        }

        int maxVote = -1;
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            DataTable dt = sqlClient.GetTableFromDB("Select * from `Vote` LIMIT 1");
            if (Convert.ToInt32(dt.Rows[0]["Variant1"]) <= maxVote)
                pb1.Value = Convert.ToInt32(dt.Rows[0]["Variant1"]);
            else
                pb1.Value = maxVote;
            if (Convert.ToInt32(dt.Rows[0]["Variant2"]) <= maxVote)
                pb2.Value = Convert.ToInt32(dt.Rows[0]["Variant2"]);
            else
                pb2.Value = maxVote;
            lbl1Now.Text = pb1.Value.ToString();
            lbl2Now.Text = pb2.Value.ToString();

            if (pb1.Value >= maxVote || pb2.Value >= maxVote)
                return;

            timer.Start();
        }

        WorkWithMYSQL sqlClient = new WorkWithMYSQL();
        private void новоеГолосованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sqlClient.ModificationDataInDB($@"UPDATE `Vote` SET `Variant1` = 0, `Variant2` = 0");
            pnlSettings.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = false;

            lbl1.Text = tbVariant1.Text;
            lbl2.Text = tbVariant2.Text;
            maxVote = (int)numericUpDown1.Value;
            pb1.Maximum = maxVote;
            pb2.Maximum = maxVote;

            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }

        private void btnReVote_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = true;
        }
    }
}
