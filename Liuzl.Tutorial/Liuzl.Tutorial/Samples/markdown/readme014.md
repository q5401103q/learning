## 保留关键字 virtual
>`virtual` 关键字用于修改方法、属性、索引器或事件声明，并使它们可以在派生类中被重写。

### 示例
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    class Demo014
    {
        public void Test()
        {
            Square squre = new Square();
            squre.Name = "Rectangle";
            squre.Width = 10;
            squre.Height = 20;
            Console.WriteLine($"{squre.Name}'s area is {squre.GetArea()}");
        }
    }

    class Rectangle
    {
        public virtual string Name { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public virtual double GetArea()
        {
            return Width * Height;
        }
    }

    class Square : Rectangle
    {
        public override string Name { get => base.Name; set => base.Name = value; }

        public override double GetArea()
        {
            return Width * Width;
        }
    }
}
```

### 补充说明
* 虚拟成员的实现可由派生类中的替代成员更改。
* 调用虚拟方法时，将为替代的成员检查该对象的运行时类型。将调用大部分派生类中的该替代成员，如果没有派生类替代该成员，则它可能是原始成员。通俗的理解是，先查找派生类中的重写，如果派生类没有重写，调用基类的虚方法实现。
* `virtual` 修饰符不能与 `static`、`abstract private` 或 `override` 修饰符一起使用。
* 在静态属性上使用 `virtual` 修饰符是错误的。
* 通过包括使用 `override` 修饰符的属性声明，可在派生类中替代虚拟继承属性。
