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
        public bool listempty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }


    }

}
