using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graph
{
    public static class Dijkstra
    {
        private class Graph
        {
            public Node[] Nodes { get; set; }
            public Graph(int nodesNum) => Nodes = new Node[nodesNum + 1];
        }
        private class Node
        {
            public int Key { get; }
            public long MinRange { get; set; }
            public Dictionary<int, int> wayToSosed;
            public Node(int key)
            {
                Key = key;
                wayToSosed = new Dictionary<int, int>();
            }
        }

        private class NodeComparer : IComparer<Node>
        {
            int IComparer<Node>.Compare(Node? x, Node? y)
            {
                if (x.MinRange < y.MinRange)
                    return -1;
                else if (x.MinRange > y.MinRange)
                    return 1;
                else
                {
                    if (x.Key < y.Key)
                        return -1;
                    else if (x.Key > y.Key)
                        return 1;
                    else
                        return 0;
                }
            }
        }
        /// <summary>
        /// Реализация Дейкстры через сбалансированнное дерево
        /// (SortedSet)
        /// </summary>
        private static long Dijkstra2(Graph graph, int start, int finish)
        {
            /// в Visited храним все пройденные вершины. А пройденной считается та вершина,
            /// до всех соседей которой мы дошли идя через эту вершину
            HashSet<int> visited = new HashSet<int>(); 
            var nodes = graph.Nodes;

            long[] waysToNodes = new long[nodes.Length];
            for (int i = 0; i < waysToNodes.Length; i++)
                waysToNodes[i] = long.MaxValue;
            waysToNodes[start] = 0;
            nodes[start].MinRange = 0;
            /// Куча, для хранения вершины (ребра) с минимальным весом в корневом узле
            SortedSet<Node> priorityQueue = new SortedSet<Node>(new NodeComparer());
            priorityQueue.Add(nodes[start]);

            while (priorityQueue.Count > 0)
            {
                var nextNode = priorityQueue.Min;
                priorityQueue.Remove(nextNode); 
                var sosedi = nextNode.wayToSosed; 
                /// перебираем пути до всех соседей. Если нашли более короткий путь до соседа,
                /// то сохраняем его в массив waysToNodes и изменяем приоритет этого соседа в куче
                /// путем удаления старого и добавления нового элемента с новым приоритетом
                foreach (var pair in sosedi)
                {
                    var sosedKey = pair.Key; 
                    if (visited.Contains(sosedKey))
                        continue;
                    var sosedRange = pair.Value;
                    var currentRange = waysToNodes[sosedKey];
                    var nextRange = waysToNodes[nextNode.Key] + sosedRange;
                    if (nextRange < currentRange)
                    {
                        waysToNodes[sosedKey] = nextRange;
                        var sosed = nodes[sosedKey];
                        priorityQueue.Remove(sosed);
                        sosed.MinRange = nextRange;
                        priorityQueue.Add(sosed);
                    }
                }
                visited.Add(nextNode.Key);
            }
            if (waysToNodes[finish] == long.MaxValue)
                return -1;
            else
                return waysToNodes[finish];
        }

        /// <summary>
        /// Реализация Дейкстры через очередь с приоритетом
        /// (PriorityQueue)
        /// </summary>
        private static long Dijkstra1(Graph graph, int start, int finish)
        {
            HashSet<Node> visited = new HashSet<Node>();
            PriorityQueue<int, long> queue = new PriorityQueue<int, long>();
            long[] waysToNodes = new long[graph.Nodes.Length];
            for (int i = 0; i < waysToNodes.Length; i++)
                waysToNodes[i] = long.MaxValue;
            waysToNodes[start] = 0;
            queue.Enqueue(start, 0);

            while (queue.Count > 0)
            {
                var nextNode = graph.Nodes[queue.Dequeue()];
                if (visited.Contains(nextNode))
                    continue;
                var sosedi = nextNode.wayToSosed;
                foreach (var pair in sosedi)
                {
                    var sosedKey = pair.Key;
                    if (visited.Contains(graph.Nodes[sosedKey]))
                        continue;
                    var range = pair.Value;
                    var currentRange = waysToNodes[sosedKey];
                    var nextRange = waysToNodes[nextNode.Key] + (long)range;
                    if (nextRange < currentRange)
                    {
                        waysToNodes[sosedKey] = nextRange;
                        graph.Nodes[sosedKey].MinRange = nextRange;
                        queue.Enqueue(sosedKey, nextRange);
                    }
                }
                visited.Add(nextNode);
            }
            if (waysToNodes[finish] == long.MaxValue)
                return -1;
            else
                return waysToNodes[finish];
        }
    }

    

    
}
