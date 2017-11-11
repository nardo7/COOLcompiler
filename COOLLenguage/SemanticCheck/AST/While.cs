using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public class While:Loop
    {
        public While(Expression condition, Expression body)
        {
            this.condition = condition;
            this.body = body;

        }
    }
}
