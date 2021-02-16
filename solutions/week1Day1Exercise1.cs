using System;
using System.Collections.Generic;
using System.Text;

namespace solutions
{
    class week1Day1Exercise1
    {
        class A
        {
            public int num;
        }
        static void Main()
        {
            Console.WriteLine("Pushkar Dhakad");
         

        

            A objA = new A();
            A objB = new A();
            objA.num = 10;
            objB.num = 20;
            if (objA == objB)
            {
                Console.WriteLine("Reference are same");
            }
            else
            {
                Console.WriteLine("reference are not same");
            }

            if (objA.Equals(objB))
            {
                Console.WriteLine("content is same");
            }
            else
            {
                Console.WriteLine("content is not same");
            }

            objA = objB;

            if (objA == objB)
            {
                Console.WriteLine("Reference are same");
            }
            else
            {
                Console.WriteLine("reference are not same");
            }

            if (objA.Equals(objB))
            {
                Console.WriteLine("content is same");
            }
            else
            {
                Console.WriteLine("content is not same");
            }












            String myName = "Pushkar";

            String hisName = "Pushkar";

            if (myName == hisName)
            {
                Console.WriteLine("Reference are same");
            }
            else
            {
                Console.WriteLine("reference are not same");
            }
            if (myName.Equals(hisName))
            {
                Console.WriteLine("content is same");
            }
            else
            {
                Console.WriteLine("content is not same");
            }



        }


    }
}

