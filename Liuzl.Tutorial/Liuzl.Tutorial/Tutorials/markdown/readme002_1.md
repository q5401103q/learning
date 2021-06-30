## dynamic
>`dynamic` 类型表示变量的使用和对其成员的引用绕过编译时类型检查。 改为在运行时解析这些操作。

### 示例1
```csharp
using System;

namespace Liuzl.Tutorial.Tutorials
{
    class Demo002
    {
        public dynamic Name { get; }

        protected dynamic Vaule { get; private set; }

        private dynamic GetName()
        {
            return this.Name;
        }

        public Tuple<bool, dynamic> Method()
        {
            return Tuple.Create<bool, dynamic>(false, 1);
        }
    }
}
```

### 补充说明
`dynamic` 最大的特点是它的类型在运行时才确定，这也是它与往静态类型关键字的最大区别。如果你在你的代码操作中用到了`dynamic` 关键字去定义一个变量时，那么这个变量在编译的时候编译器不会对它进行类型检查，允许它到运行的时候再做解释。在大多数情况下，`dynamic` 类型与 `object` 类型的行为是一样的。但是，不会用编译器对包含 `dynamic` 类型表达式的操作进行解析或类型检查，只是将有关该变量编译到类型 `object` 的变量中以及有关它的操作信息打包在一起，在运行时再解释运行。

### dynamic 与 var 的比较
`var` 实际上是编译期抛给我们的语法糖，一旦被编译，编译期会自动匹配 `var` 变量的实际类型，并用实际类型来替换该变量的申明，这看上去就好像我们在编码的时候是用实际类型进行申明的。而 `dynamic` 被编译后，实际是一个 `object` 类型，只不过编译器会对 `dynamic` 类型进行特殊处理，让它在编译期间不进行任何的类型检查，而是将类型检查放到了运行期。