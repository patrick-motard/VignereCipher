using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpleCipher
{
    class Program
    {
        public static string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string key = "motard";
        public static string text = "this is a test meepo just a test";

        public static string VigenereCipher(string key, string text)
        {

            int increment = 0, keyIndex = -1;

            string encryptedText = "";

            while (increment < text.Length)
            {
                char nextLetterFromText = text[increment];
                keyIndex = GetKeyIndex(key, keyIndex);

            }

            return "";
        }

        public static int GetKeyIndex(string key, int previousIndex)
        {
            if (previousIndex + 1 >= key.Length)
            {
                previousIndex = -1;
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

        static void Main(string[] args)
        {
            string directory = Directory.GetCurrentDirectory();
            char newCharacter = 'D';
            Console.WriteLine(FindIndexInAlpha(newCharacter));
            Console.WriteLine(directory);
            Console.ReadLine();
        }
    };
}
