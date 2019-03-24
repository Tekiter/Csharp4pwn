using Csharp4pwn.String;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public bool IsFound { get; private set; } = false;


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


        /// <summary>
        /// Start bruteforcing
        /// </summary>
        /// <param name="length">Pattern Length</param>
        /// <returns>Weather pattern found</returns>
        public bool Start(int length)
        {
            isworking = true;
            PatternNext(new StringBuilder(CharSetAvaliable[0].Multiply(length)), 0, length);
            
            return IsFound;
        }

        /// <summary>
        /// Start bruteforcing from given startpattern
        /// </summary>
        /// <param name="patterngroup">startpattern "ab" will create pattern "abaa", "abab", "abac" ... </param>
        /// <param name="length">Pattern Length</param>
        /// <returns>Found Pattern</returns>
        public bool Start(string patterngroup, int length)
        {
            if (patterngroup.Length >= length)
            {
                throw new ArgumentException("Length of PatternGroup should be smaller than target length");
            }

            foreach (var i in patterngroup)
            {
                if (!CharSetAvaliable.Contains(i))
                {
                    throw new ArgumentException("PatternGroup's char does not exist in AvaliableCharSet");
                }
            }


            isworking = true;
            IsFound = false;
            PatternNext(new StringBuilder(patterngroup.PadRight(length)), patterngroup.Length, length);

            return IsFound;
        }

        /// <summary>
        /// Start bruteforcing parallelly
        /// </summary>
        /// <param name="length">Pattern Length</param>
        /// <returns>Weather pattern found</returns>
        public bool StartParallel(int length)
        {
            isworking = true;
            IsFound = false;
            Parallel.For(0, CharSetAvaliable.Length, (i, state) =>
             {
                 string startpattern = new string(CharSetAvaliable[i], 1);
                 
                 PatternNext(new StringBuilder(startpattern.PadRight(length)), startpattern.Length, length, state);
             });
            Debug.WriteLine("Done!");
            return IsFound;
        }

        private void OnPattern(string pattern)
        {
            if (CheckFunction(pattern))
            {
                IsFound = true;
                isworking = false;
                Result = pattern;
            }
        }

        private void PatternNext(StringBuilder sb, int position, int length)
        {
            for (int i = 0; i < CharSetAvaliable.Length; i++)
            {

                sb.Replace(sb[position], CharSetAvaliable[i], position, 1);

                if (IsFound)
                {
                    return;
                }

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

        private void PatternNext(StringBuilder sb, int position, int length, ParallelLoopState pastate)
        {
            for (int i = 0; i < CharSetAvaliable.Length; i++)
            {
                
                sb.Replace(sb[position], CharSetAvaliable[i], position, 1);

                if (IsFound)
                {
                    if (pastate != null)
                    {
                        pastate.Break();
                    }
                    return;
                }

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
