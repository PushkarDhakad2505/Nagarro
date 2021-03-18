using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueueAssignment
{
    class MyPriorityQueue<Type>
    {

        //used to represent front and rear node of queue
        public Node<Type> Head;
        public Node<Type> Tail;
        public void Enqueue(int priority, Type data) 
        {

            Node<Type> TempNode = new Node<Type>(priority, data);
            //checking if queue is empty or not
            if (Tail == null)
            {
                Tail = TempNode;
                Head = TempNode;
            }
            //if queue is not empty
            else
            {
                Node<Type> PreviousNode = null;
                Node<Type> tempNode = Head;

                //logic to get to the that correct priority position of  linked list
                int flagIsHighestPriority = 1;
                while (tempNode != null && tempNode.priority<=priority )
                {
                    flagIsHighestPriority = 0;
                    PreviousNode = tempNode;
                    tempNode = tempNode.next;
                }
                if(flagIsHighestPriority == 0)
                {
                    PreviousNode.next = TempNode;
                    TempNode.next = tempNode;
                    Tail = TempNode;
                }
                else
                {
                    TempNode.next = Head;
                    Head = TempNode; }
                }
            }
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
        public void Peek()
        {
            //variable to return peek value
           
            try
            {
                if (Head != null)
                {
                    Console.WriteLine("Priority is {0} and element is {1} ", Head.priority, Head.data);
                }
                else
                {
                    throw new EmptyListException(" queue is empty");
                }
            }
            catch (EmptyListException eleException)
            {
                Console.WriteLine(eleException);
            }
        }
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
                Console.WriteLine("Priority is {0} and element is {1} ", TempNode.priority,TempNode.data);
                //Console.WriteLine(TempNode.data);
                TempNode = TempNode.next;
                //Dequeue();
            }
        }
        public void Reverse()
        {
            Node<Type> NextNode = null;
            Node<Type> PreviousNode = null;
            Node<Type> TempNode = Head;
            Node<Type> AnotherTempNode = Head;
            //logic to reverse linked list
            while (TempNode != null)
            {
                NextNode = TempNode.next;
                TempNode.next = PreviousNode;
                PreviousNode = TempNode;
                TempNode = NextNode;
            }
            Head = PreviousNode;
            Tail=AnotherTempNode;

        }

        public IEnumerable<string> iterator()
        {
            Node<Type> temp = Head;
            while (temp != null)
            {
                yield return "Priority is "+temp.priority.ToString()+" data is "+temp.data.ToString();
                temp = temp.next;
            }

        }



    }
}
