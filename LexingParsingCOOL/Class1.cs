using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime;

namespace LexingParsingCOOL
{
    public class Parser
    {
        public static void parser(string code)
        {
            var stringStream = new ANTLRFileStream(code);
            COOLLexer lexer = new COOLLexer(stringStream);
            CommonTokenStream stream = new CommonTokenStream(lexer);
            COOLParser parser = new COOLParser(stream);

            parser.TraceDestination = Console.Out;
            var tree = parser.program();
            if (parser.NumberOfSyntaxErrors > 0)
            {
                Console.WriteLine("error");
            }
        }

    }
}
