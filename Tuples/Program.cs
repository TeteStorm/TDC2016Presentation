using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static (int count, string value) Foo()
        {
            var retVal = (c: 1, v: "Foo");
            return retVal;
        }

    }
}
