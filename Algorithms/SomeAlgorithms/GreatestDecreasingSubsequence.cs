using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Находим наибольшую убывающую последовательность из массива чисел.
 */

namespace Algorithms.SomeAlgorithms
{
    public static partial class MathAlg
    {
        public static int[] GreatestDecreasingSubsequence(int[] arr)
        {
            int numsQty = arr.Length;
            // Podgotavlivaem massivi dlya hraneniya elementov i indexov etih elementov
            var lenArrValue = new List<int>(numsQty);
            lenArrValue.Add(arr[^1]);
            var lenArrIdx = new List<int>(numsQty);
            lenArrIdx.Add(arr.Length - 1);
            int[] previousArr = Enumerable.Repeat(-1, numsQty).ToArray();

            // Programm, nado vspomnit kak rabotaet
            for (int i = numsQty - 2; i >= 0; i--)
            {
                var currentNum = arr[i];
                int numPlace = lenArrValue.BinarySearch(currentNum);
                if (numPlace >= 0)
                {
                    while (numPlace < lenArrValue.Count && currentNum == lenArrValue[numPlace])
                        numPlace++;
                    if (numPlace == lenArrValue.Count)
                    {
                        lenArrValue.Add(currentNum);
                        lenArrIdx.Add(i);
                    }
                    else
                    {
                        lenArrValue[numPlace] = currentNum;
                        lenArrIdx[numPlace] = i;
                    }
                    if (numPlace > 0)
                        previousArr[i] = lenArrIdx[numPlace - 1];
                }
                else
                {
                    numPlace = -numPlace - 1;
                    if (numPlace == lenArrValue.Count)
                    {
                        lenArrValue.Add(currentNum);
                        lenArrIdx.Add(i);
                    }
                    else
                    {
                        var arrNum = lenArrValue[numPlace];
                        if (arrNum > currentNum)
                        {
                            lenArrValue[numPlace] = currentNum;
                            lenArrIdx[numPlace] = i;
                        }
                    }
                    if (numPlace > 0)
                        previousArr[i] = lenArrIdx[numPlace - 1];
                }
            }

            //  Формируем Output
            int prev = lenArrIdx.Last();
            List<int> answer = new List<int>();
            while (prev >= 0)
            {
                answer.Add(prev + 1);
                prev = previousArr[prev];
            }

            return answer.ToArray();
        }
        
    }
}
