using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Conditional : Expression
    {
        Expression condition;
        Expression body;
        Expression elsexpression;
        public Expression Condition { get { return condition; } }
        public Expression Body { get { return body; } }
        public Expression Elsexpression { get { return elsexpression; } }

        public Conditional(Expression condition, Expression body)
        {
            this.condition = condition;
            this.body = body;
            
        }
        public Conditional(Expression condition, Expression body, Expression elsexpression)
        {
            this.condition = condition;
            this.body = body;
            this.elsexpression = elsexpression;

        }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            MIPSCodeGenerator.Cond condi = new Cond((MIPSCodeGenerator.Expression)Condition.GetAstCodeGenerator(t), (MIPSCodeGenerator.Expression)Body.GetAstCodeGenerator(t), (MIPSCodeGenerator.Expression)Elsexpression?.GetAstCodeGenerator(t),Line);
            SetGeneratorType(condi);
            return condi;
        }
    }
}
