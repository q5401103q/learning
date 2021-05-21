using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    // Covariant interface.
    interface ICovariant<out R> { }

    // Extending covariant interface.
    interface IExtCovariant<out R> : ICovariant<R> { }

    // Implementing covariant interface.
    class Sample<R> : ICovariant<R> { }

    class Demo013_2
    {
        static void Test()
        {
            ICovariant<Object> iobj = new Sample<Object>();
            ICovariant<String> istr = new Sample<String>();

            // You can assign istr to iobj because
            // the ICovariant interface is covariant.
            iobj = istr;
        }
    }
}
