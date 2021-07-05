## 设计模式 - 单例模式（Singleton Pattern）
> `Singleton` 模式要求一个类有且仅有一个实例，并且提供了一个全局的访问点。

### 实现1
```csharp
using System;

namespace DesignPattern.Singleton.Implement04
{
    /// <summary>
    /// 线程安全
    /// 公共语言运行库负责处理变量初始化
    /// 缺点是无法控制实例化
    /// </summary>
    public sealed class Singleton
    {
        private static readonly Singleton _instance = new Singleton();

        static Singleton()
        { 
        }

        Singleton()
        { 
        }

        public static Singleton Instance
        {
            get { return _instance; }
        }
    }
}
```

### 补充说明
* 该示例是线程安全的；
* 在此实现中，将在第一次引用类的任何成员时创建实例。公共语言运行库负责处理变量初始化。
* 该类标记为 `sealed` 以阻止发生派生，而派生可能会增加实例。
* 变量标记为 `readonly`，这意味着只能在静态初始化期间（此处显示的示例）或在类构造函数中分配变量。
* 由于 `Singleton` 实例被私有静态成员变量引用，因此在类首次被对 `Instance` 属性的调用所引用之前，不会发生实例化。
* 这种方法唯一的潜在缺点是，您对实例化机制的控制权较少。在 `Design Patterns` 形式中，您能够在实例化之前使用非默认的构造函数或执行其他任务。由于在此解决方案中由 `.NET Framework` 负责执行初始化，因此您没有这些选项。在大多数情况下，静态初始化是在 `.NET` 中实现 `Singleton` 的首选方法。
