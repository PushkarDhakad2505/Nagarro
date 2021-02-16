using System;
using System.Collections.Generic;
using System.Text;

namespace solutions
{
    class Week1Day2Exercise1
    {

         static void Main(string[] args)
         {         
            Console.WriteLine("Enter details");
            Console.WriteLine("Enter name");
            String name = Console.ReadLine();
            Console.WriteLine("Enter description");
            String description = Console.ReadLine();
            Console.WriteLine("Enter no of wheels");
            int numOfWheels = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter weight");
            int weight = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Is it movable or immovable");
            Console.WriteLine("Press 0 for movable ");
            Console.WriteLine("Press 1 for immovable");
            int type = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter distance to move");
            int distanceToMove = Int32.Parse(Console.ReadLine());

            if ((int)Equipment.equipmentType.MOBILE == type)
            {
                Equipment car = new mobileEquip(numOfWheels, name, description, 0, 0);
                car.moveBy(distanceToMove);
                car.show();
            }

            else if ((int)Equipment.equipmentType.IMMOBILE == type)
            {
                Equipment trolly = new immobileEquip(weight, name, description, 0, 0);
                trolly.moveBy(distanceToMove);
                trolly.show();

            }
            else
            {
                Console.WriteLine("You entered wrong type");
            }
        }
    }
    abstract class Equipment
    {
        public String name;
        public String discription;
        public float dist = 0;
        public int maintaince = 0;
        public enum equipmentType { MOBILE, IMMOBILE };

        public Equipment()
        {
        }
        public Equipment(String name, String discription, float dist, int maintaince)
        {
            this.name = name;
            this.discription = discription;
            this.dist = dist;
            this.maintaince = maintaince;


        }
        virtual public void moveBy(int d)
        {

            Console.WriteLine("hi");
        }
        virtual public void show()
        {

        }

    }
    class mobileEquip : Equipment
    {
        int numberOfWheels;
        public mobileEquip(int numberOfWheels, String name, String discription, float dist, int maintaince)
             : base(name, discription, dist, maintaince)
        {

            this.numberOfWheels = numberOfWheels;
        }

        override public void moveBy(int d)
        {
            dist = dist + d;
            maintaince = maintaince + numberOfWheels * d;
        }
        override public void show()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Discription: " + discription);
            Console.WriteLine("No of wheels: " + numberOfWheels);
            Console.WriteLine("Distance: " + dist);
            Console.WriteLine("Maintaince: " + maintaince);
        }

    }
    class immobileEquip : Equipment
    {
        int weight;
        public immobileEquip(int weight, String name, String discription, float dist, int maintaince)
            : base(name, discription, dist, maintaince)
        {
            this.weight = weight;
        }
        override public void moveBy(int d)
        {
            dist = dist + d;
            maintaince = maintaince + weight * d;
        }
        override public void show()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Discription: " + discription);
            Console.WriteLine("weight: " + weight);
            Console.WriteLine("Distance: " + dist);
            Console.WriteLine("Maintaince: " + maintaince);
        }






    }

}

