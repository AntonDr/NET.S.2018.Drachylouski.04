using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BinaryLogic
{
    public static class BinaryLogic
    {
        private const int NumberOfIEE754 = 64;

        /// <summary>
        /// Obtaining a string representation of a real number in the format IEEE 754
        /// </summary>
        /// <param name="number">Source number</param>
        /// <returns>String of bit</returns>
        public static string DoubleToStringOfBit(this double number)
        {
            var @struct = new LongAndDoubleRepresentation(number);
            long @long = (long)@struct;

            return @long.LongToStringOfBit();
        }

        /// <summary>
        /// Structure for getting a long representation through a double
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct LongAndDoubleRepresentation
        {
            [FieldOffset(0)] private readonly double doubleRepresentation;

            [FieldOffset(0)] private readonly long longRepresenatiotion;

            public LongAndDoubleRepresentation(double number) : this()
            {
                doubleRepresentation = number;
            }

            public static explicit operator long(LongAndDoubleRepresentation @struct)
            {
                return @struct.longRepresenatiotion;
            }
        }

        private static string LongToStringOfBit(this long number)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < NumberOfIEE754; i++, number >>= 1)
            {
                sb.Append(number & 1);
            }

            sb.Reverse();

            return sb.ToString();
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


