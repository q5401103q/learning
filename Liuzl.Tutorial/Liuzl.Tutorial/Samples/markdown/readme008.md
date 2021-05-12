## 保留关键字 enum
>枚举类型是由基础整型数值类型的一组命名常量定义的值类型。 若要定义枚举类型，请使用 `enum` 关键字并指定枚举成员的名称。

### 定义示例
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    public class Demo008
    {
        public enum Season
        {
            Spring, //0
            Summer, //1
            Autumn, //2
            Winter  //3
        }

        [Flags]
        protected internal enum Days
        {
            None        = 0b_0000_0000,  // 0
            Monday      = 0b_0000_0001,  // 1
            Tuesday     = 0b_0000_0010,  // 2
            Wednesday   = 0b_0000_0100,  // 4
            Thursday    = 0b_0000_1000,  // 8
            Friday      = 0b_0001_0000,  // 16
            Saturday    = 0b_0010_0000,  // 32
            Sunday      = 0b_0100_0000,  // 64
            Weekend     = Saturday | Sunday
        }

        public enum ErrorCode : ushort
        {
            BadRequest = 400,
            NotFound = 404,
            InternalServerError = 500
        }
    }
}
```

### 调用示例
```csharp
Demo008.Season season1 = 0;
Demo008.Season season2 = Demo008.Season.Winter;

Console.WriteLine($"value of {season1} is {(int)season1}");
Console.WriteLine($"value of {season2} is {(int)season2}");

Console.WriteLine("0 is defined in ErrorCode? {0}", Enum.IsDefined(typeof(Demo008.ErrorCode), "0"));
Console.WriteLine("NotFound is defined in ErrorCode? {0}", Enum.IsDefined(typeof(Demo008.ErrorCode), "NotFound"));

/*
 * 输出结果：
 * value of Spring is 0
 * value of Winter is 3
 * 0 is defined in ErrorCode? False
 * 404 is defined in ErrorCode? True
*/
```

### 补充说明
* 对任何枚举都存在分别与 `System.Enum` 的拆箱和装箱转换;
* 使用 `Enum.IsDefined` 方法来确定枚举类型是否包含具有特定关联名称的枚举成员；
* 关于枚举约束会在后续部分介绍；
* 若要指示枚举类型声明位字段，请对其应用 `Flags` 属性，通俗的可以理解为在枚举成员按位进行二进制计算时，发挥作用;