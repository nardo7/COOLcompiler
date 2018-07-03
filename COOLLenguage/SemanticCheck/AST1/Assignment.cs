using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Assignment:Expression
    {
        string name;
        Expression expr;

        public string Name { get { return name; } }
        public Expression Expr { get { return expr; } }

       
        
        public Assignment(string name,Expression expr)
        {
            this.name = name;
            this.expr = expr;
        }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            var codename = t.AddString(name);
            var assing= new Assign(codename, (MIPSCodeGenerator.Expression)Expr.GetAstCodeGenerator(t),Line);
            SetGeneratorType(assing);
            return assing;
        }
    }
}
