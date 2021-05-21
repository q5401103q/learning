using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    class Demo013_3
    {
        public void Test()
        {
            //msg必须要先初始化
            string msg = string.Empty;
            Method1(ref msg);
        }

        public void Method1(ref string message)
        {
            message = "Hello";
        }
    }
}
