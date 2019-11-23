using System.Collections.Generic;

namespace COOLLenguage.SemanticCheck
{
    public interface IMethod
    {
        string Name { get; }
        IType ReturnType { get; }
        IEnumerable<IAttribute> Arguments { get; }
    }
}
