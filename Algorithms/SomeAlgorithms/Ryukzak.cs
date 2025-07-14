using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.SomeAlgorithms
{
    internal class Ryukzak
    {
        /*
         * Пусть A(k,s) есть максимальная стоимость предметов, которые можно уложить в рюкзак вместимости s, 
         * если можно использовать только первые k предметов, то есть {n1,n2,…,nk}, 
         * назовем этот набор допустимых предметов для A(k,s).
         */
        public static int[][] GetTable(int[] cost, int[] weight, int maxVmestimost, int k)
        {
            int[][] res = new int[k + 1][];
            for (int i = 0; i <= k; i++)
                res[i] = new int[maxVmestimost + 1];

            // zapolnyaem nulyami pervie znacheniya
            for (int i = 0; i <= k; i++)
                res[i][0] = 0;

            for (int i = 0; i <= maxVmestimost; i++)
                res[0][i] = 0;

            // dalee algoritm
            for (int i = 1; i <= k; i++)
            {

                for (int currentVes = 1; currentVes <= maxVmestimost; currentVes++)
                {
                    int predmetVes = weight[i - 1];
                    int predmetCost = cost[i - 1];
                    //если вес текущего предмета превышает вместимость рюкзака, то мы не можем положить этот предмет
                    // в рюкзак, поэтому максимальная стоимость для текущей вместимости сохраняется и ее можно достать
                    // из предыдущей ячейки res[i - 1][currentVes]
                    if (predmetVes > currentVes)
                        res[i][currentVes] = res[i - 1][currentVes];
                    else
                    {
                        int addThis = res[i - 1][currentVes - predmetVes >= 0 ? currentVes - predmetVes : 0] + predmetCost;
                        int withoutThis = res[i - 1][currentVes];
                        res[i][currentVes] = addThis > withoutThis ? addThis : withoutThis;
                    }
                    // если мы можем положить i-й предмет в рюкзак, то нам надо понять, будет ли это выгодно,
                    // то есть будет ли цена предметов в рюкзаке с i-м предметов больше, чем цена предметов без него
                    // (с каким-нибудь другим предметом меньшего веса)
                }
            }
            return res;
        }
    }
}
