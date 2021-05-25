using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    class Demo013_5
    {
        public void Test()
        {
            string msg = "Hello";
            Method1(msg);
            Console.WriteLine(msg); //Hello
        }

        public void Method1(in string message)
        {
            //编译报错CS8331, in string是只读的
            //message = "world";
        }

        public void Method2()
        {
            //定义变量
            var list = new List<KeyValuePair<string, string>>();

            //在循环中使用in关键字
            foreach (var data in list) { }

            //在lambada表达式中使用in关键字
            var query = from data in list
                        where data.Key == "key"
                        select data.Value;
        }
    }
}
