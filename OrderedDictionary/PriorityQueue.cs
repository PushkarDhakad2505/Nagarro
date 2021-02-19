using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
using System.Reflection;
namespace OrderedDictionary
{
    class PriorityQueue<T> : IEnumerable<T> where T : PriorityNode
    {
        


        private readonly SortedDictionary<int, Queue<T>> _dictionary;

        public PriorityQueue()
        {
            _dictionary = new SortedDictionary<int, Queue<T>>();
        }

       
        public PriorityQueue(IEnumerable<T> collection)
        {
            _dictionary = new SortedDictionary<int, Queue<T>>();

            foreach (T item in collection)
            {
                Enqueue(item.Priority, item);
            }
        }

      
        public int Count { get; private set; }

     
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

          public T Peek()
        {
            return _dictionary.Count == 0 ? null : _dictionary.First().Value.Peek();
        }

        
        public void Clear()
        {
            Count = 0;
            _dictionary.Clear();
        }

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

        public bool FilterCondition(T item)
        {
            return item.Priority < 6; //change it to whatever condition you want
        }

        public IEnumerable<T> Filter(Func<T, bool> predicate)
        {
            return this._dictionary.Values.ToArray().SelectMany(item => item).Where(predicate);

        }

        public IEnumerator<T> GetEnumerator()
        {
            return _dictionary.Keys.ToArray().SelectMany(key => _dictionary[key]).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
