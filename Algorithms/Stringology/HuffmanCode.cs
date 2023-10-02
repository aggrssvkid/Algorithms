using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * В данном алгоритме находим код хаффмана для строки
 * (минимальное количество символов для кодирования строки двоичным кодом)
 */

namespace Algorithms.Stringology
{
    public partial class Shifr
    {
        static int HuffmanCode(string input)
        {
            // Посчитаем количество различных символов в строке
            Dictionary<char, int> freqMap = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];
                if (freqMap.ContainsKey(symbol))
                    freqMap[symbol]++;
                else
                    freqMap.Add(symbol, 1);
            }

            if (freqMap.Count == 1)
                return 1;

            List<TreeNode> nodes = new List<TreeNode>(freqMap.Count);
            // Здесь мин. Кучу надо, а не просто массив
            foreach (var node in freqMap)
                nodes.Add(new TreeNode(node.Value, node.Key));

            // Далее производим слияние всех символов строки.
            // Находим 2 элемента с наиболее низклй частотой и сливаем их в один элемент
            while (nodes.Count > 1)
            {
                // Если Мин. куча, тогда здесь просто достаем верхний элемент с мин. кучи 2 раза
                // и сливаем их в один, далее просеиваим вниз
                int minIdx = FindMin(nodes);
                var firstMinNode = nodes[minIdx];
                nodes.RemoveAt(minIdx);
                minIdx = FindMin(nodes);
                var secMinNode = nodes[minIdx];
                nodes.RemoveAt(minIdx);
                TreeNode newNode = new TreeNode();
                newNode.left = firstMinNode;
                newNode.right = secMinNode;
                newNode.freq = firstMinNode.freq + secMinNode.freq;
                nodes.Add(newNode);
            }

            Dictionary<char, string> letterCodeMap = new Dictionary<char, string>();
            var koren = nodes[0];
            // Кодируем каждый символ с помощью функции GetCodes
            GetCodes(koren, letterCodeMap);
            string? binaryCodeStr = GetBinaryCode(input, letterCodeMap);
            if (binaryCodeStr == null)
                return -1;

            return binaryCodeStr.Length;

        }

        static private string? GetBinaryCode(string input, Dictionary<char, string> shifrMap)
        {
            if (input == null || input.Length == 0)
                return null;
            StringBuilder result = new StringBuilder("");
            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];
                result.Append(shifrMap[currentSymbol]);
            }
            return result.ToString();
        }

        static private void GetCodes(TreeNode koren, Dictionary<char, string> letterCodeMap)
        {
            HashSet<TreeNode> prosmotrennie = new HashSet<TreeNode>();
            StringBuilder code = new StringBuilder("");
            var current = koren;
            while (prosmotrennie.Contains(koren) == false)
            {
                if (current.left == null)
                {
                    letterCodeMap.Add(current.symbol, code.ToString());
                    prosmotrennie.Add(current);
                    code.Clear();
                    current = koren;
                }
                else if (prosmotrennie.Contains(current.left) == false)
                {
                    current = current.left;
                    code.Append('0');
                }
                else if (prosmotrennie.Contains(current.right) == false)
                {
                    current = current.right;
                    code.Append('1');
                }
                else
                {
                    prosmotrennie.Add(current);
                    code.Clear();
                    current = koren;
                }
            }
        }

        static private int FindMin(List<TreeNode> nodes)
        {
            int min = 0;
            for (int i = 1; i < nodes.Count; i++)
            {
                if (nodes[i].freq < nodes[min].freq)
                    min = i;
            }
            return min;
        }

        private class TreeNode
        {
            public int freq;
            public char symbol;
            public TreeNode? left;
            public TreeNode? right;

            public TreeNode() { }

            public TreeNode(int getFreq, char getSymbol)
            {
                freq = getFreq;
                symbol = getSymbol;
                left = null;
                right = null;
            }
        }
    }
}
