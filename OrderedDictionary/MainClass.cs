using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OrderedDictionary
{
    static class MainClass
    {

        static void Main()
        {
            var processQueue = new PriorityQueue<Process>();



            processQueue.Enqueue(3, new Process { Name = "Pushkar" });
            processQueue.Enqueue(7, new Process { Name = "Ram" });
            processQueue.Enqueue(3, new Process { Name = "Shayam" });
            processQueue.Enqueue(4, new Process { Name = "Dhakad" });
            processQueue.Enqueue(8, new Process { Name = "Sita" });
            processQueue.Enqueue(1, new Process { Name = "Gita" });



            while (true)
            {
                Console.WriteLine("Select details");
                Console.WriteLine("1.   ShowItems");
                Console.WriteLine("2.	DeQueue");
                Console.WriteLine("3.	Peek ");
                Console.WriteLine("4.	Count");
                Console.WriteLine("5.	Contains");
                Console.WriteLine("6.	GetHighest priority");
                Console.WriteLine("7.   ClearQueue");

                int input1 = Int32.Parse(Console.ReadLine());
                switch (input1)
                {
                    case 1:

                        Console.WriteLine("Item in the  queue are ");
                        foreach (var item in processQueue)
                        {
                            Console.WriteLine("Priority : {0}, Name : {1}", item.Priority, item.Name);
                        }

                        break;
                    case 2:


                        Console.WriteLine(Environment.NewLine + "The element removed during first dequeue");

                        Process process2 = processQueue.Dequeue();
                        Console.WriteLine("Priority : {0}, Name : {1}", process2.Priority, process2.Name);

                        break;
                    case 3:

                        if (processQueue.Peek() != null)
                        {
                            Console.WriteLine(
                                Environment.NewLine + "Peek :" + Environment.NewLine + "-------" + Environment.NewLine + "Priority : {0} Name : {1}",
                                processQueue.Peek().Priority, processQueue.Peek().Name);
                        }
                        else
                        {
                            Console.WriteLine("Priority Queue is empty!");
                        }
                        break;
                    case 4:

                        Console.WriteLine(Environment.NewLine + "Total items in priority queue are : {0}", processQueue.Count);


                        break;
                    case 5:


                        Console.WriteLine(Environment.NewLine + "Check if the data of following object is in priority queue");

                        var process1 = new Process { Priority = 3, Name = "Delete" };
                        Console.WriteLine("Priority : {0}, Name : {1}", process1.Priority, process1.Name);
                        Console.WriteLine(processQueue.Contains(process1));


                        break;

                    case 6:
                        break;
                    case 7:

                        processQueue.Clear();
                        Console.WriteLine(Environment.NewLine + "The number of items in the process queue after clear() : {0}", processQueue.Count);
                        break;
                    default:
                        Console.WriteLine("enter correct choice");
                        break;


                }



            }



        
            Console.ReadKey();

        }


    }
}
