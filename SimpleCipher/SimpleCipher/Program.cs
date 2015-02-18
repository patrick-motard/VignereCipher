using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace SimpleCipher
{
    class Program
    {

        public static string key;
        public static string fileName;
        public static string encryptionMethod;
        public static string removeSpaces;
        public static string outputFileName;

        static void Main(string[] args)
        {

            key = args[0];
            fileName = args[1];
            encryptionMethod = args[2];
            removeSpaces = args[3];
            outputFileName = args[4];

            if (args[0] == "help")
            {
                Console.WriteLine("Consult README file in root directory of Program.exe");
            }

            string directory = Directory.GetCurrentDirectory();
            string fullyQualifiedLocation = directory + "\\" + fileName;
            string[] text = System.IO.File.ReadAllLines(@fullyQualifiedLocation);

            string fullTextString = Common.ConcatenateLines(text);
            fullTextString = Common.RemovePunctuation(fullTextString);
            fullTextString = fullTextString.ToLower();
            List<int> indexOfSpaces = Common.FindSpaceIndexes(fullTextString);
            fullTextString = Common.RemoveSpaces(fullTextString);

            string output = "";


            if (encryptionMethod == "P")
            {
                var permutationEncryption = new Permutation(key, fullTextString);
                output = Permutation.Encrypt();

            }
            else if (encryptionMethod == "V")
            {
                output = Vignere.Cipher(key, fullTextString);
            }
            else
            {
                Console.WriteLine("Error: 3rd parameter expects 'P' for Permutation or 'V' for Vignere. Please try again.");
            };

            if (removeSpaces == "true")
            {
                try
                {
                    string outputDir = directory + '\\' + outputFileName;
                    System.IO.File.WriteAllText(@outputDir, output);
                    Console.WriteLine("Successfully wrote encrypted message to output.txt");
                }
                catch (System.IO.IOException)
                {
                    Console.WriteLine(outputFileName + "already exists. Please specify a different output file.");
                }

            }
            else if (removeSpaces == "false")
            {
                output = Common.InjectSpaces(output, indexOfSpaces);
                try
                {
                    string outputDir = directory + '\\' + outputFileName;
                    System.IO.File.WriteAllText(@outputDir, output);
                    Console.WriteLine("Successfully wrote encrypted message to output.txt");
                }
                catch (System.IO.IOException)
                {
                    Console.WriteLine(outputFileName + "already exists. Please specify a different output file.");
                }
            }
            else
            {
                Console.WriteLine("Error: 4th parameter expects 'true' to include spaces in output, or 'false' to exclude spaces in output. Please try again.");
            };
            
            
            Console.ReadLine();
        }
    };
}
