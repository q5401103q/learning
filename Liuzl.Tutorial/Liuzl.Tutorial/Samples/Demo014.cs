using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    class Demo014
    {
        public void Test()
        {
            Square squre = new Square();
            squre.Name = "Rectangle";
            squre.Width = 10;
            squre.Height = 20;
            Console.WriteLine($"{squre.Name}'s area is {squre.GetArea()}");
        }
    }

    class Rectangle
    {
        public virtual string Name { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public virtual double GetArea()
        {
            return Width * Height;
        }
    }

    class Square : Rectangle
    {
        public override string Name { get => base.Name; set => base.Name = value; }

        public override double GetArea()
        {
            return Width * Width;
        }
    }
}
