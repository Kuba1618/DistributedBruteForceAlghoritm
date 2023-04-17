using System;
using System.IO;
using System.Text;

namespace WindowsFormsApplication1
{
    class BruteForce
    {
        private static String password; //521ab
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
                        bruteForceAlghoritm(i + 1);
                    }
                }
            }
        }


        public void bruteForceAlghoritm(int index)
        {
            for (int i = min; i < max; i++)
            {
                str[index] = (char)i;

                if (index < str.Length - 1)
                {
                    bruteForceAlghoritm(index + 1);
                }

                //Console.WriteLine(str);

                if (str.ToString().Equals(password))
                {
                    DateTime stop = DateTime.Now;
                    TimeSpan czasWykonania = stop - start;
                    int czasLiczbowy = Convert.ToInt32(czasWykonania.TotalMilliseconds);
                    StringBuilder str1 = new StringBuilder("");
                    str1.Append("" + str);
                    str1.Append(";" + czasLiczbowy + "ms");
                    SaveResultToFile(str1 + "");
                }
            }
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
