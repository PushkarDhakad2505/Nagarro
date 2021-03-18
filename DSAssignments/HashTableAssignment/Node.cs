using System;
using System.Collections.Generic;
using System.Text;

namespace HashTableAssignment
{
  
    public class Node<Type>
    {
        public Type data;
        public int key;
        public Node<Type> next;

        //Initializing node
        public Node(Type val, int val1)
        {
            key = val1;
            data = val;
            next = null;
        }
    }
}
