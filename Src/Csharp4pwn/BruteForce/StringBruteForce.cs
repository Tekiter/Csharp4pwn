using Csharp4pwn.String;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp4pwn.BruteForce
{
    public class StringBruteForce : BruteForceBase<string>
    {
        public override Func<string, bool> CheckFunction { get; set; } = (s) => { return false; };
        

        private bool isworking = false;
        /// <summary>
        /// When bruteforcing, it returns true
        /// </summary>
        public override bool IsWorking { get { return isworking; } }


        /// <summary>
        /// Result after bruteforcing
        /// </summary>
        public string Result { get; private set; }


        /// <summary>
        /// Charset to create pattern
        /// </summary>
        public string CharSetAvaliable { get; set; } = StringHelper.AsciiLetters + StringHelper.Numbers;


        public StringBruteForce(Func<string, bool> checkFunc)
        {
            CheckFunction = checkFunc;
        }


        public string Start(int length)
        {
            isworking = true;
            PatternNext(new StringBuilder(CharSetAvaliable[0].Multiply(length)), 0, length);

            return "";
        }

        private void OnPattern(string pattern)
        {
            if (CheckFunction(pattern))
            {
                isworking = false;
            }
        }

        private void PatternNext(StringBuilder sb, int position, int length)
        {
            for (int i = 0; i < CharSetAvaliable.Length; i++)
            {
                if (!IsWorking)
                {
                    return;
                }


                sb.Replace(sb[position], CharSetAvaliable[i], position, 1);

                if (position == length - 1)
                {
                    OnPattern(sb.ToString());
                }
                else
                {
                    PatternNext(sb, position + 1, length);
                }

            }
        }

    }
}
