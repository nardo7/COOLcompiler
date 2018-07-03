using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LexingParsingCOOL;

namespace COOL
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = args[0];
            int index = -1;
            var outfile = "./out.s";
            if ((index = args.ToList().IndexOf("-o")) > 0)
            {
                if (index >= args.Length)
                {
                    Console.WriteLine("you must to specify the out file");
                    return;
                }
                outfile = args[index + 1];
            }
            Compilator.Compile(args[0],outfile);

            
        }
    }
}
