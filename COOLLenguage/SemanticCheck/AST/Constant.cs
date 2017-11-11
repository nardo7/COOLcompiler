using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public class Constant : Expression
    {
        IType type;
        string value;

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
                return value;
            }
        }

        public Constant(IType type,string value)
        {
            this.type = type;
            this.value = value;
        }
    }
}
