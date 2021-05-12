using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    public class Demo008
    {
        public enum Season
        {
            Spring, //0
            Summer, //1
            Autumn, //2
            Winter  //3
        }

        [Flags]
        protected internal enum Days
        {
            None = 0b_0000_0000,  // 0
            Monday = 0b_0000_0001,  // 1
            Tuesday = 0b_0000_0010,  // 2
            Wednesday = 0b_0000_0100,  // 4
            Thursday = 0b_0000_1000,  // 8
            Friday = 0b_0001_0000,  // 16
            Saturday = 0b_0010_0000,  // 32
            Sunday = 0b_0100_0000,  // 64
            Weekend = Saturday | Sunday
        }

        public enum ErrorCode : ushort
        {
            BadRequest = 400,
            NotFound = 404,
            InternalServerError = 500
        }

        public static void Test()
        {
            Season season1 = 0;
            Season season2 = Season.Winter;

            Console.WriteLine($"value of {season1} is {(int)season1}");
            Console.WriteLine($"value of {season2} is {(int)season2}");

            Console.WriteLine("0 is defined in ErrorCode? {0}", Enum.IsDefined(typeof(ErrorCode), "0"));
            Console.WriteLine("NotFound is defined in ErrorCode? {0}", Enum.IsDefined(typeof(ErrorCode), "NotFound"));
        }
    }
}
