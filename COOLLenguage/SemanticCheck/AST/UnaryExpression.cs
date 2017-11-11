using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public class UnaryExpression:Expression
    {
        protected Expression expr;
        public Expression Expr { get { return expr; } }
        public override IType ComputedType
        {
            get
            {
                return expr.ComputedType;
            }
        }
        public override string Value
        {
            get
            {
                return expr.Value;
            }
        }
        public UnaryExpression(Expression expr)
        {
            this.expr = expr;
        }

    }
}
