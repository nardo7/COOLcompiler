using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Assignment:Expression
    {
        string name;
        Expression expr;

        public string Name { get { return name; } }
        public Expression Expr { get { return expr; } }

       
        
        public Assignment(string name,Expression expr)
        {
            this.name = name;
            this.expr = expr;
        }

    }
}
