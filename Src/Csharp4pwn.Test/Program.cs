using Csharp4pwn.BruteForce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp4pwn.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start BruteForcing");

            StringBruteForce f = new StringBruteForce(CheckFunc);
            f.Start(4);
        }

        static bool CheckFunc(string pattern)
        {
            Console.WriteLine(pattern);
            return false;
        }
    }
}
