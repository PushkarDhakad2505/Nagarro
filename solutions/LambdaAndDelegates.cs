using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace solutions
{
    //public delegate void WhereDelegate(List<int>intList);
    public delegate bool BoolDelegate(int i);

    public delegate bool BoolDelegateK(int i,int k);


    class Methods
    {
        public static void  AllMethod(List<int> IList,BoolDelegate isTrue)
        {
           
            foreach (int i in IList)
            {
                if (isTrue(i))
                {
                    Console.Write(i + " ");
                }
            }
        }

        public static bool AllMethodKBool(List<int> IList, BoolDelegateK isTrue,int k)
        {
            int flag = 0;
            
            foreach (int i in IList)
            {
                if (isTrue(i,k))
                {
                    flag = 1;
                }
                
            }
            if (flag == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void AllMethodK(List<int> IList, BoolDelegateK isTrue, int k)
        {

            foreach (int i in IList)
            {
                if (isTrue(i, k))
                {
                    Console.Write(i + " ");
                }

            }
        }




    }
    public class LambdaAndDelegates
    {
        static void Main(string[] args)
        {

            List<int> intList = new List<int>();
            intList.Add(2); intList.Add(3); intList.Add(4); intList.Add(5); intList.Add(6); intList.Add(7); intList.Add(8);
            Console.WriteLine("Odd method ");
            BoolDelegate isTrue1 = new BoolDelegate(oddMethod);
            Methods.AllMethod(intList, isTrue1);
            Console.WriteLine("");

            Console.WriteLine("Even using Lambda");
            Methods.AllMethod(intList,i=>i%2==0);
            Console.WriteLine("");
            Console.WriteLine("even method");
            BoolDelegate isTrue2 = new BoolDelegate(evenMethod);
            Methods.AllMethod(intList, isTrue2);
            Console.WriteLine("");
            Console.WriteLine("Prime using lambda");
            Methods.AllMethod(intList, i => PrimeMethod(i));

            Console.WriteLine("");
            Console.WriteLine("prime method using anonymous ");
            


            BoolDelegate isTrue3 = new BoolDelegate(PrimeMethod);
            BoolDelegate isTrue12 = delegate (int i)
            {
                int isPrime = 1;
                for (int j = 2; j < (i / 2) + 1; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = 0;
                        return false;

                    }
                }
                if (isPrime == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            };




            Methods.AllMethod(intList, isTrue3);





            Console.WriteLine("");
            Console.WriteLine("greater than five method");
            BoolDelegate isTrue4 = new BoolDelegate(ElementGtThanFiveMethod);
            Methods.AllMethod(intList, isTrue4);
            Console.WriteLine(""); 
            Console.WriteLine("less than five method");
            BoolDelegate isTrue5 = new BoolDelegate(ElementLtThanFiveMethod);
            Methods.AllMethod(intList, isTrue5);
            Console.WriteLine("");
            Console.WriteLine("Enter a number k");
            int k = Int32.Parse(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("equal to 3k method");
            BoolDelegateK isTrue6 = new BoolDelegateK(Find3k);
            Methods.AllMethodK(intList, isTrue6,k);


            Console.WriteLine("");
            Console.WriteLine("equal  to 3k+1 method");
            BoolDelegateK isTrue7 = new BoolDelegateK(Find3kPlus1);
            Methods.AllMethodK(intList, isTrue7,k);



            Console.WriteLine("");
            Console.WriteLine("equal  to 3k+1 using anonymous method");

            BoolDelegateK isTrue11 = delegate (int i,int k) 
            {
                if (i == (3 * k) + 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            };

            Methods.AllMethodKBool(intList,isTrue11,k);

            Console.WriteLine("");
            Console.WriteLine("equal  to 3k+2 method");
            BoolDelegateK isTrue8 = new BoolDelegateK(Find3kPlus2);
            Methods.AllMethodK(intList, isTrue8,k);

            Console.WriteLine("");
            Console.WriteLine("find anything method using anonymous method");
            Console.WriteLine("Enter a number to find if it exist or not ");
            int key = Int32.Parse(Console.ReadLine());
            BoolDelegateK isTrue10=delegate (int i,int k) 
            {
                if (i == k)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            };
            Console.WriteLine(Methods.AllMethodKBool(intList,isTrue10,key));

            Console.WriteLine("Find Anything using normal delegate");
            BoolDelegateK isTrue9 = new BoolDelegateK(FindAnything);
            Console.WriteLine(Methods.AllMethodKBool(intList, isTrue9, key));

            

        }
        public static bool evenMethod(int i)
        {
            if (i % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool oddMethod(int i)
        {
            if (i % 2 != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool PrimeMethod(int i)
        {
            int isPrime = 1;
            for (int j = 2; j < (i / 2) + 1; j++)
            {
                if (i % j == 0)
                {
                    isPrime = 0;
                    return false;
                   
                }
            }
            if (isPrime == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ElementGtThanFiveMethod(int i)
        {
                if (i > 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
        public static bool ElementLtThanFiveMethod(int i)
        {
            if (i < 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool Find3k(int i,int k)
        {
            if (i ==3*k)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool Find3kPlus1(int i, int k)
        {
            if (i ==(3*k)+1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool Find3kPlus2(int i, int k)
        {
            if (i ==(3*k)+2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool FindAnything(int i, int k)
        {
            if (i == k)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




    }
}

