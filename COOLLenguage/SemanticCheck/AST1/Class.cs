using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;


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

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            
            List<MIPSCodeGenerator.Feature> f = new List<MIPSCodeGenerator.Feature>();
            var parent = t.AddString(typeInherited);
            if (typeInherited == null)
                parent = "Object";
            var name = t.AddString(this.Type);
            for (int i = 0; i < Attributes.Count; i++)
            {
                f.Add((MIPSCodeGenerator.Attr)Attributes[i].GetAstCodeGenerator(t));
            }
            for (int i = 0; i < Methods.Count; i++)
            {
                f.Add((MIPSCodeGenerator.Method)Methods[i].GetAstCodeGenerator(t));
            }

            return new Class(name,parent,"",f,Line);
        }

    }
}
