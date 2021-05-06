using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    class Demo006_2
    {
        public async void Method1()
        {
            //创建委托实例，方法一
            MyDelegate1 md1 = new MyDelegate1(MyDelegate1Handler);

            //创建委托实例，简化了方法一
            MyDelegate2<string> md2 = MyDelegate2Handler;

            //匿名方法实例化委托
            MyDelegate1 md3 = delegate ()
            {
                return Tuple.Create(false, string.Empty);
            };

            //lambda表达式实例化委托
            MyDelegate2<string> md4 = (source, target) =>
            {
                return 0;
            };
        }

        public Tuple<bool, string> MyDelegate1Handler()
        {
            return Tuple.Create(false, string.Empty);
        }

        public int MyDelegate2Handler(string source, string target)
        {
            return 0;
        }
    }
}
