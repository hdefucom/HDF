using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HDF.DeskBand
{
    public static class Log
    {
        static Log()
        {
            var path = Path.GetDirectoryName(typeof(Log).Assembly.Location);
            LogPath = Path.Combine(path, "log.txt");
        }

        readonly static string LogPath = "E:\\1.txt";
        public static void Write(string msg) => File.AppendAllText(LogPath, msg + Environment.NewLine);


    }
}
