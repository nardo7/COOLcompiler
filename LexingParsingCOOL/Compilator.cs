﻿using System;
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
using MIPSCodeGenerator;

namespace LexingParsingCOOL
{
    public class Compilator
    {
        public static void Compile(string code,string outFileName)
        {
            System.IO.DirectoryInfo d = new DirectoryInfo("E:\\Universidad\\4to\\compilacion 2\\testing");
            var files=d.GetFiles("*.cl");
            //foreach (var file in files)
            //{



                var t = Parse(code);
                if (t == null)
                    return;
                var ast1 = t.GetAST1();
            var semanticResults = SemantickCheck((COOLLenguage.SemanticCheck.AST1.Program)ast1);
            if (semanticResults.Item1 > 0)
            {
                Console.WriteLine("Compilation terminated because of semantic errors");
                return;
            }

            var Context = semanticResults.Item2;
            //build ast to generate
            var table=MIPSCodeGenerator.SymbolUtils.IdTable;
            var astgenerator = (MIPSCodeGenerator.Program)ast1.GetAstCodeGenerator(table);
            var inheritance = new InheritanceTree(astgenerator);

            var Cg = new CodeGen(astgenerator, inheritance, new StreamWriter("./out.s"));
            Cg.Generate();
        }

        public static Tuple<int,Context> SemantickCheck(COOLLenguage.SemanticCheck.AST1.Program ast)
        {
            var logger = new ErrorLogger(Console.Out);
            TypeCollectorVisitor visit1 = new TypeCollectorVisitor() { log =logger };
            visit1.Visit(ast);
            TypeBuilderVisitor visit2 = new TypeBuilderVisitor() { Context = visit1.Context, errorLog =logger };
            visit2.Visit(ast);
            TypeChekerVisitor visit3 = new TypeChekerVisitor() { Context = visit2.Context, errorLog = logger };
            visit3.Visit(ast);
            return new Tuple<int,Context>(visit3.errorLog.CountErrors,(Context)visit3.Context);
        
        }
        public static COOLCommonTree Parse(string code)
        {
            var stringStream = new ANTLRFileStream(code);
            COOLLexer lexer = new COOLLexer(stringStream);
            CommonTokenStream stream = new CommonTokenStream(lexer);
            COOLParser parser = new COOLParser(stream);
            ITreeAdaptor adaptor = new COOLCommonTreeAdaptor();
            parser.TreeAdaptor = adaptor;
            parser.TraceDestination = Console.Out;
            var tree = parser.program();
            if (parser.NumberOfSyntaxErrors > 0)
            {
                Console.WriteLine("Compilation terminated because of sintax errors");
                return null;
            }
            return tree.Tree;
        }
       // static void FillAstCodeGen()
    }
}