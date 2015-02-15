using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCipher
{
    class Vignere
    {
        public static string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string Cipher(string key, string text)
        {

            int textIndex = 0, keyIndex = -1;

            string encryptedText = "";

            while (textIndex < text.Length)
            {
                char textLetter = text[textIndex];

                keyIndex = GetKeyIndex(key, keyIndex);

                var keyLetter = key[keyIndex];

                var shiftAmount = FindIndexInAlpha(keyLetter);

                var indexOfTextLetterInAlpha = FindIndexInAlpha(textLetter);

                indexOfTextLetterInAlpha += shiftAmount;

                indexOfTextLetterInAlpha = WrapIndex(indexOfTextLetterInAlpha);

                textLetter = alpha[indexOfTextLetterInAlpha];

                encryptedText += textLetter;

                textIndex++;
            }

            return encryptedText;
        }

        public static int WrapIndex(int index)
        {
            if (index <= 25)
            {
                return index;
            }
            else
            {
                index = index - 26;
                return index;
            }
        }

        public static int GetKeyIndex(string key, int previousIndex)
        {
            if (previousIndex + 1 >= key.Length)
            {
                previousIndex = 0;
                return previousIndex;
            }
            else
            {
                previousIndex++;
                return previousIndex;
            };
        }

        public static int FindIndexInAlpha(char c)
        {
            c = Char.ToUpper(c);
            for (int i = 0; i < alpha.Length; i++)
            {
                char l = alpha[i];
                if (l == c)
                {
                    return i;
                };
            };
            return -1;
        }
    }
}
