using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp4pwn.BruteForce
{
    public class IntBruteForce : BruteForceBase<int>
    {
        public override Func<int, bool> CheckFunction { get; set; } = (s) => { return false; };

        bool isworking = false;
        /// <summary>
        /// While bruteforcing, it returns true
        /// </summary>
        public override bool IsWorking { get { return isworking; } }

        public bool IsFound { get; set; }

        /// <summary>
        /// Result after bruteforcing
        /// </summary>
        public int Result { get; set; }

        public IntBruteForce(Func<int, bool> checkfunc)
        {
            CheckFunction = checkfunc;
        }

        /// <summary>
        /// Start bruteforcing
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool Start(int start, int end)
        {
            isworking = true;
            for (int i = start; i <= end; i++)
            {
                if (CheckFunction(i))
                {
                    isworking = false;
                    IsFound = true;
                    Result = i;
                    break;
                }
            }
            return IsFound;
        }

        /// <summary>
        /// Start bruteforcing parallelly
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool StartParallel(int start, int end)
        {
            isworking = true;
            Parallel.For(start, end + 1, (i, state) => {
                if (CheckFunction(i))
                {
                    IsFound = true;
                    Result = i;
                    state.Break();
                }
            });
            isworking = false;
            return IsFound;
        }
    }
}
