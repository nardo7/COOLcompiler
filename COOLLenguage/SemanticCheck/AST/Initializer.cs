using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public class Initializer:Node
    {
        string name;
        IType type;
        Expression expr;
        public string Name { get { return name; } }
        public IType Type { get { return type; } }
        public Expression Expr { get { return expr; } }
        public Initializer(string name, IType type)
        {
            this.name = name;
            this.type = type;
        }
        public Initializer(string name, IType type,Expression expr)
        {
            this.name = name;
            this.type = type;
            this.expr = expr;
        }
    }
}
