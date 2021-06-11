## Interlocked
### 命名空间
```csharp
System.Threading
``` 

### 定义
```csharp
public static class Interlocked
```

### 描述
>为多个线程共享的变量提供原子操作。

### 补充说明（了解即可）
* 此类型是线程安全的。
* 以递增举例，在大多数计算机上，递增变量不是原子操作，需要执行以下步骤：
```
1、将实例变量中的值加载到寄存器中
2、递增
3、将值存储在实例变量中
```
* 如果递增的线程被抢占，结果可能出现脏读，脏写。
* 因此使用 `Interlocked` 可以保证操作的原子性。

### 示例
```csharp
using System;
using System.Threading;

namespace InterlockedExchange_Example
{
    class MyInterlockedExchangeExampleClass
    {
        //0 for false, 1 for true.
        private static int usingResource = 0;
        private const int numThreadIterations = 5;
        private const int numThreads = 10;
        static void Main()
        {
            Thread myThread;
            Random rnd = new Random();
            for(int i = 0; i < numThreads; i++)
            {
                myThread = new Thread(new ThreadStart(MyThreadProc));
                myThread.Name = String.Format("Thread{0}", i + 1);
            
                //Wait a random amount of time before starting next thread.
                Thread.Sleep(rnd.Next(0, 1000));
                myThread.Start();
            }
        }

        private static void MyThreadProc()
        {
            for(int i = 0; i < numThreadIterations; i++)
            {
                UseResource();   
                //Wait 1 second before next attempt.
                Thread.Sleep(1000);
            }
        }

        //A simple method that denies reentrancy.
        static bool UseResource()
        {
            //0 indicates that the method is not in use.
            if(0 == Interlocked.Exchange(ref usingResource, 1))
            {
                Console.WriteLine("{0} acquired the lock", Thread.CurrentThread.Name);
            
                //Code to access a resource that is not thread safe would go here.
            
                //Simulate some work
                Thread.Sleep(500);

                Console.WriteLine("{0} exiting lock", Thread.CurrentThread.Name);
            
                //Release the lock
                Interlocked.Exchange(ref usingResource, 0);
                return true;
            }
            else
            {
                Console.WriteLine("   {0} was denied the lock", Thread.CurrentThread.Name);
                return false;
            }
        }
    }
}  
```