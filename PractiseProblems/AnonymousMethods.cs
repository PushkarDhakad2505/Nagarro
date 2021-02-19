using System;
using System.Collections.Generic;
using System.Text;

namespace PractiseProblems
{
    class delegatesBasic1
    {
        static void Main()
        {
            IntDelegate idel = delegate (int a, int b) { return a + b; };
            IntDelegate idel1 = delegate (int a, int b) { return a * b; };

            Console.WriteLine("addition          " + idel(10, 20));
            Console.WriteLine("multiply " + idel1.Invoke(10, 20));

        }
    }
}
