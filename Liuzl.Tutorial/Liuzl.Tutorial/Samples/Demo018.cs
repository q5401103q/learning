using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    class Demo018
    {
        public void Method1()
        {
            Random rnd = new Random();
            int caseSwitch = rnd.Next(1, 4);

            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    break;
                case 2:
                case 3:
                    Console.WriteLine($"Case {caseSwitch}");
                    break;
                default:
                    Console.WriteLine($"An unexpected value ({caseSwitch})");
                    break;
            }
        }

        public void Method2()
        {
            object item = new object();
            switch (item)
            {
                case 0:
                    break;
                case int val:
                    break;
                case IEnumerable<object> subList when subList.Any():
                    break;
                case IEnumerable<object> subList:
                    break;
                case null:
                    break;
                default:
                    throw new InvalidOperationException("unknown item type");
            }
        }

        public void Method3(Shape sh)
        {
            switch (sh)
            {
                case Shape shape when shape == null:
                    Console.WriteLine($"An uninitialized shape (shape == null)");
                    break;
                case null:
                    Console.WriteLine($"An uninitialized shape");
                    break;
                case Shape shape when sh.Area == 0:
                    Console.WriteLine($"The shape: {sh.GetType().Name} with no dimensions");
                    break;
                case Shape shape when sh != null:
                    Console.WriteLine($"A {sh.GetType().Name} shape");
                    break;
                default:
                    Console.WriteLine($"The {nameof(sh)} variable does not represent a Shape.");
                    break;
            }
        }
    }

    public abstract class Shape
    {
        public abstract double Area { get; }
        public abstract double Circumference { get; }
    }
}
