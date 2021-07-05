## 设计模式 - 单例模式（Singleton Pattern）
> `Singleton` 模式要求一个类有且仅有一个实例，并且提供了一个全局的访问点。

### 实现2
```csharp
using System;

namespace DesignPattern.Singleton.Implement02
{
    /// <summary>
    /// 线程安全的Singleton
    /// 缺点是增加了额外开销，即locker，损失性能
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
                lock (_locker)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                    return _instance;
                }
            }
        }
    }
}

```

### 补充说明
* 该示例是线程安全的；
* 该示例每次获取实例都要加锁，增加了性能的开销；

