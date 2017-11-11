using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public class New : Expression
    {
        IType type;
        public New(IType type)
        {
            this.type = type;
        }
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
