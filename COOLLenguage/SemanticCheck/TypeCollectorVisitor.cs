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
            //defineInt();
            //defineString();
            defineVoid();
            defineIO();
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
            var str = Context.CreateType("String");
            str.DefineMethod("concat", str, new string[] { "value" }, new IType[] { str });
            Context.GetType("String").TypeInherited = Context.GetType("Object");
            defineInt();
            var @int = Context.GetType("Int");
            str.DefineMethod("length", @int, new string[] { }, new IType[] { });
            str.DefineMethod("substr", str, new string[] {"i","l" }, new IType[] {@int,str });

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
            IType obj= Context.CreateType("Object");
            obj.DefineMethod("abort", obj, new string[] { }, new IType[] { });
            defineString();
            obj.DefineMethod("type_name", Context.GetType("String"), new string[] { }, new IType[] { });
            obj.DefineMethod("copy", obj, new string[] { }, new IType[] { });
        }

        void defineIO()
        {
            var io = Context.CreateType("IO");
            io.TypeInherited = Context.GetType("Object");
            io.DefineMethod("out_string", Context.GetType("Void"), new string[] { "string" }, new IType[] { Context.GetType("String") });
            io.DefineMethod("out_int", Context.GetType("Void"), new string[] { "int" }, new IType[] { Context.GetType("Int") });

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
