using System;
using System.Collections.Generic;
using System.Text;

namespace solutions
{
    class Week1Day3Exercise2
    {

        static void Main()
        {
            List<Ducks> DuckList = new List<Ducks>();

            while (true)
            {
                Console.WriteLine("select option to choose ");
                Console.WriteLine("1.Add a duck");
                Console.WriteLine("2.Remove a duck");
                Console.WriteLine("3.Remove all ducks");
                Console.WriteLine("4.Sort accrodingly in increasing order of their weights");
                Console.WriteLine("5.Sort accrodingly increasing order of number of wings");
                Console.WriteLine("6.Exit");

                int getChioce = Int32.Parse(Console.ReadLine());
                switch (getChioce)
                {
                    case 1:
                        Console.WriteLine("1.Enter num of wings ");
                        int wing = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("2.Enter weight of duck");
                        int weight = Int32.Parse(Console.ReadLine());
                        DuckList.Add(new Ducks(wing, weight));
                        foreach (Ducks Duck in DuckList)
                        {
                            Console.WriteLine("Duck with " + Duck.numOfWings + " wings and weight is" + " " + Duck.weights);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Type index number to remove that value");
                        int indexNumber = Int32.Parse(Console.ReadLine());
                        DuckList.RemoveAt(indexNumber);
                        foreach (Ducks Duck in DuckList)
                        {
                            Console.WriteLine("Duck with " + Duck.numOfWings + " wings and weight is " + " " + Duck.weights);
                        }
                        break;
                    case 3:
                        DuckList.Clear();
                        Console.WriteLine("All Ducks Removed");

                        break;
                    case 4:
                        DuckList.Sort();
                        foreach (Ducks Duck in DuckList)
                        {
                            Console.WriteLine("Duck with " + Duck.numOfWings + " wings and weight is " + " " + Duck.weights);
                        }
                        break;
                    case 5:
                        DuckList.Sort(new DuckListSortByWing());
                        foreach (Ducks Duck in DuckList)
                        {
                            Console.WriteLine("Duck with " + Duck.numOfWings + " wings and weight is " + " " + Duck.weights);
                        }
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("you have enterd wrong number");
                        break;
                }
            }
        }
        class DuckListSortByWing : IComparer<Ducks>
        {
            public int Compare(Ducks x, Ducks y)
            {
                return x.numOfWings.CompareTo(y.numOfWings);
            }
        }
        public class Ducks : IComparable<Ducks>
        {
            public int numOfWings;
            public double weights;
            public Ducks(int numOfWings, double weights)
            {
                this.numOfWings = numOfWings;
                this.weights = weights;
            }

            public int CompareTo(Ducks other)
            {
                return this.weights.CompareTo(other.weights);
            }


            public void ShowDetails() { }

        }
    }

}

