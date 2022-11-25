using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    }

}
