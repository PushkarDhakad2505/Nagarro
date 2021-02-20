using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
namespace solutions
{
    class Person
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public Person() { }
        public Person(string FirstName, string LastName, int Age)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.LastName = LastName;
        }
    }

    class CollectionAndEvents1
    {
        static void Main(string[] args)
        {
            // Make a collection to observe and add a few Person objects.
            ObservableCollection<Person> people = new ObservableCollection<Person>()
             {
                new Person{ FirstName = "Pushkar", LastName = "Dhakad", Age = 21 },
                new Person{ FirstName = "Dhakad", LastName = "Pushkar", Age = 22 },
             };
            people.CollectionChanged += peopleChanged;
            people.Add(new Person("Ram", "Shyam", 23));

            people.RemoveAt(0);

        }
        static void peopleChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            Console.WriteLine("Action for this event: {0}", e.Action);

            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Person p in e.OldItems)
                {
                    Console.WriteLine("Element " + p.FirstName + " is removed");
                }
                Console.WriteLine();
            }

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Here are the NEW items:");
                foreach (Person p in e.NewItems)
                {
                    Console.WriteLine("Element " + p.FirstName + " is added");
                }
            }
        }


    }
}
