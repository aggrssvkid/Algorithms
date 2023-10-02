using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.CommonFunctions;

namespace Algorithms.BinaryHeap.MaxHeap
{
    public partial class MaxHeap
    {
        // Просеивание последнего элемента массива вверх, дабы он занял свое место в куче с сохранением
        // основного свойства Макс. кучи
        private static void SiftUp(List<int> priorityQueue)
        {
            int i = priorityQueue.Count - 1;
            while (i > 0 && priorityQueue[i] > priorityQueue[(i - 1) / 2])
            {
                CommonFunc.Swap(priorityQueue, i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }

        // Просеивание первого (корневого) элемента массива вниз, дабы он занял свое место в массиве с сохранением
        // основного свойства макс. кучи
        internal static void SiftDown(List<int> priorityQueue)
        {
            int i = 0;
            int maxIdx = ChooseMaxIdx(priorityQueue, i);
            while (maxIdx < priorityQueue.Count && priorityQueue[i] < priorityQueue[maxIdx])
            {
                CommonFunc.Swap(priorityQueue, i, maxIdx);
                i = maxIdx;
                maxIdx = ChooseMaxIdx(priorityQueue, i);
            }
        }
        // Перезрузка функции SiftDown. Это нужно для того, если мы хотим указать размер массива (выделить часть из большего)
        // для которого будет выполнятся свойство макс. кучи
        internal static void SiftDown(List<int> priorityQueue, int priorityQueueSize, int idxElement)
        {
            int i = idxElement;
            int maxIdx = ChooseMaxIdx(priorityQueue, i);
            while (maxIdx < priorityQueueSize && priorityQueue[i] < priorityQueue[maxIdx])
            {
                CommonFunc.Swap(priorityQueue, i, maxIdx);
                i = maxIdx;
                maxIdx = ChooseMaxIdx(priorityQueue, i);
            }
        }


        // Вспомогательная функция для определения большего значения из дочерних элементов
        private static int ChooseMaxIdx(List<int> priorityQueue, int i)
        {
            int firstChildIdx = 2 * i + 1;
            if (firstChildIdx >= priorityQueue.Count)
                return int.MaxValue;
            int secondChildIdx = firstChildIdx + 1;
            if (secondChildIdx >= priorityQueue.Count)
                return firstChildIdx;
            if (priorityQueue[firstChildIdx] >= priorityQueue[secondChildIdx])
                return firstChildIdx;
            else
                return secondChildIdx;
        }
    }
}
