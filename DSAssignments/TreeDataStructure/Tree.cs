using System;
using System.Collections.Generic;
using System.Text;

namespace TreeDataStructure
{
	class Tree
	{
		public static void Main(String[] args)
		{
			//Tree tree = new Tree();
			// Creating a root tree 
			Node<int> root = new Node<int>(100);
            //adding to root node
            root.AddChild(new Node<int>(1));
            root.AddChild(new Node<int>(2));
            root.AddChild(new Node<int>(3));

            //adding to first elements of root node
            root.child[0].AddChild(new Node<int>(4));
            root.child[0].AddChild(new Node<int>(5));
            //adding to second elements of root node

            root.child[1].AddChild(new Node<int>(6));
            //adding to third elements of root node

            root.child[2].AddChild(new Node<int>(7));
            root.child[2].AddChild(new Node<int>(8));
            //adding to first node first child of root node
            root.child[0].child[1].AddChild(new Node<int>(10));
            root.child[0].child[1].AddChild(new Node<int>(11));
            root.BFS();

            //for deletion
            root.child[0].child[1].deleteNode();

            while (true)
            {
                //this will prompt on screen 
                Console.WriteLine("enter option ");
                Console.WriteLine("1. for BFS ");
                Console.WriteLine("2. for DFS ");
                Console.WriteLine("3. for get elements by value ");
                Console.WriteLine("4. check it contains the element or not ");
                Console.WriteLine("5. to get elements by level");
                Console.WriteLine("6. iterator using  BFS ");
                Console.WriteLine("7. iterator using DFS ");

                int input = int.Parse(Console.ReadLine());
                int number;
                switch (input)
                {
                    case 1:
                        //bredth first search
                        root.BFS();
                        break;
                    case 2:
                        //depth first search
                        root.DFS();
                        break;
                    case 3:
                        //check whether it contains the elments or not
                        //if it contains then we will search 
                        Console.WriteLine("Enter the data to get element by value");
                        int data = int.Parse(Console.ReadLine());
                        if (root.Contains(data))
                            //if it contains then we will search 
                            root.getElementsByValue(data);
                        else
                            Console.WriteLine("");
                        throw new ElementDoesNotExistException("Cant return values because it doesnt exist");
                        break;
                    case 4:
                        //check whether it contains the elments or not
                        Console.WriteLine("Enter the number to find it exist or not ");
                        int Data = int.Parse(Console.ReadLine());
                        Console.WriteLine(root.Contains(Data));
                        break;
                    case 5:
                        //if it contains then we will search  levels
                        Console.WriteLine("enter level ");
                        int level = int.Parse(Console.ReadLine());
                        root.getElementsByLevel(level);
                        break;
                    case 6:
                        IEnumerable<string> ele1 = root.iteratorBFS();
                        foreach (var element in ele1)
                        {
                            Console.WriteLine(element);
                        }
                        break;
                    case 7:
                        IEnumerable<string> ele2 = root.iteratorDFS();
                        foreach (var element in ele2)
                        {
                            Console.WriteLine(element);
                        }
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
        }
	}
}
