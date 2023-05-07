using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // This code is contributed by PrinciRaj1992 from geeksforgeeks.org

    public class GFG
    {
        private static StringBuilder stringBuilder = new StringBuilder("");
        private static StringBuilder stringBuilderLocal = new StringBuilder("");

        static void allLexicographicRecur(String str, char[] data, int last, int index)
        {
            int length = str.Length;

            for (int i = 0; i < length; i++)
            {
                data[index] = str[i];

                if (index == last)
                {
                    Console.WriteLine(new String(data));
                    String s = new String(data) + "\n";
                    stringBuilderLocal.Append(s);
                }
                else
                    allLexicographicRecur(str, data, last, index + 1);
            }
        }

        public static void allLexicographic(String str,int minStrLength,int maxStrLength)
        {
            int maxLength = maxStrLength;
            
            for (int i = minStrLength - 1; i < maxStrLength; i++)
            {
                char[] data = new char[maxLength + 1];
                char[] temp = str.ToCharArray();

                Array.Sort(temp);
                str = new String(temp);

                allLexicographicRecur(str, data, i, 0);
                stringBuilder.Append(stringBuilderLocal.ToString());
                stringBuilderLocal = new StringBuilder("");
            }
            if (stringBuilder.ToString().EndsWith("\n"))
            {
                stringBuilder = stringBuilder.Remove(stringBuilder.Length - 2,2);
            }

            SaveResultToFile(stringBuilder.ToString());
        }

        public static void SaveResultToFile(string text)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + "\\combinations" + ".txt";

            DateTime thisMoment = DateTime.Now;
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(text);
                }
            }
            else
            {
                // This text is always added, making the file longer over time
                // if it is not deleted.
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text);
                }
            }
        }

        /*public static void Main(String[] args)
        {
            String str = "AB1";
            Console.Write("All permutations with repetition of {0} are: \n", str);
            allLexicographic(str);
            Console.ReadLine();


        }*/
    }

}
