using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Timers;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Api.V5.Models.Users;

namespace TheTydyshTV_Bot
{
    class TwitchChat
    {
        #region Глобальные объекты
        public static TwitchClient client;
        public static string channelName = string.Empty;
        string channelId = string.Empty;
        string botName = string.Empty;
        string twitchOAuth = string.Empty;

        delegate void delWritelineInRtbChat(string text, bool system); //Делегат для записи в чат приложения
        delegate void delWritelineInUsers(string text); //Делегат для записи в чат приложения
        delegate void delDeleteUsersFromList(string text); //Удалить пользователя из списка зрителей
        delegate void addUserToFight(string text, bool flag); //Добавление зрителя для боя
        Random random = new Random();
        TwitchLib.Api.TwitchAPI twitchAPI;

        bool isFight = false; //Флаг, если идет бой

        List<string> arrUsers = new List<string>(); //Лист активных зрителей
        #endregion

        /// <summary>
        /// Подключение к твичу
        /// </summary>
        public void Connection()
        {
            LoadDefSettings();
            ConnectionCredentials credentials = new ConnectionCredentials(botName, twitchOAuth);
            twitchAPI = new TwitchLib.Api.TwitchAPI();
            twitchAPI.Settings.ClientId =channelId;

            client = new TwitchClient(protocol: ClientProtocol.TCP);
            client.Initialize(credentials, channelName);

            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnWhisperReceived += Client_OnWhisperReceived;
            client.OnUserJoined += Client_OnUserJoined;
            client.OnUserLeft += Client_OnUserLeft;
            client.OnConnected += Client_OnConnected;
            
            client.Connect();
            }

        System.Timers.Timer timerAutoFight = new System.Timers.Timer();
        System.Timers.Timer timerBossAutoFight = new System.Timers.Timer();
        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            WriteLocalChat("Подключение", true);
            #region Установка настроек автобоев
            //Автобои
            if (Properties.Settings.Default.enAutoFight)
            {
                timerAutoFight.Interval = Properties.Settings.Default.intervalAutoFight * 1000 * 60;
                timerAutoFight.Elapsed += TimerAutoFight_Elapsed;
                timerAutoFight.Start();
            }
            //Автобои с боссом
            if (Properties.Settings.Default.enBossAutoFight)
            {
                timerBossAutoFight.Interval = Properties.Settings.Default.intervalBossAutoFight * 1000 * 60;
                timerBossAutoFight.Elapsed += TimerBossAutoFight_Elapsed;
                timerBossAutoFight.Start();
            }
            #endregion
        }
       
        #region Автобои
        /// <summary>
        /// Автобои желающих
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TimerAutoFight_Elapsed(object sender, ElapsedEventArgs e)
        {
            timerAutoFight.Stop();
            if (isFight)
                return;


            if (listTournamentFighters.Count <= Properties.Settings.Default.minTournamentFighters - 1)
            {
                
                if (listFighters.Count >= 2)
                {
                    //Обычный бой
                    string n1 = string.Empty;
                    string n2 = string.Empty;
                    do
                    {
                        n1 = listFighters[random.Next(listFighters.Count - 1)];
                        n2 = listFighters[random.Next(listFighters.Count - 1)];
                    } while (n1 == n2);
                    isFight = true;
                    await Task.Run(() => StartEventFight(n1, n2));
                }
                
            }
            else
            {
                //Турнир
                //await Task.Run(() => StartEventTournament(listTournamentFighters,"Турнир стрима " + DateTime.Now.ToShortDateString()));
            }

            timerAutoFight.Start();
        }
        
        /// <summary>
        /// Автобои с боссом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerBossAutoFight_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (isFight)
                return;
            isFight = true;

