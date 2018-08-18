using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{

    public class NTreeNode
    {
        public int value { get; set; }
        public List<NTreeNode> Childs { get; set; } = new List<NTreeNode>();

        
    }


    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}
