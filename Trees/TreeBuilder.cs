using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class NTreeBuilder
    {
        public NTreeNode Build()
        {
            var root = new NTreeNode
            {
                value = 2,
                Childs = new List<NTreeNode>
                {
                    new NTreeNode
                    {
                        value =1

                    } ,
                    new NTreeNode
                    {
                        value =3,
                        Childs = new List<NTreeNode>
                        {
                            new NTreeNode {  value=5},
                            new NTreeNode { value = 34}
                        }
                     },

                }


            };

            return root;
        }
    }
}
