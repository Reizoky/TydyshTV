using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TheTydyshTV_Bot
{
    class WriteError
    {
        public static void WriteErrorIntoFile(string msgError)
        {
            StreamWriter sw = new StreamWriter("Logs\\logError.log", true);
            sw.Write(msgError);
            sw.Close();
        }
    }
}
