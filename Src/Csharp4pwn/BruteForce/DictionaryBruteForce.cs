using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp4pwn.BruteForce
{
    public class DictionaryBruteForce : BruteForceBase<string>
    {
        public override Func<string, bool> CheckFunction { get; set; } = (s) => { return false; };

        private bool isworking = false;
        public override bool IsWorking { get { return isworking; } }

        public bool IsFound { get; private set; } = false;

        public string Result { get; private set; }

        public IEnumerable<string> Dictionary { get; set; } = new List<string>();

        public DictionaryBruteForce(Func<string, bool> checkfunc, IEnumerable<string> dictionary)
        {
            CheckFunction = checkfunc;
            Dictionary = dictionary;
        }

        public bool Start()
        {
            isworking = true;
            foreach (var i in Dictionary)
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

        public bool StartParallel()
        {
            isworking = true;
            Parallel.ForEach(Dictionary, (i, state) => {
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
