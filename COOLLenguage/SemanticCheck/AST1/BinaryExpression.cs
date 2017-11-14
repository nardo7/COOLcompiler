using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class BinaryExpression : Expression
    {

        Expression left;
        Expression rigth;
        public Expression Left { get { return left; } }
        public Expression Rigth { get { return rigth; } }
        public BinaryExpression(Expression left,Expression rigth)
        {
            this.left = left;
            this.rigth = rigth;
        }
     
    }
}
