using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    class Demo004
    {
        public void TestChecked()
        {
            try
            {
                int num = int.MaxValue;
                checked
                {
                    num++;
                    Console.WriteLine(num);
                }
            }
            catch (OverflowException) { Console.WriteLine("int类型溢出"); }
        }

        public void TestUnChecked()
        {
            try
            {
                int num = int.MaxValue;
                unchecked
                {
                    num++;
                    Console.WriteLine(num);
                }
            }
            catch (OverflowException) { Console.WriteLine("int类型溢出"); }
        }

        public void TestNoneChecked()
        {
            try
            {
                int num = int.MaxValue;
                num++;
                Console.WriteLine(num);
            }
            catch (OverflowException) { Console.WriteLine("int类型溢出"); }
        }
    }
}
