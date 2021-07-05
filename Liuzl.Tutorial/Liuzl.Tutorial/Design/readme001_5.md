## 设计模式 - 单例模式（Singleton Pattern）
> `Singleton` 模式要求一个类有且仅有一个实例，并且提供了一个全局的访问点。

### 实现1
```csharp
using System;

namespace DesignPattern.Singleton.Implement05
{
    /// <summary>
    /// 较推荐的单例模式，使用内部类持有Singleton的实例，实现了延迟初始化
    /// </summary>
    public sealed class Singleton
    {
        Singleton()
        { 
        }

        public static Singleton Instance
        {
            get
            {
                return Nested._instance;
            }
        }

        private class Nested
        {
            internal static readonly Singleton _instance = new Singleton();

            static Nested()
            { 
            }
        }
    }
}
```

### 补充说明
* 该示例是线程安全的；
* 初始化工作由 `Nested` 类的一个静态成员来完成，这样就实现了延迟初始化，并具有很多的优势，是值得推荐的一种实现方式；
* 个人推荐的最佳单例实现；
