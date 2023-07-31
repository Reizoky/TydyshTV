using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TheTydyshTV_Bot.Server
{
    class Server
    {
        public static List<UserClient> UserList = new List<UserClient>();
        public static Socket ServerSocket;
        public static string ServerIP;
        public static int ServerPort;
        public static bool Work = true;
        
        public static int CountUsers = 0;
        public delegate void UserEvent(string Name);
        public static event UserEvent UserConnected = (Username) =>
        {
            WriteLogChat($"User {Username} connected.", true);
            CountUsers++;
            //SendGlobalMessage($"Пользователь {Username} подключился к чату.");
            SendUserList();
        };
        public static event UserEvent UserDisconnected = (Username) =>
        {
            WriteLogChat($"User {Username} disconnected.", true);
            CountUsers--;
            //SendGlobalMessage($"Пользователь {Username} отключился от чата.");
            SendUserList();
        };
        public static void NewUser(UserClient usr)
        {
            if (UserList.Contains(usr))
                return;
            UserList.Add(usr);
            UserConnected(usr.Username);
        }
        public static void EndUser(UserClient usr)
        {
            if (!UserList.Contains(usr))
                return;
            UserList.Remove(usr);
            usr.End();
            UserDisconnected(usr.Username);

        }

        public static UserClient GetUser(string Name)
        {
            for (int i = 0; i < CountUsers; i++)
            {
                if (UserList[i].Username == Name)
                    return UserList[i];
            }
            return null;
        }
        public static void SendUserList()
        {
            string userList = "#userlist|";

            for (int i = 0; i < CountUsers; i++)
            {
                userList += UserList[i].Username + ",";
            }

            SendAllUsers(userList);
        }
        public static void SendGlobalMessage(string content)
        {
            for (int i = 0; i < CountUsers; i++)
            {
                UserList[i].SendMessage(content);
            }
        }

        public static void SendMessageAnyUsers(string[] listUsers, string msg, string nameChat = "main")
        {
            foreach(string user in listUsers)
            {
                try
                {
                    UserList.Find(x => x.Username.ToLower() == user.ToLower()).SendMessage(msg + "|??chat:" + nameChat);
                }
                catch (Exception ex)
                {
                    ;
                }
            }
        }

        public static void SendMessageToTarget(string msg, string target)
        {
            if (target == "toAdmin")
                for (int i = 0; i < CountUsers; i++)
                {
                    if (UserList[i].Role == "admin")
                        UserList[i].Send(msg);
                }
        }

        public static void SendAllUsers(byte[] data)
        {
            for (int i = 0; i < CountUsers; i++)
            {
                UserList[i].Send(data);
            }
        }

        public static void SendAllUsers(string data)
        {
            for (int i = 0; i < CountUsers; i++)
            {
                UserList[i].Send(data);
            }
        }
        delegate void delWritelineInRtbChat(string text, bool system); //Делегат для записи в чат приложения
        public static void WriteLogChat(string msg, bool system = false)
        {
            //this.rtbChat.Text += (system ? "System: " : "") + msg + Environment.NewLine;
            if (Сервер.frmServer.frmServerMain.InvokeRequired)
            {
                delWritelineInRtbChat d = new delWritelineInRtbChat(WriteLogChat);
                Сервер.frmServer.frmServerMain.rtbLog.Invoke(d, new object[] { msg, system });
            }
            else
            {
                //    frmMain.frmMainWindow.rtbChat.Text = frmMain.frmMainWindow.rtbChat.Text.Remove(0,50);
                Сервер.frmServer.frmServerMain.rtbLog.AppendText((system ? "System: " : "") + msg + Environment.NewLine);
            }
        }
    }
}