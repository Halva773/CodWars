using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Codewars
{
    class Kata
    {
        public static int Persistence(long n)
        {
            int count = (n == 0) ? 1 : 0, result = 0;

            while (n > 9)
            {
                n = 1;
                string nn = n.ToString();
                char[] a = nn.ToCharArray();
                for (int i = 0; i < a.Length; i++)
                {
                    n *= (a[i] - 48);
                }
                result++;
            }
            return result;
        }


        //      Valid Braces
        //"(){}[]"   =>  True
        //"([{}])"   =>  True
        //"(}"       =>  False
        //"[(])"     =>  False
        //"[({})](]" =>  False

        public static bool validBraces(string braces)
        {
            bool result = false;
            char[] a = braces.ToCharArray();
            for (int i = 1; braces != ""; i++)
            {
                a = braces.ToCharArray();
                if ((a[i] == '}' && a[i - 1] == '{') || (a[i] == ')' && a[i - 1] == '(') || (a[i] == ']' && a[i - 1] == '['))
                {
                    braces = braces.Remove((i - 1), 2);
                    i = 0;
                }
            }
            if (braces == "") result = true;
            return result;
        }


        //                  Friend or Foe?
        //["Ryan", "Kieran", "Mark"] => ["Ryan", "Mark"]
        public static IEnumerable<string> FriendOrFoe(string[] names)
        {
            string[] result = (from t in names where t.Length <= 4 select t).ToArray();
            return result;
        }


        //1 * (2 + 3) = 5
        //1 * 2 * 3 = 6
        //1 + 2 * 3 = 7
        //(1 + 2) * 3 = 9
        public static int ExpressionsMatter(int a, int b, int c)
        {
            int[] res = { a * b * c, a + b + c, a + b * c, a * b + c, a + (b + c), a * (b * c), (a + b) * c, a * (b + c) };
            return res.Max();
        }



        //Roman Numerals Encoder
        //1    => I
        //5    => V
        //10   => X
        //50   => L
        //100  => C
        //500  => D
        //1000 => M
        public static string Solution(int n)
        {
            int[] rim = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] arab = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int i = 0;
            string result = "";
            while (n > 0)
            {
                if (rim[i] <= n)
                {
                    n -= rim[i];
                    result += arab[i];
                }
                else i++;
            }
            return result;
        }
    }
}
