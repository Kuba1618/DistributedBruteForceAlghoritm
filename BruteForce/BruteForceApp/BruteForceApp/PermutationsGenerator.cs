using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceApp
{
    public class PermutationsGenerator
    {
        public static List<string> GeneratePermutations(List<char> alphabet, int minLength, int maxLength, string startRange, string endRange)
        {
            List<string> permutations = new List<string>();
            for (int length = minLength; length <= maxLength; length++)
            {
                GeneratePermutationsHelper(alphabet, "", permutations, length, startRange, endRange);
            }
            return permutations;
        }

        private static void GeneratePermutationsHelper(List<char> alphabet, string currentPermutation, List<string> permutations, int length, string startRange, string endRange)
        {
            if (currentPermutation.Length == length)
            {
                if ((!string.IsNullOrEmpty(startRange) && string.Compare(currentPermutation, startRange) < 0) ||
                    (!string.IsNullOrEmpty(endRange) && string.Compare(currentPermutation, endRange) > 0 && currentPermutation != endRange)) // zmieniony warunek dla endRange
                {
                    return;
                }

                permutations.Add(currentPermutation);
                return;
            }

            for (int i = 0; i < alphabet.Count; i++)
            {
                char currentChar = alphabet[i];
                alphabet.RemoveAt(i);

                GeneratePermutationsHelper(alphabet, currentPermutation + currentChar, permutations, length, startRange, endRange);

                alphabet.Insert(i, currentChar);
            }
        }

    }
}
