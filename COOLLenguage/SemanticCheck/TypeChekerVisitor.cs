﻿using System;
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
        IVisitor<Ident>,IVisitor<Initializer>,IVisitor<Constant>,IVisitor<Let>,IVisitor<Case>,IVisitor<Complement>
    {
        public IContext Context;
        IContext currentContext;
        public IType currentType;
        public IErrorLogger errorLog;
        IType DefaultType;
        const string TypeNotExist = "Line{0}: The Type {1} does not exist in the current context";
        const string VariableNotExist = "Line{0}: The variable {1} is not defined in the current context";
        const string CannotAssingDistintTypes = "Line{0}: The type {1} cannot be assigned to a type {2}";
        const string VariableIsdef = "Line{0}: The variable {1} is already defined in the current context";
        const string MethodIsNot = "Line{0}: The type {1} does not contain the method {2}";
        const string ConditionIsBool = "Line{0}: The condition must be type Bool";
        const string NotIsBool = "Line{0}: The Not expression must be type Bool";
        const string LeftIsNotInt = "Line{0}: The left expression must be type Int";
        const string RightIsNotInt = "Line{0}: The right expression must be type Int";
        const string RightIsNotAtomic = "Line{0}: The right expression must be type Int, String or Bool";
        const string LeftIsNotAtomic = "Line{0}: The left expression must be type Int, String or Bool";
        const string LeftIsNotEqualToRight = "Line{0}: The left expression must be type equal to right expression";
        const string MethodReturnTypeWrong = "Line{0}: The Return Type must be {1}";
        const string MethodNumArgWrong = "Line{0}: The Method {1} recieves {2} arguments ";
        const string TypeNotInheritsFrom = "Line{0}: The type {1} does not inherit from {2}";
        const string ExprIsNotInt = "Line{0}: The expression must be type Int";
        const string ArgIMustBe = "Line{0}: Method: {1} ; the argument {2} must be type {3}";
        const string argsMethodInerWrong = "Line {0}: Method: {1} is overriden and the argument {2} must be type {3}";
        const string RetTypeMethodInerWrong = "Line {0}: Method: {1} is overriden and the return type must be type {2}";
        const string argsCountMethodInerWrong = "Line {0}: Method: {1} is overriden and the number of arguments must be {2}";
        

        public void Visit(New node)
        {
            var type = Context.GetType(node.Type);
            if (type == null)
            {
                errorLog.LogError(string.Format(TypeNotExist,node.Line, node.Type));
                node.computedType = Context.GetType("Void");
            }
            else node.computedType = type;

        }

        public void Visit(Not node)
        {
            Visit(node.Expr);
            if (node.Expr.computedType.Name != "Bool")
            {
                errorLog.LogError(NotIsBool);
                node.computedType = Context.GetType("Void");
            }
            node.computedType = Context.GetType("Bool");
        }

        public void Visit(Assignment node)
        {
            Visit(node.Expr);
            var type = currentContext.GetTypeFor(node.Name);
            if (type == null)
            {
                var attr = currentType.GetAttribute(node.Name);
                if (attr != null)
                    type = attr.Type;
                else
                {
                    errorLog.LogError(string.Format(VariableNotExist,node.Line, node.Name));
                    node.computedType = Context.GetType("Void");
                    return;
                }
            } 
                if (!node.Expr.computedType.IsInheritedClass(type.Name))
                    errorLog.LogError(string.Format(CannotAssingDistintTypes,node.Line, node.Expr.computedType.Name, type.Name));
            node.computedType = type;
        }

        public void Visit(Method node)
        {

            #region verifying if is overrided method
            IMethod m;
            if ((m = currentType.GetMethodInherited(node.Name)) != null)
            {
                
                if (m.ReturnType.Name != node.ReturnType)
                {
                    errorLog.LogError(string.Format(RetTypeMethodInerWrong, node.Line, node.Name, m.ReturnType.Name));
                    return;
                }
                var argsIner = m.Arguments.ToArray();
                if(argsIner.Length!=node.Arguments.Count)
                {
                    errorLog.LogError(string.Format(argsCountMethodInerWrong, node.Line, node.Name, argsIner.Length));

                }
                for (int i = 0; i < argsIner.Length; i++)
                {
                    if (argsIner[i].Type.Name != node.Arguments[i].Type)
                    {
                        errorLog.LogError(string.Format(argsMethodInerWrong, node.Line, node.Name, i.ToString(), argsIner[i].Type.Name));
                        return;
                    }
                }
            }
            #endregion
            currentContext = Context.CreateChildContext();
            foreach (var item in node.Arguments)
            {
                var type = Context.GetType(item.Type);
                //if (type == null)
                //    errorLog.LogError(string.Format(TypeNotExist, item.Type));
                //else
                    currentContext.DefineVariable(item.Name, type);
            }
            Visit(node.Body);
            currentContext = Context;
            if (node.ReturnType!=node.Body.computedType.Name&& !node.Body.computedType.IsInheritedClass(node.ReturnType))
                errorLog.LogError(string.Format(MethodReturnTypeWrong,node.Line, node.ReturnType));
        }

        public void Visit(ClassDef node)
        {
            currentType = Context.GetType(node.Type);

            foreach (var attr in node.Attributes)
                Visit(attr);
            foreach (var met in node.Methods)
                Visit(met);
        }

        public void Visit(Program node)
        {
            currentContext = Context;
            DefaultType = Context.GetType("Object");
            foreach (var item in node.Classes)
                Visit(item);
        }

        public void Visit(AST1.Attribute node)
        {
            
            if (node.ExpresionInicializer != null)
            {
                Visit(node.ExpresionInicializer);

                if (!node.ExpresionInicializer.computedType.IsInheritedClass(node.Type))
                    errorLog.LogError(string.Format(CannotAssingDistintTypes,node.Line, node.ExpresionInicializer.computedType.Name, node.Type));
            }
        }

        public void Visit(Block node)
        {
            foreach (var item in node.Exprs)
            {
                Visit(item);
            }
            if((node.computedType = node.Exprs[node.Exprs.Count - 1].computedType)==null)
                node.computedType = Context.GetType("Void");
        }

        
        public void Visit(BinaryExpression node)
        {
            Visit(node.Left);
            Visit(node.Rigth);
            Comparison Comp = node as Comparison;

            

            if (Comp!=null &&Comp.Op!="="&& node.Left.computedType.Name != node.Rigth.computedType.Name)
            {
                errorLog.LogError(string.Format(LeftIsNotEqualToRight, node.Line));
                node.computedType = DefaultType;
                return;
            }  
            #region equals
            if ((Comp = (node as Comparison)) != null)
            {
                if (Comp.Op == "=")
                {
                    node.computedType = Context.GetType("Bool");
                    return;
                   
                    //switch (node.Left.computedType.Name)
                    //{
                    //    case "Int":
                    //        break;
                    //    case "Bool":
                    //        break;
                    //    case "String":
                    //        break;
                    //    default:
                    //        errorLog.LogError(string.Format(LeftIsNotAtomic,node.Left.Line));
                    //        break;
                    
                    //}
                    //switch (node.Rigth.computedType.Name)
                    //{
                    //    case "Int":
                    //        break;
                    //    case "Bool":
                    //        break;
                    //    case "String":
                    //        break;
                    //    default:
                    //        errorLog.LogError(RightIsNotAtomic);
                    //        break;
                    //}
                    
                }
                else
                {
                    if (node.Left.computedType.Name != "Int")
                        errorLog.LogError(string.Format(LeftIsNotInt,node.Left.Line));
                    if (node.Rigth.computedType.Name != "Int")
                        errorLog.LogError(RightIsNotInt);
                    if (node is ArithmeticOperation)
                        node.computedType = Context.GetType("Int");
                    else node.computedType = Context.GetType("Bool");
                    return;
                }
            }
            #endregion
            
                if (node.Left.computedType.Name != "Int")
                    errorLog.LogError(string.Format(LeftIsNotInt,node.Left.Line));
                if (node.Rigth.computedType.Name != "Int")
                    errorLog.LogError(RightIsNotInt);
            
            if (node is ArithmeticOperation)
                node.computedType = Context.GetType("Int");
            else node.computedType= Context.GetType("Bool");
        }

        public void Visit(Conditional node)
        {
            Visit(node.Condition);
            if (node.Condition.computedType.Name != "Bool")
                errorLog.LogError(string.Format(ConditionIsBool,node.Line));
            Visit(node.Body);
            if (node.Elsexpression != null)
            {
                Visit(node.Elsexpression);
                node.computedType = LCA(node.Body.computedType, node.Elsexpression.computedType);
            }
            else node.computedType = node.Body.computedType;

        }

        public void Visit(While node)
        {
            Visit(node.Condition);
            if (node.Condition.computedType.Name != "Bool")
                errorLog.LogError(ConditionIsBool);
            Visit(node.Body);
            node.computedType = Context.GetType("Object");
        }
        
        public void Visit(Dispatch node)
        {
            IType type = null;
            //a.b(...)
            if (node.Name != null && node.Name != "")
            {
                type = currentContext.GetTypeFor(node.Name);
            }
            //(expr).b(...)
            else if (node.ExprDispatched != null)
            {
                Visit(node.ExprDispatched);
                type = node.ExprDispatched.computedType;
            }
            else
            {
                VerifyTypesInDispatch(currentType, node);
                return;
            }
            if (type == null)
                {
                if ((type = currentType.GetAttribute(node.Name).Type) == null)
                {
                    errorLog.LogError(string.Format(VariableNotExist, node.Line, node.Name));
                    type = Context.GetType("Object");
                    return;
                }
                } 
            //(a|expr)@b(..)
            if (node.Type != null && node.Type != "")
            {

                IType typeInherited;
                if ((typeInherited = Context.GetType(node.Type)) == null)
                {
                    errorLog.LogError(string.Format(TypeNotExist, node.Line, node.Type));
                    node.computedType = DefaultType;
                    return;
                }
                else if (!type.IsInheritedClass(typeInherited.Name))
                {
                    errorLog.LogError(string.Format(TypeNotInheritsFrom, node.Line,type,typeInherited));
                    node.computedType = DefaultType;
                    return;
                }
            }
            VerifyTypesInDispatch(type, node);
            
            
        }

        void VerifyTypesInDispatch(IType type, Dispatch node)
        {
            IMethod M;
            if((M=type.GetMethod(node.MethodName))==null)
            {
                node.computedType = Context.GetType("Void");
                errorLog.LogError(string.Format(MethodIsNot, node.Line, type.Name, node.MethodName));

            }
            //if ((M = type.Methods.FirstOrDefault(m => m.Name == node.MethodName)) == null)
            //{
            //    node.computedType = Context.GetType("Void");
            //    errorLog.LogError(string.Format(MethodIsNot,node.Line, type.Name, node.MethodName));
            //}
            else
            {
                var args = node.Arg;
                var argDef = M.Arguments.ToArray();
                if (args.Count == argDef.Length)
                    for (int i = 0; i < argDef.Length; i++)
                    {
                        Visit(node.Arg[i]);
                        if (!node.Arg[i].computedType.IsInheritedClass(argDef[i].Type.Name))
                            errorLog.LogError(string.Format(ArgIMustBe,node.Line,M.Name,i.ToString(), argDef[i].Type.Name));

                    }
                else
                    errorLog.LogError(string.Format(MethodNumArgWrong,node.Line, M.Name, argDef.Length));
                node.computedType = M.ReturnType;
                if (node.Name != null && node.Name != "")
                {
                    var typeName = currentContext.GetTypeFor(node.Name);
                    if (typeName == null)
                        typeName = currentType.GetAttribute(node.Name).Type;
                    node.typeName = typeName.Name;
                }
                else
                {
                    //self
                    node.typeName = currentType.Name;
                }

            }
        }

        void Visit(Expression node)
        {
            if (node is Complement)
                Visit((Complement)node);
            else
            if (node is New)
                Visit((New)node);
            else
            if (node is IsVoid)
                Visit((IsVoid)node);
            else
            if (node is Not)
                Visit((Not)node);
            else
            if (node is Constant)
                Visit((Constant)node);
            else if (node is Ident)
                Visit((Ident)node);
            else if (node is BinaryExpression)
                Visit((BinaryExpression)node);
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
            if(node is Let)
            {
                Visit((Let)node);
                return;
            }
            if(node is Case)
            {
                Visit((Case)node);
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
            if (node.name == "self")
            {
                node.computedType = currentType;
                return;
            }

            if ((node.computedType = currentContext.GetTypeFor(node.name)) != null)
                return;
            else
            {
                var attr = currentType.GetAttribute(node.name);
                if (attr != null)
                    node.computedType = attr.Type;
                else
                {
                    node.computedType = Context.GetType("Void");
                    errorLog.LogError(string.Format(VariableNotExist,node.Line, node.name));
                }
            }
            
            
        }

        public void Visit(Initializer node)
        {
            if (node.Expr != null)
                Visit(node.Expr);
            currentContext.GetType(node.Type);
            var type = currentContext.GetType(node.Type);
            if(type==null)
            {
                errorLog.LogError(string.Format(TypeNotExist,node.Line, node.Type));
                return;
            }
            if(!node.Expr.computedType.IsInheritedClass(type.Name))
            {
                errorLog.LogError(string.Format(CannotAssingDistintTypes,node.Line, node.Expr.computedType.Name, type.Name));
                return;
            }
            if (!currentContext.DefineVariable(node.Name, type))
                errorLog.LogError(string.Format(VariableIsdef,node.Line, node.Name));
        }

        public void Visit(Constant node)
        {
            node.computedType = currentContext.GetType(node.type);
        }

        IType LCA(IType A, IType B)
        {
            IType lower;
            IType greatest;
            if (A == B)
                return A;
            if (A.LevelHierachy > B.LevelHierachy)
            {
                lower = A;
                greatest = B;
            }
            else { lower = B; greatest = A; }

            while (lower.TypeInherited.Name != "Object")
            {
                while (lower.LevelHierachy >= greatest.LevelHierachy)
                {
                    if (lower.TypeInherited.Name == greatest.TypeInherited.Name || lower.TypeInherited.Name == greatest.Name)
                        return lower.TypeInherited;

                    lower = lower.TypeInherited;

                }
                var tmp = lower;
                lower = greatest;
                greatest = tmp;
            }
            return lower.TypeInherited;
        }

        public void Visit(Let node)
        {
            var curcontext = currentContext.CreateChildContext();
            currentContext = curcontext;
            IType type;
            foreach (var init in node.Initializers)
            {
                if ((type = currentContext.GetType(init.Type)) == null)
                    errorLog.LogError(string.Format(TypeNotExist, init.Line, init.Type));
                currentContext.DefineVariable(init.Name, type,true);
                if (init.Expr != null)
                {
                    Visit(init.Expr);
                    if (!init.Expr.computedType.IsInheritedClass(init.Type))
                        errorLog.LogError(string.Format(CannotAssingDistintTypes,init.Line, init.Expr.computedType.Name, init.Type));
                }
            }
            Visit(node.Body);
            node.computedType = node.Body.computedType;
            currentContext = currentContext.Parent;

        }

        public void Visit(Case node)
        {
            var expr0 = node.expr;
            Visit(expr0);
            for (int i = 0; i < node.Exprs.Count; i++)
            {
                var val = node.Paramlist[i];
                if (currentContext.GetType(node.Paramlist[i].Type) == null)
                {
                    errorLog.LogError(string.Format(TypeNotExist, node.Paramlist[i].Type));
                    node.Paramlist[i].Type = "Object";
                }
                currentContext = currentContext.CreateChildContext();
                currentContext.DefineVariable(val.Name, currentContext.GetType(val.Type),true);
                Visit(node.Exprs[i]);
                currentContext = currentContext.Parent;
            }
            if (node.Exprs.Count > 1)
            {
                IType t1 = currentContext.GetType(node.Exprs[0].computedType.Name);
                for (int i = 1; i < node.Exprs.Count; i++)
                {

                    IType t2 = node.Exprs[i].computedType;
                    node.computedType = LCA(t1, t2);
                    if (node.computedType.Name == "Object")
                        break;
                    t1 = node.computedType;
                }
            }
            else node.computedType = node.Exprs[0].computedType;
        }

        public void Visit(Complement node)
        {
            Visit(node.Expr);
            var @int = Context.GetType("Int");
            if (node.Expr.computedType != @int)
                errorLog.LogError(string.Format(ExprIsNotInt, node.Expr.Line));
            node.computedType = @int;


        }
    }
}
