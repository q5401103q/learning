using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    class Demo006_3
    {
        public static void Method1()
        {
            //单一委托
            Logger.WriteMessage = LoggingMethods.LogToConsole;

            //多播委托的示例
            Logger.WriteMessage += LoggingMethods.LogToConsole;
            Logger.WriteMessage += LoggingMethods.LogToFile;

            //删除一个委托
            Logger.WriteMessage -= LoggingMethods.LogToFile;
            Logger.WriteMessage -= LoggingMethods.LogToFile;
            Logger.WriteMessage -= LoggingMethods.LogToFile;
        }
    }

    public static class Logger
    {
        public static Action<string> WriteMessage;

        public static void LogMessage(string msg)
        {
            WriteMessage(msg);
        }
    }

    public static class LoggingMethods
    {
        public static void LogToConsole(string message)
        {
            Console.Error.WriteLine(message);
        }

        public static void LogToFile(string message)
        {
            using (var writer = new StreamWriter("your-file-path"))
            {
                writer.WriteLine(message);
                writer.Flush();
            }
        }
    }
}
