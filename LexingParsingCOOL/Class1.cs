using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using COOLLenguage.SemanticCheck.AST1;

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
            ITreeAdaptor adaptor = new COOLCommonTreeAdaptor();
            parser.TreeAdaptor = adaptor;
            parser.TraceDestination = Console.Out;
            var tree = parser.program();
            var t = (COOLCommonTree)tree.Tree;
            var ast1 = t.GetAST1();
            
            if (parser.NumberOfSyntaxErrors > 0)
            {
                Console.WriteLine("error");
            }
        }
       
    }
}
