using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    class Demo010
    {
        public void Test()
        {
            Fahrenheit fahr1 = new Fahrenheit(100.0f);
            Console.Write("{0} Fahrenheit", fahr1.Degrees);
            Celsius c = (Celsius)fahr1;

            Console.Write(" = {0} Celsius", c.Degrees);
            Fahrenheit fahr2 = (Fahrenheit)c;
            Console.WriteLine(" = {0} Fahrenheit", fahr2.Degrees);
        }

        public void Test1()
        {
            byte b = 3;
            Digit d = (Digit)b;
            byte b1 = d;
        }
    }

    class Celsius
    {
        public Celsius(float temp)
        {
            degrees = temp;
        }
        public static explicit operator Fahrenheit(Celsius c)
        {
            return new Fahrenheit((9.0f / 5.0f) * c.degrees + 32);
        }
        public float Degrees
        {
            get { return degrees; }
        }
        private float degrees;
    }

    class Fahrenheit
    {
        public Fahrenheit(float temp)
        {
            degrees = temp;
        }
        // Must be defined inside a class called Fahrenheit:
        public static explicit operator Celsius(Fahrenheit fahr)
        {
            return new Celsius((5.0f / 9.0f) * (fahr.degrees - 32));
        }
        public float Degrees
        {
            get { return degrees; }
        }
        private float degrees;
    }

    struct Digit
    {
        byte value;
        public Digit(byte value)
        {
            if (value > 9)
            {
                throw new ArgumentException();
            }
            this.value = value;
        }

        public static explicit operator Digit(byte b)
        {
            Digit d = new Digit(b);
            return d;
        }

        public static implicit operator byte(Digit d)
        {
            return d.value;
        }
    }
}
