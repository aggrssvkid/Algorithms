using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CommonFunctions
{
    internal class CommonFunc
    {
        // Стандартный свап расположения двух элементов в массиве друг с другом
        internal static void Swap<T>(List<T> arr, int idx1, int idx2)
        {
            var tmp = arr[idx1];
            arr[idx1] = arr[idx2];
            arr[idx2] = tmp;
        }

        internal static void Swap<T>(ArraySegment<T> arr, int idx1, int idx2)
        {
            var tmp = arr[idx1];
            arr[idx1] = arr[idx2];
            arr[idx2] = tmp;
        }
    }
}
