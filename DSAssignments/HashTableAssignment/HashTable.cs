using System;
using System.Collections.Generic;
using System.Text;

namespace HashTableAssignment
{
    public class HashTable<Type>
    {
        //creating array of buckets
        Node<Type>[] bucket;
        public int SizeOfTable;
        //initializing hashtable
        public HashTable(int size)
        {
            SizeOfTable = size;
            bucket = new Node<Type>[SizeOfTable];
            for (int i = 0; i < SizeOfTable; i++)
            {
                bucket[i] = null;
            }
        }

        //internal methods

        int GetBucketByKey(int x)
        {
            return x % SizeOfTable;
        }

        (Node<Type> previous, Node<Type> Current) GetNodeByKey(int keys)
        {
            int pos = GetBucketByKey(keys);
            Node<Type> temp = bucket[pos];
            Node<Type> p = null;
            while (temp != null)
            {
                if (temp.key == keys) { return (p, temp); }
                p = temp;
                temp = temp.next;
            }
            return (null, null);

        }

        //insert
        public void Insert(Type item, int keys)
        {
            int pos = GetBucketByKey(keys);
            Node<Type> newNode = new Node<Type>(item, keys);
            if (bucket[pos] == null)
            {
                bucket[pos] = newNode;
            }
            else
            {
                Node<Type> temp = bucket[pos];
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = newNode;
            }
            Console.WriteLine("{0} with key {1} inserted at bucket {2}", item, keys, pos);
        }

        //contains(checking if contains value by key)
        public bool Containskey(int keys)
        {
            var (prev, current) = GetNodeByKey(keys);
            return current != null;
        }

        //Traverse
        public void Print()
        {
            Console.WriteLine("Hash Table:(data,key) ");
            for (int i = 0; i < SizeOfTable; i++)
            {
                Console.Write("bucket {0}: ", i);
                Node<Type> temp = bucket[i];
                while (temp != null)
                {
                    Console.Write("{0},{1} -> ", temp.data, temp.key);
                    temp = temp.next;
                }
                Console.Write("NULL");
                Console.WriteLine();
            }
        }

        //Size or number of elements
        public int Size()
        {
            int len = 0;
            for (int i = 0; i < SizeOfTable; i++)
            {
                Node<Type> temp = bucket[i];
                while (temp != null)
                {
                    len = len + 1;
                    temp = temp.next;
                }
            }
            return len;
        }

        //Delete by key
        public void Delete(int keys)
        {
            int pos = GetBucketByKey(keys);
            var (previous, current) = GetNodeByKey(keys);
            try
            {
                if (current == null && previous == null)
                    throw new KeyNotFoundException("KeyNotFoundException");
                else
                {
                    if (previous == null)
                    {
                        bucket[pos] = current.next;
                    }
                    else
                    {
                        previous.next = current.next;
                    }
                    Console.WriteLine("value {0} deleted with key {1}", current.data, keys);
                }
            }
            catch (KeyNotFoundException knfException)
            {
                Console.WriteLine(knfException);
            }
        }

        //get value by key
        public Type GetValueByKey(int keys)
        {
            var (prev, temp) = GetNodeByKey(keys);
            
            if (temp == null) 
                throw new KeyNotFoundException("Key not found");
            return temp.data;
        }

        //iterators
        public IEnumerable<string> iterator()
        {
            for (int i = 0; i < SizeOfTable; i++)
            {
                Node<Type> temp = bucket[i];
                while (temp != null)
                {
                    yield return temp.data.ToString();
                    temp = temp.next;
                }
            }
        }

    }
}
