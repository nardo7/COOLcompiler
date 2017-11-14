using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Comparison : BinaryExpression
    {
        string op;
        public string Op { get { return op; } }
        public Comparison(Expression left, Expression rigth,string op) : base(left, rigth)
        {
            this.op = op;
        }
    }
  //  public enum ComparisonAtomicOperation { Less,Greater, Equal, LessE, GreterE}
}
