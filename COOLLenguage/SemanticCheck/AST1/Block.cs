using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Block:Expression
    {
        List<Expression> exprs;
        public List<Expression> Exprs { get { return exprs; } private set { } }
      
        
        public Block(List<Expression> exprs)
        {
            this.exprs = exprs;

        }
        public Block()
        {
            this.exprs = new List<Expression>();

        }
    }
}
