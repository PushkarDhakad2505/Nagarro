using System;
using System.Collections.Generic;
using System.Text;

namespace PractiseProblems
{
    public delegate int IntDelegate1(int a,int b);
    class IntegerClass1
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


    class multiCastDelegate
    {

        static void Main()
        {
            IntDelegate1 idel = IntegerClass1.addition;
            idel += IntegerClass1.Multiply;


            Console.WriteLine("addition " + idel(10, 20));
            Console.WriteLine("multiply " + idel(10, 20));

        }
  

    }
}
