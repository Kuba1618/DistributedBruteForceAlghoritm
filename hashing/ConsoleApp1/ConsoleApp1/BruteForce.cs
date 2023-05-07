using System;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class BruteForce
    {
        private static String password; //password less than 5 characters 
        public static StringBuilder str = new StringBuilder("");
        private static int min = 32, max = 127;
        private static DateTime start;

        public BruteForce(String password1)
        {
            password = password1;
        }

        public void RunAlghoritm()
        {
            start = DateTime.Now;

            while (true)
            {
                str.Append((char)min);

                for (int i = 0; i < str.Length - 1; i++)
                {
                    for (int j = min; j < max; j++)
                    {
                        str[i] = (char)j;
                        bool passwordFound = bruteForceAlghoritm(i + 1);
                        if(passwordFound)
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
                    DateTime stop = DateTime.Now;
                    TimeSpan czasWykonania = stop - start;
                    int czasLiczbowy = Convert.ToInt32(czasWykonania.TotalMilliseconds);
                    StringBuilder str1 = new StringBuilder("");
                    str1.Append("" + password);
                    str1.Append(";" + czasLiczbowy + "ms");
                    SaveResultToFile(str1 + "");
                    Console.WriteLine(str1 + "");
                    Console.ReadLine();
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
                // Create a file to write to.
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
    }
}
