using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class UnaryExpression:Expression
    {
        protected Expression expr;
        public Expression Expr { get { return expr; } }
      
        public UnaryExpression(Expression expr)
        {
            this.expr = expr;
        }

    }
}
