using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.CommonFunctions;

/*
 * Стандартная реализация быстрой сортировки, в которой предполагается что все элементы различны.
 * Принцип действия: выбираем опорный элемент (pivot) и сравниваем с ним все остальные жлементы в массиве.
 * Всё, что больше опорного расположим правее pivota, а всё, что меньше - левее. Для левой и правой частей опять выбираем
 * опорный элемент, сортируеем относительно его и т.д, пока не получем части из 1-го элемента.
 */

namespace Algorithms.Sort.Quick
{
    public partial class QuickSort
    {
        public static void QuickSortAnyTypeStandart<T>(ArraySegment<T> arr, IComparer<T> comparer)
        {
            if (arr.Count <= 1)
                return;
            // После процедуры "Partition" все элементы относительно "pivot" будут отсортированы. (слева меньшие, справа большие)
            int pivot = Partition(arr, comparer);
            // Повторяем сортировку для новых частей исходного массива
            QuickSortAnyTypeStandart(arr.Slice(0, pivot), comparer);
            QuickSortAnyTypeStandart(arr.Slice(pivot + 1), comparer);
        }

        private static int Partition<T>(ArraySegment<T> arr, IComparer<T> comparer)
        {
            int pivotIdx = arr.Count / 2; // pivot - медиана. Это вариант близкий к оптимальному.
            int left = 0; // индекс начального элемента в массиве
            int right = arr.Count - 1; // индекс последнего элемента

            // далее сравниваем все элементы в массиве с пивотом. Если элементы стоят "неправильно" относительно pivot, то "SWAP"!

            while (left < pivotIdx || right > pivotIdx)
            {
                var pivotElement = arr[pivotIdx];
                while (comparer.Compare(arr[left], pivotElement) < 0)
                    left++;
                while (comparer.Compare(arr[right], pivotElement) > 0)
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
            // Возвратом функции будет индекс элемента, относительно которого все остальные элементы расположены как надо
            // (все меньшие слева, большие - справа)
            return pivotIdx;
        }
    }
}
