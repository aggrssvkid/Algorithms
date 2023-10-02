using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Находим расстояние Левенштейна
 * (минимальное коичество действий (вставка, удаление, замена) для того, чтобы строку 'A' переделать в строку 'B')
 */

namespace Algorithms.Stringology
{
    public static partial class Overlaps
    {
        public static int LevensteinRange(string A, string B)
        {
            int n = B.Length;
            int m = A.Length;
            int[][] res = new int[n + 1][];
            for (int i = 0; i <= n; i++)
                res[i] = new int[m + 1];

            // Zapolnyaem nulevuyu stroku matrici (str A)
            for (int j = 0; j <= m; j++)
                res[0][j] = j;
            // Zapolnyaem nulevoy stolbec matrici (str B)
            for (int i = 1; i <= n; i++)
                res[i][0] = i;

            // Dalee sam algoritm, v kotorom mi zapolnyaem matricu i poluchaem rasstoyanie Levenshteyna
            // Nahodim min iz 3 - h sosednih kletok, znachenie kotorih mi uje poschitali (sleva, sverhu i sleva-sverhu po diagonali)
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    var left = res[i][j - 1] + 1;
                    var up = res[i - 1][j] + 1;
                    var dioganal = res[i - 1][j - 1] + IsDifferent(A[j - 1], B[i - 1]);
                    res[i][j] = ChhoseMin(left, up, dioganal);
                }
            }
            return (res[n][m]);
        }

        private static int IsDifferent(char symbolA, char symbolB)
        {
            if (symbolA == symbolB)
                return 0;
            return 1;
        }

        private static int ChhoseMin(int left, int up, int dioganal)
        {
            int min;
            if (left <= up)
                min = left;
            else
                min = up;
            if (dioganal < min)
                min = dioganal;
            return min;
        }
    }
}
