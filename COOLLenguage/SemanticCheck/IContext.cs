using System.Collections.Generic;

namespace COOLLenguage.SemanticCheck
{
    public interface IContext
    {
        IContext Parent { get; }
        IType GetType(string typeName);
        IType GetTypeFor(string symbol);
        IContext CreateChildContext();
        bool DefineVariable(string symbol, IType type,bool redefine=false);
        IType CreateType(string name);
        IEnumerable<IType> Types();
    }
}
