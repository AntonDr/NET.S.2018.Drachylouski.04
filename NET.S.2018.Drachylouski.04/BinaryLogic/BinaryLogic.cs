using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryLogic
{
    public static class BinaryLogic
    {
        public static string ToBinaryString(this double number)
        {



            const int @base = 2;

            const int theRemainderOfTheMantissa = 52;


            string first = null;

            first = number < 0 ? "1" : "0";

            var temp = Math.Abs(Math.Truncate(number));

            double x = Math.Abs(number) - temp;

            var mantissa = new StringBuilder();

            int k = 0;

            while (temp != 0)
            {
                mantissa.Append(temp % @base);
                k++;
                temp = Math.Truncate(temp/@base);
            }

            string exponent = FindExponent(k);

            mantissa.Reverse();

           

            bool flag = true;

            for (int j = 0; j <= theRemainderOfTheMantissa-k; j++)
            {
                int product = (int)(x * @base);
                x = x * @base - product;
                mantissa.Append(product);

                if (product == 1)
                {
                    flag = false;
                }

            }

            if (mantissa.Length > 0)
            {
                mantissa.Remove(0, 1);
            }

            if (flag && String.Equals("00000000000",exponent))
            {
                mantissa[mantissa.Length - 1] = '1';
            }

           

            if (theRemainderOfTheMantissa!=mantissa.Length-1)
            {
                mantissa.Remove(theRemainderOfTheMantissa, mantissa.Length-theRemainderOfTheMantissa);
            }
           

            return first + exponent + mantissa.ToString();
        }

        private static string FindExponent(int k)
        {
            const int x = 1023;

            const int @base = 2;

            if (k != 0)
            {
                k--;
                k += x;


                var exponent = new StringBuilder();

                while (k != 0)
                {
                    exponent.Append((k % @base));
                    k /= @base;
                }

                exponent.Reverse();


                return exponent.ToString();
            }
            else return "00000000000";
        }

        private static void Reverse(this StringBuilder sb)
        {
            char t;
            int end = sb.Length - 1;
            int start = 0;

            while (end - start > 0)
            {
                t = sb[end];
                sb[end] = sb[start];
                sb[start] = t;
                start++;
                end--;
            }
        }

    }
}


