using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            /**
             * is 用法演示
             */
            object obj = new object();
            object objNull = null;
            bool b1 = obj is object;        //true
            bool b2 = obj is bool;          //false
            bool b3 = objNull is object;    //false
            bool b4 = animalObj is Cat;     //true
        }
    }
}