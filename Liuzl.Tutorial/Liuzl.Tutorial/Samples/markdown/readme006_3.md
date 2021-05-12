## 保留关键字 delegate
下面的代码展示了单一委托和多播委托的示例：

```csharp
using System;
using System.IO;

namespace Liuzl.Tutorial.Samples
{
    class Demo006_3
    {
        public static void Method1()
        {
            //单一委托
            Logger.WriteMessage = LoggingMethods.LogToConsole;

            //多播委托的示例
            Logger.WriteMessage += LoggingMethods.LogToConsole;
            Logger.WriteMessage += LoggingMethods.LogToFile;

            //删除一个委托
            Logger.WriteMessage -= LoggingMethods.LogToFile;
        }
    }

    public static class Logger
    {
        public static Action<string> WriteMessage;

        public static void LogMessage(string msg)
        {
            WriteMessage(msg);
        }
    }

    public static class LoggingMethods
    {
        public static void LogToConsole(string message)
        {
            Console.Error.WriteLine(message);
        }

        public static void LogToFile(string message)
        {
            using (var writer = new StreamWriter("your-file-path"))
            {
                writer.WriteLine(message);
                writer.Flush();
            }
        }
    }
}

```
调用示例：
```csharp
Logger.WriteMessage("Hello");
Logger.WriteMessage("world");
/**
 * 输出结果：
 * Hello
 * Hello
 * world
 * world
 */
```

### 补充说明
* 多播委托通过 `+=` 或者 `-=` 操作符进行绑定；
* 注意绑定的顺序与执行的顺序不是对应的，即执行顺序不确定；
* 删除委托时，不会抛出异常；
* 常见于winform中的 `event` 处理；