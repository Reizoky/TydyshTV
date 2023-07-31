using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheTydyshTV_Bot.CK2
{
    public partial class frmTableArive2 : Form
    {
        WorkWithMYSQL sqlClient = new WorkWithMYSQL();
        DataTable dt;
        Timer timerUpdate = new Timer();
        public frmTableArive2()
        {
            InitializeComponent();
        }

        PrivateFontCollection font = new PrivateFontCollection();
        private void frmTableArive2_Load(object sender, EventArgs e)
        {
            try
            {

                font.AddFontFile("fonts/Play.ttf");
                int sizeI = 30;
                btnArrive.Font = new Font(font.Families[0], 15);
                lbl1.Font = new Font(font.Families[0], sizeI, FontStyle.Bold);
                lbl2.Font = new Font(font.Families[0], sizeI, FontStyle.Bold);
                lbl3.Font = new Font(font.Families[0], sizeI, FontStyle.Bold);
                lbl4.Font = new Font(font.Families[0], sizeI, FontStyle.Bold);
                lbl5.Font = new Font(font.Families[0], sizeI, FontStyle.Bold);

                UpdateTable();

                timerUpdate.Interval = (int)(0.5 * 1000 * 60);
                timerUpdate.Tick += TimerUpdate_Tick;
                timerUpdate.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Мне не удалось отследить ошибку, так что если появится скинь мне ее." + Environment.NewLine + "Load" +
                    Environment.NewLine + ex.Message);
                this.Close();
            }
        }

        private void TimerUpdate_Tick(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            if (!isUpdate)
                UpdateTable();
            timerUpdate.Start();
        }

        bool isUpdate = false;
        List<string> hiddenSubs = new List<string>();
        Dictionary<string, int> dictStats = new Dictionary<string, int>() { { "Вое", 0 }, {"Интр", 0} ,
            {"Обр", 0}, {"Конт", 0}, {"Дип", 0} };
        private void UpdateTable()
        {
            int i = 0;
            int j = 0;
            try
            {
                isUpdate = true;
                dt = new DataTable();
                dt = sqlClient.BindingTable("Select * from `Subscribers` where `Arrive` = false order by `Coefficient` DESC Limit 20;");
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "";
                lbl4.Text = "";
                lbl5.Text = "";
                btnHide1.Visible = false;
                btnHide2.Visible = false;
                btnHide3.Visible = false;
                btnHide4.Visible = false;
                btnHide5.Visible = false;
                Control ctr;
                for (i = 0, j = 0; i < 5; j++)
                {

                    dictStats["Вое"] = 0;
                    dictStats["Интр"] = 0;
                    dictStats["Обр"] = 0;
                    dictStats["Упр"] = 0;
                    dictStats["Дип"] = 0;

                    if (j >= dt.Rows.Count)
                        break;
                    if (hiddenSubs.IndexOf(dt.Rows[j]["Name"].ToString()) != -1)
                        continue;

                    //Проверка на корректность строки с доп инофрмацией СК2
                    string[] arrStr = dt.Rows[j]["Info"].ToString().Split('|');
                    if (arrStr.Count() != 1)
                    {
                        foreach (string strStat in arrStr)
                        {
                            if (strStat == "")
                                continue;

                            string[] arrStrStat = strStat.Split(';');
                            foreach (string stat in arrStrStat)
                                if (stat != "")
                                {
                                    string test = stat.Split(' ')[0];
                                    int test1 = dictStats[stat.Split(' ')[0]];
                                    dictStats[stat.Split(' ')[0]] = dictStats[stat.Split(' ')[0]] + Convert.ToInt32(stat.Split(' ')[1]);
                                }
                        }

                        string infoStr = GetInfoStat();
                        dt.Rows[j]["Info"] = infoStr;
                        sqlClient.ModificationDataInDB($"Update `Subscribers` Set `Info` = '{infoStr}' where `Name` = '{dt.Rows[j]["Name"]}'; ");
                    }

                    ctr = this.Controls.Find("lbl" + (i + 1).ToString(), true)[0];
                    if (ctr != null)
                        ctr.Text = dt.Rows[j]["Name"].ToString() + 
                            (dt.Rows[j]["Info"].ToString() == ""? "" : "\n") + dt.Rows[j]["Info"].ToString();

                    ctr = this.Controls.Find("btnHide" + (i + 1).ToString(), true)[0];
                    if (ctr != null)
                        ctr.Visible = true;
                    i++;
                }

                isUpdate = false;
                numericUpDown1.Maximum = i;
            }
            catch (Exception ex)
            {
                //WriteError.WriteErrorIntoFile("frmTableArrive2\t UpdateTable\t" + Environment.NewLine + "dt.Rows - " + dt.Rows.Count.ToString() + Environment.NewLine +
                //    "i - " + i.ToString() + Environment.NewLine + dt.ToString());
                MessageBox.Show("Мне не удалось отследить ошибку, так что если появится скинь мне ее." + Environment.NewLine + "Update" +
                    Environment.NewLine + ex.Message);
                return;
            }
        }


        private string GetInfoStat()
        {
            string info = "";
            foreach (string str in dictStats.Keys)
            {
                if (dictStats[str] != 0)
                    info += str + " " + dictStats[str] + ";";
            }
            return info.Remove(info.Length-1);
        }

        private void btnArrive_Click(object sender, EventArgs e)
        {
            if (lbl1.Text != "" && !isUpdate)
            {
                try
                {
                    Control ctr = this.Controls.Find("lbl" + numericUpDown1.Value.ToString(), true)[0];
                    isUpdate = true;
                    sqlClient.ModificationDataInDB($@"UPDATE `Subscribers` SET `Arrive` = 1, `Month` = 0, `Coefficient` = 0, `Info` = '' WHERE `Name` = '{ctr.Text.Split('\n')[0]}' ");
                    hiddenSubs.Clear();
                    //hiddenSubs.Add(ctr.Text.Split('\n')[0]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Мне не удалось отследить ошибку, так что если появится скинь мне ее." + Environment.NewLine + "Arrive" +
                        Environment.NewLine + ex.Message);
                    this.Close();
                }
                UpdateTable();
                isUpdate = false;
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            Control ctr = this.Controls.Find("lbl" + ((Button)(sender)).Tag, true)[0];
            hiddenSubs.Add(ctr.Text.Split('\n')[0]);
            UpdateTable();
        }
    }
}
