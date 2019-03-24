using Csharp4pwn.BruteForce;
using Csharp4pwn.Interaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp4pwn.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.ReadLine();
        }

        static bool CheckFunc(string pattern)
        {
            Thread.Sleep(1000);
            Console.WriteLine(pattern);
            if (pattern == "AAAB")
            {
                return true;
            }
            return false;
        }

       
    }
}
