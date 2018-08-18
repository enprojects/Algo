using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class TreeBuilder : ITreeBuilder
    {
        public Node Build()
        {
            var root = new Node
            {
                Value = 1,
                Left = new Node
                {
                    Value = 4,
                    Left = new Node { Value = 2 }

                 },
                //Right = new Node
                //{
                //    Value = 47 ,
                //     //Left = new Node{ Value = 16 },
                //    //Right = new Node { Value = 2 }
                //}
            };

            return root;
        }
    }
}
