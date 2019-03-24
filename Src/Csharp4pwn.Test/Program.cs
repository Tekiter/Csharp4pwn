using Csharp4pwn.BruteForce;
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
            Console.WriteLine("Start BruteForcing");

            //StringBruteForce f = new StringBruteForce(CheckFunc);
            //if (f.StartParallel(4))
            //{
            //    Console.WriteLine("Found : {0}", f.Result);
            //}

            IntBruteForce f = new IntBruteForce((i) => {
                Console.WriteLine(i);
                Thread.Sleep(100);
                if (i == 5000)
                {
                    
                    return true;
                }
                return false;
            });
            if (f.StartParallel(0, 1000000))
            {
                Console.WriteLine(f.Result);
            }
            

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
