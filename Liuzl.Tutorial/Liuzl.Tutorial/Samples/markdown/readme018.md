## switch
>`switch` 是一个选择语句，它根据与匹配表达式匹配的模式，从候选列表中选择单个开关部分进行执行。

在 C# 6 及更低版本中，匹配表达式必须是返回以下类型值的表达式：
* 字符串，如 `string`
* 字符型，如 `char`
* 布尔型，如 `bool`
* 数值型，如 `int`，`long`
* 枚举型

从 C# 7.0 开始，匹配表达式可以是任何非 null 表达式。

### 示例1-普通匹配表达式
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    class Demo018
    {
        public void Method1()
        {
            Random rnd = new Random();
            int caseSwitch = rnd.Next(1, 4);

            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    break;
                case 2:
                case 3:
                    Console.WriteLine($"Case {caseSwitch}");
                    break;
                default:
                    Console.WriteLine($"An unexpected value ({caseSwitch})");
                    break;
            }
        }
    }
}
```

### 示例2-类型匹配表达式
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    class Demo018
    {
        public void Method2()
        {
            object item = new object();
            switch (item)
            {
                case 0:
                    break;
                case int val:
                    break;
                case IEnumerable<object> subList when subList.Any():
                    break;
                case IEnumerable<object> subList:
                    break;
                case null:
                    break;
                default:
                    throw new InvalidOperationException("unknown item type");
            }
        }
    }
}
```

### 示例3-复杂的用法示例
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    class Demo018
    {
        public void Method3(Shape sh)
        {
            switch (sh)
            {
                case Shape shape when shape == null:
                    Console.WriteLine($"An uninitialized shape (shape == null)");
                    break;
                case null:
                    Console.WriteLine($"An uninitialized shape");
                    break;
                case Shape shape when sh.Area == 0:
                    Console.WriteLine($"The shape: {sh.GetType().Name} with no dimensions");
                    break;
                case Shape shape when sh != null:
                    Console.WriteLine($"A {sh.GetType().Name} shape");
                    break;
                default:
                    Console.WriteLine($"The {nameof(sh)} variable does not represent a Shape.");
                    break;
            }
        }
    }

    public abstract class Shape
    {
        public abstract double Area { get; }
        public abstract double Circumference { get; }
    }
}
```

### 补充说明
* 从 `C# 7.0` 开始，因为 `case` 语句不需要互相排斥，因此可以添加 `when` 子句来指定必须满足的附加条件使 `case` 语句计算为 `true`。 `when` 子句可以是返回布尔值的任何表达式。
* `case` 语句显示的顺序很重要。
* 通常通过使用 `break`、`goto` 或 `return` 语句显式退出开关。