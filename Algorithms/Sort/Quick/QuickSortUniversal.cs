using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.CommonFunctions;

// esli elementi povtoryayutsya
namespace Algorithms.Sort.QuickSort
{
    public class QuickSortUniversal
    {
        public static void Sort(int[] array)
        {
            if (array == null || array.Length <= 1)
                return;

            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(int[] array, int left, int right)
        {
            if (left >= right) return;

            // Возвращает границы: 
            // - слева элементы < pivot
            // - в середине элементы == pivot
            // - справа элементы > pivot
            (int lessThanEnd, int greaterThanStart) = Partition(array, left, right);

            Sort(array, left, lessThanEnd);     // Сортируем элементы < pivot
            Sort(array, greaterThanStart, right); // Сортируем элементы > pivot
        }

        private static (int lessThanEnd, int greaterThanStart) Partition(int[] array, int left, int right)
        {
            int pivot = array[left + (right - left) / 2]; // Медиана (можно выбрать первый/последний/рандомный)

            int less = left;       // конец зоны "< pivot"
            int equal = left;      // конец зоны "== pivot"
            int greater = right;   // начало зоны "> pivot"

            while (equal <= greater)
            {
                if (array[equal] < pivot)
                {
                    Swap(array, equal, less);
                    less++;
                    equal++;
                }
                else if (array[equal] > pivot)
                {
                    Swap(array, equal, greater);
                    greater--;
                }
                else
                {
                    equal++;
                }
            }

            // Теперь массив разбит на:
            // - [left..less-1]   — элементы < pivot
            // - [less..greater]  — элементы == pivot
            // - [greater+1..right] — элементы > pivot
            return (less - 1, greater + 1);
        }

        private static void Swap<T>(T[] array, int i, int j)
        {

            (array[i], array[j]) = (array[j], array[i]);
        }
    }
}
