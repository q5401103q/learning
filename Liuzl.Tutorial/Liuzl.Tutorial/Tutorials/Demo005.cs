using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Tutorials
{
    class Demo005
    {
        public void Test()
        {
            foreach (var num in Method1())
            {
                Console.WriteLine(num);
            }

            foreach (var num in Method2())
            {
                Console.WriteLine(num);
            }

            //用while循环代替foreach
            IEnumerator<int> enumerator = Method1().GetEnumerator();
            while (enumerator.MoveNext())
            {
                int current = enumerator.Current;
                Console.WriteLine(current);
            }
        }

        public static IEnumerable<int> Method1()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        public static IEnumerable<int> Method2()
        {
            yield return 1;
            yield return 2;
            yield break;
            yield return 3;
        }
    }
}
