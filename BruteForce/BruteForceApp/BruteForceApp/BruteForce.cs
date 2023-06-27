using System;
using System.Collections.Generic;

namespace BruteForceApp
{
    class BruteForce
    {
        public static void Run(List<string> passwords, string alphabet, string startRange, string endRange)
        {
            List<string> listOfPermutations = PermutationsGenerator.GeneratePermutationsWithRepetitions(alphabet, startRange, endRange); //generowanie permutacji
            Console.WriteLine("Koniec generowania permutacji");
            passwords = MD5.CreateListOfMD5(passwords); //pobiera w parametrze listę haseł, zamienia ją na listę hash'y i zapisuje do tej samej listy
            listOfPermutations = MD5.CreateListOfMD5(listOfPermutations); //jak powyżej ... tylko dla listy permutacji 
            Console.WriteLine("Skończyłem generowanie permutacji i haszowanie. Zaczynam łamać hasła ...\n");
            ComparePasswordsListWithHashes(passwords, listOfPermutations);

        }

        private static void ComparePasswordsListWithHashes(List<string> passwords, List<string> listOfPermutations)
        {
            foreach (string password in passwords)
            {

                Console.Write("Teraz zajmuje się: " + password);

                if (CompareHash(password, listOfPermutations))
                {
                    // ----------- !!! HASŁO ZNALEZIONE !!! -----------------------
                    Console.Write("          Hasło złamane, " + password);
                }
                Console.Write("\n");
            }
        }

        private static bool CompareHash(string password, List<string> listOfPermutations)
        {
            DateTime startTime = DateTime.Now;
            TimeSpan timeout = TimeSpan.FromSeconds(2);

            foreach (string permutation in listOfPermutations)
            {
                DateTime endTime = DateTime.Now;

                if(endTime - startTime > timeout)
                {
                    Console.Write("          Upłynął limit czasu");
                    return false;
                }
                if (password.Equals(permutation))
                {
                    return true;
                }
            }

            return false;
        }
    }
}