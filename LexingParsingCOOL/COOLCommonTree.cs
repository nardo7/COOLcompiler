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
                return new Comparison((Expression)((COOLCommonTree)GetChild(0)).GetAST1(), (Expression)((COOLCommonTree)GetChild(1)).GetAST1(), Text) { Line = Line };
            if(Type==COOLLexer.PLUS||Type==COOLLexer.MINUS||Type==COOLLexer.MULT||Type==COOLLexer.DIV)
                return new ArithmeticOperation((Expression)((COOLCommonTree)GetChild(0)).GetAST1(), (Expression)((COOLCommonTree)GetChild(1)).GetAST1(), Text) { Line = Line };
            #endregion

            switch (this.Type)
            {
                #region constant
                case COOLLexer.STRING:
                    return new Constant("String", Text) { Line = Line };
                case COOLLexer.NUMBER:
                    return new Constant("Int", Text) { Line = Line };
                case COOLLexer.BOOLEAN:
                    return new Constant("Bool", Text) { Line = Line };
                #endregion

                #region expresions
                case COOLLexer.NOT:
                    return new Not((Expression)((COOLCommonTree)GetChild(0)).GetAST1()) { Line = Line };
                case COOLLexer.ISVOID:
                    return new IsVoid((Expression)((COOLCommonTree)GetChild(0)).GetAST1()) { Line = Line };
                case COOLLexer.WHILE:
                    return new While((Expression)((COOLCommonTree)GetChild(0)).GetAST1(), (Expression)((COOLCommonTree)GetChild(1)).GetAST1()) { Line = Line };
                case COOLLexer.BLOCK:
                    var block = new Block() { Line = Line };
                    foreach (var item in Children)
                        block.Exprs.Add((Expression)((COOLCommonTree)item).GetAST1());
                    return block;
                case COOLLexer.ASSING:
                    return new Assignment(GetChild(0).Text, (Expression)((COOLCommonTree)GetChild(1)).GetAST1()) { Line = Line };
                case COOLLexer.IF:
                    if (ChildCount == 3)
                        return new Conditional((Expression)((COOLCommonTree)GetChild(0)).GetAST1(), (Expression)(((COOLCommonTree)(GetChild(1)).GetChild(0))).GetAST1(), (Expression)(((COOLCommonTree)(GetChild(2)).GetChild(0))).GetAST1()) { Line = Line };
                    else return new Conditional((Expression)((COOLCommonTree)GetChild(0)).GetAST1(), (Expression)(((COOLCommonTree)(GetChild(1)).GetChild(0))).GetAST1()) { Line = Line };
                case COOLLexer.NEW:
                    return new New(GetChild(0).Text) { Line = Line };

                case COOLLexer.NANARITA:
                    return new Complement((Expression)((COOLCommonTree)GetChild(0)).GetAST1()) { Line=Line};
                #region dispatch
                case COOLLexer.DISPATCH:
                    var disp = new Dispatch() { Line = Line };
                    int j = 2;
                    
                    if (GetChild(1).Type == COOLLexer.TYPE)
                    {
                        disp.Type = GetChild(1).Text;
                        j = 4;
                        disp.MethodName = GetChild(2).Text;
                    }
                    else if (GetChild(1).Type == COOLLexer.OP_PARENT)
                    {
                        disp.MethodName = GetChild(0).Text;
                        j = 2;

                    }
                    else//(expr).b(...)
                    {
                        j = 3;
                        disp.MethodName = GetChild(1).Text;
                    }
                    if (GetChild(0).Type != COOLLexer.ID)
                    {
                        disp.ExprDispatched = (Expression)((COOLCommonTree)GetChild(0)).GetAST1();
                        //(expr)@A.c(...)
                        
                        
                        for (; j < ChildCount; j++)
                        {
                            if (j + 1 < ChildCount)
                                if ((GetChild(j + 1).Type == COOLLexer.OP_PARENT) || GetChild(j).Type == COOLLexer.ARROBA || GetChild(j).Type == COOLLexer.OP_PARENT)
                                     break;
                            if (GetChild(j).Type == COOLLexer.TYPE)
                                break;
                            disp.Arg.Add((Expression)((COOLCommonTree)GetChild(j)).GetAST1());
                        }
                           // return disp;
                        
                        
                    }
                    else
                    {

                        //b[@T].c(...)
                        if (GetChild(1).Type != COOLLexer.OP_PARENT)
                        {

                            disp.Name = GetChild(0).Text;
                            if (disp.Type == null || disp.Type == "")
                            {
                                disp.MethodName = GetChild(1).Text;
                                j = 3;
                            }
                                
                        }
                            for (; j < ChildCount; j++)
                            {
                                if (j + 1 < ChildCount)
                                    if (( GetChild(j + 1).Type == COOLLexer.OP_PARENT) || GetChild(j).Type == COOLLexer.ARROBA)
                                    break;
                                if (GetChild(j).Type == COOLLexer.TYPE)
                                    break;
                                disp.Arg.Add((Expression)((COOLCommonTree)GetChild(j)).GetAST1());
                            }
                        
                        
                       // return disp;
                    }
                    if (j<ChildCount&&Children.Count(x => x.Type == COOLLexer.OP_PARENT)>1 )
                    {
                        var disp2 = new Dispatch() { Line = GetChild(j).Line };
                       
                        while (j < ChildCount) {
                            //Stack<Expression> stack = new Stack<Expression>(new Expression[] { disp });
                            //problema con j, hay q aumentarlo cuando no hay parametros
                            if (GetChild(j).Type == COOLLexer.OP_PARENT)
                                j++;
                            if (j >= ChildCount)
                                break;
                            if (GetChild(j).Type == COOLLexer.TYPE)
                            {
                                disp2.Type = GetChild(j).Text;
                                j++;
                                disp2.MethodName = GetChild(j).Text;
                                j += 2;
                                //throw new NotImplementedException("no implementado @ en multi-dispatch");
                            }
                            else
                            {
                                disp2.MethodName = GetChild(j).Text;
                                j += 2;
                            }
                            j = InsertArg(disp2, j);
                            disp2.ExprDispatched = disp;
                            disp = disp2;
                            if (j >= ChildCount)
                                break;
                            disp2 = new Dispatch() { Line = GetChild(j).Line };

                        }
                    }
                    return disp;
                #endregion

                case COOLLexer.LET:
                    var initializers = (COOLCommonTree)this.GetChild(0);
                    var list = new List<Initializer>();
                    if (initializers.Type == COOLLexer.VAR_DECLARATION_LIST)
                        foreach (var init in initializers.Children)
                            list.Add((Initializer)((COOLCommonTree)init).GetAST1());
                    else
                        list.Add((Initializer)initializers.GetAST1());
                    return new Let((Expression)((COOLCommonTree)GetChild(1)).GetAST1(),list) { Line = Line };
              
                case COOLLexer.CASE:
                    var expr0 = (Expression)((COOLCommonTree)GetChild(0)).GetAST1();
                    var branches = ((COOLCommonTree)GetChild(1));
                    Case @case = new Case(new List<Param>(), new List<Expression>(), expr0) { Line = Line };
                    if (branches.Type == COOLLexer.CASEBRANCHES)
                    {
                        foreach (COOLCommonTree branch in branches.Children)
                        {
                            var tmp = new Tuple<Param, Expression>((Param)((COOLCommonTree)branch.GetChild(0)).GetAST1(), (Expression)((COOLCommonTree)branch.GetChild(1)).GetAST1());
                            @case.Paramlist.Add(tmp.Item1);
                            @case.Exprs.Add(tmp.Item2);
                        }
                    }
                    else
                    {
                        var tmp = new Tuple<Param, Expression>((Param)((COOLCommonTree)branches.GetChild(0)).GetAST1(), (Expression)((COOLCommonTree)branches.GetChild(1)).GetAST1());
                        @case.Exprs.Add(tmp.Item2);
                        @case.Paramlist.Add(tmp.Item1);
                    }
                    return @case;

                case COOLLexer.ID:
                    return new Ident() { name = Text, Line=Line };

                #endregion

                #region features
                case COOLLexer.PARAM:
                    return new Param(GetChild(0).Text, GetChild(1).Text) { Line = Line };
                case COOLLexer.VAR_DECLARATION:
                    if (ChildCount > 2)
                        return new Initializer(GetChild(0).Text, GetChild(1).Text, (Expression)((COOLCommonTree)GetChild(3)).GetAST1()) { Line = Line };
                    else
                        return new Initializer(GetChild(0).Text, GetChild(1).Text) { Line = Line };
                case COOLLexer.ATTRIBUTE:
                    var attr = new COOLLenguage.SemanticCheck.AST1.Attribute() { Line = Line };
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
                        var method = new Method() { Name = GetChild(0).Text, Line=Line };
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
                       
                        return new Method(GetChild(0).Text, new List<Param>() { new Param(param.GetChild(0).Text, param.GetChild(1).Text) }, definition.GetChild(1).Text, (Expression)((COOLCommonTree)definition.GetChild(2)).GetAST1()) { Line = Line };
                    }
                    else
                        return new Method(GetChild(0).Text, new List<Param>(), definition.GetChild(0).Text, (Expression)((COOLCommonTree)definition.GetChild(1)).GetAST1()) { Line = Line };
                #endregion

                case COOLLexer.CLASS:
                    var @class = new ClassDef(GetChild(0).Text) { Line = Line };
                    
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
                    var pro = new Program() { Line = Line };
                    foreach (var item in Children)
                        pro.Classes.Add((ClassDef)((COOLCommonTree)item).GetAST1());
                    return pro;
                default: return null;
            }
        }
        int InsertArg(Dispatch d,int initArg)
        {
            int j = initArg;
            for (; j < ChildCount; j++)
            {
                if(j+1<ChildCount)
                    if ((j + 1 < ChildCount && GetChild(j + 1).Type == COOLLexer.OP_PARENT) || GetChild(j).Type == COOLLexer.ARROBA)
                        break;
                if (GetChild(j).Type == COOLLexer.TYPE)
                    break;
                d.Arg.Add((Expression)((COOLCommonTree)GetChild(j)).GetAST1());
            }
            //if (j == initArg)
            //    return j += 1;
            //else 
            return j;
        }
    }
}
