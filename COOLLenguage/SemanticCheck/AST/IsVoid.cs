using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public class IsVoid:UnaryExpression
    {

        public IsVoid(Expression expr):base(expr)
        {

        }
    }
}