using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MD5
    {
        public static void Main()
        {
            /* string password = "test";
             string s = CreateMD5(password);

             Console.WriteLine($"MD5 hash for {password}: {s}");
             Console.ReadLine();*/
            //Generator generator = new Generator();
            //generator.displayPermutations();
            //generator.generateAll();

            String str = "AB1";
            int maxLength = 3;
            Console.Write("All permutations with repetition of {0} are: \n", str);
            GFG.allLexicographic(str, maxLength);

            /*BruteForce bruteForce = new BruteForce("abc");
            bruteForce.RunAlghoritm();*/


            Console.ReadLine();
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
                 return sb.ToString();
            }
        }
    }
}


