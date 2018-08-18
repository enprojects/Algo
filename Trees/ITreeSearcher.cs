using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    interface ITreeSearcher
    {
        int Search(Node node, Func<Node, int> func);
    }
}
