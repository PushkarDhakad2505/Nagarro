using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TreeDataStructure
{
	public class Node<Type>
	{
		//key will store data and child will keep track of child nodes
		public Type key;
		public Node<Type> parent;
		public List<Node<Type>> child = new List<Node<Type>>();
		
		//set data inside node element
		public Node(Type data)
		{
			key = data;
		}
		//set parent node
		public void setParent(Node<Type> parent)
        {
			this.parent = parent;
        }
		//used to add child to any node by setting its  parent and  adding data to linked list
		public void  AddChild(Node<Type> childNode)
        {
			childNode.setParent(this);
			this.child.Add(childNode);
        }
		//it will return list of child nodes of parent
		public List<Node<Type>> getChildren()
        {
			return child;
        }

		//used to delete a particular node
		public void deleteNode()
		{
			//if the node which we have to delete is not root element then
			if (parent != null)
			{ 
				//removing that node
				this.parent.getChildren().Remove(this);
				//setting the parent for the children of deleted node 
				foreach (Node<Type> eachChild in getChildren())
				{
					eachChild.setParent(this.parent);
				}
				//adding children to the parent of deleted node
				foreach (Node<Type> eachChild in getChildren())
				{
					this.parent.getChildren().Add(eachChild);
				}
			}
			//if the node which we have to delete is  root element then
			else
			{
				deleteRootNode();
			}

			this.getChildren().Clear();
		}
		
		//when we want to delete the root node
		private void deleteRootNode()
		{
			//setting a new variable to null for storing the first child of root node
			Node<Type> newParent = null;
			if ((this.getChildren().Count>0))
			{
				//storing the only first child of root node
				foreach (Node<Type> eachChild in getChildren())
				{
					newParent = eachChild;
					break;
				}
				newParent.setParent(null);
				//deleting the only first child of root node
				foreach (Node<Type> eachChild in getChildren())
				{
					getChildren().Remove(eachChild);
					break;
				}
				////setting the parent for the children of deleted node
				foreach (Node<Type> eachChild in getChildren())
				{
					eachChild.setParent(newParent);
				}
				
				//foreach (Node<Type> eachChild in getChildren())
				//{
				//	getChildren().Add(eachChild);					
				//}

				//add range will merge the child of previous parent node and current parent node
				newParent.getChildren().AddRange(getChildren());
			}
			this.getChildren().Clear();
			
		}
	

















	//function to print data according to bredth first search approach
	public void BFS()
		{
			Queue<Node<Type>> queue = new Queue<Node<Type>>();
			//pushing root element in queue
			queue.Enqueue(this);
			while (queue.Count != 0)
			{
				//taking front element in tempnode 
				//to find out its child elements
				Node<Type> tempNode = queue.Dequeue();
				//printing data accroding to bfs
				Console.WriteLine(tempNode.key + " ");

				if (tempNode.child != null)
				{
					//pushing all child nodes into queue
					for (int i = 0; i < tempNode.child.Count; i++)
					{
						queue.Enqueue(tempNode.child[i]);
					}
				}
			}
		}
		//function to print data according to bredth first search approach
		public void DFS()
		{
			Stack<Node<Type>> stack = new Stack<Node<Type>>();
			//pushing root node
			stack.Push(this);

			while (stack.Count != 0)
			{
				//taking top element in tempnode 
				//to find out its child elements
				Node<Type> tempNode = stack.Pop();
				//printing data accroding to dfs
				Console.WriteLine(tempNode.key + " ");

				if (tempNode.child != null)
				{//pushing all child nodes into stack
					for (int i = 0; i < tempNode.child.Count; i++)
					{
						stack.Push(tempNode.child[i]);
					}
				}
			}
		}

		//function to check a element exist or not
		public bool Contains(int number)
		{
			//using BFS approach to iterate over tree
			Queue<Node<Type>> queue = new Queue<Node<Type>>();
			//started searching from root element
			queue.Enqueue(this);
			//searching will continue till queue is empty
			while (queue.Count != 0)
			{
				//taking front element in tempnode 
				//to find out its child elements
				Node<Type> tempNode = queue.Dequeue();
				
				if (tempNode.key.Equals(number))
					return true;
				
				//if it has childs then search in them also
				if (tempNode.child != null)
				{
					for (int i = 0; i < tempNode.child.Count; i++)
					{
						//pushing all child nodes into queue
						queue.Enqueue(tempNode.child[i]);
						if (tempNode.key.Equals(number))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public void getElementsByValue( int number)
		{
			//using BFS approach to iterate over tree
			Queue<Node<Type>> queue = new Queue<Node<Type>>();
			//started searching from root element
			queue.Enqueue(this);
			//searching will continue till queue is empty
			while (queue.Count != 0)
			{
				//taking front element in tempnode 
				//to find out its child elements
				Node<Type> tempNode = queue.Dequeue();
				if (tempNode.key.Equals(number))
				{
					Console.WriteLine("here element is {0} and its childrens are ", tempNode.key);
					//if it has childs then search in them also
					if (tempNode.child != null)
					{
						Console.WriteLine(tempNode.child.Count);

						for (int i = 0; i < tempNode.child.Count; i++)
						{
							Console.WriteLine(tempNode.child[i].key);
						}
					}
					else
						Console.WriteLine("null");
					
				}
				if (tempNode.child != null)
				{
					for (int i = 0; i < tempNode.child.Count; i++)
					{
						queue.Enqueue(tempNode.child[i]);
					}
				}
			}
		}
		public void getElementsByLevel( int level)
		{
			int counter = 1;
			if (this == null) return;
			    Queue<Node<Type>> tempqueue = new Queue<Node<Type>>();
			tempqueue.Enqueue(this);
			while (tempqueue.Count != 0)
			{
				int size = tempqueue.Count;
				while (size > 0)
				{
					Node<Type> p = tempqueue.Peek();
					tempqueue.Dequeue();
					if (counter == level)
					{
						Console.Write(p.key + " ");
					}
					for (int i = 0; i < p.child.Count; i++)
						tempqueue.Enqueue(p.child[i]);
					size--;
				}
				counter = counter + 1;
				if (counter > level) break;
			}
		}

		public IEnumerable<string> iteratorBFS()
		{
			Queue<Node<Type>> queue = new Queue<Node<Type>>();
			//pushing root element in queue
			queue.Enqueue(this);
			while (queue.Count != 0)
			{
				//taking front element in tempnode 
				//to find out its child elements
				Node<Type> tempNode = queue.Dequeue();
				//printing data accroding to bfs
				 yield return (tempNode.key).ToString();

				if (tempNode.child != null)
				{
					//pushing all child nodes into queue
					for (int i = 0; i < tempNode.child.Count; i++)
					{
						queue.Enqueue(tempNode.child[i]);
					}
				}
			}
		}

		public IEnumerable<string> iteratorDFS()
		{
			Stack<Node<Type>> stack = new Stack<Node<Type>>();
			//pushing root node
			stack.Push(this);

			while (stack.Count != 0)
			{
				//taking top element in tempnode 
				//to find out its child elements
				Node<Type> tempNode = stack.Pop();
				//printing data accroding to dfs
				yield return (tempNode.key).ToString();

				if (tempNode.child != null)
				{//pushing all child nodes into stack
					for (int i = 0; i < tempNode.child.Count; i++)
					{
						stack.Push(tempNode.child[i]);
					}
				}
			}
		}
	}
}
