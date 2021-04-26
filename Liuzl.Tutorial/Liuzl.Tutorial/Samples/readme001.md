## 保留关键字 abstract
`abstract` 修饰符可用于类、方法、属性、索引和事件。 <br>
在类声明中使用 `abstract` 修饰符来指示某个类仅用作其他类的基类，而不用于自行进行实例化。 <br>
标记为抽象的成员必须由派生自抽象类的非抽象类来实现。<br>

下面是一段示例代码

``` csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    public abstract class Animal
    {
        public abstract void Raw();
    }

    public abstract class Mammal : Animal
    {
        public string GetName()
        {
            return this.GetType().Name;
        }
    }

    public class Cat : Mammal
    {
        public override void Raw()
        {
            Console.WriteLine("miaomiao");
        }
    }

    public class Dog : Mammal
    {
        public override void Raw()
        {
            Console.WriteLine("wangwang");
        }
    }
}
```
### 常见的问题解答 
1、抽象类和接口的区别？<br>
* 抽象类是特殊的类，不能被实例化，除此之外其他特性与普通类相同。抽象方法只能定义在抽象类中，并且不能有实现，派生类必须重写抽象方法。抽象类可以继承自抽象类，此时可以重写基类抽象方法，也可以不重写，由派生类重写。抽象类不能被密封。<br>
* 接口是引用类型，不能被实例化，包含的方法声明不能有实现，所有实现接口的类都必须实现接口定义的方法。<br>
> 抽象类定义了你是什么，而接口规定了你能做什么。

2、使用的原则？<br>
* 如果预计要创建组件的多个版本，则创建抽象类。抽象类提供简单的方法来控制组件版本。
* 如果创建的功能将在大范围的全异对象间使用，则使用接口。如果要设计小而简练的功能块，则使用接口。
* 如果要设计大的功能单元，则使用抽象类.如果要在组件的所有实现间提供通用的已实现功能，则使用抽象类。  
* 抽象类主要用于关系密切的对象；而接口适合为不相关的类提供通用功能。

3、抽象方法和虚方法的区别？<br>
* 虚方法使用 `virtual` 修饰，可定义在抽象类或普通类中，必须有实现，子类可以重写虚方法，也可以不重写；<br>
* 抽象方法使用 `abstract` 修饰，必须定义在抽象类中，不能有实现，子类必须重写抽象方法；<br>