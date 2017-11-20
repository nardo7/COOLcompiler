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
        const string REDEFINEDERRORTYPE= "The Type {0} is redefined";
        const string TYPEINHERITEDDOESNEXIST = "The type {0} inherits another type that does not exist";
        public void Visit(Program node)
        {
            Context = new Context();
            foreach (var item in node.Classes)
                Visit(item);
            defineBool();
            defineInt();
            defineString();
            defineVoid();
        }
        void defineInt()
        {
            Context.CreateType("Int");
        }
        void defineString()
        {
            Context.CreateType("String");
            var str = Context.GetType("String");
            str.DefineMethod("concat", str, new string[] { "value" }, new IType[] { str });
        }
        void defineBool()
        {
            Context.CreateType("Bool");
        }
        void defineVoid()
        {
            Context.CreateType("Void");
        }
       
        public void Visit(ClassDef node)
        {
            if(Context.GetType(node.Type)!=null)
            {
                log.LogError(string.Format(REDEFINEDERRORTYPE, node.Type));
                return;
            }
            var currType= Context.CreateType(node.Type);
           


        }

       
    }
}
