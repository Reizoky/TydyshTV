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
    public partial class frmSelectVariantInStrawpoll : Form
    {
        public static List<string> listVariants = new List<string>();
        Dictionary<string, int> listResults = new Dictionary<string, int>();
        List<Control[]> listControls = new List<Control[]>();
        int totalVotes = 0;

        PrivateFontCollection font = new PrivateFontCollection();
        public frmSelectVariantInStrawpoll()
        {
            InitializeComponent();
            font.AddFontFile("fonts/Play.ttf");
            this.Font = new Font(font.Families[0], 12, FontStyle.Bold);
        }

        int lastVariantIndex = 0;
        private void frmSelectVariantInStrawpoll_Load(object sender, EventArgs e)
        {
            listVariants = frmMain.frmMainWindow.listVariants;
            for (lastVariantIndex = 0; lastVariantIndex < listVariants.Count; )
            {
                AddVariant();
            }
        }

        private void AddVariant()
        {
            listControls.Add(new Control[]{this.Controls.Find("lbl" + (lastVariantIndex + 1).ToString(), true)[0],
                    this.Controls.Find("progressBar" + (lastVariantIndex + 1).ToString(), true)[0] });
            listControls[lastVariantIndex][0].Text = listVariants[lastVariantIndex];
            listControls[lastVariantIndex][0].Visible = true;
            listControls[lastVariantIndex][1].Visible = true;
            listResults.Add(listVariants[lastVariantIndex], 0);
            lastVariantIndex++;
        }

        private void btnCloseStrawpoll_Click(object sender, EventArgs e)
        {
            string msg = "#message|Голосование завершено с результатом";
            //for (int i = 0; i < listVariants.Count; i++)
            //{
            //    listResults[listControls[i][0].Text] = ((ProgressBar)(listControls[i][1])).Value;
            //}

            List<string> arrEnd = listResults.OrderBy(x => x.Value).Select(x=> x.Key + " - " + x.Value).Reverse().ToList<string>();

            foreach (string str in arrEnd)
                msg += "<br>" + str;
            frmMain.frmMainWindow.toolsCore.EndStrawpoll(msg+"<br>|??chat:main:system");
            this.Close();
        }

        /// <summary>
        /// Добавление нового варианта
        /// </summary>
        public void NewVariant(string newVariant)
        {
            if (listVariants.Count >= 8)
                return;
            listVariants.Add(newVariant);
            AddVariant();
        }

        /// <summary>
        /// Добавление голоса
        /// </summary>
        public void NewVote(string variant, string oldVariant, int count, string name)
        {
            if (oldVariant == "")
            {
                totalVotes += count;
            }
            else
            {
                listResults[oldVariant] -= count;

                for (int i = 0; i < lastVariantIndex; i++)
                {
                    if (listControls[i][0].Text == oldVariant)
                    {
                        ((ProgressBar)(listControls[i][1])).Value =
                            Convert.ToInt32(((double)listResults[oldVariant] / totalVotes) * 100);
                        break;
                    }
                }
            }
            listResults[variant] += count;

            for (int i = 0; i < lastVariantIndex; i++)
            {
                ((ProgressBar)(listControls[i][1])).Value = 
                    Convert.ToInt32(((double)listResults[listVariants[i]] / totalVotes) * 100);
            }
        }
    }
}
