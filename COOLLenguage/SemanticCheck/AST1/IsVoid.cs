using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class IsVoid:UnaryExpression
    {

        public IsVoid(Expression expr):base(expr)
        {

        }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            var isvoid= new MIPSCodeGenerator.IsVoid((MIPSCodeGenerator.Expression)expr.GetAstCodeGenerator(t),Line);
            SetGeneratorType(isvoid);
            return isvoid;
        }
    }
}