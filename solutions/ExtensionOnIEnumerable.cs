using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace solutions
{

    delegate void CustomDelegate();
    static class ExtensionClass
    {
        public static void CustomAll(this IEnumerable i)
        {

            bool AllStdudentRollIsOne = ExtensionOnIEnumerable.StudentList.All(s => s.roll == 1);
            Console.WriteLine(AllStdudentRollIsOne);
        }
        public static void CustomAny(this IEnumerable i)
        {
            bool AnyStdudentRollIsOne = ExtensionOnIEnumerable.StudentList.Any(s => s.roll == 1);
            Console.WriteLine(AnyStdudentRollIsOne);
        }
        public static void CustomMax(this IEnumerable i)
        {
            //Console.WriteLine(ExtensionOnIEnumerable.StudentList.Max());
            Console.WriteLine("Max");
            Console.WriteLine((from emp in ExtensionOnIEnumerable.StudentList select emp).Max(e => e.roll));



        }
        public static void CustomMin(this IEnumerable i)
        {
            Console.WriteLine("Min");
            //Console.WriteLine(ExtensionOnIEnumerable.StudentList.Min());
            Console.WriteLine((from emp in ExtensionOnIEnumerable.StudentList select emp).Min(e => e.roll));
        }
        public static void CustomWhere(this IEnumerable i)
        {

            List<Student> basicWhere = (from s in ExtensionOnIEnumerable.StudentList where s.roll > 0 && s.roll < 3 select s).ToList();
           
            foreach (Student s in basicWhere)
            {
                Console.WriteLine("Roll " + s.roll + " Name " + s.name);


            }
        }
        public static void CustomSelect(this IEnumerable i)
        {
            List<Student> basicselect = (from st in ExtensionOnIEnumerable.StudentList select st).ToList();
            Console.WriteLine("Selected");
            foreach (Student s in basicselect)
            {
                Console.WriteLine(" Roll " + s.roll + " Name " + s.name);


            }

        }


    }

    class Student
    {
        public int roll;
        public string name;
        public Student(int roll, string name)
        {
            this.name = name;
            this.roll = roll;
        }

    }
    public class ExtensionOnIEnumerable
    {
        internal static List<Student> StudentList = new List<Student>();


        static void Main()
        {
            Student pushkar = new Student(1, "Pushkar");
            Student Dhakad = new Student(2, "Dhakad");
            Student ram = new Student(3, "Ram");
            Student shyam = new Student(4, "Shyam");
            Student mohan = new Student(5, "Mohan");
            StudentList.Add(pushkar);
            StudentList.Add(Dhakad);
            StudentList.Add(ram);
            StudentList.Add(shyam);
            StudentList.Add(mohan);

            CustomDelegate cd1 = new CustomDelegate(StudentList.CustomSelect);
            cd1();
            Console.WriteLine("all have roll number 1?");
            
            CustomDelegate cd2 = new CustomDelegate(StudentList.CustomAll);
            cd2();
            Console.WriteLine("Anyone have roll number 1?");
            
            CustomDelegate cd3 = new CustomDelegate(StudentList.CustomAny);
            cd3();

            
            CustomDelegate cd4 = new CustomDelegate(StudentList.CustomMax);
            cd4();
            CustomDelegate cd5 = new CustomDelegate(StudentList.CustomMin);
            cd5();
            Console.WriteLine("select where roll number is between 1 and 3");
            CustomDelegate cd6 = new CustomDelegate(StudentList.CustomWhere);
            cd6();

        }


    }
}
