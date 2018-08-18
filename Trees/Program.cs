using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {

            //build tree
           // var root = new TreeBuilder().Build();

            //search
            //  var result = new TreeSearcher().Search(root, SearchMax);

            //   var result = maxElem(root);
            //print
               var tree = new NTreeBuilder().Build();
            //  Print(tree);

            //  var result = NTreeSearchMax(tree);
            var result = SumTree(tree);
            Console.WriteLine(result);

             
            Console.ReadLine();
        }


        static int  SumTree(NTreeNode node)
        {
           

            if (node == null)
                return 0;

            var sum = node.value;

            foreach (var child in node.Childs)
            {
                sum  +=  SumTree(child);

            }
            return sum;
        }

        static int  maxElem(Node node)
        {
            int max = node.Value;
            if (node.Left != null)
            {
                var temp = maxElem(node.Left);
                max = Math.Max(max,temp);


            }
            if (node.Right != null)
            {
                max = Math.Max(max, maxElem(node.Right));
            }
            return max;
        }

        static int SearchMax(Node node)
        {
            if (node == null) return int.MinValue;

            var maxLeft = SearchMax(node.Left);

            if (maxLeft < node.Value)
                maxLeft = node.Value;

            var maxRight = SearchMax(node.Right);

            if (maxRight < node.Value) maxRight = node.Value;

            return maxRight < maxLeft ? maxLeft : maxRight;

        }

        static void Print(NTreeNode root)
        {
            if (root == null)
                return;

            Console.WriteLine(root.value);



            foreach (var child in root.Childs)
            {
                Print(child);
            }
        }


        //static int MaxNtree(NTreeNode node)
        //{
        //    var result = node.value;

        //    foreach (var item in node.Childs)
        //    {
        //    result= NTreeSearchMax(item).value;
        //    }

        //}


        static int NTreeSearchMax(NTreeNode root)
        {
            var result = root.value;

            foreach (var child in root.Childs)
            {
                var maxChild = FindMaxRecursive(child);
                if (result < maxChild) result = maxChild;
            }

            return result;
        }

        private static int FindMaxRecursive(NTreeNode node)
        {
            if (node == null) return int.MinValue;
            var result = node.value;

            foreach (var child in node.Childs)
            {
                var maxChild = FindMaxRecursive(child);
                if (result < maxChild) result = maxChild;
            }

            return result;
        }
    }
}
