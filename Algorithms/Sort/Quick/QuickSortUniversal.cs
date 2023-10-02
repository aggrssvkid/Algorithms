using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.CommonFunctions;

namespace Algorithms.Sort.QuickSort
{
    public partial class QuickSort
    {
        public static void QuickSortUniversal(ArraySegment<int> arr)
        {
            if (arr.Count <= 1)
                return;
            int same; // povtori, t.e elementi ravnie pivotu.
            int pivot = Partition(arr, out same);
            QuickSortUniversal(arr.Slice(0, pivot));
            QuickSortUniversal(arr.Slice(pivot + same + 1));
        }

        static int Partition(ArraySegment<int> arr, out int same)
        {
            // pust pivot - mediana, dlya togo chtobi algoritm ne bil medlennee (n * log(n))
            // pivotLeftIdx and pivotRightIdx - indexi poslednih povtornih elementov sprava i sleva ot pivota.
            // Eto nado dlya sluchaya, esli mnogo povtornih elementov.
            int pivotRightIdx = arr.Count / 2;
            int pivotLeftIdx = pivotRightIdx;
            int pivot = arr[pivotRightIdx];
            int left = 0;
            int right = arr.Count - 1;
            same = 0;

            while (left < pivotLeftIdx || right > pivotRightIdx)
            {
                // Propuskrm vse elementi, kotorie itak stoyat na svoih mestah
                while (arr[left] < pivot)
                    left++;
                while (arr[right] > pivot)
                    right--;

                // Nashli podozritelnie elementi dlya swapa, menyaem. Vsego vozmozhno 4 kombinacii. Rassmotrim kazhduyu po otdelnosti.
                // 4 if.
                if (arr[left] > pivot && arr[right] < pivot)
                {
                    CommonFunc.Swap(arr, right, left);
                    left++;
                    right--;
                }
                else if (arr[left] > pivot && arr[right] == pivot)
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
                else if (arr[right] < pivot && arr[left] == pivot)
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
                else if (arr[right] == pivot && arr[left] == pivot)
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
