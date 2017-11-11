using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public abstract class Loop : Expression
    {
        protected Expression condition;
        protected Expression body;
        IType type = new ClassDef("Bool");
        public Expression Condition { get { return condition; } }
        public Expression Body { get { return body; } }

        public override IType ComputedType
        {
            get
            {
                return type;
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
