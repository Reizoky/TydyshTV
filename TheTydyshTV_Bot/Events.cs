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
    class Events
    {
        Random random = new Random();
        System.Timers.Timer timerAutoFight;
        bool isFight = false; //Флаг, если идет бой
        public Events()
        {
            System.Timers.Timer timerAutoFight = new System.Timers.Timer();
            System.Timers.Timer timerBossAutoFight = new System.Timers.Timer();
        }

        /// <summary>
        /// Установка настроек стартовых
        /// </summary>
        private void LoadDefSettings()
        {
            #region Установка настроек автобоев
            //Автобои
            if (Properties.Settings.Default.enAutoFight)
            {
                timerAutoFight.Interval = Properties.Settings.Default.intervalAutoFight * 1000 * 60;
                timerAutoFight.Elapsed += TimerAutoFight_Elapsed;
                timerAutoFight.Start();
            }
            #endregion
        }

        #region Бои и турниры
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


        List<string> listFighters = new List<string>();
        List<string> listTournamentFighters = new List<string>();
      
        /// <summary>
        /// Начало события Бой
        /// </summary>
        /// <param name="name1">Имя 1 бойца</param>
        /// <param name="name2">Имя 2 бойца</param>
        public void StartEventFight(string name1, string name2)
        {
            isFight = true;
            StartNewThread(new Thread(delegate ()
            {
                Fight fight1 = new Fight(name1, name2);
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
            {
                Tournament tr1 = new Tournament(fighters, tournamentName);
                while (tr1.tournamentWinnerName == string.Empty)
                    Thread.Sleep(3000);
                EndFight();
                listTournamentFighters.Clear();
            }));
        }

        /// <summary>
        /// Окончание бой, запуск тамеров
        /// </summary>
        private void EndFight()
        {
            isFight = false;
            if (timerAutoFight != null && !timerAutoFight.Enabled)
                timerAutoFight.Start();
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
        #endregion

        /// <summary>
        /// Запуск нового фонового потока
        /// </summary>
        /// <param name="th">Поток</param>
        private void StartNewThread(Thread th)
        {
            th.IsBackground = true;
            th.Start();
        }

    }
}