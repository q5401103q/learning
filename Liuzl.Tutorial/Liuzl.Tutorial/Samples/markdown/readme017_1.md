## 保留关键字 lock
`lock` 语句获取给定对象的互斥 `lock`，执行语句块，然后释放 `lock`。 持有 `lock` 时，持有 `lock` 的线程可以再次获取并释放 `lock`。 阻止任何其他线程获取 `lock` 并等待释放 `lock`。

### 示例
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    class Demo017
    {
        private readonly object balanceLock = new object();
        private decimal balance;

        public Demo017(decimal initialBalance) => balance = initialBalance;

        public decimal Debit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The debit amount cannot be negative.");
            }

            decimal appliedAmount = 0;
            lock (balanceLock)
            {
                if (balance >= amount)
                {
                    balance -= amount;
                    appliedAmount = amount;
                }
            }
            return appliedAmount;
        }
    }
}
```

### 补充说明
* `lock` 中的表达式，是引用类型，如示例中的 `balanceLock`
* 多线程中 `lock` 用的非常多
* 注意区别 `Java` 中的`synchronized`，区别是 `synchronized` 用在一段代码或方法上