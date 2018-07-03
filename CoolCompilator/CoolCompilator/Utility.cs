using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCompilator
{
    public static class Utility
    {
        public static bool is_basic_class(Symbol class_sym)
        {
            return class_sym == Constants.OBJECT || class_sym == Constants.IO || class_sym == Constants.INTEGER ||
            class_sym == Constants.BOOLEAN || class_sym == Constants.STRING;
        }
        public static void print_error(string filename, int line, string msg)
        {
            Console.Error.WriteLine(filename + ":" + line + ": error: " + msg);
        }

        public static void print_error(string filename, string msg)
        {
            Console.Error.WriteLine(filename + ": error: " + msg);
        }

        public static void print_error(AstNode ast, string msg)
        {
            print_error(ast.file_name, ast.line_no, msg);
        }
    }
}
