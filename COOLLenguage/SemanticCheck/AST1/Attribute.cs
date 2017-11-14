using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Attribute : Feature, IAttribute
    {
        public string Type { get; set; }
        Expression expr;    

        public Expression ExpresionInicializer
        {
            get
            {
                return expr;
            }
            set { expr = value; }
        }
        
    }
}
