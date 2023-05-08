using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    // This code is contributed by PrinciRaj1992 from geeksforgeeks.org

    public class GFG
    {
        private static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + "\\combinations" + ".txt";
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
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(text);
                }
            }
            else
            {
                System.IO.File.WriteAllText(path, string.Empty);

                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text);
                }
            }
        }

        public static void GetBound(int numberOfComputers)
        {
            int numberOfFileLines = File.ReadLines(path).Count();
            int numberOfLines = numberOfFileLines / numberOfComputers;
            Console.WriteLine(numberOfLines + "");

            for (int i = 1; i < numberOfFileLines; i += numberOfLines)
            {
                if(i + numberOfLines - 1 > numberOfFileLines)
                {
                    Console.WriteLine(i + "-" + numberOfFileLines);
                    Console.WriteLine(File.ReadLines(path).Skip(i - 1).Take(1).First() + "- " + File.ReadLines(path).Skip(numberOfFileLines - 1).Take(1).First());
                }
                else
                {
                    Console.WriteLine(i + "-" + (i + numberOfLines - 1));
                    Console.WriteLine(File.ReadLines(path).Skip(i - 1).Take(1).First() + "- " + File.ReadLines(path).Skip(i + numberOfLines - 2).Take(1).First());
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
