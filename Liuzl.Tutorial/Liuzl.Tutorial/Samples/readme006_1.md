## 保留关键字 delegate
`delegate` 关键字用于声明委托。<br>
编译器在你使用 `delegate` 关键字时生成的代码会映射到调用 `System.Delegate` 和 `System.MulticastDelegate` 类的成员的方法调用。<br>
请注意，声明的语法可能看起来像是声明变量，但它实际上是声明类型。我们可以在类中、在命名空间中、甚至是在全局命名空间中定义委托类型。

```csharp
using System;

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
```

### 补充说明
委托的定义：
* 委托是一种引用类型，表示对具有特定参数列表和返回类型的方法的引用。 
* 在实例化委托时，你可以将其实例与任何具有兼容签名和返回类型的方法相关联。 你可以通过委托实例调用方法。
* 委托用于将方法作为参数传递给其他方法。 
* 事件处理程序就是通过委托调用的方法。

委托的概述：
* 委托类似于 C++ 函数指针，但委托完全面向对象，不像 C++ 指针会记住函数，委托会同时封装对象实例和方法。
* 委托允许将方法作为参数进行传递。
* 委托可用于定义回调方法。
* 委托可以链接在一起；例如，可以对一个事件调用多个方法。
* 方法不必与委托类型完全匹配。 有关详细信息，请参阅委托中的变体。
* 使用 Lambda 表达式可以更简练地编写内联代码块。 