            isFight = false;
            //Доделать
        }
        #endregion

        /// <summary>
        /// Отключение от твичаchannelName
        /// </summary>
        public void Disconnect()
        {
            WriteLocalChat("Отключение");
            client.Disconnect();
        }
       
        #region Работа со списком людей чата
        private void Client_OnUserLeft(object sender, OnUserLeftArgs e)
        {
            return;
            throw new NotImplementedException();
            //AddUserToList(e.Username);
        }

        private void Client_OnUserJoined(object sender, OnUserJoinedArgs e)
        {
            return;
            throw new NotImplementedException();
            //AddUserToList(e.Username);
        }
        #endregion

        #region Обработка сообщений чата
        List<string> listFighters = new List<string>();
        List<string> listTournamentFighters = new List<string>();
       
        /// <summary>
        /// Действия на сообщения в чате стрима твича
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            WriteLocalChat(e.ChatMessage.Username + ": " + e.ChatMessage.Message);

            if (!e.ChatMessage.Message.StartsWith("!"))
                return;
            if (e.ChatMessage.Message.StartsWith("!МоеДобро", StringComparison.CurrentCultureIgnoreCase))
                {
                    StartNewThread(new Thread(delegate () { SendWhisperInventar(e.ChatMessage.Username); }));
                }
            else if (e.ChatMessage.Message.StartsWith("!ЧАРДЖ", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (listFighters.Find(x => x == e.ChatMessage.Username) == null && 
                    listTournamentFighters.Find(x => x == e.ChatMessage.Username) == null)
                        listFighters.Add(e.ChatMessage.Username);
                }
        }
        #endregion

        #region Обработка шопота стримеру
        
        /// <summary>
        /// Действия на шопот стримеру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            //Взять вещь из инвентаря и одеть
            if (e.WhisperMessage.Message.StartsWith("!Взять", StringComparison.InvariantCultureIgnoreCase))
            {
                string sqlSelect = "Call TakeEquipment ('" + e.WhisperMessage.Username + "', '" + e.WhisperMessage.Message.Replace("!Взять ", "") + "')";
                if (-1 == MySQL_Update(sqlSelect))
                    client.SendWhisper(e.WhisperMessage.Username, "Что то пошло не так, мы обязательно это исправим (или сделаем)");
                else
                    StartNewThread(new Thread(delegate () { SendWhisperInventar(e.WhisperMessage.Username); }));
            }
            else if (e.WhisperMessage.Message.StartsWith("!яОхуенен", StringComparison.InvariantCultureIgnoreCase))
            { 
                StartNewThread(new Thread(delegate () { SendInfoAboutCharacter(e.WhisperMessage.Username); }));
            }
            else if (e.WhisperMessage.Message.StartsWith("!Инфо", StringComparison.InvariantCultureIgnoreCase))
            {
                StartNewThread(new Thread(delegate () { SendWhisperInventar(e.WhisperMessage.Username); }));
            }
        }
        #endregion
        
        /// <summary>
        /// Начало события Бой
        /// </summary>
        /// <param name="name1">Имя 1 бойца</param>
        /// <param name="name2">Имя 2 бойца</param>
        public void StartEventFight(string name1, string name2)
        {
            isFight = true;
            StartNewThread(new Thread(delegate () 
            { Fight fight1 = new Fight(name1, name2);
                while (fight1.loserName == string.Empty)
                    Thread.Sleep(2000);
                EndFight(fight1.winnerName, fight1.loserName);
            }));
        }
        
        /// <summary>
        /// Начало события Турнир
        /// </summary>
        /// <param name="fighters">Список имен бойцов</string></param>
        /// <param name="tournamentName">Название турни</param>
        public void StartEventTournament(List<string> fighters, string tournamentName)
        {
            StartNewThread(new Thread(delegate () 
            { Tournament tr1 = new Tournament(fighters, tournamentName);
                while (tr1.tournamentWinnerName == string.Empty)
                    Thread.Sleep(3000);
                EndFight();
                listTournamentFighters.Clear();
            }));
        }

        #region Общие методы
        
        /// <summary>
        /// Установка настроек стартовых
        /// </summary>
        private void LoadDefSettings()
        {
            channelName = Properties.Settings.Default.channelName;
            channelId = Properties.Settings.Default.channelId;
            botName = Properties.Settings.Default.botName;
            twitchOAuth = Properties.Settings.Default.twitchOAuth;
        }

        /// <summary>
        /// Отправка сообщения в чат приложения
        /// </summary>
        /// <param name="msg">Сообщение</param>
        /// <param name="system">От имени системы</param>
        public void WriteLocalChat(string msg, bool system=false)
        {
            ////this.rtbChat.Text += (system ? "System: " : "") + msg + Environment.NewLine;
            //if (frmMain.frmMainWindow.rtbChat.InvokeRequired)
            //{
            //    delWritelineInRtbChat d = new delWritelineInRtbChat(WriteLocalChat);
            //    frmMain.frmMainWindow.rtbChat.Invoke(d, new object[] { msg, system });
            //}
            //else
            //{
            //    //if (frmMain.frmMainWindow.rtbChat.Lines.Count() > 600)
            //    //    frmMain.frmMainWindow.rtbChat.Text = frmMain.frmMainWindow.rtbChat.Text.Remove(0,50);
            //    frmMain.frmMainWindow.rtbChat.AppendText((system ? "System: " : "") + msg + Environment.NewLine);
            //}
        }
        
        /// <summary>
        /// Обновление записей в БД
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private int MySQL_Update(string sql)
        {
            WorkWithMYSQL sqlClient = new WorkWithMYSQL();

            return sqlClient.ModificationDataInDB(sql);
        }
       
        /// <summary>
        /// Отправка сообщения об вещах в инввентаре
        /// </summary>
        /// <param name="userName"></param>
        public void SendWhisperInventar(string userName)
        {
            string inInventar = string.Empty;
            string taken = string.Empty;
            string sql = @"Select * from `Subscribers`
join `Character` on `Subscribers`.`Name` = `Character`.`Name`
join `Character_Equipment` on `Character`.`IdCharacter` = `Character_Equipment`.`IdCharacter`
join `Equipment` on `Character_Equipment`.`IdEquipment` = `Equipment`.`IdEquipment`
join `Equipment_Prefix` on `Character_Equipment`.`IdEquipmentPrefix` = `Equipment_Prefix`.`IdEquipmentPrefix`
where `Subscribers`.`Name` = '" + userName + "'";
            WorkWithMYSQL sqlClient = new WorkWithMYSQL();

            DataTable dtEquipmetn = sqlClient.GetTableFromDB(sql);
            if (dtEquipmetn.Rows.Count == 0)
            {
                taken = "Ты босой, нагой, а в руках у тебя грязь и палка";
            }
            else
            {
                List<string[]> patternsSex = new List<string[]>(){
                    new string[]{ "ий$", "ая" },
                    new string[] { "ый$", "ая" },
                    new string[] { "ой$", "ая" },
                    new string[] { "ийся$", "аяся" },};
                string prefix = string.Empty;
                foreach (DataRow dr in dtEquipmetn.Rows)
                {
                    prefix = dr["Prefix"].ToString();
                    if (dr["InHonor"].ToString() == "1")
                    {
                        prefix += "'s";
                    }
                    else if (dr["Sex"].ToString() == "f")
                    {
                        foreach (string[] pattern in patternsSex)
                        {
                            if (Regex.IsMatch(prefix, pattern[0]))
                            {
                                prefix = Regex.Replace(prefix, pattern[0], pattern[1]);
                                break;
                            }
                        }
                    }
                    if (dr["Taken"].ToString() == "1")
                    {
                        switch (dr["Type"])
                        {
                            case "Weapon": taken += "В руках ты держишь " + prefix + " " + dr["NameEquipment"]; break;
                            case "Armor": taken += "Броня твоя крепка а имя ей " + prefix + " " + dr["NameEquipment"]; break;
                            case "Helmet": taken += "А за такое можно и убить " + prefix + " " + dr["NameEquipment"]; break;
                            case "Ring": taken += "Блестит на пальце " + prefix + " " + dr["NameEquipment"]; break;
                        }
                        taken += " ";
                    }
                    else
                    {
                        inInventar += dr["NameEquipment"] + ((prefix != "") ? "  (" + prefix + ")" + "" : "") + ";" + '\t';
                    }
                }
            }
            //Инфа о золоте
            sql = "Select `Coins` from `Character` where `Name` = '" + userName + "' Limit 1;";

            DataTable dtCoins = sqlClient.GetTableFromDB(sql);
            if (dtCoins.Rows.Count > 0)
                taken += ".\t В золотовалютном фонде у тебя есть: " + dtCoins.Rows[0]["Coins"].ToString() + " монет";

            if (inInventar != string.Empty)
                taken += ".\tВ сундуке твоем лежит: \t" + inInventar;
            client.SendWhisper(userName, taken);

            sql = @"Select * from `GlobalMessage`
where `CharacterName` = '" + userName + "'";

            DataTable dtGlobal = sqlClient.GetTableFromDB(sql);
            if (dtGlobal.Rows.Count > 0)
            {
                string strGlobal = string.Empty;
                foreach (DataRow dr in dtGlobal.Rows)
                {
                    strGlobal = dr["Message"] + Environment.NewLine;
                }

                sql = @"Delete from `GlobalMessage` 
where `CharacterName` = '" + userName + "'";
                sqlClient.ModificationDataInDB(sql);
                client.SendMessage(channelName, strGlobal);
            }
        }
      
        /// <summary>
        /// Отправка сообщения с приблизительной информацией о персонаже
        /// </summary>
        /// <param name="ch">Экхемпляр класса Character</param>
        public void SendInfoAboutCharacter(string userName)
        {
            Character ch = new Character(userName);
            string strInfo = string.Empty;
            if (ch.strength <= 20)
                strInfo += "Ты слаб, ты немощен, разве что палку и можешь держать.";
            else if (ch.strength <= 30)
                strInfo += "Ты что то можешь, но не расчитывай, что горы свернуть сможешь.";
            else
                strInfo += "Все, бегут от тебя в ужасе. Скрип твоих мускул слышен за пару кварталов.";

            if (ch.evasion <= 15)
                strInfo += " У тебя достаточно ловкости, дабы увернутся от удара улитки, максимум комара.";
            else if (ch.evasion <= 25)
                strInfo += " Соглашусь, ты что то да и можешь, но ты еще неповоротлив.";
            else
                strInfo += " Ловкость мангуста, оскал зверя!";

            if (ch.block <= 10)
                strInfo += " Твоя защита оставляет желать лучшего, дуновение ветра и тебя снесет.";
            else if (ch.block <= 15)
                strInfo += " Блокирую один удар, от второго лучше увернуться.";
            else
                strInfo += " Тебе не нужно двигаться, если тебя не могут пробить, верно ведь?";

            if (ch.fortune <= 20)
                strInfo += " Удача? Что то ты о ней слышал, но никогда не видел.";
            else
                strInfo += " Твой сталкер - удача.";

            client.SendWhisper(ch.characterName, strInfo);
        }
        
        /// <summary>
        /// Получение информации о пользователе
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private string GetUserId(string username)
        {
            User[] userList = twitchAPI.V5.Users.GetUserByNameAsync(username).Result.Matches;
            if (userList == null || userList.Length == 0)
            {
                return null;
            }

            return userList[0].Id;
        }
       
        /// <summary>
        /// Окончание бой, запуск тамеров
        /// </summary>
        private void EndFight()
        {
            isFight = false;
            if (!timerAutoFight.Enabled)
                timerAutoFight.Start();
            if (!timerBossAutoFight.Enabled)
                timerBossAutoFight.Start();
        }
       
        /// <summary>
        /// Окончание боя, запуск таймеров, занесение победителя в список турнира
        /// </summary>
        /// <param name="winner">Победитель</param>
        /// <param name="looser">Проигравший</param>
        private void EndFight(string winner, string looser)
        {
            listTournamentFighters.Add(winner);
            listFighters.Remove(winner);
            listFighters.Remove(looser);
            EndFight();
        }
       
        /// <summary>
        /// Запуск нового фонового потока
        /// </summary>
        /// <param name="th">Поток</param>
        private void StartNewThread(Thread th)
        {
            th.IsBackground = true;
            th.Start();
        }
        
        #endregion
    }


}