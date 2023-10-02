using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.CommonFunctions;

namespace Algorithms.BinaryHeap.MaxHeap
{
    public partial class MaxHeap
    {
        // Вставляем элемент в кучу. При вставке элемент просеивается и занимает свое место в куче.
        public static void InsertElement(List<int> priorityQueue, int element)
        {
            priorityQueue.Add(element);
            SiftUp(priorityQueue);
        }

        // Достаем элемент из кучи. При этом, сам элемент удаляется из кучи, в свойство макс. кучи сохраняется
        public static int ExtractElement(List<int> priorityQueue)
        {
            int res = priorityQueue[0];
            int last = priorityQueue.Count - 1;
            CommonFunc.Swap(priorityQueue, 0, last);
            priorityQueue.RemoveAt(last);
            SiftUp(priorityQueue);
            return res;
        }

        // Делаем из обычного массива макс. кучу
        public static void MakeMaxHeap(List<int> arr)
        {
            if (arr.Count <= 1)
                return;
            int n = arr.Count;
            for (int i = n / 2; i >= 0; i--)
                SiftDown(arr, n, i);
        }
    }
}
