using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    class Demo011
    {
        unsafe private static void Test()
        {
            Point pt = new Point();
            fixed (int* p = &pt.x)
            {
                *p = 1;

                int* innerPtr = p;
                *innerPtr = 2;
                innerPtr++;
            }
        }

        unsafe private static void FixedSpanExample()
        {
            int[] PascalsTriangle = {
                          1,
                        1,  1,
                      1,  2,  1,
                    1,  3,  3,  1,
                  1,  4,  6,  4,  1,
                1,  5,  10, 10, 5,  1
            };

            Span<int> RowFive = new Span<int>(PascalsTriangle, 10, 5);

            fixed (int* ptrToRow = RowFive)
            {
                // Sum the numbers 1,4,6,4,1
                var sum = 0;
                for (int i = 0; i < RowFive.Length; i++)
                {
                    sum += *(ptrToRow + i);
                }
                Console.WriteLine(sum);
            }
        }
    }

    class Point
    {
        public int x;
        public int y;
    }
}
