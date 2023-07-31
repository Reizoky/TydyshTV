using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Net.Sockets;
using System.Net;

namespace TheTydyshTV_Bot
{
    public partial class frmMain : Form
    {
        public static frmMain frmMainWindow;
        public Tools.ToolsCore toolsCore = new Tools.ToolsCore();
        public Tools.Strawpoll.frmStrawpoll frmStrawpoll;
        public Tools.Strawpoll.frmSelectVariantInStrawpoll frmSelectVariantInStrawpoll;
        TheTydyshTV_Bot.Events events = new Events();
        public frmMain()
        {
            InitializeComponent();
            frmMainWindow = this;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            //twitchChat = new TwitchChat();
            //tabControlChats.DrawMode = TabDrawMode.OwnerDrawFixed; //для отрисовки изменения вкладок
        }

        //Временное
        //Убрать после того, как сделаешь регистрацию
        public static string userName;
        public static string userRole;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!btnSendChatMsg.Enabled)
            {
                frmLogin frmLogin = new frmLogin();
                if (frmLogin.ShowDialog() == DialogResult.OK)
                    ConnectToServer();
                btnConnect.Text = "Отключиться";
            }
            else
            {
                btnConnect.Text = "Подключиться";
                btnSendChatMsg.Enabled = false;
                _serverSocket.Disconnect(false);
                
            }
        }

        private void btnCK2TableArive_Click(object sender, EventArgs e)
        {
            CK2.frmTableArive frmTable = new CK2.frmTableArive();
            frmTable.ShowDialog();
        }

        private void btnFightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewFight();
        }

        private void StartNewFight()
        {
            frmTestFight frmTestFight = new frmTestFight();
            if (frmTestFight.ShowDialog() == DialogResult.OK) 
                events.StartEventFight(frmTestFight.name1, frmTestFight.name2);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings frmSettings = new frmSettings();
            frmSettings.ShowDialog();
        }

        private void btnStartTournament_Click(object sender, EventArgs e)
        {
            frmNewTournament frmNewTournament = new frmNewTournament();
            if (frmNewTournament.ShowDialog() == DialogResult.OK)
                ;
                //twitchChat.StartEventTournament(frmNewTournament.fighters, frmNewTournament.tournamentName);
        }
        
        private void btnSendChatMsg_Click(object sender, EventArgs e)
        {
            PreapereSendMessage(tbChatMsg.Text);
        }

        private void tbChatMsg_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                PreapereSendMessage(tbChatMsg.Text);
            }
        }
        private void PreapereSendMessage(string msg)
        {
            SendMsg(msg);
            tbChatMsg.Focus();
        }

        private void wbChat_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (((WebBrowser)(sender)) != null)
            if (yScroll + 400 >= ((WebBrowser)(sender)).Document.Body.ScrollRectangle.Height)
            {
                ((WebBrowser)(sender)).Document.Window.ScrollTo(0, ((WebBrowser)(sender)).Document.Body.ScrollRectangle.Height);
            }
            else
            {
                ((WebBrowser)(sender)).Document.Window.ScrollTo(0, yScroll);
            }
        }

        #region Работа с сервером

        private delegate void ChatEvent(string msg, string fontStyle, string targetChat);
        private ChatEvent _addMessage;
        private Socket _serverSocket;
        private Thread listenThread;
        //private string serverIp = "192.168.1.101";
        private string serverIp = "159.69.223.153";
        private int serverPortt = 49050;
        int yScroll = -1;

        const string  systemStyle = " size=2.5  style = \"background:black; color:white\" ";
        private void ConnectToServer()
        {
            _addMessage = new ChatEvent(WriteLocalChat);
            contextMenuStripUser = new ContextMenuStrip();
            ToolStripMenuItem privateMsg = new ToolStripMenuItem();
            privateMsg.Text = "Личное сообщение";
            privateMsg.Click += PrivateMsg_Click;
            contextMenuStripUser.Items.Add(privateMsg);

            contextMenuStripUser.ContextMenuStrip = contextMenuStripUser;

            IPAddress temp = IPAddress.Parse(serverIp);
            _serverSocket = new Socket(temp.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Connect(new IPEndPoint(temp, serverPortt));
            if (_serverSocket.Connected)
            {
                btnSendChatMsg.Enabled = true; 
                WriteLocalChat("Связь с сервером установлена.", "main", systemStyle);
                listenThread = new Thread(listner);
                listenThread.IsBackground = true;
                listenThread.Start();

            }
            else
                WriteLocalChat("Связь с сервером не установлена.", systemStyle);

            Send($"setname|{userName}|role:admin");
        }
        private void PrivateMsg_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItems.Count > 0)
                tbChatMsg.Text = $"\\w " + lbUsers.SelectedItem + " ";
        }
        /// <summary>
        /// Отправка личной информации в чат
        /// </summary>
        /// <param name="msg">Сообщение</param>
        /// <param name="fontStyle">Стиль текста</param>
        private void WriteLocalChat(string msg, string targetChat = "main",  string fontStyle = " size=2 ")
        {
            if (InvokeRequired)
            {
                Invoke(_addMessage, msg, targetChat, fontStyle);
                return;
            }
            if (targetChat == "main")
            {
                wbChat.DocumentText += "<font {addStyle}>".Replace("{addStyle}", fontStyle) + msg + "</font><br>";
                if (wbChat.Document.Body != null)
                    yScroll = wbChat.Document.Body.ScrollTop;
                if (tabControlChats.SelectedIndex != 0)
                {
                    string[] arrTextHeader = tpMainChat.Text.Split(' ');
                    int numbNewMess = arrTextHeader.Length > 1 ? Convert.ToInt32(arrTextHeader[1]) + 1 : 1;
                    tpMainChat.Text = tpMainChat.Text.Split(' ')[0] + (numbNewMess > 0 ? " " + numbNewMess.ToString(): "");
                }
            }
            else if (targetChat == "fight")
            {
                wbFight.DocumentText += "<font {addStyle}>".Replace("{addStyle}", fontStyle) + msg + "</font><br>";
                if (wbFight.Document.Body != null)
                    yScroll = wbFight.Document.Body.ScrollTop;
                if (tabControlChats.SelectedIndex != 1)
                {
                    string[] arrTextHeader = tpBattle.Text.Split(' ');
                    int numbNewMess = arrTextHeader.Length > 1 ? Convert.ToInt32(arrTextHeader[1]) + 1 : 1;
                    tpBattle.Text = tpBattle.Text.Split(' ')[0] + (numbNewMess > 0 ? " " + numbNewMess.ToString() : "");
                }
            }
            else if (targetChat == "system")
            {
                wbSystem.DocumentText += "<font {addStyle}>".Replace("{addStyle}", fontStyle) + msg + "</font><br>";
                if (wbSystem.Document.Body != null)
                    yScroll = wbSystem.Document.Body.ScrollTop;
                if (tabControlChats.SelectedIndex != 2)
                {
                    string[] arrTextHeader = tpSystem.Text.Split(' ');
                    int numbNewMess = arrTextHeader.Length > 1 ? Convert.ToInt32(arrTextHeader[1]) + 1 : 1;
                    tpSystem.Text = tpSystem.Text.Split(' ')[0] + (numbNewMess > 0 ? " " + numbNewMess.ToString() : "");
                }
            }
        }


        public void Send(byte[] buffer)
        {
            try
            {
                _serverSocket.Send(buffer);
            }
            catch { }
        }
        public void Send(string Buffer)
        {
            try
            {
                _serverSocket.Send(Encoding.Unicode.GetBytes(Buffer));
            }
            catch { }
        }
        /// <summary>
        /// Прослушка сокета
        /// </summary>
        public void listner()
        {
            try
            {
                while (_serverSocket.Connected)
                {
                    byte[] buffer = new byte[2048];
                    int bytesReceive = _serverSocket.Receive(buffer);
                    handleCommand(Encoding.Unicode.GetString(buffer, 0, bytesReceive));
                }
            }
            catch
            {
                MessageBox.Show("Связь с сервером прервана", systemStyle);
                Application.Exit();
            }
        }

        public List<string> listVariants = new List<string>();
        public void handleCommand(string cmd)
        {
            string[] commands = cmd.Split('#');
            int countCommands = commands.Length;
            for (int i = 0; i < countCommands; i++)
            {
                try
                {
                    string currentCommand = commands[i];
                    if (string.IsNullOrEmpty(currentCommand))
                        continue;
                    if (currentCommand.Contains("setnamesuccess"))
                    {
                        //Из-за того что программа пыталась получить доступ к контролам из другого потока вылетал эксепщен и поля не разблокировались

                        Invoke((MethodInvoker)delegate
                        {
                            btnSendChatMsg.Enabled = true;
                        });
                        continue;
                    }
                    if (currentCommand.Contains("setnamefailed"))
                    {
                        WriteLocalChat("Неверный ник!", systemStyle);
                        continue;
                    }
                    if (currentCommand.Contains("msg"))
                    {

                        string[] strCommand = currentCommand.Split('|');
                        if (strCommand.Length == 2)
                            WriteLocalChat(strCommand[1]);
                        else
                            for (int z = 0; z < strCommand.Length; z++)
                                if (strCommand[z].Contains("??chat"))
                                {
                                    string[] chats = strCommand[z].Split(':');
                                    foreach (string chat in chats)
                                    {
                                        if (chat == "main")
                                            WriteLocalChat(strCommand[1]);
                                        else if (chat == "fight")
                                            WriteLocalChat(strCommand[1], "fight");
                                        else if (chat == "system")
                                            WriteLocalChat(strCommand[1], "system");
                                    }
                                }
                        continue;
                    }

                    if (currentCommand.Contains("userlist"))
                    {
                        string[] Users = currentCommand.Split('|')[1].Split(',');
                        int countUsers = Users.Length;
                        lbUsers.Invoke((MethodInvoker)delegate { lbUsers.Items.Clear(); });
                        for (int j = 0; j < countUsers; j++)
                        {
                            lbUsers.Invoke((MethodInvoker)delegate { lbUsers.Items.Add(Users[j]); });
                        }
                        continue;
                    }

                    if (currentCommand.Contains("strawpoll"))
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            string[] arrMsg = currentCommand.Split('|')[1].Split(':');
                            listVariants.Clear();
                            listVariants = new List<string>();
                            for (int z = 0; z < arrMsg.Length; z++)
                                listVariants.Add(arrMsg[z]);
                            frmSelectVariantInStrawpoll =
                                new Tools.Strawpoll.frmSelectVariantInStrawpoll();
                            frmSelectVariantInStrawpoll.Show();
                        });
                        continue;
                    }

                    if (currentCommand.Contains("changeStrawpoll"))
                    {
                        string[] arrMsg = currentCommand.Split('|');
                        Tools.ToolsCore.isStrawpoll = Convert.ToBoolean(arrMsg[1]);
                        continue;
                    }

                    if (currentCommand.Contains("voteStrawpoll"))
                    {
                        //voteStrawpoll|variant:new:old|count:count|nameUser:
                        string[] arrMsg = currentCommand.Split('|');

                        string variant = "";
                        string oldVariant = "";
                        int count = 0;
                        string nameUser = "";

                        foreach (string str in arrMsg)
                        {
                            //добавление голоса
                            if (str.Contains("variant:"))
                            {
                                string[] avMsg = str.Split(':');
                                variant = avMsg[1];
                                oldVariant = avMsg[2];
                            }
                            //добавление кол-ва голосов
                            else if (str.Contains("count:"))
                                count = Convert.ToInt32(str.Split(':')[1]);
                            //добавление имени, необходимо для перевыбора
                            else if (str.Contains("nameUser:"))
                                nameUser = str.Split(':')[1];
                        }

                        Invoke((MethodInvoker)delegate
                        {
                            frmMain.frmMainWindow.frmSelectVariantInStrawpoll.NewVote(variant, oldVariant, count, nameUser);
                        });

                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine("Error with handleCommand: " + exp.Message);
                }

            }
        }

        /// <summary>
        /// Отправка сообщения в общий чат
        /// </summary>
        /// <param name="msg"></param>
        public void SendMsg(string msg)
        {
            if (string.IsNullOrEmpty(msg))
                return;
            if (msg[0] == '\\' && msg[1] == 'w')
            {
                string temp = msg.Split(' ')[0];
                string content = msg.Substring(temp.Length + 1);
                temp = temp.Replace("\\w", string.Empty);
                Send($"#private|{temp}|{content}");
            }
            else
                Send($"#message|{userName}: {msg}");
            tbChatMsg.Text = string.Empty;
        }
        #endregion

        private void tabControlChats_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((TabControl)(sender)).SelectedIndex)
            {
                case 0: tpMainChat.Text = "Чат"; break;
                case 1: tpBattle.Text = "Бои"; break;
                case 2: tpSystem.Text = "Система"; break;
            }
        }

        private void btnAlerts_Click(object sender, EventArgs e)
        {
            Server.frmAlerts frmAlerts = new Server.frmAlerts();
            frmAlerts.Show();
        }

        private void btnCK2TableArive2_Click(object sender, EventArgs e)
        {
            CK2.frmTableArive2 frmTableArive2 = new CK2.frmTableArive2();
            frmTableArive2.Show();
        }

        private void btnSetDefArrive_Click(object sender, EventArgs e)
        {
            WorkWithMYSQL sqlClient = new WorkWithMYSQL();
            int rowCount = sqlClient.ModificationDataInDB("UPDATE `Subscribers` SET `Arrive` = 1, `Month` = 0, `Coefficient` = 0 where `Arrive` = 0;");
            if (rowCount == 0)
                MessageBox.Show("Либо все поломалосЬ, либо ничего не изменилось");
            else
                MessageBox.Show("Всего обнуленно "+rowCount.ToString());
        }

        private void btnStrawpoll_Click(object sender, EventArgs e)
        {
            if (Tools.ToolsCore.isStrawpoll)
            {
                MessageBox.Show("Уже идет голосование");
                return;
            }
            frmStrawpoll = new Tools.Strawpoll.frmStrawpoll();
            frmStrawpoll.Show();
        }


        private void StartNewThread(Thread th)
        {
            th.IsBackground = true;
            th.Start();
        }

        private void testSendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Send(tbChatMsg.Text);
        }

        private void голосование2ВариантаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alerts.frmTwoVariants frmTwoVariants = new Alerts.frmTwoVariants();
            frmTwoVariants.Show();
        }
    }
}
