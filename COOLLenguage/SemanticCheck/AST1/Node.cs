using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public abstract class Node
    {
        public int Line { get; set; }

        public abstract TreeNode GetAstCodeGenerator(SymbolTable t);
    }
}
