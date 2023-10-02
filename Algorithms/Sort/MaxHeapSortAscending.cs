using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.BinaryHeap.MaxHeap;
using Algorithms.CommonFunctions;

namespace Algorithms.Sort
{
    public static partial class Sort
    {
        static public void BinaryHeapSort(List<int> arr)
        {
            if (arr.Count <= 1)
                return;
            MaxHeap.MakeMaxHeap(arr);
            int size = arr.Count;
            for (int i = size - 1; i >= 1; i--)
            {
                CommonFunc.Swap(arr, i, 0);
                size--;
                MaxHeap.SiftDown(arr, size, 0);
            }
        }
    }
}
