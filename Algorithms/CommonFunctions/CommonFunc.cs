using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CommonFunctions
{
    internal class CommonFunc
    {
        internal static void Swap<T>(T[] arr, int idx1, int idx2)
        {
            var tmp = arr[idx1];
            arr[idx1] = arr[idx2];
            arr[idx2] = tmp;
        }
    }
}
