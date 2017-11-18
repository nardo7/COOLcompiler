using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public class Param:Node,IAttribute
    {
        IType type;
        string name;
        public IType Type { get { return type; } }
        public string Name { get { return name; } }
        public Param(IType type, string name)
        {
            this.type = type;
            this.name = name;
        }
    }
}
