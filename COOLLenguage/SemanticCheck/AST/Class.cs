using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public class ClassDef:Node, IType
    {
        public string Type { get; }
        List<Feature> Features;

        public List<Feature> Fetures
        {
            get
            {
               return Features; 
            }
        }

        public ClassDef(string type)
        {
            Type = type;
            Features = new List<Feature>();
        }
    }
}
