using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck
{
    public interface IMethod
    {
        string Name { get; }
        IType ReturnType { get; }
        IEnumerable<IAttribute> Arguments { get; }
    }
}
