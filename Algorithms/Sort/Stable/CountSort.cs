using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sort.Stable
{
    public static partial class StableSort
    {
        // m - nabor chisel ot nulya do m, kotorie mogut vstretitsya v massive arr
        public static int[] CountSort(int[] arr, int m)
        {
            if (arr.Length <= 1)
                return arr;
            int[] baseNums = new int[m];
            for (int i = 0; i < arr.Length; i++)
            {
                int num = arr[i];
                baseNums[num]++;
            }
            // Dalee poluchim indexi dlya samogo pravogo kraynego exemplyara kazhdogo iz chisel. Naprimer, imeem massiv int[] arr {1, 2, 1, 2, 1}
            // posle podscheta vseh chisel poluchili baseNums[] = [3, 2]. Dalee summiruem i polucheam: [3, 5]. 5 (4) - index posledney dvoyki
            // 3 (2) - index posledney troyki
            for (int i = 1; i < m; i++)
                baseNums[i] = baseNums[i] + baseNums[i - 1];

            int[] sortedArr = new int[arr.Length];
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int currentNum = arr[i];
                int sortedIdx = baseNums[currentNum];
                sortedArr[sortedIdx - 1] = currentNum;
                baseNums[currentNum]--;
            }
            return sortedArr;
        }
    }
}
