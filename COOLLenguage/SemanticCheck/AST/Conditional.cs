using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
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

        public override IType ComputedType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
