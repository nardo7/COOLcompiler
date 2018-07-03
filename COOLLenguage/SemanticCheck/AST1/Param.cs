using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Param:Node
    {
        string name;
        public string Type { get; set; }
        public string Name { get { return name; } }
        public Param( string name, string type)
        {
            this.Type = type;
            this.name = name;
        }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            var codeName = t.AddString(this.Name);
            var codeType = t.AddString(this.Type);
            return new Formal(codeName, codeType,Line);
        }
    }
}
