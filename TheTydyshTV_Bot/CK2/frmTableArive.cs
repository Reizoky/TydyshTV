using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace TheTydyshTV_Bot.CK2
{
    public partial class frmTableArive : Form
    {
        WorkWithMYSQL sqlClient = new WorkWithMYSQL();
        bool updateTable;
        public frmTableArive()
        {
            InitializeComponent();
        }

        private void btnConenct_Click(object sender, EventArgs e)
        {
            btnConenct.Enabled = false;
            UpdateTable();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvMain.ClearSelection();
            dgvMain.EndEdit();
            int rows = sqlClient.UpdateBindingTable();
            UpdateTable();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void UpdateTable()
        {
            LockButtons(false);
            updateTable = true;
            dgvMain.DataSource = "";
            dgvMain.DataSource = sqlClient.BindingTable("Select * from `Subscribers` where `Arrive` = false order by `Coefficient` DESC;");
            dgvMain.Columns["CountOfDonates"].Visible = false;
            dgvMain.Columns["Name"].ReadOnly = true;
            dgvMain.Columns["Month"].ReadOnly = true;
            dgvMain.Columns["Coefficient"].ReadOnly = true;
            
            dgvMain.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMain.AllowUserToResizeRows = false;
            updateTable = false;
            LockButtons(true);
        }

        private void LockButtons(bool ifLock)
        {
            btnUpdate.Enabled = ifLock;
            btnSave.Enabled = ifLock;
            dgvMain.Enabled = ifLock;
            tbFind.Enabled = ifLock;
            lblFind.Enabled = ifLock;
        }

        private void tbFind_TextChanged(object sender, EventArgs e)
        {
            Find();
        }

        private void Find()
        {
            dgvMain.ClearSelection();
            DataGridViewRow row = dgvMain.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["Name"].Value.ToString().StartsWith(tbFind.Text, StringComparison.CurrentCultureIgnoreCase))
                .FirstOrDefault();

            if (row != null)
            {
                dgvMain.Rows[row.Index].Selected = true;
                dgvMain.FirstDisplayedScrollingRowIndex = row.Index;
                dgvMain.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
            }

        }

        private void dgvMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!updateTable)
                dgvMain.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
        }
    }
}
