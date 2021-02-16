using System;
using System.Collections.Generic;
using System.Text;

namespace solutions
{

    class InvalidInputException:ApplicationException
    {
        public InvalidInputException(string message) : base(message)
        {

        }
    }
    class PlayedGameMultipleTimeException: ApplicationException
    {
        public PlayedGameMultipleTimeException(string message) : base(message)
        {

        }
    }
    class ExceptionHandling
    {
        static void Main(string []args)
        {
            int count = 0;
            while(true)
            {
                
                Console.WriteLine("Enter any number from 1 - 5");
                Console.WriteLine("1) Enter even number ");
                Console.WriteLine("2) Enter odd number ");
                Console.WriteLine("3) Enter a prime number");
                Console.WriteLine("4) Enter a negative number ");
                Console.WriteLine("5) Enter zero");
                int inputVal = Int32.Parse(Console.ReadLine());
                try
                {
                    count += 1;
                    if(count>5)
                    {
                        throw new PlayedGameMultipleTimeException("You had played game more than 5 times");
                    }
                    AcceptChoice(inputVal);
                }
                catch(InvalidInputException iie)
                {
                    Console.WriteLine(iie);
                }
                catch (PlayedGameMultipleTimeException pgmte)
                {
                    Console.WriteLine(pgmte);
                    break;
                }
                
                static void AcceptChoice(int inputVal1)
                {

                
                    int inputVal2;
                    switch (inputVal1)
                    {
                        case 1:
                            Console.WriteLine("Enter even number ");
                            inputVal2 = Int32.Parse(Console.ReadLine());
                            if (inputVal2 % 2 == 0)
                            {
                                Console.WriteLine("Success");
                            }
                            else
                            {
                                throw new InvalidInputException("Enter even num");
                            }

                            break;
                        case 2:

                            Console.WriteLine(" Enter odd number ");
                            inputVal2 = Int32.Parse(Console.ReadLine());
                            if (inputVal2 % 2 != 0)
                            {
                                Console.WriteLine("Success");
                            }
                            else
                            {
                                throw new InvalidInputException("Enter odd num");
                            }

                            break;


                        case 3:
                            Console.WriteLine(" Enter a prime number");
                            inputVal2 = Int32.Parse(Console.ReadLine());
                            int  i, m = 0, flag = 0;
                            m = inputVal2 / 2;
                            for (i = 2; i <= m; i++)
                            {
                                if (inputVal2 % i == 0)
                                {
                                    Console.Write("Number is not Prime.");
                                    flag = 1;
                                    throw new InvalidInputException("Enter even num");
                                    break;
                                }
                            }
                            if (flag == 0)
                                Console.WriteLine("success.");
                            
                            break;
                        case 4:

                            Console.WriteLine(" Enter a negative number ");
                            inputVal2 = Int32.Parse(Console.ReadLine());
                            if (inputVal2 < 0)
                            {
                                Console.WriteLine("Success");
                            }
                            else
                            {
                                throw new InvalidInputException("Enter negative num");
                            }

                            break;
                        case 5:

                            Console.WriteLine(" Enter zero");
                            inputVal2 = Int32.Parse(Console.ReadLine());
                            if (inputVal2 == 0)
                            {
                                Console.WriteLine("Success");
                            }
                            else
                            {
                                throw new InvalidInputException("Enter zero");
                            }
                            break;
                        default:

                            throw new ApplicationException("Enter valid choice");
                            break;

                    }

                }

            }

        }
    }
}
