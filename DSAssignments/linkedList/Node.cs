using System;
using System.Collections.Generic;
using System.Text;

namespace linkedList
{
    //below class is used to represent node of linked list
    class Node<Type>
    {
        //next is used to point next element of list
        public Node<Type> next { get; set; }
        //data variable will contain data of linked list
        public Type data { get; set; }
        public Node(Type value)
        {
            data = value;
            next = null;
        }
        public Node() { }
    }
}
