using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sort
{
    public partial class Sort
    {
        /// <summary>
        /// Основной метод для вызова сортировки (сделан ии)
        /// </summary>
        /// <param name="array">Массив для сортировки</param>
        public static void MergeSort(int[] array)
        {
            if (array == null || array.Length <= 1)
                return;

            int[] tempArray = new int[array.Length];
            MergeSort(array, tempArray, 0, array.Length - 1);
        }

        /// <summary>
        /// Рекурсивный метод сортировки слиянием
        /// </summary>
        /// <param name="array">Исходный массив</param>
        /// <param name="tempArray">Временный массив для слияния</param>
        /// <param name="left">Левый индекс подмассива</param>
        /// <param name="right">Правый индекс подмассива</param>
        private static void MergeSort(int[] array, int[] tempArray, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                // Рекурсивно сортируем левую и правую половины
                MergeSort(array, tempArray, left, middle);
                MergeSort(array, tempArray, middle + 1, right);

                // Сливаем отсортированные половины
                Merge(array, tempArray, left, middle, right);
            }
        }

        /// <summary>
        /// Метод для слияния двух отсортированных подмассивов
        /// </summary>
        /// <param name="array">Исходный массив</param>
        /// <param name="tempArray">Временный массив</param>
        /// <param name="left">Левый индекс</param>
        /// <param name="middle">Средний индекс</param>
        /// <param name="right">Правый индекс</param>
        private static void Merge(int[] array, int[] tempArray, int left, int middle, int right)
        {
            int leftStart = left;
            int leftEnd = middle;
            int rightStart = middle + 1;
            int rightEnd = right;
            int tempIndex = left;

            // Слияние пока есть элементы в обоих подмассивах
            while (leftStart <= leftEnd && rightStart <= rightEnd)
            {
                if (array[leftStart] <= array[rightStart])
                {
                    tempArray[tempIndex++] = array[leftStart++];
                }
                else
                {
                    tempArray[tempIndex++] = array[rightStart++];
                }
            }

            // Копируем оставшиеся элементы левого подмассива
            while (leftStart <= leftEnd)
            {
                tempArray[tempIndex++] = array[leftStart++];
            }

            // Копируем оставшиеся элементы правого подмассива
            while (rightStart <= rightEnd)
            {
                tempArray[tempIndex++] = array[rightStart++];
            }

            // Копируем отсортированные элементы обратно в исходный массив
            for (int i = left; i <= right; i++)
            {
                array[i] = tempArray[i];
            }
        }
    }
}
