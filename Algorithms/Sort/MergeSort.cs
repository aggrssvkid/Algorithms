using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sort
{
    public partial class Sort
    {
        public static int[] MergeSort(int[] arr)
        {
            // Делим массив пополам, пока не получим одноэлементные массивы на последнем уровне рекурсии. После этого, начинаем
            // Лепить уже отсортированный массив, вызыая Merge для каждой из половинок.
            if (arr.Length <= 1)
                return arr;
            int m = arr.Length / 2;
            var left = arr.Skip(0).Take(m).ToArray();
            var right = arr.Skip(m).Take(arr.Length % 2 == 0 ? m : m + 1).ToArray();
            return Merge(MergeSort(left), MergeSort(right));
        }

        public static int[] Merge(int[] left, int[] right)
        {
            int len = left.Length + right.Length;
            int[] newArr = new int[len];
            int currentLeft = 0, currentRight = 0, i = 0;

            // Начинаем сравнивать элементы из 2-х отсортированных массивов попарно. Меньший кладем в новый массив и сдвигаем указатель
            // Массива, откуда взяли этот меньший элемент на следующий элемент. Делаем так до тех пор, пока в каком-нибудь массиве
            // не закончатся элементы. Оставшиеся элементы другого массива просто копируем в конец нового полученного массива.
            while (currentLeft < left.Length && currentRight < right.Length)
            {
                if (left[currentLeft] <= right[currentRight])
                {
                    newArr[i] = left[currentLeft];
                    currentLeft++;
                }
                else
                {
                    newArr[i] = right[currentRight];
                    currentRight++;
                }
                i++;
            }

            // Собственно говоря, далее и идет прповерка на то, в каком массиве еще остались элементы. Оставшиеся элементы
            // копируем в новый массив.
            if (currentLeft == left.Length && currentRight != right.Length)
            {
                while (currentRight < right.Length)
                {
                    newArr[i] = right[currentRight];
                    currentRight++;
                    i++;
                }
            }
            else if (currentRight == right.Length && currentLeft != left.Length)
            {
                while (currentLeft < left.Length)
                {
                    newArr[i] = left[currentLeft];
                    currentLeft++;
                    i++;
                }
            }

            return newArr;
        }
    }
}
