using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    public abstract class Animal
    {
        public abstract void Raw();
    }

    public abstract class Mammal : Animal
    {
        public string GetName()
        {
            return this.GetType().Name;
        }
    }

    public class Cat : Mammal
    {
        public override void Raw()
        {
            Console.WriteLine("miaomiao");
        }
    }

    public class Dog : Mammal
    {
        public override void Raw()
        {
            Console.WriteLine("wangwang");
        }
    }
}
