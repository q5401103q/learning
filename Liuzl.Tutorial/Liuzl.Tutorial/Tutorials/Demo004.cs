using System;
using System.Linq;

namespace Liuzl.Tutorial.Tutorials
{
    class Demo004
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        public void Method1()
        {
            var query1 = from num in numbers
                        where num < 5 && num % 2 == 0
                        select num;

            var query2 = from num in numbers
                         where num < 5
                         where num % 2 == 0
                         select num;

            var query3 = from num in numbers
                         where IsEven(num)
                         select num;

            foreach (var s in query1)
            {
                Console.WriteLine(s.ToString());
            }
        }

        static bool IsEven(int i)
        {
            return i % 2 == 0;
        }
    }
}
