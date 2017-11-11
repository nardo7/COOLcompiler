using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public abstract class Expression:Node
    {
        IType computedType;
        public abstract IType ComputedType { get; }
        public abstract string Value { get; }
    }
}
