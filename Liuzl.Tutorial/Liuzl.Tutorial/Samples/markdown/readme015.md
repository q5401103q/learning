## 保留关键字 sealed
>应用于某个类时，`sealed` 修饰符可阻止其他类继承自该类。<br/>

>对替代基类中的虚方法或属性的方法或属性使用 sealed 修饰符。 这使你可以允许类派生自你的类并防止它们替代特定虚方法或属性。

### 示例1
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    /// <summary>
    /// 密封类
    /// </summary>
    sealed class ClassA { }

    /// <summary>
    /// 编译器报错CS0509:无法从密封类型 ClassA 派生
    /// </summary>
    //class ClassB : ClassA { }
}
```

### 示例2
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    class Demo015
    {
        protected virtual void Method1() 
        { 
            Console.WriteLine("Demo015.Method1"); 
        }
        protected virtual void Method2() 
        { 
            Console.WriteLine("Demo015.Method2"); 
        }
    }

    class Demo015_1 : Demo015
    {
        protected sealed override void Method1() 
        { 
            Console.WriteLine("Demo015_1.Method1"); 
        }
        protected override void Method2() 
        { 
            Console.WriteLine("Demo015_1.Method2"); 
        }
    }

    class Demo015_2 : Demo015_1
    {
        /// <summary>
        /// 编译器报错CS0239:Method1()是密封的，无法重写
        /// </summary>
        //protected override void Method1() 
        //{ 
        //    Console.WriteLine("Demo015_1.Method2"); 
        //}
        protected override void Method2() 
        { 
            Console.WriteLine("Demo015_2.Method2"); 
        }
    }
}
```

### 补充说明
* 将 `abstract` 修饰符与密封类结合使用是错误的，因为抽象类必须由提供抽象方法或属性的实现的类来继承。
* 应用于方法或属性时，`sealed` 修饰符必须始终与 `override` 结合使用。
* 因为结构是隐式密封的，所以无法继承它们。
