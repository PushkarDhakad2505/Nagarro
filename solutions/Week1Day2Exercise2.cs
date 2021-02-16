using System;
using System.Collections.Generic;
using System.Text;

namespace solutions
{
    class Week1Day2Exercise2
    {



        static void Main(string[] args)
        {
            Console.WriteLine("press following nunmbers for different different kind of ducks");
            Console.WriteLine("0 for Rubber ducks");
            Console.WriteLine("1 for mallard ducks");
            Console.WriteLine("2 for readhead ducks");
            int type = Int32.Parse(Console.ReadLine());
            switch (type)
            {
                case (int)Ducks.typeOfDuck.RUBBER:
                    Ducks rubberDuck = new RubberDucks();
                    rubberDuck.ShowDetails();
                    break;
                case (int)Ducks.typeOfDuck.MALLARD:
                    Ducks mallardDuck = new MallardDucks();
                    mallardDuck.ShowDetails();
                    break;
                case (int)Ducks.typeOfDuck.READHAED:
                    Ducks readheadDuck = new ReadheadDucks();
                    readheadDuck.ShowDetails();
                    break;
                default:
                    Console.WriteLine("you have enterd wrong number");
                    break;
            }
        }
    }
    public interface Ducks
    {
        public enum typeOfDuck { RUBBER, MALLARD, READHAED };
        public void fly();
        public void quack();
        public void ShowDetails();
    }
    class RubberDucks : Ducks
    {
        public void fly()
        {
            Console.WriteLine("didn't fly");
        }
        public void quack()
        {
            Console.WriteLine("squeak");
        }
        public void ShowDetails()
        {
            fly();
            quack();
        }
    }
    class MallardDucks : Ducks
    {
        public void fly()
        {
            Console.WriteLine("fly fast");
        }
        public void quack()
        {
            Console.WriteLine("quack loud");
        }
        public void ShowDetails()
        {
            fly();
            quack();
        }
    }
    class ReadheadDucks : Ducks
    {
        public void fly()
        {
            Console.WriteLine("fly slow");
        }
        public void quack()
        {
            Console.WriteLine("quack mild");
        }
        public void ShowDetails()
        {
            fly();
            quack();

        }



    }






}
