using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Constant : Expression
    {
        public string type;
        public string value;

        

        public Constant(string type,string value)
        {
            this.type = type;
            this.value = value;
        }
    }
}
