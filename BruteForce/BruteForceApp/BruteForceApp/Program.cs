using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BruteForceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // CallMD5();
            //CallListOfMD5();
            //CallPermutationGenerator();
            //TimeExecutor.CallTimeExecutor();
            CallBruteForce();
            Console.ReadLine();
        }

/*        public static void CallMD5()
        {
            string password = "AlaMaKota1234!";
            string s = MD5.CreateMD5(password);
            Console.WriteLine($"MD5 hash for {password}: {s}");
        }*/

        public static void CallListOfMD5()
        {
            List<string> passwords = readFromFile();
            passwords = MD5.CreateListOfMD5(passwords);
            foreach (string s in passwords)
            {
                Console.WriteLine("{0}", s);
            }
        }

        public static List<string> readFromFile()
        {
            List<string> lines = new List<string>();
            string filePath = @"D:\PŚK\PSR\Projekt\hasla223.txt";

            try
            {
                using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd podczas odczytu pliku: " + ex.Message);
            }

            return lines;
        }

        public static void CallPermutationGenerator() 
        {
            string alphabet = "ABD";
            string startRange = "A";
            string endRange = "DD";

            List<string> permutations = PermutationsGenerator.GeneratePermutationsWithRepetitions(alphabet,startRange, endRange);

            foreach (string permutation in permutations)
            {
                Console.WriteLine(permutation);
            }
        }

        public static void CallBruteForce()
        {
            List<string> passwords = readFromFile();
            string alphabet = "'0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!#$%&\'()*+,-./:;<=>?@[\\]^_`{|}~ \t\n\r\x0b\x0c";
            //'0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!"#$%&\'()*+,-./:;<=>?@[\\]^_`{|}~ \t\n\r\x0b\x0c
            string startRange = "A";
            string endRange = "ACC";
            BruteForce.Run(passwords,alphabet,startRange,endRange);
        }

    }
}

//@ToDo #2 znaleść sposób jak ograniczyć metodę czasowo
