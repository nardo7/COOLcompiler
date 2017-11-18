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

        public const string TypeNotExist= "The Type {0} does not exist in the current context";

        public void Visit(ClassDef node)
        {
            currentType = Context.GetType(node.Type);
            foreach (var item in node.Attributes)
            {
                Visit(item);
            }
            foreach (var item in node.Methods)
            {
                Visit(item);
            }
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
                errorLog.LogError(string.Format( TypeNotExist,node.Type));
                return;
            }
            currentType.DefineAttribute(node.Name,attrType);
        }

        public void Visit(Method node)
        {
            var retType = Context.GetType(node.ReturnType);
            if (retType == default(Type))
                errorLog.LogError(string.Format(TypeNotExist, node.ReturnType));
            var argTypes = node.Arguments.Select(t => Context.GetType(t.Type));
            var argNames = node.Arguments.Select(t => t.Name);
            currentType.DefineMethod(node.Name, retType, argNames.ToArray(), argTypes.ToArray());
        }
    }
}
