using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.HashCode
{

    internal class SimpleGoodHashFunction
    {
        private static readonly int x = 257;
        private static readonly int p = 1000000000 + 7;
        private readonly int maxHashtableSize;
        const int MaxStrLen = 20;
        private static int[] powArr = new int[MaxStrLen];
        public SimpleGoodHashFunction(int size)
        {
            MakePowArr();
            maxHashtableSize = size;
        }
        private static void MakePowArr()
        {
            powArr[0] = 1;
            for (int i = 1; i <= powArr.Length; i++)
            {
                long powX = (long)powArr[i - 1] * x;
                int pow = (int)(powX % p);
                powArr[i] = pow;
            }
        }

        public int GetHashCode(string str)
        {
            long hash = 0;
            int len = str.Length < MaxStrLen ? str.Length : MaxStrLen;
            for (int i = 0; i < len; i++)
            {
                long symbolCode = (long)str[i];
                hash += symbolCode * powArr[i];
            }
            hash = (hash % p) % maxHashtableSize;
            return (int)hash;
        }
    }
}
