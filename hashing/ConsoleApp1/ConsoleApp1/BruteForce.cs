using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class BruteForce
    {
        private static String password; //password less than 5 characters 
        public static StringBuilder str = new StringBuilder("");
        private static int min = 32, max = 127;
        private static DateTime start;
        private static string path = @"D:\PŚK\PSR\Projekt\hasla.txt";

        public BruteForce()
        {

        }

        public BruteForce(String password1)
        {
            password = password1;
        }

        public void Alghoritm(String pass)
        {
            bool passwordFound;
            password = pass;
            Console.WriteLine("pass: {0}", password);
            start = DateTime.Now;

            while (true)
            {
                str.Append((char)min);

                for (int i = 0; i < str.Length - 1; i++)
                {
                    for (int j = min; j < max; j++)
                    {
                        str[i] = (char)j;
                        passwordFound = bruteForceAlghoritm(i + 1);
                        //Console.WriteLine(passwordFound);
                        if (passwordFound)
                        {
                            return;
                        }
                    }
                }
            }
        }


        public bool bruteForceAlghoritm(int index)
        {
            for (int i = min; i < max; i++)
            {
                str[index] = (char)i;

                //Console.WriteLine(str);

                //if(HASŁO ZNALEZIONE)
                if (str.ToString().Equals(password))
                {
                    StringBuilder str1 = new StringBuilder("");
                    str1.Append("" + password);
                    SaveResultToFile(str1 + "");
                    Console.WriteLine(str1 + "");
                    return true;
                }

                if (index < str.Length - 1)
                {
                    bruteForceAlghoritm(index + 1);
                }
            }
            return false;
        }

        public void SaveResultToFile(string text)
        {
            string path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + "\\passwords" + ".txt";

            DateTime thisMoment = DateTime.Now;
            if (!File.Exists(path1))
            {
                // Create alphabet file to write to.
                using (StreamWriter sw = File.CreateText(path1))
                {
                    sw.WriteLine(text);
                }
            }
            else
            {
                // This text is always added, making the file longer over time
                // if it is not deleted.
                using (StreamWriter sw = File.AppendText(path1))
                {
                    sw.WriteLine(text);
                }
            }
        }

        public void GetPasswordAndRunAlgorithm()
        {
            int numberOfFileLines = File.ReadLines(path).Count();
            for (int i = 1; i < 5; i++)
            {
                //Console.WriteLine(File.ReadLines(path).Skip(i - 1).Take(1).First());
                string s = File.ReadLines(path).Skip(i - 1).Take(1).First();
                Alghoritm(s);
            }
        }
    }
}