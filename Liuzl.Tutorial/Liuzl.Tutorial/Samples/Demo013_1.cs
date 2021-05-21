using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    class Demo013_1
    {
        public void Test()
        {
            //C# 6 及更早版本
            string msg;
            Method1(out msg);

            //C# 7.0 及以后的版本
            Method1(out var msg1);
        }

        public void Method1(out string message)
        {
            //do something
            message = "Hello";
        }
    }

    /// <summary>
    /// 编译器报错CS0663
    /// </summary>
    class Demo013_Sample1
    {
        public void SampleMethod(out int i) { i = 1; }
        //public void SampleMethod(ref int i) { i = 1; }
        //public void SampleMethod(in int i) {}
    }

    /// <summary>
    /// 编译通过
    /// </summary>
    class Demo013_Sample2
    {
        public void SampleMethod(int i) { i = 1; }
        public void SampleMethod(out int i) { i = 1; }
    }
}
