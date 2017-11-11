using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
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
        public override IType ComputedType
        {
            get
            {
                return left.ComputedType;
            }
        }

        public override string Value
        {
            get
            {
                return left.Value;
            }
        }
    }
}
