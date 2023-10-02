using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.CommonFunctions;

/*
 * QuickSort с учетом того, что в массиве присутствует множество одинаковых элементов
 */

namespace Algorithms.Sort.QuickSort
{
    public partial class QuickSort
    {
        public static void QuickSortAnyTypeUniversal<T>(ArraySegment<T> arr, IComparer<T> comparer)
        {
            if (arr.Count <= 1)
                return;
            int same;
            int pivot = Partition(arr, out same, comparer);
            QuickSortAnyTypeUniversal(arr.Slice(0, pivot), comparer);
            QuickSortAnyTypeUniversal(arr.Slice(pivot + same + 1), comparer);
        }

        static int Partition<T>(ArraySegment<T> arr, out int same, IComparer<T> comparer)
        {
            int pivotRightIdx = arr.Count / 2;
            int pivotLeftIdx = pivotRightIdx;
            var pivot = arr[pivotRightIdx];
            int left = 0;
            int right = arr.Count - 1;
            same = 0;

            while (left < pivotLeftIdx || right > pivotRightIdx)
            {
                // Пропустим все элементы, которые "стоят на своих местах" (если меньше пивота и слева; если больше пивота и справа)
                while (comparer.Compare(arr[left], pivot) < 0)
                    left++;
                while (comparer.Compare(arr[right], pivot) > 0)
                    right--;

                // Нашли подозрительные элементы для свапа, меняем. Всего возможно 4 комбинации
                // 4 if.
                if (comparer.Compare(arr[left], pivot) > 0 && comparer.Compare(arr[right], pivot) < 0)
                {
                    CommonFunc.Swap(arr, right, left);
                    left++;
                    right--;
                }
                else if (comparer.Compare(arr[left], pivot) > 0 && comparer.Compare(arr[right], pivot) == 0)
                {
                    CommonFunc.Swap(arr, left, right);
                    CommonFunc.Swap(arr, left, pivotLeftIdx - 1);
                    if (right != pivotRightIdx)
                    {
                        pivotLeftIdx--;
                        same++;
                    }
                    else if (right == pivotRightIdx)
                    {
                        pivotLeftIdx--;
                        pivotRightIdx--;
                    }
                    right--;
                }
                else if (comparer.Compare(arr[right], pivot) < 0 && comparer.Compare(arr[left], pivot) == 0)
                {
                    CommonFunc.Swap(arr, left, right);
                    CommonFunc.Swap(arr, right, pivotRightIdx + 1);
                    if (left != pivotLeftIdx)
                    {
                        pivotRightIdx++;
                        same++;
                    }
                    else if (left == pivotLeftIdx)
                    {
                        pivotLeftIdx++;
                        pivotRightIdx++;
                    }
                    left++;
                }
                else if (comparer.Compare(arr[right], pivot) == 0 && comparer.Compare(arr[right], pivot) == 0)
                {
                    if (left != pivotLeftIdx)
                    {
                        CommonFunc.Swap(arr, left, pivotLeftIdx - 1);
                        same++;
                        pivotLeftIdx--;
                    }
                    if (right != pivotRightIdx)
                    {
                        CommonFunc.Swap(arr, right, pivotRightIdx + 1);
                        same++;
                        pivotRightIdx++;
                    }
                }
            }
            return pivotLeftIdx;
        }
    }
}
