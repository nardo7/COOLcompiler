using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolCompilator;


namespace Main
{
    class Program
    {

        // all defined by lexer
         int yyparse();
         int yynerrs;
        extern FILE* yyin;

        // Root of AST used by the parser. This should be populated
        // after parsing phase
        ProgramPtr ast_root;

        // Used by the error handling routines in both lexer and
        // parser to provide a more informative error message
        std::string curr_filename;

        static void Main(string[] args)
        {
           

            SemanticAnalyzer semant;
            semant.install_basic(ast_root);
            if (!semant.validate_inheritance(ast_root.classes))
            {
                std::cerr << "Compilation halted due to inheritance errors.\n";
                exit(1);
            }

            if (!semant.type_check(ast_root))
            {
                std::cerr << "Compilation halted due to type errors.\n";
                exit(1);
            }

            AstNodeDisplayer print = new AstNodeDisplayer(Console.Out., AstNodeDisplayer.display_option.DISPLAYNONBASIC);
            ast_root.accept(print);

            std::ofstream out("output.s");
            AstNodeCodeGenerator codegen(semant.get_inherit_graph(), out);
            ast_root.accept(codegen);

        }
    }
}
