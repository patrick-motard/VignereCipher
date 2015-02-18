using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCipher
{
    class Common
    {

        public static string alpha = "abcdefghijklmnopqrstuvwxyz";
        

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

        public static string ConcatenateLines(string[] input)
        {
            string fullTextString = "";
            foreach (string line in input)
            {
                fullTextString = fullTextString + " " + line;
            }
            return fullTextString;
        }

        public static string RemovePunctuation(string text)
        {
            var sb = new StringBuilder();
            foreach (char c in text)
            {
                if (!char.IsPunctuation(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string RemoveSpaces(string text)
        {
            var sb = new StringBuilder();
            foreach (char c in text)
            {
                if (!char.IsWhiteSpace(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static List<int> FindSpaceIndexes(string text)
        {
            List<int> indexOfSpaces = new List<int>();
            for (int i = 0; i < text.Length; i++)
            {
                char curChar = text[i];
                if (char.IsWhiteSpace(curChar))
                {
                    indexOfSpaces.Add(i);
                }
            }
            return indexOfSpaces;
        }

        internal static string InjectSpaces(string output, List<int> indexes)
        {
            for (int i = 0; i < indexes.Count; i++)
            {
                output = output.Insert(indexes[i], " ");
            }
            return output;
        }
    }
}
