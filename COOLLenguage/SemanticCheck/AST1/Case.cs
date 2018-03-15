using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Case : Expression
    {
        List<Param> paramlist;
        List<Expression> exprs;
        public Expression expr { get; protected set; }
        public List<Param> Paramlist { get { return paramlist; } }
        public List<Expression> Exprs { get { return exprs; } }
        public Case(List<Param> paramlist,List<Expression> exprs,Expression expr0)
        {
            this.exprs = exprs;
            this.paramlist = paramlist;
            expr = expr0;
        }
       
    }
}
