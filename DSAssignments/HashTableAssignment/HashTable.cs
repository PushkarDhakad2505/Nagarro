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
            //setting each bucket to null 
            for (int i = 0; i < SizeOfTable; i++)
            {
                bucket[i] = null;
            }
        }

        //it will retun index of bucket based on key of a node

        int GetBucketByKey(int x)
        {
            return x % SizeOfTable;
        }

        //it will return current and previous node
        (Node<Type> previous, Node<Type> Current) GetNodeByKey(int keys)
        {
            //getting index of bucket from key
            int pos = GetBucketByKey(keys);
            //pre and temp will hold previous and current node respectively
            Node<Type> temp = bucket[pos];
            Node<Type> pre = null;
            //searching for the key in bucket
            while (temp != null)
            {
                //if found return
                if (temp.key == keys)
                {
                    return (pre, temp); 
                }
                pre = temp;
                temp = temp.next;
            }
            //else will return null values
            return (null, null);

        }

        //insert items and keys in particular bucket
        public void Insert(Type item, int keys)
        {
            int pos = GetBucketByKey(keys);
            Node<Type> newNode = new Node<Type>(item, keys);
           //if bucket is empty then set first node directly at first position
            if (bucket[pos] == null)
            {
                bucket[pos] = newNode;
            }
            //else iterate till the last node of particular bucket and then add
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

        //checking if it contains the key or not
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
            //iterate for every bucket
            for (int i = 0; i < SizeOfTable; i++)
            {
                Node<Type> temp = bucket[i];
                //iterate for every node in particular bucket
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

            //getting position from key
            int pos = GetBucketByKey(keys);
            //getting previous and current node from key
            var (previous, current) = GetNodeByKey(keys);
            try
            {
                //if key not found
                if (current == null && previous == null)
                    throw new KeyNotFoundException("KeyNotFoundException");
                //if key found
                else
                {
                    //first element
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
