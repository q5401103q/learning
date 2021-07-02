## yield
如果你在语句中使用 `yield` 上下文关键字，则意味着它在其中出现的方法、运算符或 `get` 访问器是迭代器。 通过使用 `yield` 定义迭代器，可在实现自定义集合类型的 `IEnumerator<T>` 和 `IEnumerable` 模式时无需其他显式类。

### 示例1
```csharp
using System;
using System.Collections.Generic;

namespace Liuzl.Tutorial.Tutorials
{
    class Demo005
    {
        public void Test()
        {
            foreach (var num in Method1())
            {
                Console.WriteLine(num); //1 2 3
            }

            foreach (var num in Method2())
            {
                Console.WriteLine(num);//1 2
            }
        }

        public static IEnumerable<int> Method1()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        public static IEnumerable<int> Method2()
        {
            yield return 1;
            yield return 2;
            yield break;
            yield return 3;
        }
    }
}
```

### 补充说明
* 使用 `yield return` 语句可一次返回一个元素。
* 可通过使用 `foreach` 语句或 `LINQ` 查询来使用从迭代器方法返回的序列。 `foreach` 循环的每次迭代都会调用迭代器方法。 迭代器方法运行到 `yield return` 语句时，会返回一个 `expression`，并保留当前在代码中的位置。 下次调用迭代器函数时，将从该位置重新开始执行。
* 可以使用 `yield break` 语句来终止迭代。
* 我们用 `while` 循环代替 `foreach` 循环，发现我们虽然没有实现 `GetEnumerator()`，也没有实现对应的 `IEnumerator` 的`MoveNext()`，和 `Current` 属性，但是我们仍然能正常使用这些函数。原因在后面进行分析。