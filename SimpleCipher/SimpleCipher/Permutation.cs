using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCipher
{
    class Permutation
    {
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
    }
}