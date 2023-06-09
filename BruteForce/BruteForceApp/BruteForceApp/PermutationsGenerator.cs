using System;
using System.Collections.Generic;

namespace BruteForceApp
{
    public class PermutationsGenerator
    {
        public static List<string> GeneratePermutationsWithRepetitions(string alphabet,string startRange, string endRange)
        {
            List<string> permutations = new List<string>();
             
            GeneratePermutationsWithRepetitionsHelper(alphabet,startRange, endRange, "", permutations);

            return permutations;
        }

        private static void GeneratePermutationsWithRepetitionsHelper(string alphabet, string startRange, string endRange, string current, List<string> permutations)
        {
            if (current.Length >= startRange.Length && CompareTwoString(current, startRange) >= 0 && CompareTwoString(current, endRange) <= 0)
            {
                permutations.Add(current);
            }

            if (current.Length >= endRange.Length)
            {
                return;
            }

            for (int i = 0; i < alphabet.Length; i++)
            {
                GeneratePermutationsWithRepetitionsHelper(alphabet, startRange, endRange, current + alphabet[i], permutations);
            }
        }

        private static int CompareTwoString(string s1, string s2)
        {
            char[] charArray1 = s1.ToCharArray();
            char[] charArray2 = s2.ToCharArray();

            int minLength = Math.Min(charArray1.Length, charArray2.Length);

            if (charArray1.Length < charArray2.Length)
                return -1;
            else if (charArray1.Length > charArray2.Length)
                return 1;

            for (int i = 0; i < minLength; i++)
            {
                if (charArray1[i] < charArray2[i])
                    return -1;
                else if (charArray1[i] > charArray2[i])
                    return 1;
            }

            return 0;
        }
        
    }
}
