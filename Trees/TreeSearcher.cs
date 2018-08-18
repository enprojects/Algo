using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class TreeSearcher : ITreeSearcher
    {
        public int Search(Node node, Func<Node, int> func)
        {
            return func(node);
        }
    }
}
