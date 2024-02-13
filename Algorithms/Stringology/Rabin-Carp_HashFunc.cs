using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * S pomowyu etogo algoritma nahodim vse vhozhdeniya stroki "pattern" v stroku "text"
 * Dlya etogo predstavlyaem stroku kak posledovatelnost chisel i perevodim posledovatelnost v odno choslo (hashFunction)
 * s pomowyu polynoma (a * x^0 + a * x^1 + a * x^2 i tak dalee), gde koff "a" - symbol code.
 * Predpolagaetsya, chto "pattern.len" > 1 and "text.len" > "pattern.len"
 */

namespace Algorithms.Stringology
{
    public class StrHashTable
    {
        private int[] hashTable;

        private readonly long p = 1000000007; // constanta dlya togo, chtobi v "int" znacheniya pomewalis

        private readonly int x = 263; // osnovanie v polynome. chem bolshe raznih simvolov, tem bolshe nado brat "x"

        private static int[] pows; // zaranee schitaem stepeni "x" polynoma

        private int patternSize; //  dlina stroki, vhozhdeniya kotoroy iwem

        private string text; // v texte iwem vhozhdeniya stroki "pattern"
        public StrHashTable(int patternLen, string txt) // init hashTable
        {
            patternSize = patternLen;
            text = txt;
            pows = new int[patternSize];
            pows[0] = 1;
            // schitaem stepeni zaranee
            for (int i = 1; i < patternSize; i++)
            {
                long kek = (long)pows[i - 1] * x;
                pows[i] = (int)(kek % p);
            }
            hashTable = new int[text.Length];
            int lastIdx = text.Length - patternSize;
            hashTable[lastIdx] = GetHash(text.Substring(lastIdx, patternSize)); // hash last podstroki razmera "pattern.len"
            for (int i = lastIdx - 1; i >= 0; i--)
            {
                /* dalee vichislyaem hashi dlya vseh okon razmera "pattern" */
                int hashPrevious = hashTable[i + 1]; // hash prediduschey podstroki
                long lastSymbol = (long)text[i + patternSize]; // hash poslednego symbola nado budet otnyat
                int lastSymbolHash = (int)((lastSymbol * (long)pows[patternSize - 1]) % p);
                long newSymbolHash = (long)text[i]; //  hash novogo symvola - dobavit.
                /* hash stroki, nachalo kotoroy v indexe "i". Tak kak vichitanie, to dobavlyaem "p", chtobi otric ne bilo */
                int currentHash = (int)(((((hashPrevious - lastSymbolHash + p) * x) + newSymbolHash) % p));
                hashTable[i] = currentHash;
            }
            // zapolnyaem lishnie simvoli. Podstroki "text", beruwie nachalo v etih simvolah tochno ne sovpad s "pattern"
            // ih dlina uzhe menshe "pattern.len"
            for (int i = lastIdx + 1; i < text.Length; i++)
                hashTable[i] = -1;
        }

        public List<int> GetSubStrings(string pattern)
        {
            List<int> startIndexes = new List<int>(); // zdes vse nachala sovpad s pattern
            if (pattern == null || pattern == "")
                return startIndexes;
            var patternHash = GetHash(pattern);
            for (int i = 0; i <= text.Length - patternSize; i++)
            {
                if (patternHash == hashTable[i])
                    startIndexes.Add(i);
            }
            return startIndexes;
        }

        // Hash-Function sobstvennoy personi
        private int GetHash(string str)
        {
            long hash = 0;
            for (int i = 0; i < str.Length; i++)
            {
                long symbolCode = (long)str[i];
                hash += symbolCode * pows[i];
            }
            hash = (hash % p);
            return (int)hash;
        }
    }
}
