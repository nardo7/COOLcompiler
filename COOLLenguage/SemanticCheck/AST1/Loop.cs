using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST1
{
    public abstract class Loop : Expression
    {
        protected Expression condition;
        protected Expression body;
        public Expression Condition { get { return condition; } }
        public Expression Body { get { return body; } }
        
    }
}
