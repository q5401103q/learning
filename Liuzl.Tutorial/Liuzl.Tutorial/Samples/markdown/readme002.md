## 保留关键字 is/as
`is`/`as` 关键字用于类型的转换和判断。<br>
`is` 检查一个对象是否兼任与指定的类型，并返回一个bool值，检查的过程不会抛出异常；<br>
`as` 工作方式与强类型转换一样，转换的过程不会抛出异常，如果对象不能转换，返回null；<br>
下面是一段示例代码:<br>
``` csharp
namespace Liuzl.Tutorial.Samples
{
    class Demo002
    {
        public void Method()
        {
            /**
             * as 用法演示
             */
            object animalObj = new Cat();
            Cat cat = (animalObj as Cat);   //cat!=null
            Dog dog = (animalObj as Dog);   //dog==null

            /**
             * is 用法演示
             */
            object obj = new object();
            object objNull = null;
            bool b1 = obj is object;        //true
            bool b2 = obj is bool;          //false
            bool b3 = objNull is object;    //false
            bool b4 = animalObj is Cat;     //true

            /**
             * 以下转换编译器报错，因为值类型数据不能转换
             * object objNumber = 11;
             * int num = objNumber as int;
             */

            /**
             * 正确的做法：
             * object objNumber = 11;
             * if (objNumber is int)
             * {
             *     int num = (int)objNumber;
             * }
             */
        }
    }
}
```

### 结论
* Object转换为已知引用类型，使用 `as` 操作符；
* Object转换为已知值类型，先使用 `is` 操作符进行判断，再用强类型转换；
* 在已知引用类型之间转换，相应的提供操作符函数（后续会介绍`explicit`），再用强类型转换；
* 已知值类型之间转换，使用系统提供的Convert类中的静态方法；

### 补充说明
当用 `as` 操作符进行类型转换的时候，首先判断当前对象的类型，当类型满足要求后才进行转换。而传统的类型转换方式，是用当前对象直接去转换，而且为了保护转换成功，要加上try-catch，所以，相对来说， `as` 效率高点。