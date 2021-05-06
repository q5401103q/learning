using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    class Demo005<T> where T : class
    {
        public string prop1 => default;
        public int prop2 => default;
        public DateTime prop3 => default;
        public double? prop4 => default;
        public dynamic prop5 => default;

        public void Method1(string arg1 = default) { }

        public void Method2(byte arg1)
        {
            switch (arg1)
            {
                case 0x30:
                    break;
                default:
                    break;
            }
        }

        public T Function3(T arg)
        {
            T temp = default(T);
            return temp;
        }
    }
}
