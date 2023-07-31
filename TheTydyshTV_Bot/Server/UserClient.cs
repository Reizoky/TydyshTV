using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TheTydyshTV_Bot.Server
{
    class UserClient
    {
        private Thread _userThread;
        private string _userName;
        private string _role;
        private bool AuthSuccess = false;
        public string Username
        {
            get { return _userName; }
        }
        public string Role
        {
            get { return _role; }
        }
        private Socket _userHandle;
        public UserClient(Socket handle)
        {
            _userHandle = handle;
            _userThread = new Thread(listner);
            _userThread.IsBackground = true;
            _userThread.Start();
        }
        private void listner()
        {
            try
            {
                while (_userHandle.Connected)
                {
                    byte[] buffer = new byte[2048];
                    int bytesReceive = _userHandle.Receive(buffer);
                    handleCommand(Encoding.Unicode.GetString(buffer, 0, bytesReceive));
                }
            }
            catch { Server.EndUser(this); }
        }
        private bool setName(string Name)
        {
            _userName = Name;
            Server.NewUser(this);
            AuthSuccess = true;
            return true;
        }

        private void setRole(string role)
        {
            _role = role;
        }

        private void handleCommand(string cmd)
        {
            try
            {
                string[] commands = cmd.Split('#');
                int countCommands = commands.Length;
                for (int i = 0; i < countCommands; i++)
                {
                    string currentCommand = commands[i];
                    if (string.IsNullOrEmpty(currentCommand))
                        continue;
                    if (!AuthSuccess)
                    {
                        if (currentCommand.Contains("setname"))
                        {
                            if (setName(currentCommand.Split('|')[1]))
                            {
                                setRole("user");
                                foreach (string role in currentCommand.Split('|'))
                                {
                                    if (role.Contains("role"))
                                        setRole(role.Split(':')[1]);
                                }
                                Send("#setnamesuccess");
                            }
                            else
                                Send("#setnamefailed");
                        }
                        continue;
                    }
                    if (currentCommand.Contains("fightMessage"))
                    {
                        string nameChat = string.Empty;
                        string listUsersForMsg = string.Empty;
                        string msg = string.Empty;
                        string[][] arrArg = new string[currentCommand.Split('|').Length][];
                        for (int z = 0; z < arrArg.GetLength(0); z++)
                            arrArg[z] = currentCommand.Split('|')[z].Split(':');
                        foreach (string[] strArr in arrArg)
                        {
                            if (strArr[0] == "??chat")
                            {
                                for (int z = 1; z < strArr.Length; z++)
                                    nameChat += strArr[z] + ":";
                                nameChat = nameChat.Remove(nameChat.LastIndexOf(':'));
                                continue;
                            }
                            if (strArr[0] == "??users")
                            {
                                for (int z = 1; z < strArr.Length; z++)
                                    listUsersForMsg += strArr[z] + ":";
                                listUsersForMsg = listUsersForMsg.Remove(listUsersForMsg.LastIndexOf(':'));
                                continue;
                            }
                            if (strArr[0] == "??msg")
                            {
                                msg = strArr[1];
                                continue;
                            }
                        }
                        Server.SendMessageAnyUsers(listUsersForMsg.Split(':'), msg, nameChat == "" ? "main" : nameChat);
                        continue;
                    }
                    if (currentCommand.Contains("message"))
                    {
                        string endCommand = "";
                        string[] arguments = currentCommand.Split('|');
                        for (int z = 1; z < arguments.Length; z++)
                            endCommand += arguments[z]+"|";
                        Server.SendGlobalMessage(endCommand.Remove(endCommand.LastIndexOf('|')));

                        continue;
                    }
                    if (currentCommand.Contains("endsession"))
                    {
                        Server.EndUser(this);
                        return;
                    }
                    if (currentCommand.Contains("private"))
                    {
                        //Переписать приватные сообщения
                        string[] arguments = currentCommand.Split('|');
                        string TargetName = arguments[1];
                        string Content = arguments[2];
                        UserClient targetUser = Server.GetUser(TargetName);
                        if (targetUser == null)
                        {
                            SendMessage($"Пользователь {TargetName} не найден!");
                            continue;
                        }
                        SendMessage($"-[Отправлено][{TargetName}]: {Content}");
                        targetUser.SendMessage($"-[Получено][{Username}]: {Content}");
                        continue;
                    }
                    if (currentCommand.Contains("targetMessage"))
                    {
                        string[] arrArg = currentCommand.Split('|');
                        string msg = "#";
                        for (int z = 2; z < arrArg.Length; z++)
                            msg += arrArg[z]+"|";
                        Server.SendMessageToTarget(msg.Remove(msg.LastIndexOf('|')), arrArg[1]);
                        continue;
                    }
                    if (currentCommand.Contains("strawpoll"))
                    {
                        Server.SendAllUsers("#"+currentCommand);
                    }

                    if (currentCommand.Contains("voteStrawpoll"))
                    {
                        Server.SendAllUsers("#" + currentCommand);
                    }
                }

            }
            catch (Exception exp) { Console.WriteLine("Error with handleCommand: " + exp.Message); }
        }
        public void SendMessage(string content)
        {
            Send($"#msg|{content}");
        }
        public void Send(byte[] buffer)
        {
            try
            {
                _userHandle.Send(buffer);
            }
            catch { }
        }
        public void Send(string Buffer)
        {
            try
            {
                _userHandle.Send(Encoding.Unicode.GetBytes(Buffer));
            }
            catch { }
        }
        public void End()
        {
            try
            {
                _userHandle.Close();
            }
            catch { }

        }

    }
}