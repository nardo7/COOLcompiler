using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Complement : UnaryExpression
    {
        public Complement(Expression expr) : base(expr)
        {
        }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            var com= new MIPSCodeGenerator.Comp((MIPSCodeGenerator.Expression)expr.GetAstCodeGenerator(t));

            SetGeneratorType(com);
            return com;
        }
    }
}
