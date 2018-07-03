using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Case : Expression
    {
        List<Param> paramlist;
        List<Expression> exprs;
        public Expression expr { get; protected set; }
        public List<Param> Paramlist { get { return paramlist; } }
        public List<Expression> Exprs { get { return exprs; } }
        public Case(List<Param> paramlist,List<Expression> exprs,Expression expr0)
        {
            this.exprs = exprs;
            this.paramlist = paramlist;
            expr = expr0;
        }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            List<MIPSCodeGenerator.Case> branches = new List<MIPSCodeGenerator.Case>();
            for (int i = 0; i < paramlist.Count; i++)
            {
                branches.Add(new MIPSCodeGenerator.Case(t.AddString(paramlist[i].Name), t.AddString(paramlist[i].Type), (MIPSCodeGenerator.Expression)Exprs[i].GetAstCodeGenerator(t),Exprs[i].Line));
                exprs[i].SetGeneratorType(branches[i].Expression);
            }

            Typcase c = new MIPSCodeGenerator.Typcase((MIPSCodeGenerator.Expression)expr.GetAstCodeGenerator(t), branches);
            SetGeneratorType(c);
            return c;
        }
    }
}
