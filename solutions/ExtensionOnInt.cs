using System;
using System.Collections.Generic;
using System.Text;

namespace solutions
{
    public static class IntExtension
    {
        public static bool IsOdd(this int i)
        {
            if (i % 2 != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsEven(this int i)
        {
            if (i % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsPrime(this int num)
        {
                            int  i, m = 0, flag = 0;
                            m = num / 2;
                            for (i = 2; i <= m; i++)
                            {
                                if (num % i == 0)
                                {
                                    
                                    flag = 1;
                                    return false;
                                    break;
                                }
                            }
                return true;
                            
        }
        public static bool IsDivisibleBy(this int i,int value)
        {
            if (i % value == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
    class ExtensionOnInt
    {

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Enter a number");
                int i = Int32.Parse(Console.ReadLine());


                Console.WriteLine("1.IsOdd");
                Console.WriteLine("2.IsEven");
                Console.WriteLine("3.IsPrime");
                Console.WriteLine("4.IsDivisible");

                Console.WriteLine("Enter choice ");


                int choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {

                    case 1:
                        Console.WriteLine(i.IsOdd());
                        break;

                    case 2:
                        Console.WriteLine(i.IsEven());
                        break;
                    case 3:
                        Console.WriteLine(i.IsPrime());
                        break;
                    case 4:
                        Console.WriteLine("Enter another number");
                        int value = Int32.Parse(Console.ReadLine());
                        Console.WriteLine(i.IsDivisibleBy(value));
                        break;
                    default:
                        Console.WriteLine("Enter correct choice");
                        break;
                }
            }
        }
    }
}
