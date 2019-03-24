using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp4pwn.Strings
{
    public class StringHelper
    {
        /// <summary>
        /// Return all ascii printable letters (0x20 ~ 0x7e)
        /// </summary>
        public static string Printable
        {
            get
            {
                return StringRange(0x20, 0x7e);
            }
        }

        /// <summary>
        /// Return all lowercase letters ('a'~'z')
        /// </summary>
        public static string LowerCases
        {
            get
            {
                return StringRange(0x61, 0x7a);
            }
        }

        /// <summary>
        /// Return all lowercase letters ('A'~'Z')
        /// </summary>
        public static string UpperCases
        {
            get
            {
                return StringRange(0x41, 0x5a);
            }
        }

        /// <summary>
        /// Return all alphabetical letters ('A'~'z')
        /// </summary>
        public static string AsciiLetters
        {
            get
            {
                return UpperCases + LowerCases;
            }
        }

        /// <summary>
        /// Return all lowercase letters ('a'~'z')
        /// </summary>
        public static string Numbers
        {
            get
            {
                return StringRange(0x30, 0x39);
            }
        }

        public static string StringRange(int start, int end)
        {
            string str = "";
            for (int i = start; i <= end; i++)
            {
                str += (char)i;
            }
            return str;
        }
    }
}
