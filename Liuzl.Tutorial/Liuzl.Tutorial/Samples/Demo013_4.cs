using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    class Demo013_4
    {
        public static void Test()
        {
            int[,] matrix = new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
            Func<int, bool> pridicate = n =>
            {
                if (n == 8)
                {
                    return true;
                }
                return false;
            };
            var a = Find(matrix, pridicate);
            Console.WriteLine(a);
            //ref double d = ref SomeMethod();
        }

        public static ref int Find(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (predicate(matrix[i, j]))
                    {
                        return ref matrix[i, j];
                    }
                }
            }
            throw new InvalidOperationException("Not found");
        }
    }
}
