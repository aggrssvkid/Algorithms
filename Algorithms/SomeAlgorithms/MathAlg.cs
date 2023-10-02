using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ищем наибольший общий делитель, как завещал Евклид

namespace Algorithms.SomeAlgorithms
{
    public static partial class MathAlg
    {
        static int FindNOD(int a, int b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if (a > b)
                return FindNOD(a % b, b);
            else
                return FindNOD(b % a, a);

        }
    }
}
