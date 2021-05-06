## 保留关键字 default
`default` 关键字有两种用法：
* 指定 `switch` 语句中的默认标签。
* 作为 `default` 默认运算符或文本生成类型的默认值。

```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    class Demo005<T> where T : class
    {
        public string prop1 => default;
        public int prop2 => default;
        public DateTime prop3 => default;
        public double? prop4 => default;
        public dynamic prop5 => default;

        public void Method1(string arg1 = default) { }

        public void Method2(byte arg1)
        {
            switch (arg1)
            {
                case 0x30:
                    break;
                default:
                    break;
            }
        }

        public T Function3(T arg)
        {
            T temp = default(T);
            return temp;
        }
    }
}
```

调用说明：
```csharp
Demo04<dynamic> demo = new Demo04<dynamic>();
Console.WriteLine(demo.prop1 == null);
Console.WriteLine(demo.prop2 == 0);
Console.WriteLine(demo.prop3);
Console.WriteLine(demo.prop3.ToString("yyyy-MM-dd HH:mm:ss"));
Console.WriteLine(demo.prop4 == null);
Console.WriteLine(demo.prop4.HasValue);
Console.WriteLine(demo.prop5 == null);
/**
 * 输出结果：
 * True
 * True
 * 0001/1/1 0:00:00
 * 0001-01-01 00:00:00
 * True
 * False
 * True
 */
```

### 补充说明
关于默认值的一些补充：
* 引用类型结果 ：null
* 数值类型结果 ：0
* 布尔类型结果 ：false
* 枚举类型结果 ：枚举的第一个值
* 结构体型结果 ： 值类型为默认值，引用类型为null
* 可空类型结果 ：HasValue属性为false，且Value未实例化