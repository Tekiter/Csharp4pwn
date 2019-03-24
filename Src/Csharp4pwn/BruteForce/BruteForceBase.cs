using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp4pwn.BruteForce
{
    public abstract class BruteForceBase<T>
    {
        public abstract Func<T,bool> CheckFunction { get; set; }
        public abstract bool IsWorking { get; }

        //public abstract void Start();

    }
}
