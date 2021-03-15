using System;
using System.Collections.Generic;
using System.Text;

namespace StackDataStructure
{
    class MyStack<Type>
    {
        public Node<Type> Top;
        public void Push(Type data)
        {

            Node<Type> TempNode = new Node<Type>(data);
            //checking if linked list is empty or not
            if (Top == null)
            {
                Top = TempNode;
            }
            //if list is not empty
            else
            {
                TempNode.next = Top;
                Top = TempNode;
            }
        }
        public void Pop()
        {
            try
            {

                if (Top != null)
                {
                    Top = Top.next;
                }
                else
                {
                    throw new EmptyListException("  can't pop stack is empty");
                }
            }
            catch (EmptyListException eleException)
            {
                Console.WriteLine(eleException);
            }


        }
        public void Peek()
        {
            try
            {
                if (Top != null)
                {
                    Console.WriteLine(Top.data);
                }
                else
                {
                    throw new EmptyListException(" stack is empty");
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
            Node<Type> TempNode = Top;
            while (TempNode != null)
            {
                length++;
                TempNode = TempNode.next;
            }

            return length;
        }

        public bool Contains( Type data)
        {
            Node<Type> TempNode ;
            TempNode = Top;
            while (TempNode != null)
            {
                if (TempNode.data.Equals(data) )
                {
                    return true;
                }
                TempNode = TempNode.next;
            }
            return false;
        }
        public void Traverse()
        {
            Node<Type> TempNode;
            TempNode = Top;
            while (TempNode != null)
            {
                Console.WriteLine(TempNode.data);
                TempNode = TempNode.next;
                //Pop();
            }
        }


        public void Reverse()
        {
            Node<Type> NextNode = null;
            Node<Type> PreviousNode = null;
            Node<Type> TempNode = Top;
            //logic to reverse linked list
            while (TempNode != null)
            {
                NextNode = TempNode.next;
                TempNode.next = PreviousNode;
                PreviousNode = TempNode;
                TempNode = NextNode;
            }
            Top = PreviousNode;

        }

    }
}
