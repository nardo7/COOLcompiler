using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
      
    }
}
