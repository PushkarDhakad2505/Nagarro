using System;
using System.Collections.Generic;
using System.Text;

namespace RemainingAssignment
{
    class Week1Day3Exercise1
    {
        static List<Equipment> EquipList = new List<Equipment>();

       
    static void Main()
        {
              

            while (true)
            {
                Console.WriteLine("Select details");
                Console.WriteLine("1.	Create an equipment ");
                Console.WriteLine("2.	Delete an equipment");
                Console.WriteLine("3.	Move an equipment ");
                Console.WriteLine("4.	List all equipment");
                Console.WriteLine("5.	Show details of an equipment");
                Console.WriteLine("6.	List all mobile equipment ");
                Console.WriteLine("7.	List all Immobile equipment ");
                Console.WriteLine("8.	List all equipment that have not been moved till now");
                Console.WriteLine("9.	Delete all equipment");
                Console.WriteLine("10.	Delete all immobile equipment");
                Console.WriteLine("11.	Delete all mobile equipment");
                Console.WriteLine("12.	Exit");
                int input2=Int32.Parse(Console.ReadLine());


                switch(input2)
                {
                    case 1:
                        Console.WriteLine("1.Create an equipment ");

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
                            Equipment car = new mobileEquip(numOfWheels, name, description, 0, 0,0);
                            EquipList.Add(car);
                            car.moveBy(distanceToMove);
                            //car.show();
                        }

                        else if ((int)Equipment.equipmentType.IMMOBILE == type)
                        {
                            Equipment trolly = new immobileEquip(weight, name, description, 0, 0,1);
                            EquipList.Add(trolly);
                            trolly.moveBy(distanceToMove);
                            //trolly.show();

                        }
                        else
                        {
                            Console.WriteLine("You entered wrong type");
                        }
                        



                        break;
                    case 2:
                        int i = 0;
                        foreach (Equipment equip in EquipList)
                        {
                                
                            Console.WriteLine("No."+i+equip.name);
                            i++;
                        }


                            Console.WriteLine("Enter number of equipment to remove");
                        int indexNum = Int32.Parse(Console.ReadLine());
                        EquipList.RemoveAt(indexNum);
                        break;
                    case 3:
                        int i1 = 0;

                        foreach (Equipment equip1 in EquipList)
                        {

                            Console.WriteLine("No." + i1 + equip1.name);
                            i1++;
                        }

                        Console.WriteLine("Enter number of equipment to  which you are trying to move");
                        int indexNum1 = Int32.Parse(Console.ReadLine());

                     
                        Console.WriteLine("Enter distance to be move");
                        int d = Int32.Parse(Console.ReadLine());

                        EquipList[indexNum1].moveBy(d);
                


                        break;
                    case 4:
                        foreach (Equipment equip in EquipList)
                        {
                            Console.WriteLine(equip.name);
                        
                        }


                            break;
                    case 5:
                        foreach (Equipment equip in EquipList)
                        {
                            equip.show();
                        }
                        break;
                    case 6:
                        foreach (Equipment equip in EquipList)
                        {
                            if (equip.type_of_equip == (int)Equipment.equipmentType.MOBILE)
                            {
                                equip.show();
                            }
                        }


                        break;
                    case 7:
                        foreach (Equipment equip in EquipList)
                        {
                            if (equip.type_of_equip == (int)Equipment.equipmentType.IMMOBILE)
                            {
                                equip.show();
                            }
                        }


                        break;
                    case 8:
                        foreach (Equipment equip in EquipList)
                        {
                            if (equip.dist == 0)
                            {
                                equip.show();
                            }
                        }





                        break;
                    case 9:
                        EquipList.Clear();
                        break;
                    case 10:
                        foreach (Equipment equip in EquipList.ToArray())
                        { 
                            if(equip.type_of_equip == (int)Equipment.equipmentType.IMMOBILE)
                            {
                                EquipList.Remove(equip);
                            }
                                    
                                    
                        }
                            break;
                    case 11:
                        foreach (Equipment equip in EquipList.ToArray())
                        {
                            
                            if (equip.type_of_equip == (int)Equipment.equipmentType.MOBILE)
                            {
                                
                                EquipList.Remove(equip);
                                
                            }


                        }

                        break;
                    case 12:
                        return;


                }

            }
            
        }
    }
    abstract class Equipment
    {
        public String name;
        public String discription;
        public float dist = 0;
        public int maintaince = 0;
        public int type_of_equip;
        public enum equipmentType { MOBILE, IMMOBILE };

        public Equipment()
        {
        }
        public Equipment(String name, String discription, float dist, int maintaince,int type_of_equip)
        {
            this.name = name;
            this.discription = discription;
            this.dist = dist;
            this.maintaince = maintaince;
            this.type_of_equip = type_of_equip;


        }
        virtual public void moveBy(int d)
        {

           // Console.WriteLine("hi");
        }
        virtual public void show()
        {
            Console.WriteLine("name"+ name + " discription " + discription+" dist "+dist +" maintaince "+maintaince);

        }

    }
    class mobileEquip : Equipment
    {
        int numberOfWheels;
        public mobileEquip(int numberOfWheels, String name, String discription, float dist, int maintaince, int type_of_equip)
             : base(name, discription, dist, maintaince,0)
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
        public immobileEquip(int weight, String name, String discription, float dist, int maintaince,int type_of_equip)
            : base(name, discription, dist, maintaince,1)
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
