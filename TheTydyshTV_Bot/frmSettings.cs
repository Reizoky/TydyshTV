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
    public partial class frmSettings : Form
    {
        bool isLoad = true;
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.actionTime = Convert.ToInt32(nudTimeAction.Value);
            Properties.Settings.Default.defChanceBlEv = Convert.ToInt32(nudDefChanceBlEv.Value);
            Properties.Settings.Default.enBossAutoFight = chbBossAutoFight.Checked;
            Properties.Settings.Default.enAutoFight = chbAutoFight.Checked;
            Properties.Settings.Default.intervalAutoFight = Convert.ToInt32(nudAutoFight.Value);
            Properties.Settings.Default.intervalBossAutoFight = Convert.ToInt32(nudBossAutoFight.Value);
            Properties.Settings.Default.minTournamentFighters = Convert.ToInt32(nudMinTournamentFighters.Value);

            Properties.Settings.Default.Save();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            nudTimeAction.Value = Properties.Settings.Default.actionTime;
            nudDefChanceBlEv.Value = Properties.Settings.Default.defChanceBlEv;
            chbBossAutoFight.Checked = Properties.Settings.Default.enBossAutoFight;
            chbAutoFight.Checked = Properties.Settings.Default.enAutoFight;
            nudAutoFight.Value = Properties.Settings.Default.intervalAutoFight;
            nudBossAutoFight.Value = Properties.Settings.Default.intervalBossAutoFight;
            nudMinTournamentFighters.Value = Properties.Settings.Default.minTournamentFighters;

            gbAutoFight.Enabled = chbAutoFight.Checked;
            gbBossAutoFight.Enabled = chbBossAutoFight.Checked;

            isLoad = false;
        }

        private void chbAutoFight_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoad)
                gbAutoFight.Enabled = chbAutoFight.Checked;
        }

        private void chbBossAutoFight_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoad)
                gbBossAutoFight.Enabled = chbBossAutoFight.Checked;
        }
    }
}
