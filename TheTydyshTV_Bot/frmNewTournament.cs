using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheTydyshTV_Bot
{
    public partial class frmNewTournament : Form
    {
        public List<string> fighters = new List<string>();
        public string tournamentName;
        public frmNewTournament()
        {
            InitializeComponent();
        }

        private void btnLoadCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "CSV | *.csv";

            if (opd.ShowDialog() == DialogResult.OK)
            {
                rtbFighters.Clear();
                rtbFighters.Text = System.IO.File.ReadAllText(opd.FileName);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            fighters.AddRange(rtbFighters.Text.Split(';'));

            if (tbTournamentName.Text != string.Empty)
                if (fighters.Count > 2)
                {
                    tournamentName = tbTournamentName.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
