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
    public partial class frmTestFight : Form
    {
        public string name1 = "";
        public string name2 = "";

        public frmTestFight()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name1 = textBox1.Text.ToLower();
            name2 = textBox2.Text.ToLower();
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTestFight_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
