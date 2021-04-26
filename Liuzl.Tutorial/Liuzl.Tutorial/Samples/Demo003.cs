using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    public class Car
    {
        public string Color { get; set; }

        public Car() 
        {
            Console.WriteLine("car constructor non-param");
        }

        public Car(string color)
        {
            Color = color;
            Console.WriteLine("car constructor with-param");
        }

        public string GetColor()
        {
            return Color;
        }
    }

    public class SUV : Car
    {
        public string Brand { get; set; }

        public SUV() : base()
        {
            Console.WriteLine("SUV constructor non-param");
        }

        public SUV(string color) : base(color)
        {
            Console.WriteLine("SUV constructor with-param");
        }

        public SUV(string color, string brand) : this()
        {
            Color = color;
            Brand = brand;
            Console.WriteLine("SUV constructor with-two-param");
        }


        public string GetSUVColor()
        {
            return base.GetColor().ToUpper();
        }
    }
}
