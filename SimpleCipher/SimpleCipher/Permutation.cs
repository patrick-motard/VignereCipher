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
            _cipherText = cipherText;
            _key = key;
            _shiftAmounts = new List<int>();
            _orderedAlphaIndexes = new List<int>();
            _subsets = new List<string>();
        }


        private static List<string> Columnize()
        {

            for (int i = 1; i < _cipherText.Length; i++){
                if (i % _key.Length == 0){
                    _subsets.Add(_cipherText.Substring(i - _key.Length, _key.Length));
                }
            }

            var remainder = _cipherText.Length % _key.Length;
            if (remainder != 0)
            {
                var startingIndexOfLastChunk = _cipherText.Length - remainder;
                string lastChunk = _cipherText.Substring(startingIndexOfLastChunk, remainder);
                int amountToAppendAtEnd = _key.Length - lastChunk.Length;
                for (int i = 0; i < amountToAppendAtEnd; i++)
                {
                    lastChunk += "k";
                }
                    _subsets.Add(lastChunk);
            }
            return _subsets;
        }

        private static List<int> KeyToAlphaIndex(string key)
        {
            List<int> keyIndexsInAlpha = new List<int>();

            for (int i = 0; i < key.Length; i++)
            {
                keyIndexsInAlpha.Add(Common.FindIndexInAlpha(key[i]));
            }
            return keyIndexsInAlpha;
        }

        private static void Permutate()
        {
            var alphaIndexes = KeyToAlphaIndex(_key);
            List<int> sortedAlphaIndexes = new List<int>(alphaIndexes);
            sortedAlphaIndexes.Sort();

            for (int i = 0; i < alphaIndexes.Count; i++)
            {
                for (int j = 0; j < sortedAlphaIndexes.Count; j++)
                {
                    if (alphaIndexes[i] == sortedAlphaIndexes[j])
                    {
                        _shiftAmounts.Add(j);
                    }
                }
            }
        }

        private static string ShiftSubset(string subset)
        {
            string shiftedSubset = "";
            string[] shiftedSubsetArray = new string[subset.Length];

            for (int i = 0; i < subset.Length; i++)
            {
                shiftedSubsetArray[_shiftAmounts[i]] = subset[i].ToString();
            }
            for (int j = 0; j < shiftedSubsetArray.Length; j++)
            {
                shiftedSubset += shiftedSubsetArray[j];
            }
            return shiftedSubset;
        }

        public static string Encrypt()
        {
            
            Columnize();
            Permutate();
            for (int i = 0; i < _subsets.Count; i++)
            {
                _encryptedText += ShiftSubset(_subsets[i]);

            }
                return _encryptedText;
        }

        private static List<string> _subsets;
        private List<int> _orderedAlphaIndexes;
        private static List<int> _shiftAmounts;
        private static string _key;
        private static string _cipherText;
        private static string _encryptedText;
    }
}