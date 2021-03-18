using System;
using System.Collections.Generic;

namespace PriorityQueueAssignment
{
    class Program
    {
        static void Main(string[] args)
        {

            MyPriorityQueue<int> q1 = new MyPriorityQueue<int>();
            while (true)
            {

                Console.WriteLine("enter option ");
                Console.WriteLine("1. for Enqueue ");
                Console.WriteLine("2. for Dequeue ");
                Console.WriteLine("3. for Peek ");
                Console.WriteLine("4. check it contains the element or not ");
                Console.WriteLine("5. for size ");
                Console.WriteLine("6. for reverse");
                Console.WriteLine("7. for iterator ");
                Console.WriteLine("8. for Traverse ");
                int input = int.Parse(Console.ReadLine());
                int number;
                int priority;
                switch (input)
                {
                    case 1:
                        
                        Console.WriteLine("Please enter a number to be enqueue");
                        number = int.Parse(Console.ReadLine());

                        Console.WriteLine("Please enter Priority");
                        priority = int.Parse(Console.ReadLine());
                        q1.Enqueue(priority,number);
                        break;
                    case 2:
                        q1.Dequeue();
                        break;
                    case 3:
                        q1.Peek();
                        break;
                    case 4:
                        Console.WriteLine("Please enter a number to know queue contains it or not");
                        number = int.Parse(Console.ReadLine());
                        Console.WriteLine(q1.Contains(number));
                        break;
                    case 5:
                        Console.WriteLine(q1.Size());
                        break;
                    case 6:
                        q1.Reverse();
                        break;
                    case 7:
                        IEnumerable<string> ele = q1.iterator();
                        foreach (var element in ele)
                        {
                            Console.WriteLine(element);
                        }
                        break;
                    case 8:
                        q1.Traverse();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }


        }
    }
}
