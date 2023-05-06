using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // This code is contributed by PrinciRaj1992 from geeksforgeeks.org

    public class GFG
    {
        static void allLexicographicRecur(String str, char[] data, int last, int index)
        {
            int length = str.Length;

            for (int i = 0; i < length; i++)
            {
                data[index] = str[i];

                if (index == last)
                    Console.WriteLine(new String(data));
                else
                    allLexicographicRecur(str, data, last, index + 1);
            }
        }

        public static void allLexicographic(String str)
        {
            int length = str.Length;

            char[] data = new char[length + 1];
            char[] temp = str.ToCharArray();

            Array.Sort(temp);
            str = new String(temp);

            allLexicographicRecur(str, data, length - 1, 0);
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
