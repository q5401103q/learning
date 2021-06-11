## 保留关键字 volatile
`volatile` 关键字指示一个字段可以由多个同时执行的线程修改。 出于性能原因，编译器，运行时系统甚至硬件都可能重新排列对存储器位置的读取和写入。 声明了 `volatile` 的字段不进行这些优化。 添加 `volatile` 修饰符可确保所有线程观察易失性写入操作（由任何其他线程执行）时的观察顺序与写入操作的执行顺序一致。 不确保从所有执行线程整体来看时所有易失性写入操作均按执行顺序排序。

`volatile` 关键字可应用于以下类型的字段：

* 引用类型
* 指针类型（在不安全的上下文中）。请注意，虽然指针本身可以是可变的，但是它指向的对象不能是可变的。换句话说，不能声明“指向可变对象的指针”
* 简单类型，如 `sbyte、byte、short、ushort、int、uint、char、float` 和 `bool`
* 具有以下基本类型之一的 `enum` 类型：`byte、sbyte、short、ushort、int` 或 `uint`
* 已知为引用类型的泛型类型参数
* `IntPtr` 和 `UIntPtr`

### 示例
```csharp
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    class Demo016
    {
        public static void Test()
        {
            var worker = new Worker();
            Console.WriteLine("主线程：启动工作线程...");
            var workerTask = Task.Run(worker.DoWork);
            // 等待 500 毫秒以确保工作线程已在执行
            Thread.Sleep(500);
            Console.WriteLine("主线程：请求终止工作线程...");
            worker.RequestStop();
            // 待待工作线程执行结束
            workerTask.Wait();
            Console.WriteLine("主线程：工作线程已终止");
        }
    }

    public class Worker
    {
        //给 _shouldStop 打上 volatile 标记，让cpu每次都到内存中取 _shouldStop 值
        private volatile bool _shouldStop;
        //由于while循环太频繁了，release做了代码优化，将 _shouldStop 的值直接放在了 ecx 寄存器中， 当B线程执行 _shouldStop=true 更新到内存的时候，并没有什么通知机制，导致A线程在不知情的情况下一直读自己的 ecx 寄存器的值0，这时候就脏读了，
        //private bool _shouldStop;
        public void DoWork()
        {
            bool work = false;
            // 注意：不定义为volatile，这里会被编译器优化
            while (!_shouldStop)
            {
                work = !work; // do sth.
            }
            Console.WriteLine("工作线程：正在终止...");
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
    }
}
```

### 补充说明
* 写入标记为 `volatile` `的字段时，volatile` 关键字会控制写入操作的执行顺序。 它不保证这些写入操作对其他线程立即可见
* `volatile` 关键字只能应用于 `class` 或 `struct` 的字段。 不能将局部变量声明为 `volatile`
* 其他类型（包括 `double` 和 `long` ）无法标记为 `volatile`，因为对这些类型的字段的读取和写入不能保证是原子的。 若要保护对这些类型字段的多线程访问，请使用 `Interlocked` 类成员或使用 `lock` 语句保护访问权限。
