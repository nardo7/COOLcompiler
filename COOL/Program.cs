using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LexingParsingCOOL;
//using System.

namespace COOL
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.parser(args[0]);
            var curdir = System.Environment.CurrentDirectory;
        }
    }
}
