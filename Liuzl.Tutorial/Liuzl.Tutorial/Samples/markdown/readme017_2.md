## SpinLock
### 命名空间
```csharp
System.Threading
``` 

### 定义
```csharp
public struct SpinLock
```

### 描述
>提供一个相互排斥锁基元，在该基元中，尝试获取锁的线程将在重复检查的循环中等待，直至该锁变为可用为止。

### 补充说明（了解即可）
* 所有成员 `SpinLock` 都是线程安全的，可同时从多个线程使用。
* `SpinLock` 是值类型。如果 `SpinLock` 必须传递实例，则它应按引用而不是按值传递。
* 别名为旋转锁，可用于叶级锁，有助于避免阻塞。
* 不要 `SpinLock` 在只读字段中存储实例。

### 示例
```csharp
// Demonstrates:
// Default SpinLock constructor (tracking thread owner)
// SpinLock.Enter(ref bool)
// SpinLock.Exit() throwing exception
// SpinLock.IsHeld
// SpinLock.IsHeldByCurrentThread
// SpinLock.IsThreadOwnerTrackingEnabled
static void SpinLockSample2()
{
    // Instantiate a SpinLock
    SpinLock sl = new SpinLock();

    // These MRESs help to sequence the two jobs below
    ManualResetEventSlim mre1 = new ManualResetEventSlim(false);
    ManualResetEventSlim mre2 = new ManualResetEventSlim(false);
    bool lockTaken = false;

    Task taskA = Task.Factory.StartNew(() =>
    {
        try
        {
            sl.Enter(ref lockTaken);
            Console.WriteLine("Task A: entered SpinLock");
            mre1.Set(); // Signal Task B to commence with its logic

            // Wait for Task B to complete its logic
            // (Normally, you would not want to perform such a potentially
            // heavyweight operation while holding a SpinLock, but we do it
            // here to more effectively show off SpinLock properties in
            // taskB.)
            mre2.Wait();
        }
        finally
        {
            if (lockTaken) sl.Exit();
        }
    });

    Task taskB = Task.Factory.StartNew(() =>
    {
        mre1.Wait(); // wait for Task A to signal me
        Console.WriteLine("Task B: sl.IsHeld = {0} (should be true)", sl.IsHeld);
        Console.WriteLine("Task B: sl.IsHeldByCurrentThread = {0} (should be false)", sl.IsHeldByCurrentThread);
        Console.WriteLine("Task B: sl.IsThreadOwnerTrackingEnabled = {0} (should be true)", sl.IsThreadOwnerTrackingEnabled);

        try
        {
            sl.Exit();
            Console.WriteLine("Task B: Released sl, should not have been able to!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Task B: sl.Exit resulted in exception, as expected: {0}", e.Message);
        }

        mre2.Set(); // Signal Task A to exit the SpinLock
    });

    // Wait for task completion and clean up
    Task.WaitAll(taskA, taskB);
    mre1.Dispose();
    mre2.Dispose();
}
```