using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    class Demo012
    {
        public void Method1()
        {
            int length = 100;
            Span<int> numbers = length <= 128 ? stackalloc int[length] : new int[length];
            for (var i = 0; i < length; i++)
            {
                numbers[i] = i;
            }
        }

        public void Method2()
        {
            Span<int> first = stackalloc int[3] { 1, 2, 3 };
            Span<int> second = stackalloc int[] { 1, 2, 3 };
            ReadOnlySpan<int> third = stackalloc[] { 1, 2, 3 };
        }

        public void Method3()
        {
            unsafe
            {
                int length = 3;
                int* numbers = stackalloc int[length];
                for (var i = 0; i < length; i++)
                {
                    numbers[i] = i;
                }
            }
        }
    }
}
