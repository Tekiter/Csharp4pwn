using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp4pwn.String
{
    public static class StringExtensions
    {
        public static string SliceEnd(this string str, int length)
        {
            return str.Substring(0, str.Length - length);
        }

        public static string Slice(this string str, int start, int end)
        {
            return str.Substring(start, str.Length - end - start);
        }

        public static byte[] ToByteArray(this string hexString)
        {
            byte[] retval = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length; i += 2)
                retval[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            return retval;
        }

        public static char MinAscii(this string str)
        {
            char min = char.MaxValue;
            foreach (var i in str)
            {
                if (min > i)
                {
                    min = i;
                }
            }
            return min;
        }

        public static char MaxAscii(this string str)
        {
            char max = char.MinValue;
            foreach (var i in str)
            {
                if (max < i)
                {
                    max = i;
                }
            }
            return max;
        }
    }
}
