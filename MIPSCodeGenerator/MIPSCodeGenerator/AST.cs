using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPSCodeGenerator
{
    public abstract class TreeNode
    {
        public string Type { get; set; } = "";
        public int LineNumber { get; set; }

    }

    public class Expression : TreeNode
    {

    }

    public class Program : TreeNode
    {
        public List<Class> Classes { get; set; }
        public Program(List<Class> classes, int lineno = 0)
        {
            Classes = classes;
            LineNumber = lineno;
        }
    }

    public class Class : TreeNode
    {
        public Symbol Name { get; set; }
        public Symbol Parent { get; set; }
        public Symbol FileName { get; set; }
        public List<Feature> Features { get; set; }
        public Class(Symbol name, Symbol parent, Symbol fileName,List<Feature>feats ,int line = 0)
        {
            Name = name;
            Parent = parent;
            FileName = fileName;
            Features = new List<Feature>(feats);
            LineNumber = line;
        }
    }

    public class Feature : TreeNode
    {

    }

    public class Method : Feature
    {
        public Symbol Name { get; set; }
        public Symbol ReturnType { get; set; }
        public List<Formal> Formals { get; set; }
        public Expression Expression { get; set; }
        public Method(Symbol name, Symbol returnType, List<Formal> formals, Expression expression, int lineno = 0)
        {
            Name = name;
            ReturnType = returnType;
            Formals = new List<Formal>(formals);
            Expression = expression;
            LineNumber = lineno;
        }
    }
    public class Attr : Feature
    {
        public Symbol Name { get; set; }
        public Symbol TypeDecl { get; set; }
        public Expression Init { get; set; }
        public Attr(Symbol name, Symbol typeDecl, Expression init, int lineno = 0)
        {
            Name = name;
            TypeDecl = typeDecl;
            Init = init;
            LineNumber = lineno;
        }
    }
    public class Formal : TreeNode
    {
        public Symbol Name { get; set; }
        public Symbol TypeDecl { get; set; }
        public Formal(Symbol name, Symbol typeDecl, int lineno = 0)
        {
            Name = name;
            TypeDecl = typeDecl;
            LineNumber = lineno;
        }
    }

    public class Case : TreeNode
    {
        public Symbol Name { get; set; }
        public Symbol TypeDecl { get; set; }
        public Expression Expression { get; set; }
        public Case(Symbol name, Symbol typeDecl, Expression expression, int lineno = 0)
        {
            Name = name;
            TypeDecl = typeDecl;
            Expression = expression;
            LineNumber = lineno;
        }
    }
    public class Assign : Expression
    {
        public Symbol Name { get; set; }
        public Expression Expression { get; set; }
        public Assign(Symbol name, Expression expression, int lineno = 0)
        {
            Name = name;
            Expression = expression;
            LineNumber = lineno;
        }
    }
    public class StaticDispatch : Expression
    {
        public Symbol Name { get; set; }
        public Symbol TypeName { get; set; }
        public Expression Expression { get; set; }
        public List<Expression> ActualExpressions { get; set; }
        public StaticDispatch(Symbol name, Symbol typeName, Expression expression, List<Expression> actualExpressoins, int lineno = 0)
        {
            Name = name;
            TypeName = typeName;
            Expression = expression;
            ActualExpressions = new List<Expression>(actualExpressoins);
            LineNumber = lineno;
        }
    }
    public class Dispatch : Expression
    {
        public Symbol Name { get; set; }
        public Expression Expression { get; set; }
        public List<Expression> ActualExpressions { get; set; }
        public Dispatch(Symbol name, Expression expression, List<Expression> actualExpressions, int lineno = 0)
        {
            Name = name;
            Expression = expression;
            ActualExpressions = new List<Expression>(actualExpressions);
            LineNumber = lineno;
        }
    }
    public class Cond : Expression
    {
        public Expression Predicate { get; set; }
        public Expression Then { get; set; }
        public Expression Else { get; set; }
        public Cond(Expression predicate, Expression then, Expression ellse, int lineno = 0)
        {
            Predicate = predicate;
            Then = then;
            Else = ellse;
            LineNumber = lineno;
        }
    }
    public class Loop : Expression
    {
        public Expression Predicate { get; set; }
        public Expression Body { get; set; }
        public Loop(Expression predicate, Expression body, int lineno = 0)
        {
            Predicate = predicate;
            Body = body;
            LineNumber = lineno;
        }
    }
    public class Typcase : Expression
    {
        public Expression Expression { get; set; }
        public List<Case> Cases { get; set; }
        public Typcase(Expression expression, List<Case> cases, int lineno = 0)
        {
            Expression = expression;
            Cases = new List<Case>(cases);
            LineNumber = lineno;
        }
    }
    public class Block : Expression
    {
        public List<Expression> Body { get; set; }
        public Block(List<Expression> body, int lineno = 0)
        {
            Body = new List<Expression>(body);
            LineNumber = lineno;
        }
    }
    public class Let : Expression
    {
        public Symbol Identifier { get; set; }
        public Symbol TypeDecl { get; set; }
        public Expression Init { get; set; }
        public Expression Body { get; set; }
        public Let(Symbol identifier, Symbol typeDecl, Expression init, Expression body, int lineno = 0)
        {
            Identifier = identifier;
            TypeDecl = typeDecl;
            Init = init;
            Body = body;
            LineNumber = lineno;
        }
    }
    public class Plus : Expression
    {
        public Expression Exp1 { get; set; }
        public Expression Exp2 { get; set; }
        public Plus(Expression e1, Expression e2, int lineno = 0)
        {
            Exp1 = e1;
            Exp2 = e2;
            LineNumber = lineno;
        }
    }
    public class Mul : Expression
    {
        public Expression Exp1 { get; set; }
        public Expression Exp2 { get; set; }
        public Mul(Expression e1, Expression e2, int lineno = 0)
        {
            Exp1 = e1;
            Exp2 = e2;
            LineNumber = lineno;
        }
    }
    public class Sub : Expression
    {
        public Expression Exp1 { get; set; }
        public Expression Exp2 { get; set; }
        public Sub(Expression e1, Expression e2, int lineno = 0)
        {
            Exp1 = e1;
            Exp2 = e2;
            LineNumber = lineno;
        }
    }
    public class Divide : Expression
    {
        public Expression Exp1 { get; set; }
        public Expression Exp2 { get; set; }
        public Divide(Expression e1, Expression e2, int lineno = 0)
        {
            Exp1 = e1;
            Exp2 = e2;
            LineNumber = lineno;
        }
    }
    public class Neg : Expression
    {
        public Expression Exp { get; set; }
        public Neg(Expression e, int lineno = 0)
        {
            Exp = e;
            LineNumber = lineno;
        }
    }
    public class Lt : Expression
    {
        public Expression Exp1 { get; set; }
        public Expression Exp2 { get; set; }
        public Lt(Expression e1, Expression e2, int lineno = 0)
        {
            Exp1 = e1;
            Exp2 = e2;
            LineNumber = lineno;
        }
    }
    public class Eq : Expression
    {
        public Expression Exp1 { get; set; }
        public Expression Exp2 { get; set; }
        public Eq(Expression e1, Expression e2, int lineno = 0)
        {
            Exp1 = e1;
            Exp2 = e2;
            LineNumber = lineno;
        }
    }
    public class Leq : Expression
    {
        public Expression Exp1 { get; set; }
        public Expression Exp2 { get; set; }
        public Leq(Expression e1, Expression e2, int lineno = 0)
        {
            Exp1 = e1;
            Exp2 = e2;
            LineNumber = lineno;
        }
    }
    public class Comp : Expression
    {
        public Expression Exp { get; set; }
        public Comp(Expression e, int lineno = 0)
        {
            Exp = e;
            LineNumber = lineno;
        }
    }
    public class IntConst : Expression
    {
        public Symbol Token { get; set; }
        public IntConst(Symbol t, int lineno = 0)
        {
            Token = t;
            LineNumber = lineno;
        }
    }
    public class BoolConst : Expression
    {
        public bool Value { get; set; }
        public BoolConst(bool v, int lineno = 0)
        {
            Value = v;
            LineNumber = lineno;
        }
    }
    public class StringConst : Expression
    {
        public Symbol Token { get; set; }
        public StringConst(Symbol t, int lineno = 0)
        {
            Token = t;
            LineNumber = lineno;
        }
    }
    public class New : Expression
    {
        public Symbol TypeName { get; set; }
        public New(Symbol typeName, int lineno = 0)
        {
            TypeName = typeName;
            LineNumber = lineno;
        }
    }
    public class IsVoid : Expression
    {
        public Expression Expr { get; set; }
        public IsVoid(Expression expr, int lineno = 0)
        {
            Expr = expr;
            LineNumber = lineno;
        }
    }
    public class NoExpr : Expression
    {
        public NoExpr(int lineno = 0)
        {
            LineNumber = lineno;
        }
    }
    public class Object : Expression
    {
        public Symbol Name { get; set; }
        public Object(Symbol name, int lineno = 0)
        {
            Name = name;
            LineNumber = lineno;
        }
    }

    public static class CGUtils
    {
        public static List<Class> CreateNilClasses()
        {
            return new List<Class>();
        }

        public static List<Class> CreateSingleClasses(Class c)
        {
            return AppendClass(new List<Class>(), c);
        }

        public static List<Class> AppendClass(List<Class> cs, Class c)
        {
            if (cs == null)
            {
                //if (g_log_cerr) cerr << "AppendClass:NULL" << endl;
                return null;
            }
            cs.Add(c);
            return cs;
        }

        public static List<Feature> CreateNilFeatures()
        {
            return new List<Feature>();
        }

        public static List<Feature> CreateSingleFeatures(Feature f)
        {
            return AppendFeature(new List<Feature>(), f);
        }

        public static List<Feature> AppendFeature(List<Feature> fs, Feature f)
        {
            if (fs==null)
            {
                //if (g_log_cerr) cerr << "AppendFeature:NULL" << endl;
                return null;
            }
            fs.Add(f);
            return fs;
        }

        public static List<Formal> CreateNilFormals()
        {
            return new List<Formal>();
        }

        public static List<Formal> CreateSingleFormals(Formal f)
        {
            return AppendFormal(new List<Formal>(), f);
        }

        public static List<Formal> AppendFormal(List<Formal> fs, Formal f)
        {
            if (fs==null)
            {
                //if (g_log_cerr) cerr << "AppendFormal:NULL" << endl;
                return null;
            }
            fs.Add(f);
            return fs;
        }

        public static List<Expression> CreateNilExpressions()
        {
            return new List<Expression>();
        }

        public static List<Expression> CreateSingleExpressions(Expression e)
        {
            return AppendExpression(new List<Expression>(), e);
        }

        public static List<Expression> AppendExpression(List<Expression> es, Expression e)
        {
            if (es==null)
            {
               // if (g_log_cerr) cerr << "AppendExpression:NULL" << endl;
                return null;
            }
            es.Add(e);
            return es;
        }

        public static List<Case> CreateNilCases()
        {
            return new List<Case>();
        }

        public static List<Case> CreateSingleCases(Case c)
        {
            return AppendCase(new List<Case>(), c);
        }

        public static List<Case> AppendCase(List<Case> cs, Case c)
        {
            if (cs == null)
            {
                //if (g_log_cerr) cerr << "AppendCase:NULL" << endl;
                return null;
            }
            cs.Add(c);
            return cs;
        }

        public static Program CreateProgram(List<Class> cs, int lineno=0)
        {
            return new Program(cs, lineno);
        }

        public static Class CreateClass(Symbol name, Symbol parent, Symbol filename, List<Feature> features, int lineno=0)
        {
            return new Class(name, parent, filename, features, lineno);
        }

        public static Feature CreateMethod(Symbol name, Symbol return_type, List<Formal> formals, Expression expression, int lineno=0)
        {
            return new Method(name, return_type, formals, expression, lineno);
        }

        public static Feature CreateAttr(Symbol name, Symbol type_decl, Expression init, int lineno=0)
        {
            return new Attr(name, type_decl, init, lineno);
        }

        public static Formal CreateFormal(Symbol name, Symbol type_decl, int lineno=0)
        {
            return new Formal(name, type_decl, lineno);
        }

        public static Case CreateCase(Symbol name, Symbol type_decl, Expression expression, int lineno=0)
        {
            return new Case(name, type_decl, expression, lineno);
        }

        public static Expression CreateAssign(Symbol name, Expression expression, int lineno=0)
        {
            return new Assign(name, expression, lineno);
        }

        public static Expression CreateStaticDispatch(Symbol name, Symbol type_name, Expression expression, List<Expression> actual_exprs, int lineno=0)
        {
            return new StaticDispatch(name, type_name, expression, actual_exprs, lineno);
        }

        public static Expression CreateDispatch(Symbol name, Expression expression, List<Expression> actual_exprs, int lineno=0)
        {
            return new Dispatch(name, expression, actual_exprs, lineno);
        }

        public static Expression CreateCond(Expression pred, Expression then_exp, Expression else_exp, int lineno=0)
        {
            return new Cond(pred, then_exp, else_exp, lineno);
        }

        public static Expression CreateLoop(Expression pred, Expression body, int lineno=0)
        {
            return new Loop(pred, body);
        }

        public static Expression CreateTypecase(Expression expression, List<Case> cases, int lineno=0)
        {
            return new Typcase(expression, cases);
        }

        public static Expression CreateBlock(List<Expression> body, int lineno=0)
        {
            return new Block(body, lineno);
        }

        public static Expression CreateLet(Symbol identifier, Symbol type_decl, Expression init, Expression body, int lineno=0)
        {
            return new Let(identifier, type_decl, init, body, lineno);
        }

        public static Expression CreatePlus(Expression e1, Expression e2, int lineno=0)
        {
            return new Plus(e1, e2, lineno);
        }

        public static Expression CreateSub(Expression e1, Expression e2, int lineno=0)
        {
            return new Sub(e1, e2, lineno);
        }

        public static Expression CreateMul(Expression e1, Expression e2, int lineno=0)
        {
            return new Mul(e1, e2, lineno);
        }

        public static Expression CreateDivide(Expression e1, Expression e2, int lineno=0)
        {
            return new Divide(e1, e2);
        }

        public static Expression CreateNeg(Expression e, int lineno=0)
        {
            return new Neg(e, lineno);
        }

        public static Expression CreateLt(Expression e1, Expression e2, int lineno=0)
        {
            return new Lt(e1, e2, lineno);
        }

        public static Expression CreateEq(Expression e1, Expression e2, int lineno=0)
        {
            return new Eq(e1, e2);
        }

        public static Expression CreateLeq(Expression e1, Expression e2, int lineno=0)
        {
            return new Leq(e1, e2);
        }

        public static Expression CreateComp(Expression e, int lineno=0)
        {
            return new Comp(e, lineno);
        }

        public static Expression CreateIntConst(Symbol token, int lineno=0)
        {
            return new IntConst(token, lineno);
        }

        public static Expression CreateBoolConst(bool val, int lineno=0)
        {
            return new BoolConst(val, lineno);
        }

        public static Expression CreateStringConst(Symbol token, int lineno=0)
        {
            return new StringConst(token, lineno);
        }

        public static Expression CreateNew(Symbol type_name, int lineno=0)
        {
            return new New(type_name, lineno);
        }

        public static Expression CreateIsVoid(Expression e, int lineno=0)
        {
            return new IsVoid(e, lineno);
        }

        public static Expression CreateNoExpr(int lineno = 0)
        {
            return new NoExpr(lineno);
        }

        public static Expression CreateObject(Symbol name, int lineno=0)
        {
            return new Object(name, lineno);
        }

    }

}
