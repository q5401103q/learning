using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

delegate string ConvertMethod(string inString);
delegate void DisplayMessage(string message);

namespace Liuzl.Tutorial.Samples
{
    class Demo006_4
    {
        private static string UppercaseString(string inputString)
        {
            return inputString.ToUpper();
        }

        private static void ShowWindowsMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void TestFunc()
        {
            ConvertMethod target = UppercaseString;
            Console.WriteLine(target("hello"));

            Func<string, string> func1 = UppercaseString;
            Console.WriteLine(func1("hello"));

            Func<string, string> func2 = delegate (string s) { return s.ToUpper(); };
            Console.WriteLine(func2("hello"));

            Func<string, string> func3 = s => s.ToUpper();
            Console.WriteLine(func3("hello"));
        }

        public void TestAction()
        {
            DisplayMessage target = ShowWindowsMessage;
            target("hello");

            Action<string> act1 = ShowWindowsMessage;
            act1("hello");

            Action<string> act2 = delegate (string s) { Console.WriteLine(s); };
            act2("hello");

            Action<string> act3 = s => Console.WriteLine(s);
            act3("hello");
        }
    }
}
