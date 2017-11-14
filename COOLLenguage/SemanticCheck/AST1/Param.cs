using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Param:Node
    {
        string type;
        string name;
        public string Type { get { return type; } }
        public string Name { get { return name; } }
        public Param( string name, string type)
        {
            this.type = type;
            this.name = name;
        }
    }
}
