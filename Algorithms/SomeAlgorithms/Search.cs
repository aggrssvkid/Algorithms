using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Стандартный бинарный поиск

namespace Algorithms.SomeAlgorithms
{
    public static class Search
    {
        // Binarniy Poisk
        static public int BinarySearch(int[] array, int element)
        {
            int start = 0;
            int end = array.Length - 1;
            while (start <= end)
            {
                int sdvig = (end - start) / 2;
                int middle = start + sdvig;
                if (element == array[middle])
                    return middle + 1; // dobavlyam edinichku tak kak index elementov v reale s edinici
                else if (element > array[middle])
                    start = middle + 1;
                else
                    end = middle - 1;
            }
            return -1;
        }

        /// <summary>
        /// Эта функция ищет элемент, который находится на k-й позиции.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left">Левая граница массива для поиска, включительно.</param>
        /// <param name="right">Правая граница массива для поиска, не включительно</param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int GetKStat(int[] arr, int left, int right, int k)
        {

            int currentStat = Partition(arr, left, right);
            while (currentStat != k)
            {
                if (k < currentStat)
                    right = currentStat;
                else if (k > currentStat)
                    left = currentStat + 1;
                currentStat = Partition(arr, left, right);
            }
            return arr[currentStat];
        }
        private static int Partition(int[] arr, int left, int right)
        {
            int idxOporniy = (right + left) / 2;
            int elementOporniy = arr[idxOporniy];
            int bigFirst = left;
            int equalFirst = bigFirst;
            for (int i = left; i < right; i++)
            {
                var now = arr[i];
                if (now == elementOporniy)
                {
                    arr[i] = arr[bigFirst];
                    arr[bigFirst] = now;
                    bigFirst++;
                }
                else if (now < elementOporniy)
                {
                    arr[i] = arr[bigFirst];
                    arr[bigFirst] = arr[equalFirst];
                    arr[equalFirst] = now;
                    equalFirst++;
                    bigFirst++;
                }
            }
            return equalFirst;
        }
    }
}
