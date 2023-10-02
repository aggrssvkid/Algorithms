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
        public static void QuickSortStandart(ArraySegment<int> arr)
        {
            if (arr.Count <= 1)
                return;
            // Posle proceduri "Partition" vse elementi otnositelno "pivot" budut otsortirovani. (sleva menshie, sprava bolshie)
            // Povtoryaem etot process dlya vseh elementov menshih i dlya vseh elementov bolshe. Itak poka vse podmassivi ne budut v poryadke.
            int pivot = PartitionStandart(arr);
            QuickSortStandart(arr.Slice(0, pivot));
            QuickSortStandart(arr.Slice(pivot + 1));
        }

        private static int PartitionStandart(ArraySegment<int> arr)
        {
            int pivotIdx = arr.Count / 2; // pivot - mediana. Eto variant, bliziy k optimalnomu.
            int left = 0; // index nachalnogo elementa v massive
            int right = arr.Count - 1; // index konechnogo elementa v massive
            // dalee sravnivaem vse elementi v massive s pivotom. Esli elementi stoyat nepravilno otnositelno pivota, to use "SWAP"!
            while (left < pivotIdx || right > pivotIdx)
            {
                var pivotElement = arr[pivotIdx];
                while (arr[left] < pivotElement)
                    left++;
                while (arr[right] > pivotElement)
                    right--;

                if (left != pivotIdx && right != pivotIdx)
                    CommonFunc.Swap(arr, left, right);
                else if (left == pivotIdx && right != pivotIdx)
                {
                    CommonFunc.Swap(arr, pivotIdx, right);
                    pivotIdx = right;
                }
                else if (right == pivotIdx && left != pivotIdx)
                {
                    CommonFunc.Swap(arr, pivotIdx, left);
                    pivotIdx = left;
                }
            }
            return pivotIdx;
        }
    }
}
