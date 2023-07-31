using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading;

namespace TheTydyshTV_Bot
{
    class Tournament
    {
        string channelName = string.Empty;
        public string tournamentName = string.Empty;
        List<string> fighters = new List<string>();
        System.Timers.Timer timerAction = new System.Timers.Timer();

        public string tournamentWinnerName = string.Empty;
        /// <summary>
        /// Создание турнира
        /// </summary>
        /// <param name="_fighters">Массив имен бойцов</param>
        public Tournament(List<string> _fighters, string _tournamentname)
        {
            channelName = TwitchChat.channelName;
            tournamentName = _tournamentname;

            timerAction.Interval = 5 * 1000;
            timerAction.Elapsed += NextFight;

            GetListNextPhase(_fighters, true);
        }

        int phaseCount = 0;
        /// <summary>
        /// Получение списка бойцов следующего круга
        /// </summary>
        /// <param name="_fighters">Массив имен бойцов</param>
        /// <returns></returns>
        private void GetListNextPhase(List<string> _fighters, bool newTournament)
        {
            if (phaseCount == 0)
                TwitchChat.client.SendMessage(channelName, "Да начнется турнир");
            
            fightCount = 0;
            string listFighters = string.Empty;
            
            foreach (string fighter in _fighters)
            {
                if (newTournament)
                    fighters.Add(fighter);
                listFighters += fighter + "; ";
            }

            phaseCount++;
            TwitchChat.client.SendMessage(channelName, "В " + phaseCount.ToString() + " кругу будут учавствовать: " +
                listFighters.Remove(listFighters.Length - 2));

            timerAction.Start();
        }

        public List<string[]> losers = new List<string[]>();
        int fightCount = 0;
        /// <summary>
        /// Страрт нового боя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextFight(object sender, ElapsedEventArgs e)
        {
            timerAction.Stop();

            if (fightCount + 1 >= fighters.Count)
            {
                GetListNextPhase(fighters, false);
                return;
            }
            Fight fg = new Fight(fighters[fightCount], fighters[++fightCount]);

            while (fg.loserName == string.Empty)
                Thread.Sleep(1000);

            losers.Add( new string[] { fg.loserName, phaseCount.ToString(), fg.winnerName });
            fighters.Remove(fg.loserName);


            if (fighters.Count == 1)
            {
                TwitchChat.client.SendMessage(channelName, "Победителем турнира \"" + tournamentName +
                    "\" становится - " + fighters[0]);
                string endMsg = "";
                foreach (string[] str in losers)
                    endMsg += str[0] + ";" + str[1] + ";" + str[2] + Environment.NewLine;
                endMsg += Environment.NewLine + "Winner;" + fighters[0];
                File.WriteAllText("TournamentLogs\\Tournamern (" + tournamentName + ") result.txt", endMsg);
                tournamentWinnerName = fighters[0];
                return;
            }

            timerAction.Start();
        }
    }
}