using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class New : Expression
    {
        string type;
        public New(string type)
        {
            this.type = type;
        }
      
    }
}
