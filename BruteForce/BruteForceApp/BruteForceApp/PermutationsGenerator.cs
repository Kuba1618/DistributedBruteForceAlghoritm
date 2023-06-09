using System;
using System.Collections.Generic;

namespace BruteForceApp
{
    public class PermutationsGenerator
    {
        public static List<string> GeneratePermutationsWithRepetitions(string startRange, string endRange)
        {
            List<string> permutations = new List<string>();

            GeneratePermutationsWithRepetitionsHelper(startRange, endRange, "", permutations, Compare);

            return permutations;
        }

        private static void GeneratePermutationsWithRepetitionsHelper(string startRange, string endRange, string current, List<string> permutations, Comparison<string> comparison)
        {
            if (current.Length >= startRange.Length && comparison(current, startRange) >= 0 && comparison(current, endRange) <= 0)
            {
                permutations.Add(current);
            }

            if (current.Length >= endRange.Length)
            {
                return;
            }

            for (char c = 'A'; c <= 'C'; c++)
            {
                GeneratePermutationsWithRepetitionsHelper(startRange, endRange, current + c, permutations, comparison);
            }
        }

        private static int Compare(string s1, string s2)
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
