## 保留关键字 fixed
`fixed` 语句可防止垃圾回收器重新定位可移动的变量。 `fixed` 语句仅允许存在于不安全的上下文( `unsafe` )中。 还可以使用 `fixed` 关键字创建固定大小的缓冲区。

### 示例1
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    class Demo011
    {
        unsafe private static void Test()
        {
            Point pt = new Point();
            fixed (int* p = &pt.x)
            {
                //指针指向的内容变化，编译器不会报错
                *p = 1;

                //修改只读指针，编译器报错CS1656
                //p++;

                //定义第二个指针变量
                int* innerPtr = p;

                //第二个指针指向的内容变化，编译器不会报错
                *innerPtr = 2;

                //修改第二个指针，编译器不会报错
                innerPtr++;
            }
        }
    }

    class Point
    {
        public int x;
        public int y;
    }
}
```

### 示例2
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    class Demo011
    {
        unsafe private static void FixedSpanExample()
        {
            int[] PascalsTriangle = {
                          1,
                        1,  1,
                      1,  2,  1,
                    1,  3,  3,  1,
                  1,  4,  6,  4,  1,
                1,  5,  10, 10, 5,  1
            };

            Span<int> RowFive = new Span<int>(PascalsTriangle, 10, 5);

            fixed (int* ptrToRow = RowFive)
            {
                var sum = 0;
                for (int i = 0; i < RowFive.Length; i++)
                {
                    sum += *(ptrToRow + i);
                }
                Console.WriteLine(sum); //结果是16
            }
        }
    }
}
```

### 补充说明
* 如果没有 `fixed` 上下文，垃圾回收可能会不可预测地重定位变量。 
* `C#` 编译器只允许将指针分配给 `fixed` 语句中的托管变量。
* 从 `C# 7.3` 开始，`fixed` 语句可在数组、字符串、固定大小缓冲区或非托管变量以外的其他类型上执行。 
* 从 `C# 7.3` 开始，实现了 `GetPinnableReference` 的方法的任何类型都可以被固定。 
* 从 `C# 7.3` 开始，`GetPinnableReference` 必须返回非托管类型的 `ref` 变量。 
* `.NET Core 2.0` 中引入的 `.NET` 类型 `System.Span<T>` 和 `System.ReadOnlySpan<T>` 使用此模式，并且可以固定。 
* 在 `fixed` 语句中初始化的指针为只读变量。 
* 如果想要修改指针值，必须声明第二个指针变量，并修改它。 不能修改在 `fixed` 语句中声明的变量，参见示例1。 
* 可以在堆栈上分配内存，在这种情况下，内存不受垃圾回收的约束，因此不需要固定。 为此，请使用 `stackalloc` 表达式。
