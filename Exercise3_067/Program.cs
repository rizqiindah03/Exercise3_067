using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise3_067
{
    class node 
    {
        /*create Nodes for the circular nextad list*/
        public int rollNumber;
        public string name;
        public node next; 
    }

    class Circularlist
    {
        node LAST;
        public Circularlist()
        {
            LAST = null;
        }
        public bool Search(int rollNo, ref node previous, ref node current)/*searches for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);/*returns true if the node is found*/
            }
            if (rollNo == LAST.rollNumber)/*if the node is present at the end*/
                return true;
            else
                return (false);/*returns false is the node is not found*/
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void traverse()/*Traverses all the nodes of the list*/
        {
            if (listEmpty())
                Console.WriteLine("\nlist is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are:\n");
                node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + " " + currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + " " + LAST.name + "\n");
            }               
        }
        public void firstnode()
        {
            if (listEmpty())
                Console.WriteLine("\nlist is empty");
            else
                Console.WriteLine("\nthe first record in the list is:\n\n" + LAST.next.rollNumber + " " + LAST.next.name);
        }
        public void addNode()
        {
            int nim;
            string name;
            Console.WriteLine("\nEnter the roll number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student: ");
            name = Console.ReadLine();
            node newNode = new node();
            newNode.rollNumber = nim;
            newNode.name = name;
            // if the node to be inserted is the first node
            if (LAST == null || nim <= LAST.rollNumber) ;
            {
                if ((LAST != null) && (nim == LAST.rollNumber)) ;
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }
                newNode.next = LAST;
                LAST = newNode;
                return;
            }
            //locate the position of the new node in the list 
            node prev, curr;
            prev = LAST;
            curr = LAST;

            while ((curr != null) && (nim <= curr.rollNumber))
            {
                if (nim == curr.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll number not allowed\n");
                    return;
                }
                prev = curr;
                curr = curr.next;
            }
            //*once the above for loop is executed */
            newNode.next = curr;
            prev.next = newNode;

        }
        public bool delNode(int nim)
        {
            node prev, curr;
            prev = curr = null;
            //check if the spesified node is present in the list or not
            if (Search(nim, ref prev, ref curr) == false)
                return false;
            prev.next = curr.next;
            if (curr == LAST)
                LAST = LAST.next;
            return true;
        }

        static void Main(string[] args)
        {
            Circularlist obj = new Circularlist();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("2. Search for a record in the list");
                    Console.WriteLine("3. Display the first record in the list");
                    Console.WriteLine("4. Add a record in the list");
                    Console.WriteLine("5. Delete a record from the list");
                    Console.WriteLine("6. Exit");
                    Console.Write("\nEnter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nlist is empty");
                                    break;

                                }
                                node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record is to be searched :");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number : " + curr.rollNumber);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.firstnode();
                            }
                            break;
                        case '4':
                            {
                                obj.addNode();
                            }
                            break;
                       
            }
        }
    }

}
