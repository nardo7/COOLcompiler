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
using System.IO;

namespace LexingParsingCOOL
{
    public class Parser
    {
        public static void parser(string code)
        {
            System.IO.DirectoryInfo d = new DirectoryInfo("E:\\Universidad\\4to\\compilacion 2\\testing");
            var files=d.GetFiles("*.cl");
            foreach (var file in files)
            {


                var stringStream = new ANTLRFileStream(file.FullName);
                COOLLexer lexer = new COOLLexer(stringStream);
                CommonTokenStream stream = new CommonTokenStream(lexer);
                COOLParser parser = new COOLParser(stream);
                ITreeAdaptor adaptor = new COOLCommonTreeAdaptor();
                parser.TreeAdaptor = adaptor;
                parser.TraceDestination = Console.Out;
                var tree = parser.program();
                var t = (COOLCommonTree)tree.Tree;
        }
       // var ast1 = t.GetAST1();

            //TypeCollectorVisitor visit1 = new TypeCollectorVisitor() { log = new ErrorLogger(Console.Out) };
            //visit1.Visit((Program)ast1);
            //TypeBuilderVisitor visit2 = new TypeBuilderVisitor() { Context = visit1.Context, errorLog = new ErrorLogger(Console.Out) };
            //visit2.Visit((Program)ast1);
            //TypeChekerVisitor tcv = new TypeChekerVisitor() { Context = visit2.Context, errorLog = new ErrorLogger(Console.Out) };
            //tcv.Visit((Program)ast1);
            //if (parser.NumberOfSyntaxErrors > 0)
            //{
            //    Console.WriteLine("error");
            //}
        }
       
    }
}
