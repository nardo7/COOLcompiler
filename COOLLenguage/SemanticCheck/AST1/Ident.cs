using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Ident:Expression
    {
        public string name { get; set; }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            MIPSCodeGenerator.Object obj = new MIPSCodeGenerator.Object(t.AddString(name));
            SetGeneratorType(obj);
            return obj;
        }
    }
}
