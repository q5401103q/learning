## 保留关键字 in
>`in` 关键字会导致按引用传递参数，但确保未修改参数。它让形参成为实参的别名，这必须是变量。换而言之，对形参执行的任何操作都是对实参执行的。

### 示例1
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    class Demo014_5
    {
        public void Test()
        {
            string msg = "Hello";
            Method1(msg);
            Console.WriteLine(msg); //Hello
        }

        public void Method1(in string message)
        {
            //编译报错CS8331, in string是只读的
            //message = "world";
        }
    }
}
```

### 示例2
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    class Demo014_5
    {
        public void Method2()
        {
            //定义变量
            var list = new List<KeyValuePair<string, string>>();

            //在循环中使用in关键字
            foreach (var data in list) { }

            //在lambada表达式中使用in关键字
            var query = from data in list
                        where data.Key == "key"
                        select data.Value;
        }
    }
}
```

### 补充说明
* `in` 与 `ref` 关键字相似，在传递之前初始化变量。 
* `in` 不允许修改参数值，如示例。 
* 若要使用 `in` 参数，方法定义和调用方法均必须显式使用 `in` 关键字。
* `in`、`ref` 和 `out` 关键字不被视为用于重载决议的方法签名的一部分。 因此，如果唯一的不同是一个方法采用 `ref` 或 `in` 参数，而另一个方法采用 `out` 参数，则无法重载这两个方法；但是，如果一个方法采用 `ref`、`in` 或 `out` 参数，而另一个方法采用其他参数，则可以完成重载；
* 不能将`in`、`ref` 和 `out` 关键字用于异步方法和迭代器方法（后续介绍）
* 与 `ref` 类似，`in` 还可以搭配 `readonly` 使用
* `in` 关键字还作为 `foreach` 语句的一部分，或作为 `LINQ` 查询中 `join` 子句的一部分，与泛型类型参数一起使用来指定该类型参数为逆变。 

* 通过理解使用 `in` 参数的动机，可以理解使用按值方法和使用 `in` 参数方法的重载决策规则。 定义使用 `in` 参数的方法是一项潜在的性能优化。 某些 `struct` 类型参数可能很大，在紧凑的循环或关键代码路径中调用方法时，复制这些结构的成本就很高。 方法声明 `in` 参数以指定参数可能按引用安全传递，因为所调用的方法不修改该参数的状态。按引用传递这些参数可以避免（可能产生的）高昂的复制成本。