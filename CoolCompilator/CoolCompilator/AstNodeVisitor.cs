using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCompilator
{

    public abstract class AstNodeVisitor
    {
        public abstract void visit(Program program);
        public abstract void visit(Class clas);
        public abstract void visit(Attribute attribute);
        public abstract void visit(Method method);
        public abstract void visit(Formal formal);
        public abstract void visit(StringConst stringConst);
        public abstract void visit(IntConst intConst);
        public abstract void visit(BoolConst boolConst);
        public abstract void visit(New ne);
        public abstract void visit(IsVoid isVoid);
        public abstract void visit(CaseBranch caseBranch);
        public abstract void visit(Assign assign);
        public abstract void visit(Block block);
        public abstract void visit(If i);
        public abstract void visit(While whil);
        public abstract void visit(Complement complement);
        public abstract void visit(LessThan lessThan);
        public abstract void visit(EqualTo equalTo);
        public abstract void visit(LessThanEqualTo lessThanEqualTo);
        public abstract void visit(Plus plus);
        public abstract void visit(Div div);
        public abstract void visit(Sub sub);
        public abstract void visit(Mul mul);
        public abstract void visit(Not not);
        public abstract void visit(StaticDispatch staticDispatch);
        public abstract void visit(DynamicDispatch dynamicDispatch);
        public abstract void visit(Let let);
        public abstract void visit(Case cas);
        public abstract void visit(Object objec);
        public abstract void visit(NoExpr noExpr);
    }

    public class AstNodeDisplayer:AstNodeVisitor
    {
        public enum display_option
        {
            DISPLAYALL,
            DISPLAYBASIC,
            DISPLAYNONBASIC
        };

        public TextWriter sw { get; set; }
        public int depth { get; set; }
        public display_option opt { get; set; }
        public AstNodeDisplayer(TextWriter sw, display_option opt)
        {
            this.sw = sw;
            this.depth = 0;
            this.opt = opt;
        }

        public override void visit(Program program)
        {
            foreach(var cs in program.classes)
            {
                switch (opt)
                {
                    case display_option.DISPLAYALL:
                        cs.accept(this);
                        break;
                    case display_option.DISPLAYBASIC:
                        if (Utility.is_basic_class(cs.name))
                            cs.accept(this);
                        break;
                    case display_option.DISPLAYNONBASIC:
                        if (!Utility.is_basic_class(cs.name))
                            cs.accept(this);
                        break;
                    default:
                        break;
                }

            }
        }

        public override void visit(Class clas)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_class (" + clas.name + ")");

            foreach (var item in clas.attributes)
                item.accept(this);

            foreach (var item in clas.methods)
                item.accept(this);

            depth--;
        }

        public override void visit(Attribute attribute)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_attribute (" + attribute.name + ")");

            attribute.init.accept(this);

            depth--;
        }

        public override void visit(Method method)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_method (" + method.name + ")");

            foreach (var item in method.paramms)
                item.accept(this);

            method.body.accept(this);

            depth--;
        }

        public override void visit(Formal formal)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            sw.WriteLine("_formal (" + formal.name + ")");

        }

        public override void visit(StringConst stringConst)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            sw.WriteLine("_stringconst(" + stringConst.token + ") : " + stringConst.type);

        }

        public override void visit(IntConst intConst)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            sw.WriteLine("_intconst(" + intConst.token + ") : " + intConst.type);
        }

        public override void visit(BoolConst boolConst)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            sw.WriteLine("_boolconst(" + boolConst.value + ") : " + boolConst.type);
        }

        public override void visit(New ne)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            sw.WriteLine("_new (" + ne.type_decl + ") : " + ne.type);
        }

        public override void visit(IsVoid isVoid)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_isvoid : " + isVoid.type);
            isVoid.expr.accept(this);
            depth--;
        }

        public override void visit(CaseBranch caseBranch)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_casebranch ( " + caseBranch.name + ") : " + caseBranch.type);
            caseBranch.expr.accept(this);
            depth--;
        }

        public override void visit(Assign assign)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_assign (" + assign.name + ") : " + assign.type);
            assign.rhs.accept(this);
            depth--;
        }

        public override void visit(Block block)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_block : " + block.type);

            foreach (var item in block.body)
                item.accept(this);
            depth--;
        }

        public override void visit(If ifs)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_if : " + ifs.type);

            ifs.predicate.accept(this);
            ifs.iftrue.accept(this);
            ifs.iffalse.accept(this);
            depth--;
        }

        public override void visit(While whil)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_while : " + whil.type);

            whil.predicate.accept(this);
            whil.body.accept(this);
           
            depth--;
        }

        public override void visit(Complement complement)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_complement : " + complement.type);

            complement.expr.accept(this);

            depth--;
        }

        public override void visit(LessThan lessThan)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_lessthan : " + lessThan.type);

            lessThan.lhs.accept(this);
            lessThan.rhs.accept(this);

            depth--;
        }

        public override void visit(EqualTo equalTo)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_equalto : " + equalTo.type);

            equalTo.lhs.accept(this);
            equalTo.rhs.accept(this);

            depth--;
        }

        public override void visit(LessThanEqualTo lessThanEqualTo)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_lessthanequalto : " + lessThanEqualTo.type);

            lessThanEqualTo.lhs.accept(this);
            lessThanEqualTo.rhs.accept(this);

            depth--;
        }

        public override void visit(Plus plus)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_plus : " + plus.type);

            plus.lhs.accept(this);
            plus.rhs.accept(this);

            depth--;
        }

        public override void visit(Div div)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_div : " + div.type);

            div.lhs.accept(this);
            div.rhs.accept(this);

            depth--;
        }

        public override void visit(Sub sub)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_sub : " + sub.type);

            sub.lhs.accept(this);
            sub.rhs.accept(this);

            depth--;
        }

        public override void visit(Mul mul)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_mul : " + mul.type);

            mul.lhs.accept(this);
            mul.rhs.accept(this);

            depth--;
        }

        public override void visit(Not not)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_not : " + not.type);

            not.expr.accept(this);

            depth--;
        }

        public override void visit(StaticDispatch staticDispatch)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_staticDispach (" + staticDispatch.method + ") : " + staticDispatch.type);

            staticDispatch.obj.accept(this);

            foreach (var item in staticDispatch.actual)
                item.accept(this);
                
            depth--;
        }

        public override void visit(DynamicDispatch dynamicDispatch)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_dynamicDispach (" + dynamicDispatch.method + ") : " + dynamicDispatch.type);

            dynamicDispatch.obj.accept(this);

            foreach (var item in dynamicDispatch.actual)
                item.accept(this);

            depth--;
        }

        public override void visit(Let let)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_let (" + let.name + ") : " + let.type);

            let.init.accept(this);
            let.body.accept(this);

            depth--;
        }

        public override void visit(Case cas)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            depth++;
            sw.WriteLine("_staticDispach : " + cas.type);

            cas.expr.accept(this);

            foreach (var item in cas.branches)
                item.accept(this);

            depth--;
        }

        public override void visit(Object objec)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            sw.WriteLine("_object (" + objec.name + ") : " + objec.type);

        }

        public override void visit(NoExpr noExpr)
        {
            for (int i = 0; i < depth * 2; i++)
                sw.Write(" ");
            sw.WriteLine("_noexpr : " + noExpr.type);
        }
    }
}
