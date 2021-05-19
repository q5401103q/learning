## 保留关键字 explicit
`explicit` 关键字用于声明必须使用强制转换来调用的用户定义的类型转换运算符。转换运算符将源类型转换为目标类型。 源类型提供转换运算符。 与隐式转换不同，必须通过强制转换的方式来调用显式转换运算符。 如果转换操作可能导致异常或丢失信息，则应将其标记为 `explicit`。 这可以防止编译器无提示地调用可能产生无法预见后果的转换操作。

### 示例1
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    class Celsius
    {
        public Celsius(float temp)
        {
            degrees = temp;
        }
        public static explicit operator Fahrenheit(Celsius c)
        {
            return new Fahrenheit((9.0f / 5.0f) * c.degrees + 32);
        }
        public float Degrees
        {
            get { return degrees; }
        }
        private float degrees;
    }
    class Fahrenheit
    {
        public Fahrenheit(float temp)
        {
            degrees = temp;
        }
        public static explicit operator Celsius(Fahrenheit fahr)
        {
            return new Celsius((5.0f / 9.0f) * (fahr.degrees - 32));
        }
        public float Degrees
        {
            get { return degrees; }
        }
        private float degrees;
    }
}
```
### 调用示例1
```csharp
Fahrenheit fahr1 = new Fahrenheit(100.0f);
Console.Write("{0} Fahrenheit", fahr1.Degrees);
Celsius c = (Celsius)fahr1;

Console.Write(" = {0} Celsius", c.Degrees);
Fahrenheit fahr2 = (Fahrenheit)c;
Console.WriteLine(" = {0} Fahrenheit", fahr2.Degrees);

// Output:
// 100 Fahrenheit = 37.77778 Celsius = 100 Fahrenheit
```

### 示例2
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
    }
}
```

### 调用示例2
```csharp
byte b = 3;
Digit d = (Digit)b; 
```

### 补充说明
* 与 `explict` 相似的关键字是 `implicit`（后面的章节介绍）