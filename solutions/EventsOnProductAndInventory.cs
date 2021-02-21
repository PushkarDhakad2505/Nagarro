using System;
using System.Collections.Generic;
using System.Text;
namespace solutions
{
    public  delegate void InventoryDelegate();

    public delegate void InventoryPriceDelegate();
    class Product
    {
        public event  InventoryDelegate  EventTORemove;
        public event InventoryPriceDelegate EventTOChangePrice;
        public int id;
        public double price;
        public bool isDefective;
        Inventory i = new Inventory();


        public void defective()
        {
            isDefective = true;
            EventTORemove?.Invoke();
        }
        public void ChangePrice()
        {
            price = 10;
            EventTOChangePrice?.Invoke();
        }






        public Product(){}
        public Product(int id, double price, bool isDefective)
        {
            this.id = id;
            this.price = price;
            this.isDefective = isDefective;
        }
    }
    class Inventory
    {

        



        public event InventoryDelegate RemovingDefective;
        static public int quantity;
        static public Dictionary<Product, int> inventDict = new Dictionary<Product, int>();
        static public double Inventvalue;
        public void AddProduct(Product p, int quant)
        {
            inventDict.Add(p, quant);
        }
        public void RemoveProduct(Product p)
        {
            inventDict.Remove(p);
        }
        public void UpdateQuantity(Product p, int quant)
        {
            inventDict[p] = quant;
        }

        public void CalculateValue()
        {
            Inventvalue = 0;
            foreach (var oneProduct in inventDict)
            {
                Console.WriteLine("Price " + oneProduct.Key.price);
                Console.WriteLine("Quantitiy " + oneProduct.Value);
                Inventvalue = oneProduct.Key.price * oneProduct.Value + Inventvalue;
            }
        }

        public void RemoveDefective()
        {
            foreach (var oneProduct in inventDict)
            {
                if (oneProduct.Key.isDefective == true)
                {
                    inventDict.Remove(oneProduct.Key);
                }
            }
           
        }
        public void OnRemovingDefective()
        {
            RemovingDefective.Invoke();
        }
        public void getValue()
        {
            //RemoveDefective();
            CalculateValue();
            Console.WriteLine("Invent value "+Inventvalue);
        }
    }
    class EventsOnProductAndInventory
    {

        public static void Main()
        {
            Product laptop = new Product(1234, 45000, false);
            Product monitor = new Product(2234, 5000, false);
            Product mouse = new Product(3234, 400, false);
            
            Inventory invent = new Inventory();



















            //monitor.defective();
            //
            invent.RemovingDefective += a;
            //invent.OnRemovingDefective();
           
            invent.AddProduct(laptop,10);
            invent.AddProduct(monitor, 20);
            invent.AddProduct(mouse, 30);

            Console.WriteLine("--------------------");
            invent.getValue();

            Console.WriteLine("--------------------");
            invent.RemoveProduct(laptop);
            invent.getValue();

            Console.WriteLine("--------------------");
            invent.UpdateQuantity(monitor,30);
            invent.getValue();

            Console.WriteLine("--------------------");
            Console.WriteLine("--------------------");

            invent.getValue();

            Console.WriteLine("--------------------");
            Console.WriteLine(monitor.price);


            ////////////////////////////

            monitor.EventTOChangePrice += b;
            monitor.ChangePrice();
            void b()
            {

                Console.WriteLine("+++++++++");
                invent.CalculateValue();
            }


            ///////////////////////


            invent.getValue();

            Console.WriteLine(monitor.price);
            Console.WriteLine("--------------------");
            Console.WriteLine("--------------------");
           // monitor.isDefective = true;
            
            invent.getValue();

            monitor.EventTORemove += a;
            monitor.defective();
            void a()
            {
                Console.WriteLine("*******");
                invent.RemoveDefective();
            }







            invent.getValue();

        }
    }
}
