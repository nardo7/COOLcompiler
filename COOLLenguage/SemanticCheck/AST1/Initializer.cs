using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Initializer:Node
    {
        string name;
        string type;
        Expression expr;
        public string Name { get { return name; } }
        public string Type { get { return type; } }
        public Expression Expr { get { return expr; } }
        public Initializer(string name, string type)
        {
            this.name = name;
            this.type = type;
        }
        public Initializer(string name, string type,Expression expr)
        {
            this.name = name;
            this.type = type;
            this.expr = expr;
        }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            throw new NotImplementedException();
        }
    }
}
