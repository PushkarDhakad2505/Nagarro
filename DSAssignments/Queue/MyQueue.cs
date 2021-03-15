using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    class MyQueue<Type>
    {
        //used to represent front and rear node of queue
        public Node<Type> Head;
        public Node<Type> Tail;

        public void Enqueue(Type data)
        {

            Node<Type> TempNode = new Node<Type>(data);
            //checking if queue is empty or not
            if (Tail == null)
            {
                Tail = TempNode;
                Head = TempNode;
            }
            //if queue is not empty
            else
            {
                Tail.next = TempNode;
                Tail = TempNode;
            }
        }
        //deleteting the element from head of the queue
        public void Dequeue()
        {
            try
            {
                //if queue is not empty
                if (Head != null)
                {
                    Head = Head.next;
                    if (Head == null)
                    {
                        Tail = null;
                    }
                }
                //if queue is empty
                else
                {
                    throw new EmptyListException("cant delete, queue is empty");
                }
            }
            catch (EmptyListException eleException)
            {
                Console.WriteLine(eleException);
            }

        }
        //get first element from the queue
        public Type Peek()
        {
            //variable to return peek value
            //it is assigned default because in Exceptional condition it will return dafault value
            Type variable=default;
            try
            {
                if (Head != null)
                {
                    return(Head.data);
                }
                else
                {
                    throw new EmptyListException(" queue is empty");
                    return variable;
                }
            }
            catch (EmptyListException eleException)
            {
                Console.WriteLine(eleException);
                return variable;
            }
        }
        //return size of the queue
        public int Size()
        {
            int length = 0;
            Node<Type> TempNode = Head;
            //calculate the size by reaching till the end of queue
            while (TempNode != null)
            {
                length++;
                TempNode = TempNode.next;
            }
            return length;
        }
        //check if the queue contains specific data or not
        public bool Contains(Type data)
        {
            Node<Type> TempNode;
            TempNode = Head;
            while (TempNode != null)
            {
                //comparing input with data in linked list
                if (TempNode.data.Equals(data))
                {
                    return true;
                }
                TempNode = TempNode.next;
            }
            return false;
        }
        //printing all the elements
        public void Traverse()
        {
            Node<Type> TempNode;
            TempNode = Head;
            while (TempNode != null)
            {
                Console.WriteLine(TempNode.data);
                TempNode = TempNode.next;
                //Dequeue();
            }
        }
        public void Reverse()
        {
            Stack<Type> stack = new Stack<Type>();
            while (this.Size() > 0)
            {
                stack.Push(Peek());
                this.Dequeue();
            }
            while (stack.Count > 0)
            {
                this.Enqueue(stack.Peek());
                stack.Pop();
            }
        }
    }
}