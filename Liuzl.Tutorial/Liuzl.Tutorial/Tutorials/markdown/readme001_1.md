## async/await
>使用 `async` 修饰符可将方法、`lambda` 表达式或匿名方法指定为异步。如果对方法或表达式使用此修饰符，则其称为异步方法。异步方法同步运行，直至到达其第一个 `await` 表达式，此时会将方法挂起，直到等待的任务完成。
```csharp
public async Task<int> ExampleMethodAsync() { }
```

### 示例1
```csharp
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Tutorials
{
    class Demo001
    {
        public static async Task Main()
        {
            Task<int> downloading = DownloadDocsMainPageAsync();
            Console.WriteLine($"{nameof(Main)}: Launched downloading.");

            int bytesLoaded = await downloading;
            Console.WriteLine($"{nameof(Main)}: Downloaded {bytesLoaded} bytes.");
        }

        private static async Task<int> DownloadDocsMainPageAsync()
        {
            Console.WriteLine($"{nameof(DownloadDocsMainPageAsync)}: About to start downloading.");

            var client = new HttpClient();
            byte[] content = await client.GetByteArrayAsync("https://docs.microsoft.com/en-us/");

            Console.WriteLine($"{nameof(DownloadDocsMainPageAsync)}: Finished downloading.");
            return content.Length;
        }
    }
}
// 输出的结果类似于下面的形式:
// DownloadDocsMainPageAsync: About to start downloading.
// Main: Launched downloading.
// DownloadDocsMainPageAsync: Finished downloading.
// Main: Downloaded 27700 bytes.
```

### 补充说明
* `async` 和 `await` 关键字在 `C# 5` 和更高版本中都可用。
* `await` 运算符的操作数通常是以下其中一个 `.NET` 类型：`Task`、`Task<TResult>`、`ValueTask` 或 `ValueTask<TResult>`。 但是，任何可等待表达式都可以是 `await` 运算符的操作数。如果 `t` 的类型为 `Task` 或 `ValueTask`，则 `await t` 的类型为 `void`。 
* 从 `C# 7.1` 开始，作为应用程序入口点的 `Main` 方法可以返回 `Task` 或 `Task<int>`，使其成为异步的，以便在其主体中使用 `await` 运算符。 
* 只能在通过 `async` 关键字修改的方法、`lambda` 表达式或匿名方法中使用 `await` 运算符。 在异步方法中，不能在同步函数的主体、`lock` 语句块内以及不安全的上下文中使用 `await` 运算符。
* 可使用 `await foreach` 语句来使用异步数据流。
* 可使用 `await using` 语句来处理异步可释放对象，即其类型可实现 `IAsyncDisposable` 接口的对象。