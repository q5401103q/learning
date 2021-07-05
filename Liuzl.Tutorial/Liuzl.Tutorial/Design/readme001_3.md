## 设计模式 - 单例模式（Singleton Pattern）
> `Singleton` 模式要求一个类有且仅有一个实例，并且提供了一个全局的访问点。

### 实现1
```csharp
using System;

namespace DesignPattern.Singleton.Implement03
{
    /// <summary>
    /// 线程安全的单例模式
    /// 相对于Implements02的单例模式，改进之处：
    /// 在于线程不是每次都加锁，只有判断对象实例没有被建造时它才加锁
    /// </summary>
    public sealed class Singleton
    {
        private static Singleton _instance = null;
        private static readonly object _locker = new object();

        Singleton()
        { 
        }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
```

### 补充说明
* 该示例是线程安全的；
* 该示例中线程不是每次都加锁，只有判断对象实例没有被建造时，它才加锁，降低了性能的开销；
* 该示例是常见的二次加锁的实现方式，用处非常广泛；
