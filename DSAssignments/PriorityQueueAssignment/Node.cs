using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueueAssignment
{
    class Node<Type>
    {
        //next is used to point next element of list
        public Node<Type> next { get; set; }
        //data variable will contain data of linked list
        public int priority { get; set; }
        public Type data { get; set; }
        public Node(int priority,Type value)
        {
            this.priority = priority;
            data = value;
            next = null;
        }
        public Node() { }

    }
}
