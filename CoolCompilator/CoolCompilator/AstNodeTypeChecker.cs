using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCompilator
{


    public class AstNodeTypeChecker : AstNodeVisitor
    {

        SymbolTable<Symbol, Symbol> env = new SymbolTable<Symbol, Symbol>(); // used to verify scoping rules
        Symbol curr_class; // current class that's being type checked
        Dictionary<Symbol, Dictionary<Symbol, List<Symbol>>> mtbl = new Dictionary<Symbol, Dictionary<Symbol, List<Symbol>>>();// mapping of [class name][method name] -> param_type0 ... param_typeN, return type

        public int err_count { get; set; }
        public Dictionary<Class, Class> inherit_graph { get; set; }

        public AstNodeTypeChecker(Dictionary<Class, Class> ig)
        {
            this.inherit_graph = ig;
            err_count = 0;
        }



        public void error(AstNode node, string msg)
        {
            Utility.print_error(node, msg);
            ++err_count;
        }

        bool is_subtype(Symbol child, Symbol parent)
        {
            if (child == Constants.NOTYPE || child == parent) return true;
            if (child == Constants.OBJECT) return false;

            // SELF_TYPE hasn't been implemented yet so this will turn off type check
            // for methods that return SELF_TYPE
            if (child == Constants.SELF_TYPE || parent == Constants.SELF_TYPE) return true;

            // find @child's pointer to class
            Class child_cptr = null;
            foreach (var item in inherit_graph)
            {
                if (item.Key.name.value == child.value)
                {
                    child_cptr = item.Key;
                    break;
                }
            }

            // this simply checks if parent is encountered anywhere in 
            // child's inheritance tree
            Class curr = child_cptr;
            while (curr.name != Constants.OBJECT)
            {
                if (curr.name == parent)
                    return true;

                curr = inherit_graph[curr];
            }

            return false;
        }

        Symbol lub(Symbol[] types)
        {
            Symbol basse = types[0];

            if (types.All((x) => x.Equals(basse)))
                return basse;



            Class base_ptr = null;
            foreach (var item in inherit_graph)
            {
                if (item.Key.name == basse)
                {
                    base_ptr = item.Key;
                    break;
                }
            }



            Class curr = base_ptr;

            while (curr.parent != Constants.OBJECT)
            {
                Symbol result = null;

                foreach (var item in types)
                {
                    if (!is_subtype(item, curr.parent))
                    {
                        result = item;
                        break;
                    }
                }

                if (result == null)
                    return curr.parent;

                curr = inherit_graph[curr];
            }

            return Constants.OBJECT;
        }

        public override void visit(Program prog)
        {
            // populate method table with [class][method] -> argument types, return type
            foreach (var cs in prog.classes)
            {
                Symbol cl = cs.name;
                Class curr = cs;

                while (curr.name != Constants.NOCLASS)
                {
                    foreach (var method in curr.methods)
                    {
                        // if an overriden method already exists, don't add anymore
                        if (!mtbl[cl].ContainsKey(method.name))
                        {
                            foreach (var formal in method.paramms)
                                mtbl[cl][method.name].Add(formal.type_decl);

                            mtbl[cl][method.name].Add(method.return_type);
                        }
                        else
                        {
                            // if there is an overriden version of this method, type check
                            // to ensure that the signature including return type is exactly same 

                            // have to subtract 1 from mtbl because the last element is the return type (ie. it has one extra element)
                            bool cond = true;

                            for (int i = 0; i < method.paramms.Length; i++)
                            {
                                if (method.paramms[i].type_decl != mtbl[cl][method.name][i])
                                {
                                    cond = false;
                                    break;
                                }
                            }


                            if (method.paramms.Length != mtbl[cl][method.name].Count - 1 || cond)

                            {
                                string msg = "overriden method " + curr.name + "." + method.name + " has different parameters from " + cl + "." + method.name;
                                error(method, msg);
                            }

                            if (method.return_type != mtbl[cl][method.name][mtbl[cl][method.name].Count - 1])
                            {
                                string msg = "overriden method " + curr.name + "." + method.name + " has different return type from " + cl + "." + method.name;
                                error(method, msg);
                            }
                        }
                    }

                    curr = inherit_graph[curr];
                }
            }

            foreach (var cs in prog.classes)
                cs.accept(this);
        }

        public override void visit(Class cs)
        {
            env.enter_scope();
            curr_class = cs.name;
            env.add(Constants.SELF, curr_class);

            Class cptr = null;

            foreach (var item in inherit_graph)
            {
                if (item.Key.name == cs.parent)
                {
                    cptr = item.Key;
                    break;
                }
            }


            if (cptr != null)
            {

                while (cptr.name != Constants.NOCLASS)
                {
                    foreach (var attrib in cptr.attributes)
                    {
                        if (env.probe(attrib.name) != null)
                            error(attrib, "attribute " + attrib.name.value + " redefined in one of its subclasses");
                        else
                            env.add(attrib.name, attrib.type_decl);
                    }

                    cptr = inherit_graph[cptr];
                }
            }

            foreach (var attrib in cs.attributes)
                attrib.accept(this);

            foreach (var method in cs.methods)
                method.accept(this);

            env.exit_scope();
        }

        public override void visit(Attribute attr)
        {
            env.add(attr.name, attr.type_decl);
            attr.init.accept(this);

            if (attr.init.type != Constants.NOTYPE)
                if (!is_subtype(attr.init.type, attr.type_decl))
                    error(attr, "type of attribute initializer not a subtype of declared type");
        }

        public override void visit(Method method)
        {
            env.enter_scope();

            foreach (var formals in method.paramms)
                env.add(formals.name, formals.type_decl);

            method.body.accept(this);

            if (!is_subtype(method.body.type, method.return_type))
                error(method, "method body type not a subtype of return type");

            env.exit_scope();
        }

        public override void visit(Formal f)
        {

        }

        public override void visit(StringConst snode)
        {
            snode.type = Constants.STRING;
        }

        public override void visit(IntConst inode)
        {
            inode.type = Constants.INTEGER;
        }

        public override void visit(BoolConst boolean)
        {
            boolean.type = Constants.BOOLEAN;
        }

        public override void visit(New nnode)
        {
            nnode.type = nnode.type_decl;
        }

        public override void visit(IsVoid isvoid)
        {
            isvoid.expr.accept(this);
            isvoid.type = Constants.BOOLEAN;

            if (isvoid.expr.type == Constants.OBJECT)
            {
                error(isvoid, "isvoid expression doesn't evaluate to type Bool");
                isvoid.type = Constants.OBJECT;
            }
        }

        public override void visit(CaseBranch br)
        {
            br.expr.accept(this);
            br.type = br.expr.type;
        }

        public override void visit(Assign assign)
        {
            //optional
            Symbol obj_type = env.lookup(assign.name);
            assign.type = Constants.OBJECT;

            if (obj_type == null)
                error(assign, "variable " + assign.name.value + " not in scope");

            assign.rhs.accept(this);

            if (is_subtype(assign.rhs.type, obj_type))
            {
                if (obj_type != null)
                    assign.type = assign.rhs.type;
            }
            else
            {
                error(assign, "type of RHS not a subtype of variable type");
            }
        }

        public override void visit(Block block)
        {
            foreach (var expr in block.body)
                expr.accept(this);

            block.type = block.body[block.body.Length - 1].type;
        }

        public override void visit(If ifstmt)
        {
            ifstmt.predicate.accept(this);

            if (ifstmt.predicate.type != Constants.BOOLEAN)
                error(ifstmt, "predicate doesn't evaluate to type Bool");

            ifstmt.iftrue.accept(this);
            ifstmt.iffalse.accept(this);

            ifstmt.type = lub(new Symbol[] { ifstmt.iftrue.type, ifstmt.iffalse.type });
        }

        public override void visit(While wstmt)
        {
            wstmt.predicate.accept(this);

            if (wstmt.predicate.type != Constants.BOOLEAN)
                error(wstmt, "predicate doesn't evaluate to type Bool");

            wstmt.body.accept(this);
            wstmt.type = Constants.OBJECT;
        }

        public override void visit(Complement cmpl)
        {
            cmpl.expr.accept(this);
            cmpl.type = Constants.INTEGER;

            if (cmpl.expr.type != Constants.INTEGER)
            {
                error(cmpl, "RHS of expression must evaluate to type Int");
                cmpl.type = Constants.OBJECT;
            }
        }

        public override void visit(LessThan lt)
        {
            lt.lhs.accept(this);
            lt.rhs.accept(this);
            lt.type = Constants.BOOLEAN;

            if (lt.lhs.type != Constants.INTEGER || lt.rhs.type != Constants.INTEGER)
            {
                error(lt, "LHS or RHS of comparison operator not of type Int");
                lt.type = Constants.OBJECT;
            }
        }

        public override void visit(EqualTo eq)
        {
            eq.lhs.accept(this);
            eq.rhs.accept(this);
            eq.type = Constants.BOOLEAN;

            Symbol lhs_type = eq.lhs.type;
            Symbol rhs_type = eq.rhs.type;

            if (lhs_type == Constants.INTEGER || lhs_type == Constants.BOOLEAN || lhs_type == Constants.STRING ||
                rhs_type == Constants.INTEGER || rhs_type == Constants.BOOLEAN || rhs_type == Constants.STRING)
            {
                if (lhs_type != rhs_type)
                {
                    error(eq, "comparison of primitives Int, Bool, and String must be of same type");
                    eq.type = Constants.OBJECT;
                }
            }
        }

        public override void visit(LessThanEqualTo lte)
        {
            lte.lhs.accept(this);
            lte.rhs.accept(this);
            lte.type = Constants.BOOLEAN;

            if (lte.lhs.type != Constants.INTEGER || lte.rhs.type != Constants.INTEGER)
            {
                error(lte, "LHS or RHS of comparison operator not of type Int");
                lte.type = Constants.OBJECT;
            }
        }

        public override void visit(Plus plus)
        {
            plus.lhs.accept(this);
            plus.rhs.accept(this);
            plus.type = Constants.INTEGER;

            if (plus.lhs.type != Constants.INTEGER || plus.rhs.type != Constants.INTEGER)
            {
                error(plus, "operands of arithmetic expression not of type Int");
                plus.type = Constants.OBJECT;
            }
        }

        public override void visit(Sub sub)
        {
            sub.lhs.accept(this);
            sub.rhs.accept(this);
            sub.type = Constants.INTEGER;

            if (sub.lhs.type != Constants.INTEGER || sub.rhs.type != Constants.INTEGER)
            {
                error(sub, "operands of arithmetic expression not of type Int");
                sub.type = Constants.OBJECT;
            }
        }

        public override void visit(Mul mul)
        {
            mul.lhs.accept(this);
            mul.rhs.accept(this);
            mul.type = Constants.INTEGER;

            if (mul.lhs.type != Constants.INTEGER || mul.rhs.type != Constants.INTEGER)
            {
                error(mul, "operands of arithmetic expression not of type Int");
                mul.type = Constants.OBJECT;
            }
        }

        public override void visit(Div div)
        {
            div.lhs.accept(this);
            div.rhs.accept(this);
            div.type = Constants.INTEGER;

            if (div.lhs.type != Constants.INTEGER || div.rhs.type != Constants.INTEGER)
            {
                error(div, "operands of arithmetic expression not of type Int");
                div.type = Constants.OBJECT;
            }
        }

        public override void visit(Not nt)
        {
            nt.expr.accept(this);
            nt.type = Constants.BOOLEAN;

            if (nt.expr.type != Constants.BOOLEAN)
            {
                error(nt, "not expression does not evaluate to Bool");
                nt.type = Constants.OBJECT;
            }
        }

        public override void visit(StaticDispatch stat)
        {
            List<Symbol> disptypes = new List<Symbol>();

            // get type of object that dispatches
            stat.obj.accept(this);
            Symbol obj_type = stat.obj.type;

            // get types of all arguments to dispatch
            foreach (var expr in stat.actual)
            {
                expr.accept(this);
                disptypes.Add(expr.type);
            }

            bool statsub = is_subtype(obj_type, stat.type_decl);

            if (!statsub)
            {
                error(stat, "dispatch object type not a subtype of static dispatch type");
                stat.type = Constants.OBJECT;
            }

            // check if each dispatch argument's type is a subtype of declared type for method

            bool result = true;

            for (int i = 0; i < disptypes.Count; i++)
            {
                if (!is_subtype(disptypes[i], mtbl[obj_type][stat.method][i]))
                {
                    result = false;
                    break;
                }

            }

            if (result)
            {
                if (statsub)
                {
                    int length = mtbl[stat.type_decl][stat.method].Count;
                    stat.type = mtbl[stat.type_decl][stat.method][length - 1];
                }
            }
            else
            {
                error(stat, "type mismatch in one of the arguments of the dispatch");
                stat.type = Constants.OBJECT;
            }
        }

        public override void visit(DynamicDispatch dyn)
        {
            List<Symbol> disptypes = new List<Symbol>();

            // get type of object that dispatches
            dyn.obj.accept(this);
            Symbol obj_type = dyn.obj.type;

            // get types of all arguments to dispatch
            foreach (var expr in dyn.actual)
            {
                expr.accept(this);
                disptypes.Add(expr.type);
            }

            if (obj_type == curr_class)
                obj_type = curr_class;

            if (!mtbl[obj_type].ContainsKey(dyn.method))
            {
                error(dyn, "method " + dyn.method.value + " is not defined in this class");
                dyn.type = Constants.OBJECT;
                return;
            }

            bool result = true;

            for (int i = 0; i < disptypes.Count; i++)
            {
                if (!is_subtype(disptypes[i], mtbl[obj_type][dyn.method][i]))
                {
                    result = false;
                    break;
                }

            }

            if (result)
            {
                int length = mtbl[obj_type][dyn.method].Count;
                dyn.type = mtbl[obj_type][dyn.method][length - 1];
            }
            else
            {
                error(dyn, "type mismatch in one of the arguments of the dispatch");
                dyn.type = Constants.OBJECT;
            }
        }

        public override void visit(Let let)
        {
            let.type = Constants.OBJECT;
            let.init.accept(this);

            bool type_status = true;

            if (let.init.type != Constants.NOTYPE)
            {
                type_status = is_subtype(let.init.type, let.type_decl);
                if (!type_status)
                    error(let, "initialization of " + let.name.value + " not a subtype of declared type");
            }

            env.enter_scope();
            env.add(let.name, let.type_decl);
            let.body.accept(this);

            if (type_status)
                let.type = let.body.type;

            env.exit_scope();
        }

        public override void visit(Case cs)
        {
            cs.expr.accept(this);

            List<Symbol> types = new List<Symbol>();

            foreach (var br in cs.branches)
            {
                env.enter_scope();
                env.add(br.name, br.type_decl);
                br.accept(this);
                types.Add(br.type);
                env.exit_scope();
            }

            cs.type = lub(types.ToArray());
        }

        public override void visit(Object var)
        {
            //optioanla
            var obj_type = env.lookup(var.name);
            var.type = Constants.OBJECT;

            if (obj_type != null)
                var.type = obj_type;
            else
                error(var, "variable " + var.name.value + " not in scope");
        }

        public override void visit(NoExpr ne)
        {
            ne.type = Constants.NOTYPE;
        }


    }
}
