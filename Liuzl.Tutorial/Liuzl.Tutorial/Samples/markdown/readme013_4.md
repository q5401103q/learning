## 保留关键字 ref
>引用返回值（或 `ref` 返回值）是由方法按引用向调用方返回的值。即调用方可以修改方法所返回的值，此更改反映在调用方法中的对象的状态中。

### 示例
```csharp
using System;

namespace Liuzl.Tutorial.Samples
{
    class Demo013_4
    {
        public static void Test()
        {
            int[,] matrix = new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
            Func<int, bool> pridicate = n =>
            {
                if (n == 8)
                {
                    return true;
                }
                return false;
            };
            var a = Find(matrix, pridicate);
            Console.WriteLine(a);

            // 还有以下的用法
            // ref double d = ref SomeMethod();
        }

        public static ref readonly int Find(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (predicate(matrix[i, j]))
                    {
                        return ref matrix[i, j];
                    }
                }
            }
            throw new InvalidOperationException("Not found");
        }
    }
}
```

### 补充说明
* 方法的返回值要使用 `ref` 关键字修饰
* 返回语句要使用 `ref` 关键字修饰
* `ref readonly` 返回值做为分配到存储的别名，无法修改
* 注意局部变量时， `ref` 的用法