## 保留关键字 base
`base` 关键字用于从派生类中访问基类的成员：
* 调用基类上已被其他方法重写的方法；
* 指定创建派生类实例时应调用的基类构造函数；

仅允许基类访问在构造函数、实例方法或实例属性访问器中进行。<br>
从静态方法中使用 `base` 关键字是错误的。

``` csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    public class Car
    {
        public string Color { get; set; }
        public Car() 
        {
            Console.WriteLine("car constructor non-param");
        }
        public Car(string color)
        {
            Color = color;
            Console.WriteLine("car constructor with-param");
        }
        public string GetColor()
        {
            return Color;
        }
    }

    public class SUV : Car
    {
        public string Brand { get; set; }
        public SUV() : base()
        {
            Console.WriteLine("SUV constructor non-param");
        }
        public SUV(string color) : base(color)
        {
            Console.WriteLine("SUV constructor with-param");
        }
        public SUV(string color, string brand) : this()
        {
            Color = color;
            Brand = brand;
            Console.WriteLine("SUV constructor with-two-param");
        }
        public string GetSUVColor()
        {
            return base.GetColor().ToUpper();
        }
    }
}
```

调用示例：
``` csharp
SUV suv1 = new SUV();
SUV suv2 = new SUV("blue");
SUV suv3 = new SUV("red", "bmw");
/**
 * 输出结果
 * car constructor non-param
 * SUV constructor non-param
 * car constructor with-param
 * SUV constructor with-param
 * car constructor non-param
 * SUV constructor non-param
 * SUV constructor with-two-param
 */
```

### 结论
* 尽量少用或不用 `base`，`this` 关键字。除了避开子类的名称冲突和在一个构造函数中调用其他的构造函数之外，`base` 和 `this` 的使用容易引起不必要的结果；
* 在静态成员中使用 `base` 和 `this` 都是不允许的。原因是，`base` 和 `this` 访问的都是类的实例，也就是对象，而静态成员只能由类来访问，不能由对象来访问；
* `base` 是为了实现多态而设计的；
* 使用 `this` 或 `base` 关键字只能指定一个构造函数，也就是说不可同时将 `this` 和 `base` 作用在一个构造函数上；
* 简单的来说，`base` 用于在派生类中访问重写的基类成员；而 `this` 用于访问本类的成员，当然也包括继承而来公有和保护成员；

### 补充说明
构造函数的调用顺序是：先调用父类的构造函数，再调用派生类的构造函数。