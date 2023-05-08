using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class MD5
    {
        private static DateTime start;

        public static void Main()
        {
            /*//-------Run GFG class (combinations generator)------------
            String str = "ABC";
            int minStrLength = 1;
            int maxStrLength = 3;

            Console.Write("All permutations with repetition of {0} are: \n", str);
            GFG.allLexicographic(str, minStrLength, maxStrLength);
            GFG.GetBoundFromFile(5);

            Console.ReadLine();
            //------------ End of GFG --------------*/

            start = DateTime.Now;
            BreakPasswords();
            Console.ReadLine(); 

            /*BruteForce bruteForce = new BruteForce();
            bruteForce.GetPasswordAndRunAlgorithm();
            Console.ReadLine();*/

            /*string password = "AlaMaKota1234!";
            string s = CreateMD5(password);
            Console.WriteLine($"MD5 hash for {password}: {s}");
            Console.ReadLine();*/
        }

        public static void BreakPasswords()
        {
            string path = @"D:\PŚK\PSR\Projekt\hasla.txt";
            int numberOfFileLines = File.ReadLines(path).Count();

            for (int i = 1; i < numberOfFileLines; i++)
            {
                string password = File.ReadLines(path).Skip(i - 1).Take(1).First();
                BruteForce(password);
            }

            //Koniec mierzenia czasu
            DateTime stop = DateTime.Now;
            TimeSpan czasWykonania = stop - start;
            int czasLiczbowy = Convert.ToInt32(czasWykonania.TotalMilliseconds);
            Console.WriteLine("It took about:  " + czasLiczbowy + "ms");
            Console.WriteLine("It took about:  " + czasLiczbowy/numberOfFileLines + "ms / hasło");
            Console.WriteLine("It took about:  " + czasWykonania.TotalSeconds + "s");
        }

        public static void BruteForce(string password1)
        {
            BruteforceIter b = new BruteforceIter();
            b.min = 2;
            b.max = 4;
            b.alphabet = "!#$%&\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";

            foreach (string result in b)
            {
                //Console.Write(result + "\r");
                if (result == password1)
                {
                    Console.WriteLine(result);
                    b.SaveResultToFile(result);
                    return;
                }
            }
            
        }








        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                //return Convert.ToHexString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string 
                 StringBuilder sb = new System.Text.StringBuilder();
                 for (int i = 0; i < hashBytes.Length; i++)
                 {
                     sb.Append(hashBytes[i].ToString("X2"));
                 }
                 return sb.ToString().ToLower();
            }
        }
    }
}


