using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheTydyshTV_Bot.Server
{
    public partial class frmAlerts : Form
    {
        public frmAlerts()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAlerts_Load(object sender, EventArgs e)
        {
            wbAlerts.DocumentText = @"
       <style type = 'text/css'>
         body {background-color: #FFFFFFFF;}
</ style >
</ head >
< body >

   <p id='text'>
   

</ body >";
        }

        private void btnShowBorder_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = this.FormBorderStyle == FormBorderStyle.None ? FormBorderStyle.Sizable : FormBorderStyle.None;
        }

        private void btnChangeBgColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                wbAlerts.DocumentText = wbAlerts.DocumentText.Replace("body {background-color: #FFFFFFFF;}","body {background - color: #" + colorDialog.Color.Name.ToString() + ";}");
            }
        }
    }
}
