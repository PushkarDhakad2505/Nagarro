using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
using System.Reflection;
namespace solutions
{

    public class PriorityNode
    {
        /// 

        /// Gets or sets the priority.
        /// 
        /// The priority.
        public int Priority { get; set; }
    }
    public class Process : PriorityNode
    {
        /// 

        /// Gets or sets the name.
        /// 
        /// The name.
        public string Name { get; set; }
    }




    public class PriorityQueue<T> : IEnumerable<T> where T : PriorityNode
    {
        /// 

        /// The sorted dictionary
        /// 
        private readonly SortedDictionary<int, Queue<T>> _dictionary;

        /// 

        /// Initializes a new instance of the  class.
        /// 
        public PriorityQueue()
        {
            _dictionary = new SortedDictionary<int, Queue<T>>();
        }

        /// 

        /// Initializes a new instance of the  class.
        /// 
        /// The collection.
        public PriorityQueue(IEnumerable<T> collection)
        {
            _dictionary = new SortedDictionary<int, Queue<T>>();

            foreach (T item in collection)
            {
                Enqueue(item.Priority, item);
            }
        }

        /// 

        /// Gets the number of items in the dictionary.
        /// 
        /// The count.
        public int Count { get; private set; }

        /// 

        /// Enqueues the specified (key, value) pair.
        /// 
        /// The key.
        /// The value.
        public void Enqueue(int key, T value)
        {
            value.Priority = key;
            Queue<T> list;
            if (!_dictionary.TryGetValue(key, out list))
            {
                list = new Queue<T>();
                _dictionary.Add(key, list);
            }

            list.Enqueue(value);
            Count++;
        }

        /// 

        /// Dequeues this instance.
        /// 
        /// T.
        public T Dequeue()
        {
            var first = _dictionary.First();
            var item = first.Value.Dequeue();
            if (!first.Value.Any())
            {
                _dictionary.Remove(first.Key);
            }

            Count--;
            return item;
        }

        /// 

        /// Peeks this instance.
        /// 
        /// An item of data type T if priority queue is not empty, otherwise null.
        public T Peek()
        {
            return _dictionary.Count == 0 ? null : _dictionary.First().Value.Peek();
        }

        /// 

        /// Clears this instance.
        /// 
        public void Clear()
        {
            Count = 0;
            _dictionary.Clear();
        }

        /// 

        /// Determines whether the instance [contains] [the specified item].
        /// 
        /// The item.
        /// true if [contains] [the specified item]; otherwise, false.
        public bool Contains(T item)
        {
            bool isContains = false;

            foreach (var otherItem in _dictionary.Values.ToArray().SelectMany(elem => elem))
            {
                foreach (PropertyInfo prop in item.GetType().GetProperties())
                {
                    isContains = prop.GetValue(item, null).Equals(prop.GetValue(otherItem, null));
                    if (!isContains)
                        break;
                }

                if (isContains == true)
                {
                    break;
                }
            }

            return isContains;
        }

        /// 

        /// Filters the items of dictionary according to the condition.
        /// 
        /// The item.
        /// true if condition is satisfied, false otherwise.
        public bool FilterCondition(T item)
        {
            return item.Priority < 6; //change it to whatever condition you want
        }

        /// 

        /// Filters the items of dictionary according to the specified predicate.
        /// 
        /// The predicate.
        /// filtered list of items of data-type T.
        public IEnumerable<T> Filter(Func<T, bool> predicate)
        {
            return this._dictionary.Values.ToArray().SelectMany(item => item).Where(predicate);

        }

        /// 

        /// Returns an enumerator that iterates through the collection.
        /// 
        /// A  that can be used to iterate through the collection.
        public IEnumerator<T> GetEnumerator()
        {
            return _dictionary.Keys.ToArray().SelectMany(key => _dictionary[key]).GetEnumerator();
        }

        /// 

        /// Returns an enumerator that iterates through a collection.
        /// 
        /// An  object that can be used to iterate through the collection.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }





























































































    class MainClass
    {

        static void Main()
        {
            var processQueue = new PriorityQueue<Process>();

            processQueue.Enqueue(3, new Process { Name = "Read" });
            processQueue.Enqueue(7, new Process { Name = "Write" });
            processQueue.Enqueue(3, new Process { Name = "Delete" });
            processQueue.Enqueue(4, new Process { Name = "Close" });
            processQueue.Enqueue(8, new Process { Name = "Open" });
            processQueue.Enqueue(1, new Process { Name = "Cancel" });

            Console.WriteLine("Item in the process queue");
            Console.WriteLine("--------------------------");
            foreach (var item in processQueue)
            {
                Console.WriteLine("Priority : {0}, Name : {1}", item.Priority, item.Name);
            }

            Console.WriteLine("********************************************************************");
            Console.WriteLine(Environment.NewLine + "Total items in priority queue are : {0}", processQueue.Count);
            Console.WriteLine("********************************************************************");

            Console.WriteLine(Environment.NewLine + "The element removed during first dequeue");
            Console.WriteLine("-----------------------------------------");
            Process process2 = processQueue.Dequeue();
            Console.WriteLine("Priority : {0}, Name : {1}", process2.Priority, process2.Name);
            Console.WriteLine("********************************************************************");

            Console.WriteLine(Environment.NewLine + "Check if the data of following object is in priority queue");
            Console.WriteLine("-----------------------------------------------------------");
            var process1 = new Process { Priority = 3, Name = "Delete" };
            Console.WriteLine("Priority : {0}, Name : {1}", process1.Priority, process1.Name);
            Console.WriteLine(processQueue.Contains(process1));
            Console.WriteLine("********************************************************************");

            if (processQueue.Peek() != null)
            {
                Console.WriteLine(
                    Environment.NewLine + "Peek :" + Environment.NewLine + "-------" + Environment.NewLine + "Priority : {0} Name : {1}",
                    processQueue.Peek().Priority, processQueue.Peek().Name);
            }
            else
            {
                Console.WriteLine("Priority Queue is empty!");
            }

            Console.WriteLine("********************************************************************");
            Console.WriteLine(Environment.NewLine + "Filtered data using Filter method with condition that priority < 6");
            Console.WriteLine("----------------------------------------------------------------");
            IEnumerable<Process> filteredResult = processQueue.Filter(processQueue.FilterCondition);
            foreach (var item in filteredResult)
            {
                Console.WriteLine("Priority : {0}, Name : {1}", item.Priority, item.Name);
            }

            Console.WriteLine("********************************************************************");
            Console.WriteLine(Environment.NewLine + "Filtered data using linq with condition that priority < 6");
            Console.WriteLine("---------------------------------------------------------");

            foreach (var item in processQueue.Where(item => item.Priority < 6))
            {
                Console.WriteLine("Priority : {0}, Name : {1}", item.Priority, item.Name);
            }

            Console.WriteLine("********************************************************************");

            processQueue.Clear();
            Console.WriteLine(Environment.NewLine + "The number of items in the process queue after clear() : {0}", processQueue.Count);
            Console.ReadKey();

        }






    }
}
