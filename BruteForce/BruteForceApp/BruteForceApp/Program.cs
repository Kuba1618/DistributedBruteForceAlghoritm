using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BruteForceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // CallMD5();
            //CallListOfMD5();
            generateAlphabet();
            //CallPermutationGenerator();

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
            passwords = MD5.CreateMD5(passwords);
            foreach (string s in passwords)
            {
                Console.WriteLine("{0}", s);
            }
        }

        public static List<string> readFromFile()
        {
            List<string> linesFromFile = new List<string>();
            string path = @"D:\PŚK\PSR\Projekt\hasla.txt";
            int numberOfFileLines = File.ReadLines(path).Count();

            for (int i = 1; i < numberOfFileLines; i++)
            {
                string password = File.ReadLines(path).Skip(i - 1).Take(1).First();
                linesFromFile.Add(password);
            }

            return linesFromFile;
        }

        public static void generateAlphabet() 
        {
           String str = "ACB";
           int minStrLength = 1;
           int maxStrLength = 3;

           Console.Write("All permutations with repetition of {0} are: \n", str);
            Alphabet.allLexicographic(str, minStrLength, maxStrLength);
            Alphabet.GetBoundFromFile(4);
        }

        public static void generateAplhabetFromRange()
        {
            String str = "ABC";
            int minStrLength = 1;
            int maxStrLength = 3;

            Console.Write("All permutations with repetition of {0} are: \n", str);
            Alphabet.allLexicographic(str, minStrLength, maxStrLength);
            Alphabet.GetBoundFromFile(4);
        }

        public static void CallPermutationGenerator() 
        {
            List<char> alphabet = new List<char>() { 'A', 'B', 'C' };
            int minLength = 1;
            int maxLength = 3;
            string startRange = "B";
            string endRange = "CC";
            List<string> permutations = PermutationsGenerator.GeneratePermutations(alphabet, minLength, maxLength, startRange, endRange);

            foreach (string permutation in permutations)
            {
                Console.WriteLine(permutation);
            }
        }
    }
}

//@ToDo #1 zrobić haszowanie listy haseł
//
//@ToDo #2 wdrożyć haszowanie do algorytmu Bruteforce
//
//@ToDo #3 znaleść sposób jak ograniczyć metodę czasowo
//
//@ToDo #4 generowanie alfabetu na podstawie zakresu
