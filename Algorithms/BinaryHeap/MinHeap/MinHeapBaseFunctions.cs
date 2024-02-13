using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Мин. куча для любых типов (классов)
 */

namespace Algorithms.BinaryHeap.MinHeap
{
    public partial class MinHeap
    {
        // Просеивание последнего элемента массива вверх, дабы он занял свое место в куче с сохранением
        // основного свойства Мин. кучи
        private static void SiftUp<T>(List<T> priorityQueue, IComparer<T> comparer)
        {
            int i = priorityQueue.Count - 1;
            while (i > 0 && comparer.Compare(priorityQueue[i], priorityQueue[(i - 1) / 2]) < 0)
            {
                Swap(priorityQueue, i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }

        // Просеивание последнего элемента массива вниз, дабы он занял свое место в куче с сохранением
        // основного свойства Мин. кучи
        public static void SiftDown<T>(List<T> priorityQueue, IComparer<T> comparer)
        {
            int i = 0;
            int minIdx = ChooseMinIdx(priorityQueue, i, comparer);
            while (minIdx < priorityQueue.Count && comparer.Compare(priorityQueue[i], priorityQueue[minIdx]) > 0)
            {
                Swap(priorityQueue, i, minIdx);
                i = minIdx;
                minIdx = ChooseMinIdx(priorityQueue, i, comparer);
            }
        }

        private static void SiftDown<T>(List<T> priorityQueue, int priorityQueueSize, int idxElement, IComparer<T> comparer)
        {
            int i = idxElement;
            int minIdx = ChooseMinIdx(priorityQueue, i, comparer);
            while (minIdx < priorityQueueSize && comparer.Compare(priorityQueue[i], priorityQueue[minIdx]) > 0)
            {
                Swap(priorityQueue, i, minIdx);
                i = minIdx;
                minIdx = ChooseMinIdx(priorityQueue, i, comparer);
            }
        }

        // Определяем минимальный элемент из 2-х дочерних
        private static int ChooseMinIdx<T>(List<T> priorityQueue, int i, IComparer<T> comparer)
        {
            int firstChildIdx = 2 * i + 1;
            if (firstChildIdx >= priorityQueue.Count)
                return int.MaxValue;
            int secondChildIdx = firstChildIdx + 1;
            if (secondChildIdx >= priorityQueue.Count)
                return firstChildIdx;
            if (comparer.Compare(priorityQueue[firstChildIdx], priorityQueue[secondChildIdx]) <= 0)
                return firstChildIdx;
            else
                return secondChildIdx;
        }
        
        // Стандартный свап позиций между 2-мя элементами одного массива
        private static void Swap<T>(List<T> priorityQueue, int idx1, int idx2)
        {
            var tmp = priorityQueue[idx1];
            priorityQueue[idx1] = priorityQueue[idx2];
            priorityQueue[idx2] = tmp;
        }
    }
}
