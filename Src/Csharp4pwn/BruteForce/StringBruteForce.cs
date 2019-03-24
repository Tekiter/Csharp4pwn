using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp4pwn.BruteForce
{
    public class StringBruteForce : BruteForceBase<string>
    {
        public override Func<string, bool> CheckFunction { get; set; }

        private bool isworking = false;
        public override bool IsWorking { get { return isworking; } }

        public void Start()
        {
            
        }


    }
}
