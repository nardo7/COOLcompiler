using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class While:Loop
    {
        public While(Expression condition, Expression body)
        {
            this.condition = condition;
            this.body = body;

        }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            MIPSCodeGenerator.Loop w = new MIPSCodeGenerator.Loop((MIPSCodeGenerator.Expression)condition.GetAstCodeGenerator(t), (MIPSCodeGenerator.Expression)body.GetAstCodeGenerator(t));
            SetGeneratorType(w);
            return w;
            
        }
    }
}
