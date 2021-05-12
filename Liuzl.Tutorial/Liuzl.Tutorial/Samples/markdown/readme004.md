## 保留关键字 checked/unchecked
`checked` 关键字用于对整型类型算术运算和转换显式启用溢出检查。<br>
`unchecked` 关键字用于取消整型类型的算术运算和转换的溢出检查。<br>

``` csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    class Demo004
    {
        public void TestChecked()
        {
            try
            {
                int num = int.MaxValue;
                checked
                {
                    num++;
                    Console.WriteLine(num);
                }
            }
            catch (OverflowException) { Console.WriteLine("int类型溢出"); }
        }

        public void TestUnChecked()
        {
            try
            {
                int num = int.MaxValue;
                unchecked
                {
                    num++;
                    Console.WriteLine(num);
                }
            }
            catch (OverflowException) { Console.WriteLine("int类型溢出"); }
        }

        public void TestNoneChecked()
        {
            try
            {
                int num = int.MaxValue;
                num++;
                Console.WriteLine(num);
            }
            catch (OverflowException) { Console.WriteLine("int类型溢出"); }
        }
    }
}



```

调用示例：
``` csharp
var demo = new Demo004();
demo.TestChecked();
demo.TestUnChecked();
demo.TestNoneChecked();
/**
 * 输出结果
 * int类型溢出
 * -2147483648
 * -2147483648
 */
```

### 结论
* 通常用于越界检查，如果使用 `checked` 检查，会抛出异常；

### 补充说明
* int.MaxValue等于2147483647；
* c#中int的长度为32位；
* 《计算机组成原理》中描述了二进制补码加法，请参阅，这里简单介绍；
* 正数的补码是其本身；
* 负数的补码的求法是，除符号位外，全部取反再加1；
* 有符号的整型数，最高位表示符号位，其中符号位0表示正数，符号位1表示负数；
* 原码同数字的二进制表示，例如5的原码是0101,4的原码是0100；
* 原码中有两个0，正零和负零，假设长度为4bit，即 0000 和 1000；
* 正零的补码为0000；
* 负零的反码是1111；
* 负零的补码是10000（除符号位外取反加1），舍弃最高位后（因为长度只有4位）也是0000；
* 基于以上说明，可知补码的个数比原码和反码多了一个；
* 因此多出一个特殊的补码表示真值为-8的数（人为规定的特殊补码）；
* 所以int的取值范围是[-2147483648, 2147483647]；
* 所以short的取值范围是[-32768, 32767]；
* 所以sbyte的取值范围是[-128, 127]；

在以上基础上理解溢出的计算过程，如下：
``` javascript
  //溢出计算过程说明
  0111 1111 1111 1111 1111 1111 1111 1111  //2147483647的补码
+ 0000 0000 0000 0000 0000 0000 0000 0001  //1补码
= 1000 0000 0000 0000 0000 0000 0000 0000  //加法计算后的补码（特殊补码），即-2147483648
```

