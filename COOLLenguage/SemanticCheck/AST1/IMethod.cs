using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST1
{
    public interface IMethod
    {
        string Name { get; }
        List<Param> Arguments { get; }
        string ReturnType { get; }
        Expression Body { get; }

    }
}
