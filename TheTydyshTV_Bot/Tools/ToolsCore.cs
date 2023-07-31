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

namespace TheTydyshTV_Bot.Tools
{
    public class ToolsCore
    {
        public static bool isStrawpoll = false;
        public void StartStrawpoll(List<string> listVariants)
        {
            frmMain.frmMainWindow.Send("#targetMessage|toAdmin|changeStrawpoll|true");
            frmMain.frmMainWindow.Send("#strawpoll|"+ string.Join(":", listVariants));
        }

        public void EndStrawpoll(string msg)
        {
            frmMain.frmMainWindow.Send("#targetMessage|toAdmin|changeStrawpoll|false");
            frmMain.frmMainWindow.Send(msg);
        }

        
    }
}
