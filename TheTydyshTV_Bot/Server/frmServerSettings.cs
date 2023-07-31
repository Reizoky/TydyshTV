using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheTydyshTV_Bot.Сервер
{
    public partial class frmServerSettings : Form
    {
        public frmServerSettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.serverIP = mtbServerIP.Text;
            Properties.Settings.Default.serverPort = mtbServerPort.Text;

            Properties.Settings.Default.Save();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmServerSettings_Load(object sender, EventArgs e)
        {
            mtbServerIP.Text = Properties.Settings.Default.serverIP;
            mtbServerPort.Text = Properties.Settings.Default.serverPort;
        }
    }
}
