
#region Doubly Linkedlist Implementation

using System;

namespace Doubly_Linkedlist
{
    class Node
    {
        int data;
        Node next;
        Node previous;
        public int Data { get { return data; } set { data = value; } }
        public Node Next { get { return next; } set { next = value; } }
        public Node Previous { get { return previous; } set { previous = value; } }

        public Node(int d)
        {
            data = d;
        }
        public Node()
        {

        }
    }

    public class DoublyLinkedList
    {
        Node head;
        public DoublyLinkedList()
        {

        }
        public void insertAtEnd(int value)
        {
            if (head == null)
            {
                head = new Node(value);
                return;
            }
            Node temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            Node newNode = new Node(value);
            temp.Next = newNode;
            newNode.Previous = temp;

        }

        public void insertNodeAtPosition(int position, int value)
        {
            Node firstNode = Find(position);

            if (firstNode == null)
            {
                insertAtEnd(value);
            }
            else
            {
                Node newNode = new Node(value);
                newNode.Next = firstNode.Next;
                newNode.Previous = firstNode;
                firstNode.Next.Previous = newNode;
                firstNode.Next = newNode;
            }
        }
        public void printLinkedList()
        {
            Node temp = head;
            while (temp != null)
            {

                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
            Console.WriteLine("\n");
        }
        public void reversePrintLinkedList()
        {
            Node temp = head;
            while (temp.Next != null)
            {

                // Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Previous;
            }

            Console.WriteLine("\n");
        }
        Node Find(object value)
        {
            Node temp = head;
            while (temp.Next != null)
            {
                if (temp.Data.Equals(value))
                {
                    // Console.WriteLine($"Element: {temp.data} is found");
                    return temp;
                }
                temp = temp.Next;
            }
            Console.WriteLine($"Element: {value} isn't found");
            return null;
        }
        public void RemoveSpecificNode(object value)
        {
            Node deleteNode = Find(value);
            if (deleteNode == null)
            {
                return;
            }
            else
            {
                //Node target = deleteNode;
                deleteNode.Next.Previous = deleteNode.Previous ;
                deleteNode.Previous.Next = deleteNode.Next;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.insertAtEnd(100);
            list.insertAtEnd(200);
            list.insertAtEnd(300);
            list.insertAtEnd(400);
            list.insertAtEnd(500);
            list.printLinkedList(); Console.WriteLine();
            list.insertNodeAtPosition(300, 350);
            list.printLinkedList();
            Console.WriteLine();
            list.reversePrintLinkedList();
            list.RemoveSpecificNode(350);
            list.printLinkedList();
            list.reversePrintLinkedList();
        }
    }
}


#endregion
