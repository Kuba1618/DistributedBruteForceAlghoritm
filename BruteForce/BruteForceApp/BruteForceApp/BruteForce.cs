using System;
using System.Collections.Generic;

namespace BruteForceApp
{
    class BruteForce
    {
        public static void Run(List<string> passwords, string alphabet, string startRange, string endRange)
        {
            List<string> listOfPermutations = PermutationsGenerator.GeneratePermutationsWithRepetitions(alphabet, startRange, endRange); //generowanie permutacji
          
            passwords = MD5.CreateListOfMD5(passwords); //pobiera w parametrze listę haseł, zamienia ją na listę hash'y i zapisuje do tej samej listy
            listOfPermutations = MD5.CreateListOfMD5(listOfPermutations); //jak powyżej ... tylko dla listy permutacji 

            ComparePasswordsListWithHashes(passwords, listOfPermutations);
            
        }

        private static void ComparePasswordsListWithHashes(List<string> passwords,List<string> listOfPermutations)
        {
            foreach (string password in passwords)
            { 
                if (CompareHash(password, listOfPermutations))
                {
                    // ----------- !!! HASŁO ZNALEZIONE !!! -----------------------
                    Console.WriteLine("Hasło złamane");
                }
            }
        }

        private static bool CompareHash(string password, List<string> listOfPermutations)
        {
            foreach(string permutation in listOfPermutations)
            {
                if(password.Equals(permutation))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
