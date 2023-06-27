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
            //CallMD5();
            //CallListOfMD5();
            //CallPermutationGenerator();
            //TimeExecutor.CallTimeExecutor();
            CallBruteForce();
            Console.WriteLine("Wściśnij enter aby zakończyć działanie programu.");
            Console.ReadLine();
        }

        public static void CallMD5()
        {
            string password = "AlaMaKota1234!";
            string s = MD5.CreateMD5(password);
            Console.WriteLine($"MD5 hash for {password}: {s}");
        }

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
            string filePath = @"D:\PSK\PSR\Projekt\hasla223.txt";

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
            string alphabet = "ABC";
            string startRange = "AC";
            string endRange = "AAA";

            List<string> permutations = PermutationsGenerator.GeneratePermutationsWithRepetitions(alphabet,startRange, endRange);

            foreach (string permutation in permutations)
            {
                Console.WriteLine(permutation);
            }
        }

        public static void CallBruteForce()
        {
            //Ilość rdzeni procesora
            //Console.WriteLine(System.Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS")); 
            List<string> passwords = readFromFile();
            //'0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!"#$%&\'()*+,-./:;<=>?@[\\]^_`{|}~ \t\n\r\x0b\x0c
            string alphabet = "ABC";
            string startRange = "AC";
            string endRange = "AAA";
            BruteForce.Run(passwords,alphabet,startRange,endRange);
        }

    }
}

//@ToDo #2 znaleść sposób jak ograniczyć metodę czasowo
