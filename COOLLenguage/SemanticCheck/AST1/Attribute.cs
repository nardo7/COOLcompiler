using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Attribute : Feature
    {
        public string Type { get; set; }
        Expression expr;    

        public Expression ExpresionInicializer
        {
            get
            {
                return expr;
            }
            set { expr = value; }
        }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            var name = t.AddString(this.Name);
            var typeDecl = t.AddString(this.Type);
            var codeExpr = (MIPSCodeGenerator.Expression)expr?.GetAstCodeGenerator(t);
            return new MIPSCodeGenerator.Attr(name, typeDecl, codeExpr);
        }
    }
}
