using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BinaryHeap.MinHeap
{
    public partial class MinHeap
    {
        // Вставляем элемент в кучу. При вставке элемент просеивается и занимает свое место в куче.
        public static void InsertElement<T>(List<T> priorityQueue, T element, IComparer<T> comparer)
        {
            priorityQueue.Add(element);
            SiftUp(priorityQueue, comparer);
        }
        // Достаем элемент из кучи. При этом, сам элемент удаляется из кучи, а свойство мин. кучи сохраняется
        public static T ExtractElement<T>(List<T> priorityQueue, IComparer<T> comparer)
        {
            T res = priorityQueue[0];
            int last = priorityQueue.Count - 1;
            Swap(priorityQueue, 0, last);
            priorityQueue.RemoveAt(last);
            SiftDown(priorityQueue, comparer);
            return res;
        }
        public static void MakeMinHeap<T>(List<T> arr, IComparer<T> comparer)
        {
            if (arr.Count <= 1)
                return;
            int n = arr.Count;
            for (int i = n / 2; i >= 0; i--)
                SiftDown(arr, n, i, comparer);
        }
    }
}
