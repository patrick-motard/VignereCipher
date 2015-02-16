using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCipher
{
    class Permutation
    {
        public Permutation(string key, string cipherText)
        {
            this._cipherText = cipherText;
            this._key = key;
            this._dog = "dog";

        }


        public static List<string> Columnize(string text, string key)
        {
            List<string> columnizedText = new List<string>();

            for (int i = 1; i < text.Length; i++){
                if (i % key.Length == 0){
                    columnizedText.Add(text.Substring(i - key.Length, key.Length));
                }
            }

            var remainder = text.Length % key.Length;
            if (remainder != 0)
            {
                var startingIndexOfLastChunk = text.Length - remainder;
                columnizedText.Add(text.Substring(startingIndexOfLastChunk, remainder));
            }
            return columnizedText;
        }

        public static List<int> KeyToAlphaIndex(string key)
        {
            List<int> keyIndexsInAlpha = new List<int>();

            for (int i = 0; i < key.Length; i++)
            {
                keyIndexsInAlpha.Add(Common.FindIndexInAlpha(key[i]));
            }
            return keyIndexsInAlpha;
        }

        public static List<int> Permutate(string key)
        {
            var chicken = KeyToAlphaIndex(key);
            List<int> dog = new List<int>(chicken);
            dog.Sort();
            List<int> shiftAmounts = new List<int>();

            for (int i = 0; i < chicken.Count; i++)
            {
                for (int j = 0; j < dog.Count; j++)
                {
                    if (chicken[i] == dog[j])
                    {
                        shiftAmounts.Add(j);
                    }
                }
            }
            return shiftAmounts;
        }

        public static void ShiftSubset(string subset)
        {

        }

        private List<int> _orderedAlphaIndexes = null;
        private string _key;
        private string _cipherText { get; set; }

        private string _dog { get; set; }
    }
}