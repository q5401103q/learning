## 保留关键字 stackalloc
>`stackalloc` 表达式在堆栈上分配内存块。该方法返回时，将自动丢弃在方法执行期间创建的堆栈中分配的内存块。

### 示例
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    class Demo012
    {
        public void Method1()
        {
            int length = 100;
            Span<int> numbers = length <= 128 ? stackalloc int[length] : new int[length];
            for (var i = 0; i < length; i++)
            {
                numbers[i] = i;
            }
        }

        public void Method2()
        {
            Span<int> first = stackalloc int[3] { 1, 2, 3 };
            Span<int> second = stackalloc int[] { 1, 2, 3 };
            ReadOnlySpan<int> third = stackalloc[] { 1, 2, 3 };
        }

        public void Method3()
        {
            unsafe
            {
                int length = 3;
                int* numbers = stackalloc int[length];
                for (var i = 0; i < length; i++)
                {
                    numbers[i] = i;
                }
            }
        }
    }
}
```

### 补充说明
* 定义中表名，`stackalloc`关键字仅在局部变量的初始值中有效
* 不能显式释放使用 `stackalloc` 分配的内存
* 堆栈中分配的内存块不受垃圾回收的影响
* 不必通过 `fixed` 语句固定
* 从 C# 7.2 开始，可以使用 `System.Span<T>` 或 `System.ReadOnlySpan<T>`在条件表达式或赋值表达式中使用 `stackalloc `表达式
* 将堆栈中分配的内存块分配给 `Span<T>` 或 `ReadOnlySpan<T>` 变量时，不必使用 `unsafe` 上下文
* 建议尽可能使用 `Span<T>` 或 `ReadOnlySpan<T>` 类型来处理堆栈中分配的内存
* 在使用指针类型时必须使用 `unsafe` 上下文
* 如果在堆栈上分配过多的内存，会引发 `StackOverflowException`
* 建议限制使用 `stackalloc` 分配的内存量
* 建议避免在循环内使用 `stackalloc`
* 在表达式 `stackalloc T[E]` 中，`T` 必须是非托管类型，并且 `E` 的计算结果必须为非负 `int` 值
* 如果检测到缓冲区溢出，则将尽快终止进程，以便将执行恶意代码的可能性降到最低