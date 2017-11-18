using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck
{
    public interface IType
    {
        string Name { get; }
        IEnumerable<IAttribute> Attributes { get; }
        IEnumerable<IMethod> Methods { get; }
        IAttribute GetAttribute(string name);
        IMethod GetMethod(string name);
        bool DefineAttribute(string name, IType type);
        bool DefineMethod(string name, IType returnType,
        string[] arguments, IType[] argumentTypes);
    }
}
