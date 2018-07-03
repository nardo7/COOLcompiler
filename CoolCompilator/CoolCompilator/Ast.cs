using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCompilator
{
    public class AstNode
    {
        public int line_no { get; set; }
        public string file_name { get; set; }
    }

    public class Expression: AstNode
    {
        public Symbol type { get; set; }
        public virtual void accept(AstNodeVisitor visitor)
        { }
    }
    
    public class Attribute:AstNode
    {
        public Symbol name { get; set; }
        public Symbol type_decl { get; set; }
        public Expression init { get; set; }
        public Attribute(Symbol name, Symbol type_decl, Expression init)
        {
            this.name = name;
            this.type_decl = type_decl;
            this.init = init;
            if (init == null)
                this.init = new NoExpr();
        }
        public void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Formal : AstNode
    {
        public Symbol name { get; set; }
        public Symbol type_decl { get; set; }
        public Formal(Symbol name, Symbol type_decl)
        {
            this.name = name;
            this.type_decl = type_decl;
        }
        public void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Method : AstNode
    {
        public Symbol name { get; set; }
        public Symbol return_type { get; set; }
        public Formal[] paramms { get; set; }
        public Expression body { get; set; }
        public Method(Symbol name, Symbol return_type, Formal[] paramms, Expression body)
        {
            this.name = name;
            this.return_type = return_type;
            this.paramms = paramms;
            this.body = body;
        }
        public void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Class: AstNode
    {
        public Symbol name { get; set; }
        public Symbol parent { get; set; }
        public Attribute[] attributes { get; set; }
        public Method[] methods { get; set; }
        public Class(Symbol name, Symbol parent, Attribute[] attributes, Method[] methods)
        {
            this.name = name;
            this.parent = parent;
            this.attributes = attributes;
            this.methods = methods;
        }
        public void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Program : AstNode
    {
        public Class[] classes { get; set; }
        public Program(Class[] classes)
        {
            this.classes = classes;
        }
        public void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class StringConst : Expression
    {
        public Symbol token { get; set; }
        public StringConst(Symbol token)
        {
            this.token = token;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class IntConst : Expression
    {
        public Symbol token { get; set; }
        public IntConst(Symbol token)
        {
            this.token = token;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class BoolConst : Expression
    {
        public bool value { get; set; }
        public BoolConst(bool value)
        {
            this.value = value;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class New : Expression
    {
        public Symbol type_decl { get; set; }
        public New(Symbol type_decl)
        {
            this.type_decl = type_decl;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class IsVoid : Expression
    {
        public Expression expr { get; set; }
        public IsVoid(Expression expr)
        {
            this.expr = expr;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class CaseBranch : Expression
    {
        public Symbol name { get; set; }
        public Symbol type_decl { get; set; }
        public Expression expr { get; set; }
        public CaseBranch(Symbol name, Symbol type_decl, Expression expr)
        {
            this.name = name;
            this.type_decl = type_decl;
            this.expr = expr;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Assign : Expression
    {
        public Symbol name { get; set; }
        public Expression rhs { get; set; }
        public Assign(Symbol name,Expression rhs)
        {
            this.name = name;
            this.rhs = rhs;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Block : Expression
    {
        public Expression[] body { get; set; }
        public Block(Expression[] body)
        {
            this.body = body;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class If : Expression
    {
        public Expression predicate { get; set; }
        public Expression iftrue { get; set; }
        public Expression iffalse { get; set; }
        public If(Expression predicate, Expression iftrue, Expression iffalse)
        {
            this.predicate = predicate;
            this.iftrue = iftrue;
            this.iffalse = iffalse;
            if (iffalse == null)
                this.iffalse = new NoExpr();
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class While : Expression
    {
        public Expression predicate { get; set; }
        public Expression body { get; set; }
        public While(Expression predicate, Expression body)
        {
            this.predicate = predicate;
            this.body = body;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Complement : Expression
    {
        public Expression expr { get; set; }
        public Complement(Expression expr)
        {
            this.expr = expr;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class LessThan : Expression
    {
        public Expression lhs { get; set; }
        public Expression rhs { get; set; }
        public LessThan(Expression lhs, Expression rhs)
        {
            this.lhs = lhs;
            this.rhs = rhs;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }
    public class EqualTo : Expression
    {
        public Expression lhs { get; set; }
        public Expression rhs { get; set; }
        public EqualTo(Expression lhs, Expression rhs)
        {
            this.lhs = lhs;
            this.rhs = rhs;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }
    public class LessThanEqualTo : Expression
    {
        public Expression lhs { get; set; }
        public Expression rhs { get; set; }
        public LessThanEqualTo(Expression lhs, Expression rhs)
        {
            this.lhs = lhs;
            this.rhs = rhs;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Plus : Expression
    {
        public Expression lhs { get; set; }
        public Expression rhs { get; set; }
        public Plus(Expression lhs, Expression rhs)
        {
            this.lhs = lhs;
            this.rhs = rhs;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Sub : Expression
    {
        public Expression lhs { get; set; }
        public Expression rhs { get; set; }
        public Sub(Expression lhs, Expression rhs)
        {
            this.lhs = lhs;
            this.rhs = rhs;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Mul : Expression
    {
        public Expression lhs { get; set; }
        public Expression rhs { get; set; }
        public Mul(Expression lhs, Expression rhs)
        {
            this.lhs = lhs;
            this.rhs = rhs;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }
    public class Div : Expression
    {
        public Expression lhs { get; set; }
        public Expression rhs { get; set; }
        public Div(Expression lhs, Expression rhs)
        {
            this.lhs = lhs;
            this.rhs = rhs;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Not : Expression
    {
        public Expression expr { get; set; }
        public Not(Expression expr)
        {
            this.expr = expr;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class StaticDispatch : Expression
    {
        public Expression obj { get; set; }
        public Symbol type_decl { get; set; }
        public Symbol method { get; set; }
        public Expression[] actual { get; set; }
        public StaticDispatch(Expression obj, Symbol type_decl, Symbol method, Expression[] actual)
        {
            this.obj = obj;
            this.type_decl = type_decl;
            this.method = method;
            this.actual = actual;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class DynamicDispatch : Expression
    {
        public Expression obj { get; set; }
        public Symbol method { get; set; }
        public Expression[] actual { get; set; }
        public DynamicDispatch(Expression obj, Symbol method, Expression[] actual)
        {
            this.obj = obj;
            if (obj == null)
                this.obj = new NoExpr();
            this.method = method;
            this.actual = actual;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Let : Expression
    {
        public Symbol name { get; set; }
        public Symbol type_decl { get; set; }
        public Expression init { get; set; }
        public Expression body { get; set; }
        public Let(Symbol name, Symbol type_decl, Expression init, Expression body)
        {
            this.name = name;
            this.type_decl = type_decl;
            this.init = init;
            if (init == null)
                this.init = new NoExpr();
            this.body = body;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Case : Expression
    {
       
        public Expression expr { get; set; }
        public CaseBranch[] branches { get; set; }
        public Case(Expression expr, CaseBranch[] branches)
        {
            this.expr = expr;
            this.branches = branches;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Object : Expression
    {

        public Symbol name { get; set; }
        public Object(Symbol name)
        {
            this.name = name;
        }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class NoExpr : Expression
    {
        public NoExpr()
        { }
        public override void accept(AstNodeVisitor visitor)
        {
            visitor.visit(this);
        }
    }


}
