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
    }
}
