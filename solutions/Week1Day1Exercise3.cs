using System;
using System.Collections.Generic;
using System.Text;

namespace solutions
{
    class Week1Day1Exercise3
    {



        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter first number");
                String s1 = Console.ReadLine();
                Console.WriteLine("Enter Second number");
                String s2 = Console.ReadLine();
                int num1 = int.Parse(s1);
                int num2 = int.Parse(s2);

                if (num1 < num2)
                {

                    Console.WriteLine("Prime numbers are");
                    for (int i = num1; i < num2; i++)
                    {
                        int isPrime = 1;
                        for (int j = 2; j < (i / 2) + 1; j++)
                        {
                            if (i % j == 0)
                            {
                                isPrime = 0;
                                break;
                            }

                        }
                        if (isPrime == 1)
                        {
                            Console.WriteLine(i);
                        }

                    }


                    break;
                }
                else
                {
                    Console.WriteLine("First number should be less than second one");
                    Console.WriteLine("Enter the numbers again");



                }
            }
        }






    }
}
