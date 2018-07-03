using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;


namespace COOLLenguage.SemanticCheck.AST1
{
    public class Block:Expression
    {
        List<Expression> exprs;
        public List<Expression> Exprs { get { return exprs; } private set { } }
      
        
        public Block(List<Expression> exprs)
        {
            this.exprs = exprs;

        }
        public Block()
        {
            this.exprs = new List<Expression>();

        }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            List<MIPSCodeGenerator.Expression> codeBody = new List<MIPSCodeGenerator.Expression>();
            for (int i = 0; i < exprs.Count; i++)
                codeBody.Add((MIPSCodeGenerator.Expression)exprs[i].GetAstCodeGenerator(t));
            var bl= new MIPSCodeGenerator.Block(codeBody,Line);
            SetGeneratorType(bl);
            return bl;
            
        }
    }
}
