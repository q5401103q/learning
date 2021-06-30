using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Tutorials
{
    class Demo003
    {
        public void Test()
        {
            var p1 = new RecordPerson1()
            {
                Name = "Tom",
                Age = 12,
            };
            Console.WriteLine(p1);

            var p2 = p1 with { Age = 10 };
            Console.WriteLine(p2);

            var p3 = new RecordPerson1() { Name = "Tom", Age = 12 };
            Console.WriteLine(p3);
            Console.WriteLine($"p1 Equals p3 =: {p1 == p3}");

            RecordPerson2 p4 = new("Tom", 12);
            Console.WriteLine(p4);
        }
    }

    record RecordPerson1
    {
        public string Name { get; init; }
        public int Age { get; init; }
    }

    record RecordPerson2(string Name, int Age);
}
