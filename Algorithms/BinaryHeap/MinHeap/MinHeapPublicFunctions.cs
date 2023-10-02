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
        // Достаем элемент из кучи. При этом, сам элемент удаляется из кучи, в свойство макс. кучи сохраняется
        public static T ExtractElement<T>(List<T> priorityQueue, IComparer<T> comparer)
        {
            T res = priorityQueue[0];
            int last = priorityQueue.Count - 1;
            Swap(priorityQueue, 0, last);
            priorityQueue.RemoveAt(last);
            SiftUp(priorityQueue, comparer);
            return res;
        }
    }
}
