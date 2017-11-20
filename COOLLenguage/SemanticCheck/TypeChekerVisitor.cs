using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COOLLenguage.SemanticCheck.AST1;
using COOLLenguage.Utils;

namespace COOLLenguage.SemanticCheck
{
    public class TypeChekerVisitor : IVisitor<Program>,
                                     IVisitor<ClassDef>, IVisitor<AST1.Attribute>, IVisitor<Method>, IVisitor<Block>,
                                     IVisitor<Assignment>, IVisitor<BinaryExpression>, IVisitor<Not>, IVisitor<IsVoid>,
                                     IVisitor<Conditional>, IVisitor<New>, IVisitor<While>, IVisitor<Dispatch>,
        IVisitor<Ident>,IVisitor<Initializer>,IVisitor<Constant>
    {
        public IContext Context;
        IContext currentContext;
        public IType currentType;
        public IErrorLogger errorLog;

        const string TypeNotExist = "The Type {0} does not exist in the current context";
        const string VariableNotExist = "The variable {0} is not defined in the current context";
        const string CannotAssingDistintTypes = "The type {0} cannot be assigned to a type {1}";
        const string VariableIsdef = "The variable {0} is already defined in the current context";
        const string MethodIsNot = "The type {0} does not contain the method {1}";

        public void Visit(New node)
        {
            var type = Context.GetType(node.Type);
            if (type == null)
                errorLog.LogError(string.Format(TypeNotExist, node.Type));
            else node.computedType = type;

        }

        public void Visit(Not node)
        {
            Visit(node.Expr);
            node.computedType = Context.GetType("Bool");
        }

        public void Visit(Assignment node)
        {
            Visit(node.Expr);
            var type = currentContext.GetTypeFor(node.Name);
            if (type == null)
                errorLog.LogError(string.Format(VariableNotExist, node.Name));
            else
                if (!node.Expr.computedType.IsInheritedClass(type.Name))
                    errorLog.LogError(string.Format(CannotAssingDistintTypes, node.computedType.Name, type.Name));

        }

        public void Visit(Method node)
        {
            throw new NotImplementedException();
        }

        public void Visit(ClassDef node)
        {
            throw new NotImplementedException();
        }

        public void Visit(Program node)
        {
            throw new NotImplementedException();
        }

        public void Visit(AST1.Attribute node)
        {
            throw new NotImplementedException();
        }

        public void Visit(Block node)
        {
            foreach (var item in node.Exprs)
            {
                Visit(item);
            }
            node.computedType = node.Exprs[node.Exprs.Count - 1].computedType;
        }



        public void Visit(BinaryExpression node)
        {
            throw new NotImplementedException();
        }

        public void Visit(Conditional node)
        {
            throw new NotImplementedException();
        }

        public void Visit(While node)
        {
            throw new NotImplementedException();
        }
        
        //falta el arroba
        public void Visit(Dispatch node)
        {
            if (node.Name != null)
            {
                var type = currentContext.GetTypeFor(node.Name);
                IMethod M;
                if ((M=type.Methods.FirstOrDefault(m => m.Name == node.MethodName)) ==null)
                    errorLog.LogError(string.Format(MethodIsNot, type.Name, node.MethodName));
                else
                {
                    var args= M.Arguments.ToList();
                    for (int i = 0; i < node.Arg.Count; i++)
                    {
                        Visit(node.Arg[i]);
                        if (!node.Arg[i].computedType.IsInheritedClass(args[i].Type.Name))
                            errorLog.LogError(string.Format(CannotAssingDistintTypes, node.Arg[i].computedType.Name, args[i].Type.Name));
                    }

                }
            }
            else
            {
                IMethod M;
                if ((M=currentType.Methods.FirstOrDefault(m => m.Name == node.MethodName)) == null)
                    errorLog.LogError(string.Format(MethodIsNot, currentType.Name, node.MethodName));
                else
                {
                    var args = M.Arguments.ToList();
                    for (int i = 0; i < node.Arg.Count; i++)
                    {
                        Visit(node.Arg[i]);
                        if (!node.Arg[i].computedType.IsInheritedClass(args[i].Type.Name))
                            errorLog.LogError(string.Format(CannotAssingDistintTypes, node.Arg[i].computedType.Name, args[i].Type.Name));
                    }
                }
            }

            throw new NotImplementedException();
        }

        void Visit(Expression node)
        {

            if (node is New)
                Visit((New)node);
            else
            if (node is IsVoid)
                Visit((IsVoid)node);
            else
            if (node is Not)
                Visit((Not)node);
            else
                if (node is Assignment)
                {
                    Visit((Assignment)node);
                    return;
                }
            if (node is Block)
            {
                Visit((Block)node);
                return;
            }
            if (node is While)
            {
                Visit((While)node);
                return;
            }
            if(node is Conditional)
            {
                Visit((Conditional)node);
                return;
            }
            if (node is Dispatch)
            {
                Visit((Dispatch)node);
                return;
            }
        }

        public void Visit(IsVoid node)
        {
            Visit(node.Expr);
            node.computedType = Context.GetType("Bool");
        }

        public void Visit(Ident node)
        {
            // currentContext.DefineVariable(node.name,node.)
            throw new NotImplementedException();
        }

        public void Visit(Initializer node)
        {
            if (node.Expr != null)
                Visit(node.Expr);
            currentContext.GetType(node.Type);
            var type = currentContext.GetType(node.Type);
            if(type==null)
            {
                errorLog.LogError(string.Format(TypeNotExist, node.Type));
                return;
            }
            if(!node.Expr.computedType.IsInheritedClass(type.Name))
            {
                errorLog.LogError(string.Format(CannotAssingDistintTypes, node.Expr.computedType.Name, type.Name));
                return;
            }
            if (!currentContext.DefineVariable(node.Name, type))
                errorLog.LogError(string.Format(VariableIsdef, node.Name));
        }

        public void Visit(Constant node)
        {
            node.computedType = currentContext.GetType(node.type);
        }
    }
}
