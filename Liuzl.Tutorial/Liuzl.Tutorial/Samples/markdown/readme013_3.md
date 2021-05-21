## 保留关键字 ref
>在方法的参数列表中使用 `ref` 关键字时，它指示参数按引用传递，而非按值传递。 `ref` 关键字让形参成为实参的别名，这必须是变量。 换而言之，对形参执行的任何操作都是对实参执行的。

### 示例
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    class Demo013_3
    {
        public void Test()
        {
            //msg必须要先初始化
            string msg = string.Empty;
            Method1(ref msg);
        }

        public void Method1(ref string message)
        {
            message = "Hello";
        }
    }
}
```

### 补充说明
* `ref` 要求在传递之前初始化变量。 
* 若要使用 `ref` 参数，方法定义和调用方法均必须显式使用 `ref` 关键字。
* `in`、`ref` 和 `out` 关键字不被视为用于重载决议的方法签名的一部分。 因此，如果唯一的不同是一个方法采用 `ref` 或 `in` 参数，而另一个方法采用 `out` 参数，则无法重载这两个方法；但是，如果一个方法采用 `ref`、`in` 或 `out` 参数，而另一个方法采用其他参数，则可以完成重载，同示例2；
* 不能将`in`、`ref` 和 `out` 关键字用于异步方法和迭代器方法（后续介绍）
* 不要混淆通过引用传递的概念与引用类型的概念。 这两种概念是不同的。 无论方法参数是值类型还是引用类型，均可由 `ref` 修改。 当通过引用传递时，不会对值类型装箱。