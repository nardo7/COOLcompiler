using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class New : Expression
    {
        public string Type { get; set; }
        public New(string type)
        {
            this.Type = type;
        }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            MIPSCodeGenerator.New nw = new MIPSCodeGenerator.New(t.AddString(Type));
            SetGeneratorType(nw);
            return nw;
        }
    }
}
