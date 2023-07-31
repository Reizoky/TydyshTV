using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;

namespace TheTydyshTV_Bot.Сервер
{
    public partial class frmServer : Form
    {
        public static frmServer frmServerMain;
        public frmServer()
        {
            InitializeComponent();
            frmServerMain = this;
        }

        private void OpenServerSettings(object sender, EventArgs e)
        {
            frmServerSettings frmNew = new frmServerSettings();
            frmNew.ShowDialog();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (Server.Server.Work)
                StartNewThread(new Thread(delegate () { StartServer(); }));
            else
                StartNewThread(new Thread(delegate () { ShutdownServer(); }));

        }

        private void StartNewThread(Thread th)
        {
            th.IsBackground = true;
            th.Start();
        }

        private void StartServer()
        {
            try
            {
                Server.Server.ServerIP = Properties.Settings.Default.serverIP;
                Server.Server.ServerPort = Convert.ToInt32(Properties.Settings.Default.serverPort);
                IPAddress address = IPAddress.Parse(Server.Server.ServerIP);
                Server.Server.ServerSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                Server.Server.ServerSocket.Bind(new IPEndPoint(address, Server.Server.ServerPort));
                Server.Server.ServerSocket.Listen(100);
                WriteLogChat($"Server has been started on {Server.Server.ServerIP}:{Server.Server.ServerPort}", true);
                WriteLogChat("Waiting connections...", true);
            
            frmServer.frmServerMain.btnStartServer.Text = "Выключить сервер";
            while (Server.Server.Work)
            {
                Socket handle = Server.Server.ServerSocket.Accept();
                WriteLogChat($"New connection: {handle.RemoteEndPoint.ToString()}");
                new Server.UserClient(handle);

            }
            WriteLogChat("Server closeing..." + Environment.NewLine);}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShutdownServer()
        {
            Server.Server.Work = false;
            frmServer.frmServerMain.btnStartServer.Text = "Включить сервер";
        }

        private void frmServer_Load(object sender, EventArgs e)
        {
        }
        frmMain frmMain;
        private void OpenAdminClient(object sender, EventArgs e)
        {
            frmMain = new frmMain();
            frmMain.Show();
        }

        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmMain != null)
                frmMain.Close();
        }

        delegate void delWritelineInRtbChat(string text, bool system); //Делегат для записи в чат приложения
        public void WriteLogChat(string msg, bool system = false)
        {
            if (this.InvokeRequired)
            {
                delWritelineInRtbChat d = new delWritelineInRtbChat(WriteLogChat);
                rtbLog.Invoke(d, new object[] { msg, system });
            }
            else
            {
                rtbLog.AppendText((system ? "System: " : "") + msg + Environment.NewLine);
            }
        }

        #region Работа с статистикой и информацией
        /// <summary>
        /// Запись о новом бое
        /// </summary>
        /// <param name="fighter1">Боец 1</param>
        /// <param name="fighter2">Боец 2</param>
        /// <returns></returns>
        public string AddFight(string fighter1, string fighter2)
        {
            if (lbFights.Items.IndexOf(fighter1 + " | " + fighter2) != -1 || lbFights.Items.IndexOf(fighter2 + " | " + fighter1) != -1)
            {
                return "Бой еще продолжается";
            }
            lbFights.Items.Add(fighter1 + " | " + fighter2);
            return "";
        }
        /// <summary>
        /// Удаление записи о бое
        /// </summary>
        /// <param name="fighter1">Боец 1</param>
        /// <param name="fighter2">Боец 2</param>
        /// <returns></returns>
        public string RemoveFight(string fighter1, string fighter2)
        {
            int indexFight = (lbFights.Items.IndexOf(fighter1 + " | " + fighter2) != -1) ? lbFights.Items.IndexOf(fighter1 + " | " + fighter2) :
                (lbFights.Items.IndexOf(fighter2 + " | " + fighter1) != -1 ? lbFights.Items.IndexOf(fighter2 + " | " + fighter1) : -1);
            if (indexFight == -1)
            {
                return "Такого боя не найдено";
            }
            lbFights.Items.RemoveAt(indexFight);
            return "";
        }
        #endregion
    }
}
