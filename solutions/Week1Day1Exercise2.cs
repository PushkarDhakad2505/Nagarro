using System;
using System.Collections.Generic;
using System.Text;

namespace solutions
{
    class Week1Day1Exercise2
    {
        

        static void Main(string[] args)
        {
            //conversion of integer
            Console.WriteLine("enter a number:");
            String s = Console.ReadLine();
            //string by default
            Console.WriteLine("you entered " + s);

            int FirstInt = Int16.Parse(s);
            int SecInt = Int32.Parse(s);
            long ThirdInt = Int64.Parse(s);
            Console.WriteLine("SUM=" + (FirstInt + SecInt + ThirdInt));
            // give error when pass null value
            //String s2=null;
            //int.pareseInt(s2);//gives argument null exception


            Console.WriteLine(Convert.ToInt16(s));
            Console.WriteLine(Convert.ToInt32(s));
            Console.WriteLine(Convert.ToInt64(s));

            //not give argument null exception
            String s2 = null;
            Console.WriteLine(Convert.ToInt64(s2));//gives zero

            //but above both type of format give error like FormatException,  OverflowException	
            //for that we use int.tryParse Method
            //it takse two parameter other one is by default value if parsing failed default value returned
            int def = 0;
            int.TryParse(s, out def);
            Console.WriteLine(def);

            //conversion to float
            String stringInFloat = Console.ReadLine();


            float b = float.Parse("8.8");
            Console.WriteLine(b);
            //using convert.ToDouble method 
            //more precise
            Console.WriteLine(Convert.ToDouble(stringInFloat));


            //conversion to bool
            Console.WriteLine("Enter either true or false ");
            String val = Console.ReadLine();
            bool boolean_val = bool.Parse(val);
            Console.WriteLine(boolean_val);

        }



    }
}
