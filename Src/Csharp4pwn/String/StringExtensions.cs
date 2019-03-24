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

        /// <summary>
        /// string[start:end]
        /// </summary>
        /// <param name="str"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string Slice(this string str, int start, int end)
        {
            if (end < 0)
            {
                end = str.Length + end;
            }
            if (start < 0)
            {
                start = str.Length + start;
            }

            if (start > end)
            {
                return "";
            }

            return str.Substring(start, end - start);
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

        public static string Multiply(this string str, int cnt)
        {
            string s = "";
            for (int i = 0; i < cnt; i++)
            {
                s += str;
            }
            return s;
        }

        public static string Multiply(this char str, int cnt)
        {
            string s = "";
            for (int i = 0; i < cnt; i++)
            {
                s += str;
            }
            return s;
        }
    }
}
