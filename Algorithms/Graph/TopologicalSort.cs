using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graph
{
    internal class TopologicalSort
    {
        private static bool DFS(Node currentNode, Node[] nodes, List<int> answer)
        {
            currentNode.color = Color.Grey;
            var incindentNodes = currentNode.incindentNodes;
            foreach (var key in incindentNodes)
            {
                var nextNode = nodes[key];
                if (nextNode.color.Equals(Color.Grey))
                    return false;
                else if (nextNode.color.Equals(Color.Black))
                    continue;
                var nextDfs = DFS(nextNode, nodes, answer);
                if (nextDfs == false)
                    return false;
            }
            answer.Add(currentNode.key);
            currentNode.color = Color.Black;
            return true;
        }
        private class Node
        {
            public readonly int key;
            public HashSet<int> incindentNodes = new HashSet<int>();
            public int edgesInside = 0;
            public Color color = Color.White;
            public Node(int key) => this.key = key;
        }
        private enum Color
        {
            White,
            Grey,
            Black
        }
    }
}
