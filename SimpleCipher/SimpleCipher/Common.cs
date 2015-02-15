using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCipher
{
    class Common
    {

        public static string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

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
