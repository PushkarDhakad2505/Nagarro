using System;
namespace StackDataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MyStack<int> s1 = new MyStack<int>();
            while (true)
            {

                Console.WriteLine("enter option ");
                Console.WriteLine("1. for Push ");
                Console.WriteLine("2. for Pop ");
                Console.WriteLine("3. for Peek ");
                Console.WriteLine("4. check it contains the element or not ");
                Console.WriteLine("5. for size ");
                Console.WriteLine("6. for reverse");
                Console.WriteLine("7. for iterator ");
                Console.WriteLine("8. for Traverse ");
                int input = int.Parse(Console.ReadLine());
                int number;
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Please enter a number to be inserted at the end");
                         number = int.Parse(Console.ReadLine());
                        s1.Push(number);
                        break;
                    case 2:
                        s1.Pop();
                        break;
                    case 3:
                        s1.Peek();
                        break;
                    case 4:
                        Console.WriteLine("Please enter a number to know stack contains it or not");
                        number = int.Parse(Console.ReadLine());
                        Console.WriteLine(s1.Contains(number));
                        break;
                    case 5:
                        Console.WriteLine(s1.Size());
                        break;
                    case 6:
                        s1.Reverse();
                        break;
                    case 7:
                        break;
                    case 8:
                        s1.Traverse();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}