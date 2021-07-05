## 设计模式 - 单例模式（Singleton Pattern）
> `Singleton` 模式要求一个类有且仅有一个实例，并且提供了一个全局的访问点。

### 实现1
```csharp
using System;

namespace DesignPattern.Singleton.Implement01
{
    /// <summary>
    /// 单例模式的最简单的实现
    /// 非线程安全的，多线程访问可能都会建造Singleton实例
    /// 例如，两个线程同时判断 _instance == null,且都得到true的结果
    /// </summary>
    public sealed class Singleton
    {
        private static Singleton _instance = null;

        Singleton()
        {
        }

        public static Singleton Instance
        {
            get 
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
```

### 补充说明
* 该示例不是线程安全的，例如，两个线程同时判断 `_instance == null`,且都得到 `true` 的结果，从而获得两个实例；
