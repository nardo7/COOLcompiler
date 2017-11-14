using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST1
{
    public interface IAttribute
    {
        string Name { get; }
        string Type { get; }
        Expression ExpresionInicializer { get; }
    }
}
