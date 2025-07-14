using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BinaryTree
{
    public class TreeNode
    {
        public int Parent { get; set; } = -1;
        public int Key { get; set; }
        public int Left { get; set; } = -1;
        public int Right { get; set; } = -1;
        public TreeNode(int key) => Key = key;
    }
}
