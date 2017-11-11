using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public class Attribute : Feature, IAttribute
    {
        public IType Type { get; }
        Expression expr;    
        public Expression Expr { get { return expr; } }

        public Attribute(string name, IType type)
        {
            this.Name = name;
            this.Type = type;
        }
        public Attribute(string name, IType type, Expression expr)
        {
            this.Name = name;
            this.Type = type;
            this.expr = expr;
        }

    }
}
