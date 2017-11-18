using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck
{
    public interface IAttribute
    {
        string Name { get; }
        IType Type { get; }
    }
}
