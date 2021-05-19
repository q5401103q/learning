## 保留关键字 implicit
`implicit` 关键字用于声明隐式的用户定义类型转换运算符。如果可以确保转换过程不会造成数据丢失，则可使用该关键字在用户定义类型和其他类型之间进行隐式转换。

### 示例1
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    struct Digit
    {
        byte value;
        public Digit(byte value)
        {
            if (value > 9)
            {
                throw new ArgumentException();
            }
            this.value = value;
        }

        public static explicit operator Digit(byte b)
        {
            Digit d = new Digit(b);
            return d;
        }

        public static implicit operator byte(Digit d)
        {
            return d.value;
        }
    }
}
```

### 调用示例1
```csharp
Digit d = new Digit(3);
byte b = d;
```

### 补充说明
* `explicit` 需要显式转换，`implicit`可以隐式转换；
* 隐式转换运算符更容易使用，但是如果您希望用户能够意识到正在进行转换，则显式运算符很有用；