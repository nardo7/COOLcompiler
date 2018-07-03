using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Not : UnaryExpression
    {
        public Not(Expression expr) : base(expr)
        {
        }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            var not= new MIPSCodeGenerator.Neg((MIPSCodeGenerator.Expression)expr.GetAstCodeGenerator(t),Line);
            SetGeneratorType(not);
            return not;
        }
    }
}
