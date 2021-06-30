## record
从 `C# 9` 开始，可以使用 `record` 关键字定义一个引用类型，用来提供用于封装数据的内置功能。 通过使用位置参数或标准属性语法，可以创建具有不可变属性的记录类型。

### 示例
```csharp
using System;

namespace Liuzl.Tutorial.Tutorials
{
    class Demo003
    {
        public void Test()
        {
            var p1 = new RecordPerson1()
            {
                Name = "Tom",
                Age = 12,
            };
            Console.WriteLine(p1);

            var p2 = p1 with { Age = 10 };
            Console.WriteLine(p2);

            var p3 = new RecordPerson1() { Name = "Tom", Age = 12 };
            Console.WriteLine(p3);
            Console.WriteLine($"p1 Equals p3 =: {p1 == p3}");

            RecordPerson2 p4 = new("Tom", 12);
            Console.WriteLine(p4);
        }
    }

    record RecordPerson1
    {
        public string Name { get; init; }
        public int Age { get; init; }
    }

    record RecordPerson2(string Name, int Age);
}

// 输出结果：
// RecordPerson1 { Name = Tom, Age = 12 }
// RecordPerson1 { Name = Tom, Age = 10 }
// RecordPerson1 { Name = Tom, Age = 12 }
// p1 Equals p3 =: True
// RecordPerson2 { Name = Tom, Age = 12 }
```

### 补充说明
* `record` 实现了基于值的相等性比较，并且实现了原型模式，可以比较方便的创建一个新的值完全相等的对象，这对于有一些业务场景来说是非常适合使用 `record` 来代替原来的实现的。
* `init` 只在对象构造阶段进行初始化时可以用来赋值，算是 `set` 访问器的变体，`set` 访问器的位置使用 `init` 来替换。`init` 有着如下限制：
1. init访问器只能用在实例属性或索引器中，静态属性或索引器中不可用。
2. 属性或索引器不能同时包含init和set两个访问器
3. 如果基类的属性有init，那么属性或索引器的所有相关重写，都必须有init。接口也一样。