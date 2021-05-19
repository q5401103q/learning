## 保留关键字 extern
`extern` 修饰符用于声明在外部实现的方法。 `extern` 修饰符的常见用法是在使用 `Interop` 服务调入非托管代码时与 `DllImport` 特性一起使用。
在这种情况下，还必须将方法声明为 `static`，如下面的示例所示：
```csharp
[DllImport("avifil32.dll")]
private static extern void AVIFileInit();
```

### 示例1
```csharp
using System;
using System.Runtime.InteropServices;

namespace Liuzl.Tutorial.Samples
{
    class Demo009
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);

        public int Test()
        {
            string myString = "hello world";
            return MessageBox((IntPtr)0, myString, "My Message Box", 0);
        }
    }
}
```

### 示例2
1、假设有以下c代码;
```c
// cmdll.c
// Compile with: -LD
int __declspec(dllexport) SampleMethod(int i)
{
  return i*10;
}
```
2、打开 Visual Studio x64（或 x32）本机工具命令提示符窗口，并键入下面的命令来编译 `cmdll.c` 文件;
```
cl -LD cmdll.c
```
3、在同一目录下，创建c#文件并命名为 `cm.cs`;
```csharp
// cm.cs
using System;
using System.Runtime.InteropServices;
public class MainClass
{
    [DllImport("Cmdll.dll")]
    public static extern int SampleMethod(int x);

    static void Main()
    {
        Console.WriteLine("SampleMethod() returns {0}.", SampleMethod(5));
    }
}
```
4、打开 Visual Studio x64（或 x32）本机工具命令提示符窗口，并键入下面的命令来编译 `cm.cs` 文件;
```
csc cm.cs                   //针对 x64 命令提示符
csc -platform:x86 cm.cs     //针对 x32 命令提示符
```
5、运行cm.exe，结果如下；
```js
SampleMethod() returns 50.
```

### 补充说明
* `extern` 不能和 `abstract` 关键字一起修饰同一成员，使用 `extern` 修饰符意味着方法是在 `C#` 代码的外部实现的，而使用 `abstract` 修饰符意味着类中未提供方法实现。
* `extern` 还可以为某个程序集的多个版本声明别名，见下面的例子：
```csharp
/*
 * 意味着命名空间与类名都完全一致,只有版本号不一致，缺都需要调用时
 */

//声明两个别名
extern alias GridV1;  
extern alias GridV2;  

//使用
using Class1V1 = GridV1::Namespace.Class1;
using Class1V2 = GridV2::Namespace.Class1;
```