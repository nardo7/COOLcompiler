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
            MIPSCodeGenerator.Let firstLet = null;
            for (int i = initializers.Count-1; i >=0; i--)
            {
                var item = initializers[i];
                if (firstLet == null)
                {
                    firstLet = new MIPSCodeGenerator.Let(t.AddString(item.Name), t.AddString(item.Type), (MIPSCodeGenerator.Expression)item.Expr?.GetAstCodeGenerator(t), (MIPSCodeGenerator.Expression)body.GetAstCodeGenerator(t));
                    SetGeneratorType(firstLet);
                }
                else
                {
                    firstLet = new MIPSCodeGenerator.Let(t.AddString(item.Name), t.AddString(item.Type), (MIPSCodeGenerator.Expression)item.Expr?.GetAstCodeGenerator(t), firstLet);
                    SetGeneratorType(firstLet);
                }

            }
            //var initsCodeGen = new MIPSCodeGenerator.Block(assGen);
            //var let= new MIPSCodeGenerator.Let(t.AddString(initializers[0].Name), t.AddString(initializers[0].Type), (MIPSCodeGenerator.Expression)initializers[0].Expr.GetAstCodeGenerator(t), (MIPSCodeGenerator.Expression)body.GetAstCodeGenerator(t));
            //SetGeneratorType(let);
            return firstLet;
            //throw new NotImplementedException();
        }
    }
}
