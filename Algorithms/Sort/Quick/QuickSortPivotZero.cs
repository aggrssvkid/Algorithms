﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.CommonFunctions;

namespace Algorithms.Sort.QuickSort
{
    public partial class QuickSort
    {
        public static void QuickSortUniversalPivotZero(ArraySegment<int> arr)
        {
            if (arr.Count <= 1)
                return;
            int same;
            int pivot = PartitionPivotZero(arr, out same);
            QuickSortUniversalPivotZero(arr.Slice(0, pivot));
            QuickSortUniversalPivotZero(arr.Slice(pivot + same + 1));
        }

        private static int PartitionPivotZero(ArraySegment<int> arr, out int same)
        {
            int pivotEl = arr[0];
            int next = 1;
            int hight = 1;
            same = 0;

            while (next < arr.Count)
            {
                if (arr[next] == pivotEl)
                {
                    CommonFunc.Swap(arr, next, hight);
                    same++;
                    hight++;
                }
                else if (arr[next] < pivotEl)
                {
                    if (same != 0)
                        CommonFunc.Swap(arr, next, hight - same);
                    CommonFunc.Swap(arr, next, hight);
                    hight++;
                }
                next++;
            }
            int pivot = hight - same - 1;
            CommonFunc.Swap(arr, 0, pivot);
            return pivot;
        }
    }
}
