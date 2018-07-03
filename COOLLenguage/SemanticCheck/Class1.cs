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
//using CoolCompilator;

namespace LexingParsingCOOL
{
    public class Parser
    {
        public static void parser(string code)
        {
            System.IO.DirectoryInfo d = new DirectoryInfo("E:\\Universidad\\4to\\compilacion 2\\testing");
            var files=d.GetFiles("*.cl");
            //foreach (var file in files)
            //{


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
                TypeCollectorVisitor visit1 = new TypeCollectorVisitor() { log = new ErrorLogger(Console.Out) };
                visit1.Visit((Program)ast1);
                TypeBuilderVisitor visit2 = new TypeBuilderVisitor() { Context = visit1.Context, errorLog = new ErrorLogger(Console.Out) };
                visit2.Visit((Program)ast1);
                TypeChekerVisitor tcv = new TypeChekerVisitor() { Context = visit2.Context, errorLog = new ErrorLogger(Console.Out) };
                tcv.Visit((Program)ast1);

                //build ast to generate
                var astGenerator = (CoolCompilator.Program)ast1.GetAstCodeGenerator();

            CoolCompilator.AstNodeDisplayer displayer = new CoolCompilator.AstNodeDisplayer(Console.Out, CoolCompilator.AstNodeDisplayer.display_option.DISPLAYNONBASIC);
            displayer.visit((CoolCompilator.Program)astGenerator);
            var rootType = tcv.Context.GetType("Object");
            var IntType = tcv.Context.GetType("Int");
            var IOType = tcv.Context.GetType("IO");
            var strType = tcv.Context.GetType("String");
            var boolType = tcv.Context.GetType("Bool");
            var VoidType = tcv.Context.GetType("Void");
            Dictionary<CoolCompilator.Class, CoolCompilator.Class> dict = new Dictionary<CoolCompilator.Class, CoolCompilator.Class>();
            Dictionary<string, CoolCompilator.Class> codeClass = new Dictionary<string, CoolCompilator.Class>();
            

            var classs = astGenerator.classes.ToList();
            classs.AddRange(new CoolCompilator.Class[] {rootType.ToNodeCodeClass(),IntType.ToNodeCodeClass(),strType.ToNodeCodeClass(),
            IOType.ToNodeCodeClass(),boolType.ToNodeCodeClass(),VoidType.ToNodeCodeClass()});
            astGenerator.classes = classs.ToArray();
            for (int i = 0; i < astGenerator.classes.Length; i++)
            {
                codeClass.Add(astGenerator.classes[i].name.value, astGenerator.classes[i]);
            }
            foreach (var name in codeClass.Keys)
            {
                if (name == "Object")
                    dict.Add(codeClass[name], new CoolCompilator.Class(CoolCompilator.Constants.NOCLASS, "", new CoolCompilator.Attribute[0], new CoolCompilator.Method[0]));
                else
                    dict.Add(codeClass[name], codeClass[codeClass[name].parent.value]);
            }
            StreamWriter sw = new StreamWriter("./out.s");
            CoolCompilator.AstNodeCodeGenerator cd = new CoolCompilator.AstNodeCodeGenerator(dict, sw);
            cd.visit(astGenerator);
            //}



            //if (parser.NumberOfSyntaxErrors > 0)
            //{
            //    Console.WriteLine("error");
            //}
        }

       
    }
}
