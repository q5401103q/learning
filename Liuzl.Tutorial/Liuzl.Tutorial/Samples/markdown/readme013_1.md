## 保留关键字 out
>`out` 关键字通过引用传递参数。它让形参成为实参的别名，这必须是变量。换而言之，对形参执行的任何操作都是对实参执行的。 

### 示例1
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    class Demo013
    {
        public void Test()
        {
            //C# 6 及更早版本
            string msg;
            Method1(out msg);

            //C# 7.0 及以后的版本
            Method1(out var msg1);
        }

        public void Method1(out string message)
        {
            //do something
            message = "Hello";
        }
    }
}
```

### 示例2
```csharp
/// <summary>
/// 编译器报错CS0663
/// </summary>
class Demo013_Sample1
{
    public void SampleMethod(out int i) { i = 1; }
    //不能定义仅在参数修饰符"ref"和"out"上存在区别的重载
    public void SampleMethod(ref int i) { i = 1; } 
    //不能定义仅在参数修饰符"in"和"out"上存在区别的重载
    public void SampleMethod(in int i) {}
}

/// <summary>
/// 编译通过
/// </summary>
class Demo013_Sample2
{
    public void SampleMethod(int i) { i = 1; }
    public void SampleMethod(out int i) { i = 1; }
}
```

### 补充说明
* `out` 与 `ref` 关键字相似，`ref` 要求在传递之前初始化变量，`out` 不必进行初始化。 
* `out` 与 `in` 关键字相似，只不过 `in` 不允许通过调用方法来修改参数值。 
* 若要使用 `out` 参数，方法定义和调用方法均必须显式使用 `out` 关键字。
* `in`、`ref` 和 `out` 关键字不被视为用于重载决议的方法签名的一部分。 因此，如果唯一的不同是一个方法采用 `ref` 或 `in` 参数，而另一个方法采用 `out` 参数，则无法重载这两个方法；但是，如果一个方法采用 `ref`、`in` 或 `out` 参数，而另一个方法采用其他参数，则可以完成重载，同示例2；
* 不能将`in`、`ref` 和 `out` 关键字用于异步方法和迭代器方法（后续介绍）