using System;
using System.Collections.Generic;
using System.Text;

namespace PractiseProblems
{
    public delegate int IntDelegate(int a, int b);
    class IntegerClass
    {
        public static int addition(int a, int b)
        {
            return a + b;
        }
        public static int Multiply(int a, int b)
        {
            return a * b;
        }
    }
    class delegatesBasic
    {
        static void Main()
        {
            IntDelegate idel = new IntDelegate(IntegerClass.addition);
            IntDelegate idel1 = new IntDelegate(IntegerClass.Multiply);

            Console.WriteLine("addition "+idel.Invoke(10,20));
            Console.WriteLine("multiply "+idel1.Invoke(10, 20));

        }


    }
}
