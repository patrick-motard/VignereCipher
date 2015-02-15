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

        public static string key = "doggy";
        public static string text = "thisisatestmeepo";

        

        static void Main(string[] args)
        {
            var ecrypte = Vignere.Cipher(key, text);
            Console.WriteLine(ecrypte);
            string directory = Directory.GetCurrentDirectory();

            Console.WriteLine(directory);
            Console.ReadLine();

            //var dog = Permutation.Columnize("doggy","cat");
            //Console.WriteLine(dog[0]);
            //Console.WriteLine(dog[1]);
            //Console.WriteLine(dog[2]);
            Console.ReadLine();
        }
    };
}
