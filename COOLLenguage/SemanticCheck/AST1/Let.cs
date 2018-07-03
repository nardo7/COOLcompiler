using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Let : Expression
    {

        List<Initializer> initializers;
        Expression body;

        public Expression Body { get { return body; } }
        public List<Initializer> Initializers { get { return initializers; } }

        public Let(Expression body, List<Initializer> initializers)
        {
            this.body = body;
            this.initializers = initializers;
        }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            var let= new MIPSCodeGenerator.Let(t.AddString(initializers[0].Name), t.AddString(initializers[0].Type), (MIPSCodeGenerator.Expression)initializers[0].Expr.GetAstCodeGenerator(t), (MIPSCodeGenerator.Expression)body.GetAstCodeGenerator(t));
            SetGeneratorType(let);
            return let;
            //throw new NotImplementedException();
        }
    }
}
