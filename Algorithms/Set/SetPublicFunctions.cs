using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set
{
    public class Set
    {
        // Sozdaem massiv, v kotorom kazhdiy element - sam sebe roditel (mnozhestvo s odnim elementom)
        public static void MakeSet(int[] parent)
        {
            for (int i = 0; i < parent.Length; i++)
                parent[i] = i;
        }

        /* obyedinenie mnozhestv */
        public static void Union(int destination, int source, int[] parent, int[] rank)
        {
            // ot "rank" mnozhestva zavisit, kakoe derevo k kakomu podvyazhem
            int korenDestination = FindKoren(destination, parent);
            int korenSource = FindKoren(source, parent);
            if (korenDestination == korenSource)
                return;
            if (rank[korenDestination] > rank[korenSource])
            {
                parent[korenSource] = korenDestination;
            }
            else if (rank[korenDestination] < rank[korenSource])
            {
                parent[korenDestination] = korenSource;
            }
            else
            {
                parent[korenSource] = korenDestination;
                rank[korenDestination] += 1;
            }
        }

        // koren - identificator mnozhestva, kotoromu prinadlezhit element
        public static int FindKoren(int elementIdx, int[] parent)
        {
            while (elementIdx != parent[elementIdx])
                elementIdx = parent[elementIdx];
            return elementIdx;
        }
    }
}
