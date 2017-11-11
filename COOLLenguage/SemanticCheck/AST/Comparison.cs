using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public class Comparison : BinaryExpression
    {
        ComparisonAtomicOperation op;
        public ComparisonAtomicOperation Op { get { return op; } }
        public Comparison(Expression left, Expression rigth,ComparisonAtomicOperation op) : base(left, rigth)
        {
            this.op = op;
        }
    }
    public enum ComparisonAtomicOperation { Less,Greater, Equal, LessE, GreterE}
}
