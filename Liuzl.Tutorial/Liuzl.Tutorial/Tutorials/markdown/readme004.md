## where
`where` 子句用在查询表达式中，用于指定将在查询表达式中返回数据源中的哪些元素。 它将一个布尔条件（谓词）应用于每个源元素（由范围变量引用），并返回满足指定条件的元素。 一个查询表达式可以包含多个 `where` 子句，一个子句可以包含多个谓词子表达式。

`where` 子句是一种筛选机制。 除了不能是第一个或最后一个子句外，它几乎可以放在查询表达式中的任何位置。 `where` 子句可以出现在 `group` 子句的前面或后面，具体取决于时必须在对源元素进行分组之前还是之后来筛选源元素。

### 示例
```csharp
using System;
using System.Linq;

namespace Liuzl.Tutorial.Tutorials
{
    class Demo004
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        public void Method1()
        {
            var query1 = from num in numbers
                        where num < 5 && num % 2 == 0
                        select num;

            var query2 = from num in numbers
                         where num < 5
                         where num % 2 == 0
                         select num;

            var query3 = from num in numbers
                         where IsEven(num)
                         select num;

            foreach (var s in query1)
            {
                Console.WriteLine(s.ToString());
            }
        }

        static bool IsEven(int i)
        {
            return i % 2 == 0;
        }
    }
}
```