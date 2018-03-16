using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COOLLenguage.SemanticCheck.AST1;
//using COOLLenguage.SemanticCheck.AST;
using COOLLenguage.Utils;

namespace COOLLenguage.SemanticCheck
{
    public class TypeCollectorVisitor : IVisitor<Program>, IVisitor<ClassDef>
    {
        public IContext Context;
        public ErrorLogger log;
        const string REDEFINEDERRORTYPE= "Line {0}: The Type {1} is redefined";
        const string TYPEINHERITEDDOESNEXIST = "Line {0}: The type {1} inherits another type that does not exist";
        public void Visit(Program node)
        {
            Context = new Context();
            defineObject();
            defineBool();
            defineInt();
            defineString();
            defineVoid();
            foreach (var item in node.Classes)
                Visit(item);
        }

        void defineInt()
        {
            Context.CreateType("Int");
            Context.GetType("Int").TypeInherited = Context.GetType("Object");
        }

        void defineString()
        {
            Context.CreateType("String");
            var str = Context.GetType("String");
            str.DefineMethod("concat", str, new string[] { "value" }, new IType[] { str });
            Context.GetType("String").TypeInherited = Context.GetType("Object");

        }

        void defineBool()
        {
            Context.CreateType("Bool");
            Context.GetType("Bool").TypeInherited = Context.GetType("Object");
        }

        void defineVoid()
        {
            Context.CreateType("Void");
            Context.GetType("Void").TypeInherited = Context.GetType("Object");
        }

        void defineObject()
        {
            Context.CreateType("Object");
        }

        public void Visit(ClassDef node)
        {
            if(Context.GetType(node.Type)!=null)
            {
                log.LogError(string.Format(REDEFINEDERRORTYPE,node.Line, node.Type));
                return;
            }
            var currType= Context.CreateType(node.Type);
           


        }

       
    }
}
