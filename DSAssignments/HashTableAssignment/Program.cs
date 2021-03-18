using System;
using System.Collections.Generic;
namespace HashTableAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<int> h = new HashTable<int>(3);

            //Insert
            Console.WriteLine("Insert Operation");
            Console.WriteLine();
            h.Insert(10, 1);
            h.Insert(20, 2);
            h.Insert(30, 3);
            h.Insert(40, 4);
            h.Insert(50, 5);
            Console.WriteLine();

            //traverse
            Console.WriteLine("Traverse Operation");
            Console.WriteLine();
            h.Print();
            Console.WriteLine();

            //Contains and Size
            Console.WriteLine("Contains and Size Operation");
            Console.WriteLine();
            Console.WriteLine("Size: {0}", h.Size());
            Console.WriteLine("Contains key =3: " + h.Containskey(3));
            Console.WriteLine("Contains key=0: " + h.Containskey(0));
            Console.WriteLine();

            //Delete
            Console.WriteLine("Delete Operation");
            Console.WriteLine();
            h.Delete(1);
            Console.WriteLine();
            
            h.Print();
            Console.WriteLine();

            Console.WriteLine("Size: {0}", h.Size());
            Console.WriteLine();

            //Get value by Key
            Console.WriteLine("Get value by Key Operation");
            Console.WriteLine();
            Console.WriteLine("Value with key 2: {0}", h.GetValueByKey(2));

            Console.WriteLine();

            //iterator
            Console.WriteLine("Iterator");

            IEnumerable<string> ele = h.iterator();
            foreach (var element in ele)
            {
                Console.WriteLine(element);
            }
        }
    }
}
