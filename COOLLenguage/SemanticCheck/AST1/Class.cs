using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class ClassDef:Node
    {
        public string Type { get; set; }
        public string typeInherited;
        List<Method> methods;
        List<Attribute> attributes;
        public List<Method> Methods
        {
            get
            {
               return methods; 
            }
        }

        public List<Attribute> Attributes
        {
            get
            {
                return attributes;
            }
            
        }
        public ClassDef()
        {
            methods = new List<Method>();
            attributes = new List<Attribute>();
        }
        public ClassDef(string type)
        {
            Type = type;
            methods = new List<Method>();
            attributes = new List<Attribute>();
        }
        public ClassDef(string type,List<Method>Methods,List<Attribute>Attributes)
        {
            Type = type;
            methods = Methods;
            attributes = Attributes;
        }
        public ClassDef(string type, string TypeInherited, List<Method> Methods, List<Attribute> Attributes)
        {
            Type = type;
            methods = Methods;
            attributes = Attributes;
            typeInherited = TypeInherited;
        }

    }
}
