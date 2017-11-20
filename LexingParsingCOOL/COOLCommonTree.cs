using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime.Tree;
using COOLLenguage.SemanticCheck.AST1;
using Antlr.Runtime;

namespace LexingParsingCOOL
{
    public class COOLCommonTree:CommonTree
    {
        public COOLCommonTree(IToken t):base(t)
        {

        }
       public virtual Node GetAST1()
        {
            #region BinaryOperation
            if (Type==COOLLexer.L||Type==COOLLexer.LEQ||Type==COOLLexer.G||Type==COOLLexer.GEQ||Type==COOLLexer.EQ)
                return new Comparison((Expression)((COOLCommonTree)GetChild(0)).GetAST1(), (Expression)((COOLCommonTree)GetChild(1)).GetAST1(), Text);
            if(Type==COOLLexer.PLUS||Type==COOLLexer.MINUS||Type==COOLLexer.MULT||Type==COOLLexer.DIV)
                return new ArithmeticOperation((Expression)((COOLCommonTree)GetChild(0)).GetAST1(), (Expression)((COOLCommonTree)GetChild(1)).GetAST1(), Text);
            #endregion

            switch (this.Type)
            {
                #region constant
                case COOLLexer.STRING:
                    return new Constant("String", Text);
                case COOLLexer.NUMBER:
                    return new Constant("Int", Text);
                case COOLLexer.BOOLEAN:
                    return new Constant("Bool", Text);
                #endregion

                #region expresions
                case COOLLexer.NOT:
                    return new Not((Expression)((COOLCommonTree)GetChild(0)).GetAST1());
                case COOLLexer.ISVOID:
                    return new IsVoid((Expression)((COOLCommonTree)GetChild(0)).GetAST1());
                case COOLLexer.WHILE:
                    return new While((Expression)((COOLCommonTree)GetChild(0)).GetAST1(), (Expression)((COOLCommonTree)GetChild(1)).GetAST1());
                case COOLLexer.BLOCK:
                    var block = new Block();
                    foreach (var item in Children)
                        block.Exprs.Add((Expression)((COOLCommonTree)item).GetAST1());
                    return block;
                case COOLLexer.ASSING:
                    return new Assignment(GetChild(0).Text, (Expression)((COOLCommonTree)GetChild(1)).GetAST1());
                case COOLLexer.IF:
                    if (ChildCount == 3)
                        return new Conditional((Expression)((COOLCommonTree)GetChild(0)).GetAST1(), (Expression)(((COOLCommonTree)(GetChild(1)).GetChild(0))).GetAST1(), (Expression)(((COOLCommonTree)(GetChild(2)).GetChild(0))).GetAST1());
                    else return new Conditional((Expression)((COOLCommonTree)GetChild(0)).GetAST1(), (Expression)(((COOLCommonTree)(GetChild(1)).GetChild(0))).GetAST1());
                case COOLLexer.NEW:
                    return new New(GetChild(0).Text);
                case COOLLexer.DISPATCH:
                    var disp = new Dispatch();
                    if (GetChild(0).Type != COOLLexer.ID)
                    {
                        disp.ExprDispatched = (Expression)((COOLCommonTree)GetChild(0)).GetAST1();
                       
                        if (GetChild(1).Type == COOLLexer.TYPE)
                        {
                            throw new NotImplementedException();
                        }
                        else
                        {
                            disp.MethodName = GetChild(1).Text;
                            for (int i = 2; i < ChildCount; i++)
                                if(GetChild(i).Type!=COOLLexer.OP_PARENT)
                                    disp.Arg.Add((Expression)((COOLCommonTree)GetChild(i)).GetAST1());
                            return disp;
                        }
                        
                    }
                    else
                    {
                        int i = 2;
                        if (GetChild(1).Type != COOLLexer.OP_PARENT)
                        {
                            disp.Name = GetChild(0).Text;
                            disp.MethodName = GetChild(1).Text;
                            i = 3;
                        }
                        else
                            disp.MethodName=GetChild(0).Text;
                        for (;i  < ChildCount; i++)
                            disp.Arg.Add((Expression)((COOLCommonTree)GetChild(i)).GetAST1());
                        
                        
                        return disp;
                    }
                case COOLLexer.ID:
                    return new Ident() { name = Text };
                        
                #endregion

                #region features
                case COOLLexer.PARAM:
                    return new Param(GetChild(0).Text, GetChild(1).Text);
                case COOLLexer.VAR_DECLARATION:
                    if (ChildCount > 2)
                        return new Initializer(GetChild(0).Text, GetChild(1).Text, (Expression)((COOLCommonTree)GetChild(3)).GetAST1());
                    else
                        return new Initializer(GetChild(0).Text, GetChild(1).Text);
                case COOLLexer.ATTRIBUTE:
                    var attr = new COOLLenguage.SemanticCheck.AST1.Attribute();
                    if (ChildCount > 2)
                    {
                        attr.Name = GetChild(0).Text;
                        attr.Type = GetChild(1).Text;
                        attr.ExpresionInicializer = (Expression)((COOLCommonTree)GetChild(3)).GetAST1();
                        return attr;
                    }
                    else
                    {
                        attr.Name = GetChild(0).Text;
                        attr.Type = GetChild(1).Text;
                        return attr;
                    }
                case COOLLexer.BODY:
                    return ((COOLCommonTree)GetChild(0)).GetAST1();
                case COOLLexer.METHOD:
                    
                    var definition = GetChild(1);
                    if(definition.GetChild(0).Type==COOLLexer.PARAMLIST)
                    {
                        var method = new Method() { Name = GetChild(0).Text };
                        var paramlist = (COOLCommonTree)definition.GetChild(0);
                        foreach (var item in paramlist.Children)
                            method.Arguments.Add(new Param(item.GetChild(0).Text, item.GetChild(1).Text));
                        method.ReturnType = definition.GetChild(1).Text;
                        method.Body= (Expression)((COOLCommonTree)definition.GetChild(2).GetChild(0)).GetAST1();
                        return method;
                    }
                    else if (definition.GetChild(0).Type == COOLLexer.PARAM)
                    {
                        var param = definition.GetChild(0);
                       
                        return new Method(GetChild(0).Text, new List<Param>() { new Param(param.GetChild(0).Text, param.GetChild(1).Text) }, definition.GetChild(1).Text, (Expression)((COOLCommonTree)definition.GetChild(2)).GetAST1());
                    }
                    else
                        return new Method(GetChild(0).Text, new List<Param>(), definition.GetChild(0).Text, (Expression)((COOLCommonTree)definition.GetChild(1)).GetAST1());
                #endregion

                case COOLLexer.CLASS:
                    var @class = new ClassDef(GetChild(0).Text);
                    
                    if (GetChild(1)!=null&&(GetChild(1).Type == COOLLexer.INHERITS))
                    {
                        @class.typeInherited = GetChild(2).Text;
                        for (int i = 3; i < ChildCount; i++)
                        {
                            var item = GetChild(i);
                            if (item.Type == COOLLexer.ATTRIBUTE)
                                @class.Attributes.Add((COOLLenguage.SemanticCheck.AST1.Attribute)((COOLCommonTree)item).GetAST1());
                            else
                                @class.Methods.Add((Method)((COOLCommonTree)item).GetAST1());
                            
                        }
                        return @class;

                    }

                    for (int i = 1; i < ChildCount; i++)
                    {
                        var item = GetChild(i);
                        if (item.Type == COOLLexer.ATTRIBUTE)
                            @class.Attributes.Add((COOLLenguage.SemanticCheck.AST1.Attribute)((COOLCommonTree)item).GetAST1());
                        else
                            @class.Methods.Add((Method)((COOLCommonTree)item).GetAST1());
                    }
                    //foreach (var item in features.Children)
                    //    if (item.Type == COOLLexer.ATTRIBUTE)
                    //        @class.Attributes.Add((COOLLenguage.SemanticCheck.AST1.Attribute)((COOLCommonTree)item).GetAST1());
                    //    else
                    //        @class.Methods.Add((Method)((COOLCommonTree)item).GetAST1());
                    return @class;

                case COOLLexer.PROGRAM:
                    var pro = new Program();
                    foreach (var item in Children)
                        pro.Classes.Add((ClassDef)((COOLCommonTree)item).GetAST1());
                    return pro;
                default: return null;
            }
        }
    }
}
