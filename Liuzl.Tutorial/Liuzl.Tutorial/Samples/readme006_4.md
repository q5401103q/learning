## 保留关键字 delegate
在C#中，还可以使用 `Func<in T, out TResult>` 和 `Action<in T>` 进行委托声明，看下面的例子：
### Func示例
```csharp 
using System;
//传统的声明委托方式
delegate string ConvertMethod(string inString);

namespace Liuzl.Tutorial.Samples
{
    class Demo006_4
    {
        private static string UppercaseString(string inputString)
        {
            return inputString.ToUpper();
        }

        public void TestFunc()
        {
            //传统的实例化委托
            ConvertMethod target = UppercaseString; 
            Console.WriteLine(target("hello"));
            //使用Func声明与实例化委托
            Func<string, string> func1 = UppercaseString;
            Console.WriteLine(func1("hello"));
            //使用Func匿名委托
            Func<string, string> func2 = delegate (string s) { return s.ToUpper(); };
            Console.WriteLine(func2("hello"));
            //使用Func与Lambda表达式匿名委托
            Func<string, string> func3 = s => s.ToUpper();
            Console.WriteLine(func3("hello"));
        }
    }
}
```
### Action示例
```csharp
using System;
//传统的声明委托方式
delegate void DisplayMessage(string message);

namespace Liuzl.Tutorial.Samples
{
    class Demo006_4
    {
        private static void ShowWindowsMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void TestAction()
        {
            //传统的实例化委托
            DisplayMessage target = ShowWindowsMessage;
            target("hello");
            //使用Action声明与实例化委托
            Action<string> act1 = ShowWindowsMessage;
            act1("hello");
            //使用Action匿名委托
            Action<string> act2 = delegate (string s) { Console.WriteLine(s); };
            act2("hello");
            //使用Action与Lambda表达式匿名委托
            Action<string> act3 = s => Console.WriteLine(s);
            act3("hello");
        }
    }
}
```

调用示例：
```csharp
//略
```

### 补充说明
* `Func` 与 `Action` 的区别是，`Action` 没有返回值；
* `Func` 与 `Action`最多有16个入参；
* `Func` 与 `Action`的入参 `T` 是逆变类型参数（后面会介绍协变与逆变）；
