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

            StringBruteForce f = new StringBruteForce(CheckFunc);
            if (f.Start("abcde",4))
            {
                Console.WriteLine("Found : {0}", f.Result);
            }

            //IntBruteForce f = new IntBruteForce((i) => {
            //    Console.WriteLine(i);
            //    Thread.Sleep(100);
            //    if (i == 5000)
            //    {

            //        return true;
            //    }
            //    return false;
            //});
            //if (f.StartParallel(0, 1000000))
            //{
            //    Console.WriteLine(f.Result);
            //}
            //List<string> lst = new List<string>
            //{
            //    "haha",
            //    "Nice",
            //    "Passwrd",
            //    "NoNo",
            //    "hahahahaha",
            //    "helloworld",
            //    "Nicetomeet",
            //    "NONONO"
            //};
            //DictionaryBruteForce f = new DictionaryBruteForce((i) =>
            //{
            //    Console.WriteLine(i);
            //    Thread.Sleep(1000);
            //    if (i == "helloworld")
            //    {
            //        return true;
            //    }
            //    return false;
            //}, lst);

            //if (f.StartParallel())
            //{
            //    Console.WriteLine("Found! {0}", f.Result);
            //}


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
