using System;
using System.Collections.Generic;
using System.Text;

namespace linkedList
{
    class MyLinkedList<Type>
    {
        //Represent root element of linked list
        public Node<Type> Head;
        Node<Type> tempNode { get; set; }
        Node<Type> previous { get; set; }
        
        //function for insertion of data in beginning of linked list
        public void Insert(Type data)
        {
            Node<Type> TempNode = new Node<Type>(data);

            //checking if linked list is empty or not
            if (Head == null)
            {
                Head = TempNode;
            }
            //if list is not empty
            else
            {
                TempNode.next = Head;
                Head = TempNode;
            }
        }
        //insert at end of linked list
        public void InsertAtEnd(Type data)
        {
            Node<Type> TempNode = new Node<Type>(data);
            //checking if linked list is empty or not
            if (Head == null)
            {
                Head = TempNode;
            }
            //if list is not empty
            else
            {
                Node<Type> TemperoryNode = Head;
                //we will traverse till end 
                while (TemperoryNode.next != null)
                {
                    TemperoryNode = TemperoryNode.next;
                }
                TemperoryNode.next = TempNode;
            }
        }

        //function for insertion of data at given position
        public void InsertAt(Type data, int index)
        {
            try
            {
                //if entered index is larger than size of linked list then throw error
                if (index > Size())
                {
                    throw new InvalidIndexInputException("please enter valid index");
                }
                else
                {
                    Node<Type> TemperoryNode = new Node<Type>(data);

                    int counter = 0;
                    // temperary variable for holding linked list node data
                    Node<Type> TempNode = Head;
                    //previous node will keep track of one node before the current node
                    Node<Type> PreviousNode = null;
                    while (counter < index)
                    {
                        PreviousNode = TempNode;
                        TempNode = TempNode.next;
                        counter++;
                    }
                    PreviousNode.next = TemperoryNode;
                    TemperoryNode.next = TempNode;
                }
            }
            catch (InvalidIndexInputException iiiException)
            {
                Console.WriteLine(iiiException);
            }
        }
        //function to delete a data from beginning
        public void Delete()
        {
            try
            {
                if (Head != null)
                {
                    //Node<Type> TempNode = Head;
                    Head = Head.next;
                }
                else
                {
                    throw new EmptyListException("cant delete, List is empty");
                }
            }
            catch (EmptyListException eleException)
            {
                Console.WriteLine(eleException);
            }
        }
        //function to delete data at specified index/position
        public void DeleteAt(int index)
        {
            int counter = 0;
            try
            { 
                if (Head != null && index < Size())
                {
                    if (index == 0)
                    {
                        //Node<Type> TempNode = Head;
                        Head = Head.next;
                    }
                    else
                    {
                        Node<Type> TemperoryNode = Head;
                        Node<Type> PreviousNode = null;
                        //previous node will keep track of one node before the current node
                        while (counter <= index)
                        {
                            PreviousNode = TemperoryNode;
                            TemperoryNode = TemperoryNode.next;
                            counter++;
                        }
                        PreviousNode.next = TemperoryNode.next;
                    }
                }
                else if (index >= Size())
                {
                    throw new InvalidIndexInputException("please enter valid index");
                }
            }
            catch (InvalidIndexInputException iiiException)
            {
                Console.WriteLine(iiiException);
            }
        }
        //gives center element of linked list
        public Type Center()
        {
            int CenterIndex = Size()/2;
            int iteratorVariable = 1;
            Node<Type> TempNode = Head;
            while (iteratorVariable<=CenterIndex)
            {
                iteratorVariable++;
                TempNode = TempNode.next;
            }
            return (TempNode.data);
        }
        //below function is used to reverse linked list
        public void Reverse()
        {
            Node<Type> NextNode = null;
            Node<Type> PreviousNode = null;
            Node<Type> TempNode = Head;
            //logic to reverse linked list
            while (TempNode!=null)
            {
                NextNode = TempNode.next;
                TempNode.next = PreviousNode;
                PreviousNode = TempNode;
                TempNode = NextNode;
            }
            Head = PreviousNode;
        }
        //it will return size of linked list
        public int Size()
        {
            int length = 0;
            Node<Type> TempNode = Head;
            while (TempNode != null)
            {
                length++;
                TempNode = TempNode.next;
            }
            return length;
        }
        //used to traverse or print linked list
        public void Traverse()
        {
            tempNode = Head;
            while (tempNode != null)
            {
                Console.WriteLine(tempNode.data);
                tempNode = tempNode.next;
            }
        }
        public IEnumerable<Type> iterator()
        {
            Node<Type> temp = Head;
            while (temp != null)
            {
                yield return temp.data;
                temp = temp.next;
            }
        }
    }
}



