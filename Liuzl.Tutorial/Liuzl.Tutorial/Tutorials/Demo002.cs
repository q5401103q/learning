using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Test()
        {
            //dynamic obj = new System.Dynamic.ExpandoObject();
            //obj.name = "zhangsan";
            //obj.score = 88.5;
            //obj.age = 20;

            //Console.WriteLine(obj);

            var obj = new Student();
            obj.name = "zhangsan";
            obj.score = 88.5f;
            obj.age = 20;

            Console.WriteLine(obj);
        }
    }

    class Student
    {
        public string name { get; set; }
        public float score { get; set; }
        public int age { get; set; }
    }
}
