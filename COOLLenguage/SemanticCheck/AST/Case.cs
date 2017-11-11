using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public class Case : Expression
    {
        List<Param> paramlist;
        List<Expression> exprs;
        public List<Param> Paramlist { get { return paramlist; } }
        public List<Expression> Exprs { get { return exprs; } }
        public Case(List<Param> paramlist,List<Expression> exprs)
        {
            this.exprs = exprs;
            this.paramlist = paramlist;
        }
        public override IType ComputedType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
