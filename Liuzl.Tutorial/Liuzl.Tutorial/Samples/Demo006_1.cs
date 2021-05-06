using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 定义在全局命名空间的委托
/// </summary>
/// <returns></returns>
public delegate Tuple<bool, string> MyDelegate1();

namespace Liuzl.Tutorial.Samples
{
    /// <summary>
    /// 定义在命名空间中的委托
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    internal delegate int MyDelegate2<in T>(T source, T target);

    class Demo006_1
    {
        /// <summary>
        /// 定义在类中的委托
        /// </summary>
        /// <param name="arg"></param>
        protected delegate void MyDelegate3(ref string arg);
    }
}
