using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public interface IMethod:IAttribute
    {   
        List<Param> Arguments { get; }
        IType ReturnType { get; }
        Expression Body { get; }
    }
}
