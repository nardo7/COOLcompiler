using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public class Block:Expression
    {
        List<Expression> exprs;
        public List<Expression> Exprs { get { return exprs; } private set { } }
        IType computedType;
        string value;
        public override IType ComputedType
        {
            get
            {
                return computedType;
            }
        }

        public override string Value
        {
            get
            {
                return value;
            }
        }
        public Block(List<Expression> exprs)
        {
            this.exprs = exprs;
            computedType= exprs[exprs.Count() - 1].ComputedType;
            value= exprs[exprs.Count() - 1].Value;

        }
    }
}
