using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graph
{
    public class Graph
    {
        public int Root { get; set; } // mojet ponadobitsya, esli graf - derevo
        public List<Node> allNodes; // massiv dlya hraneniya vseh vershin grafa
        public Graph(int vertexNum) 
        {
            allNodes = new List<Node>(vertexNum + 1);
            for (int i = 0; i <= vertexNum; i++)
                allNodes.Add(new Node(i));
        }

        public static void Dfs(Graph graph, HashSet<int> visited, Node now)
        {
            visited.Add(now.Key); // добавили в просмотренные, дабы  не посещать эту вершину дважды
            var incindent = now.incindentNodes;
            // далее для каждого соседа проделываем то же самое, пока не посетим все вершины
            foreach (var key in incindent)
            {
                if (visited.Contains(key) == false)
                {
                    var nextNode = graph.allNodes[key];
                    Dfs(graph, visited, nextNode);
                }
            }
            // здесь можно что-то сделать с вешиной, либо что-то можно было с ней сделать в начале Dfs
            // 
        }

        // Dfs s vozvratom dlini puti ot start k end
        public static int Bfs(Graph graph, int start, int end, HashSet<int> visited)
        {

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited.Add(start);
            int way = 0;
            while (queue.Count > 0)
            {
                // поуровневая обработк вершин. Размер текущего уровня определяем вначале
                int nextLvlSize = queue.Count(); 
                for (int i = 0; i < nextLvlSize; i++)
                {
                    var next = queue.Dequeue();
                    if (next == end)
                        return way;
                    var incindent = graph.allNodes[next].incindentNodes;
                    foreach (var item in incindent)
                    {
                        if (visited.Contains(item) == false)
                        {
                            queue.Enqueue(item);
                            visited.Add(item);
                        }
                    }
                }
                way++;
            }
            return -1;
        }
    }

    public class Node
    {
        public int Key { get; set; }

        public HashSet<int> incindentNodes = new HashSet<int>();

        public Node(int key) => Key = key;
    }
}
