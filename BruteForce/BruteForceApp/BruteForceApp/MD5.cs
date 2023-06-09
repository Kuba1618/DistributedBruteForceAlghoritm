using System;
using System.Collections.Generic;
using System.Text;

namespace BruteForceApp
{
    class MD5
    {
        public static List<String> CreateMD5(List<String> listOfPasswords)
        {
            List<string> passwordConvertedOnMD5 = new List<string>();
            
            foreach (string password in listOfPasswords)
            {
                passwordConvertedOnMD5.Add(CreateMD5(password));
            }

            return passwordConvertedOnMD5;
        }

        public static string CreateMD5(string password)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
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
