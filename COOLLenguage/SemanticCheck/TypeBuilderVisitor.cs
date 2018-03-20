using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COOLLenguage.SemanticCheck.AST1;
using COOLLenguage.Utils;

namespace COOLLenguage.SemanticCheck
{
    public class TypeBuilderVisitor : IVisitor<Program>, IVisitor<ClassDef>, IVisitor<AST1.Attribute>, IVisitor<Method>
    {
        public IContext Context;
        public IType currentType;
        public IErrorLogger errorLog;

        const string TypeNotExist= "Line{0}: The Type {1} does not exist in the current context";
        const string AttrRedefined = "Line{0}: The attribute {1} is redefined in {2} definition";
        const string MethodRedefined = "Line{0}: The method {1} is redefined in {2} class definition";
        const string TYPEINHERITEDDOESNEXIST = "Line{0}: The type {1} inherits another type that does not exist";

        public void Visit(ClassDef node)
        {
            currentType = Context.GetType(node.Type);
            if (node.typeInherited != null)
            {
                IType t;
                if ((t = Context.GetType(node.typeInherited)) != null)
                {
                    currentType.TypeInherited = t;
                    currentType.LevelHierachy = t.LevelHierachy + 1;
                }
                else
                    errorLog.LogError(string.Format(TYPEINHERITEDDOESNEXIST,node.Line, currentType.Name, node.typeInherited));

            }
            else
                currentType.TypeInherited = Context.GetType("Object");
            foreach (var item in node.Attributes)
            {
                Visit(item);
            }
            foreach (var item in node.Methods)
            {
                Visit(item);
            }
            currentType.DefineAttribute("self", currentType);
        }

        public void Visit(Program node)
        {
            foreach (var item in node.Classes)
                Visit(item);
        }

        public void Visit(AST1.Attribute node)
        {
            var attrType = Context.GetType(node.Type);
            if (attrType == default(Type))
            {
                errorLog.LogError(string.Format( TypeNotExist,node.Line, node.Type));
                return;
            }
            if (currentType.GetAttributeInherited(node.Name) != null)
            {
                errorLog.LogError(string.Format(AttrRedefined,node.Line, node.Name, currentType.Name));
                return;
            }
            currentType.DefineAttribute(node.Name,attrType);
            
        }

        public void Visit(Method node)
        {
            var retType = Context.GetType(node.ReturnType);
            if (retType == null)
                errorLog.LogError(string.Format(TypeNotExist, node.ReturnType));
            var argTypes = node.Arguments.Select(t => Context.GetType(t.Type));
            foreach (var type in argTypes)
                if(type==null)
                    errorLog.LogError(string.Format(TypeNotExist, type));

            var argNames = node.Arguments.Select(t => t.Name);
            if (!currentType.DefineMethod(node.Name, retType, argNames.ToArray(), argTypes.ToArray()))
                errorLog.LogError(string.Format(MethodRedefined, node.Name, currentType.Name));
        }

       
    }
}
