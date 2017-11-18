using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using COOLLenguage.SemanticCheck;
using COOLLenguage.SemanticCheck.AST1;
using COOLLenguage.Utils;


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

            TypeCollectorVisitor visit1 = new TypeCollectorVisitor();
            visit1.Visit((Program)ast1);
            TypeBuilderVisitor visit2 = new TypeBuilderVisitor() { Context = visit1.Context,errorLog=new ErrorLogger(Console.Out) };
            visit2.Visit((Program)ast1);
            if (parser.NumberOfSyntaxErrors > 0)
            {
                Console.WriteLine("error");
            }
        }
       
    }
}
