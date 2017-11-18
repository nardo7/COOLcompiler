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

        public void Visit(Program node)
        {
            Context = new Context();
            foreach (var item in node.Classes)
                Visit(item);
            defineBool();
            defineInt();
            defineString();
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
            Context.CreateType(node.Type);
        }

       
    }
}
