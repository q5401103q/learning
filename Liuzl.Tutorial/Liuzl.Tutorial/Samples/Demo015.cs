using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    class Demo015
    {
        protected virtual void Method1() { Console.WriteLine("Demo015.Method1"); }
        protected virtual void Method2() { Console.WriteLine("Demo015.Method2"); }
    }

    class Demo015_1 : Demo015
    {
        protected sealed override void Method1() { Console.WriteLine("Demo015_1.Method1"); }
        protected override void Method2() { Console.WriteLine("Demo015_1.Method2"); }
    }

    class Demo015_2 : Demo015_1
    {
        /// <summary>
        /// 编译器报错CS0239:Method1()是密封的，无法重写
        /// </summary>
        //protected override void Method1() { Console.WriteLine("Demo015_1.Method2"); }
        protected override void Method2() { Console.WriteLine("Demo015_2.Method2"); }
    }

    /// <summary>
    /// 密封类
    /// </summary>
    sealed class ClassA { }
    /// <summary>
    /// 编译器报错CS0509:无法从密封类型 ClassA 派生
    /// </summary>
    //class ClassB : ClassA { }
}
