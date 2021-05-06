## 保留关键字 delegate
在 C# 中，可以如下面的示例所示实例化委托。
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    class Demo006_2
    {
        public void Method1()
        {
            //创建委托实例, C# 1.0
            MyDelegate1 md1 = new MyDelegate1(MyDelegate1Handler);

            //创建委托实例，简化了方法一, C#2.0
            MyDelegate2<string> md2 = MyDelegate2Handler;

            //匿名方法实例化委托, C#2.0
            MyDelegate1 md3 = delegate ()
            {
                return Tuple.Create(false, string.Empty);
            };

            //lambda表达式实例化委托, C#3.0
            MyDelegate2<string> md4 = (source, target) =>
            {
                return 0;
            };
        }

        public Tuple<bool, string> MyDelegate1Handler()
        {
            return Tuple.Create(false, string.Empty);
        }

        public int MyDelegate2Handler(string source, string target)
        {
            return 0;
        }
    }
}
```
调用示例：
```csharp
var result1 = md1();
var result2 = md2("a", "b");
var result3 = md3();
var result4 = md4("c", "d");
```

### 补充说明
* 还可以通过 `Invoke()` / `BeginInvoke()` 调用委托，后面会详细解释；