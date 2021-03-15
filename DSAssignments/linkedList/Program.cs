using System;

namespace linkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //int number = 10;
            MyLinkedList<int> l1 = new MyLinkedList<int>();
            while (true)
            {

                Console.WriteLine("enter option ");
                Console.WriteLine("0. for inserting in end ");
                Console.WriteLine("1. for inserting in beginning ");
                Console.WriteLine("2. for insert at a position ");
                Console.WriteLine("3. for traversing ");
                Console.WriteLine("4. for size ");
                Console.WriteLine("5. for delete");
                Console.WriteLine("6. for center ");
                Console.WriteLine("7. for deleteAt ");
                Console.WriteLine("8. for reversing ");
                int input = int.Parse(Console.ReadLine());

                //insertion at the end
                if (input == 0)
                {
                    Console.WriteLine("Please enter a number to be inserted at the end");
                    int number=int.Parse(Console.ReadLine());
                    
                    l1.InsertAtEnd(number);
                }
                //insertion at the beginning
                else if (input == 1)
                {
                    Console.WriteLine("Please enter a number to be inserted in the beginning");
                    int number = int.Parse(Console.ReadLine());
                    l1.Insert(number);
                }
                // insertion at the specified index
                else if (input == 2)
                {
                    Console.WriteLine("Please enter a number to be inserted at the specified index");
                    int number = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter a index where you want to insert the number");
                    int index = int.Parse(Console.ReadLine());
                    l1.InsertAt(number,index);
                }
                //print the elements
                else if (input == 3)
                {
                    l1.Traverse();
                }
                //print size
                else if(input==4)
                {
                    Console.WriteLine("Size is "+l1.Size());
                }
                //delete the element from beginning
                else if (input == 5)
                {
                    l1.Delete();
                }
                //print center
                else if (input == 6)
                {
                    Console.WriteLine("Center element is " + l1.Center());
                }
                //deletion at specified index
                else if (input == 7)
                {
                    Console.WriteLine("Please enter a index where you want to delete the number");
                    int index = int.Parse(Console.ReadLine());
                    l1.DeleteAt(index);
                }
                //reverse the list
                else if (input == 8)
                {
                    l1.Reverse();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
