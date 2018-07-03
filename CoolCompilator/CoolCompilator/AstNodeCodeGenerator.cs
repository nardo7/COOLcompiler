using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CoolCompilator
{

    public class AstNodeCodeGenerator : AstNodeVisitor
    {
        public static Program ast_root;

        const int STR_CLASS_TAG = 5;
        const int INT_CLASS_TAG = 6;
        const int BOOL_CLASS_TAG = 7;

        const int STR_CONST_BASE = 4;
        const int INT_CONST_SIZE = 4;
        const int BOOL_CONST_SIZE = 4;

        const int WORD_SIZE = 4;
        const int OBJECT_HEADER_SIZE = 3;

        const int AR_BASE_SIZE = 3;

        Dictionary<Class, Class> inherit_graph;
        StreamWriter sw;

        int curr_attr_count;

        Symbol curr_class;

        SymbolTable<Symbol, int> var_env=new SymbolTable<Symbol, int>();

        Dictionary<string, Dictionary<string, int>> method_tbl=new Dictionary<string, Dictionary<string, int>>();

        Dictionary<string, Dictionary<string, int>> attr_tbl=new Dictionary<string, Dictionary<string, int>>();

        int while_count;

        int if_count;

        public AstNodeCodeGenerator(Dictionary<Class, Class> ig, StreamWriter sw)
        {
            this.inherit_graph = ig;
            this.sw = sw;
            this.curr_attr_count = this.if_count = this.while_count = 0;
        }

        public void emit_addiu(string dst, string src1, int imm)
        {
            sw.WriteLine("\taddiu\t$" + dst + ", $" + src1 + ", " + imm);
        }
        public void emit_addi(string dst, string src1, int imm)
        {
            sw.WriteLine("\taddi\t$" + dst + ", $" + src1 + ", " + imm);
        }
        public void emit_add(string dst, string src1, string src2)
        {
            sw.WriteLine("\tadd\t$" + dst + ", $" + src1 + ", $" + src2);
        }
        public void emit_div(string dst, string src1, string src2)
        {
            sw.WriteLine("\tdiv\t$" + dst + ", $" + src1 + ", $" + src2);
        }
        public void emit_divu(string dst, string src1, string src2)
        {
            sw.WriteLine("\tdivu\t$" + dst + ", $" + src1 + ", $" + src2);
        }
        public void emit_mul(string dst, string src1, string src2)
        {
            sw.WriteLine("\tmul\t$" + dst + ", $" + src1 + ", $" + src2);
        }
        public void emit_sub(string dst, string src1, string src2)
        {
            sw.WriteLine("\tmul\t$" + dst + ", $" + src1 + ", $" + src2);
        }
        public void emit_and(string dst, string src1, string src2)
        {
            sw.WriteLine("\tand\t$" + dst + ", $" + src1 + ", $" + src2);
        }
        public void emit_not(string dst, string src)
        {
            sw.WriteLine("\tnot\t$" + dst + ", $" + src);
        }
        public void emit_or(string dst, string src1, string src2)
        {
            sw.WriteLine("\tor\t$" + dst + ", $" + src1 + ", $" + src2);
        }
        public void emit_xor(string dst, string src1, string src2)
        {
            sw.WriteLine("\txor\t$" + dst + ", $" + src1 + ", $" + src2);
        }
        public void emit_li(string dst, int imm)
        {
            sw.WriteLine("\tli\t$" + dst + ", " + imm);
        }
        public void emit_lui(string dst, int imm)
        {
            sw.WriteLine("\tlui\t$" + dst + ", " + imm);
        }
        public void emit_seq(string dst, string src1, string src2)
        {
            sw.WriteLine("\tseq\t$" + dst + ", $" + src1 + ", $" + src2);
        }
        public void emit_seq(string dst, string src1, int imm)
        {
            sw.WriteLine("\tseq\t$" + dst + ", $" + src1 + ", " + imm);
        }
        public void emit_sge(string dst, string src1, string src2)
        {
            sw.WriteLine("\tsge\t$" + dst + ", $" + src1 + ", $" + src2);
        }
        public void emit_sge(string dst, string src1, int imm)
        {
            sw.WriteLine("\tsge\t$" + dst + ", $" + src1 + ", " + imm);
        }
        public void emit_sgt(string dst, string src1, string src2)
        {
            sw.WriteLine("\tsgt\t$" + dst + ", $" + src1 + ", $" + src2);
        }
        public void emit_sgt(string dst, string src1, int imm)
        {
            sw.WriteLine("\tsgt\t$" + dst + ", $" + src1 + ", " + imm);
        }
        public void emit_sle(string dst, string src1, string src2)
        {
            sw.WriteLine("\tsle\t$" + dst + ", $" + src1 + ", $" + src2);
        }
        public void emit_sle(string dst, string src1, int imm)
        {
            sw.WriteLine("\tsle\t$" + dst + ", $" + src1 + ", " + imm);
        }
        public void emit_sne(string dst, string src1, string src2)
        {
            sw.WriteLine("\tsne\t$" + dst + ", $" + src1 + ", $" + src2);
        }
        public void emit_sne(string dst, string src1, int imm)
        {
            sw.WriteLine("\tsne\t$" + dst + ", $" + src1 + ", " + imm);
        }
        public void emit_b(string label)
        {
            sw.WriteLine("\tb\t$" + label);
        }
        public void emit_beq(string src1, string src2, string label)
        {
            sw.WriteLine("\tbqe\t$" + src1 + ", $" + src2 + ", " + label);
        }
        public void emit_beq(string src1, int imm, string label)
        {
            sw.WriteLine("\tbqe\t$" + src1 + ", " + imm + ", " + label);
        }
        public void emit_bge(string src1, string src2, string label)
        {
            sw.WriteLine("\tbge\t$" + src1 + ", $" + src2 + ", " + label);
        }
        public void emit_bge(string src1, int imm, string label)
        {
            sw.WriteLine("\tbge\t$" + src1 + ", " + imm + ", " + label);
        }
        public void emit_bne(string src1, string src2, string label)
        {
            sw.WriteLine("\tbne\t$" + src1 + ", $" + src2 + ", " + label);
        }
        public void emit_bne(string src1, int imm, string label)
        {
            sw.WriteLine("\tbne\t$" + src1 + ", " + imm + ", " + label);
        }
        public void emit_j(string label)
        {
            sw.WriteLine("\tj\t" + label);
        }
        public void emit_jal(string label)
        {
            sw.WriteLine("\tjal\t" + label);
        }
        public void emit_jalr(string src)
        {
            sw.WriteLine("\tjalr\t$" + src);
        }
        public void emit_jr(string src)
        {
            sw.WriteLine("\tjr\t$" + src);
        }
        public void emit_la(string dst, string addr)
        {
            sw.WriteLine("\tla\t$" + dst + ", " + addr);
        }
        public void emit_lb(string dst, string addr)
        {
            sw.WriteLine("\tlb\t$" + dst + ", " + addr);
        }
        public void emit_ld(string dst, string addr)
        {
            sw.WriteLine("\tld\t$" + dst + ", " + addr);
        }
        public void emit_lw(string dst, int offset, string src)
        {
            sw.WriteLine("\tlw\t$" + dst + ", " + offset + "($" + src + ")");
        }
        public void emit_sb(string dst, string addr)
        {
            sw.WriteLine("\tsb\t$" + dst + ", " + addr);
        }
        public void emit_sd(string dst, string addr)
        {
            sw.WriteLine("\tsd\t$" + dst + ", " + addr);
        }
        public void emit_sw(string dst, int offset, string src)
        {
            sw.WriteLine("\tsw\t$" + dst + ", " + offset + "($" + src + ")");
        }
        public void emit_move(string dst, string src)
        {
            sw.WriteLine("\tmove\t$" + dst + ", $" + src);
        }
        public void emit_syscall()
        {
            sw.WriteLine("\tsyscall\t");
        }
        public void emit_nop()
        {
            sw.WriteLine("\tnop\t");
        }
        public void emit_align(int boundary)
        {
            sw.WriteLine("\t.align\t" + boundary);
        }
        public void emit_ascii(string str)
        {
            sw.WriteLine("\t.ascii\t" + "\"" + str + "\"");
        }
        public void emit_asciiz(string str)
        {
            sw.WriteLine("\t.asciiz\t" + "\"" + str + "\"");
        }
        public void emit_byte(int val)
        {
            sw.WriteLine("\t.byte\t" + val);
        }
        public void emit_global(string symbol)
        {
            sw.WriteLine("\t.global\t" + symbol);
        }
        public void emit_word(string sym)
        {
            sw.WriteLine("\t.word\t" + sym);
        }
        public void emit_word(int val)
        {
            sw.WriteLine("\t.word\t" + val);
        }
        public void emit_label(string label)
        {
            sw.WriteLine("label:" + label);
        }
        public void emit_push(int num_word)
        {
            emit_addiu("sp", "sp", WORD_SIZE * -num_word);
        }
        public void emit_pop(int num_bytes)
        {
            emit_addiu("sp", "sp", WORD_SIZE * num_bytes);
        }
        public void code_constants()
        {

            foreach (var p in inherit_graph)
                tables.stringtable.add(p.Key.name.value);

            var str_consts = tables.stringtable.tbl;

            tables.stringtable.add("");

            foreach (var it in str_consts)
            {
                Console.Write("str_const");
                emit_label((tables.stringtable.get_idx(it.Key)).ToString());
                emit_word(STR_CLASS_TAG);

                emit_word(STR_CONST_BASE + Math.Ceiling(it.Key.Length / 4.0).ToString());
                emit_word("String_disptable");
                emit_word(it.Key.Length);
                emit_asciiz(it.Key);
                emit_align(2);

            }

            var int_consts = tables.inttable.tbl;

            foreach (var it in int_consts)
            {
                Console.Write("int_consts");
                emit_label((tables.inttable.get_idx(it.Key)).ToString());
                emit_word(INT_CLASS_TAG);
                emit_word(INT_CONST_SIZE);
                emit_word("Int_disptable");

                int repr = int.Parse(it.Key);
                emit_word(repr);
            }


            emit_label("bool_const0");
            emit_word(BOOL_CLASS_TAG);
            emit_word(BOOL_CONST_SIZE);
            emit_word("Bool_disptable");
            emit_word(0);

            emit_label("bool_const1");
            emit_word(BOOL_CLASS_TAG);
            emit_word(BOOL_CONST_SIZE);
            emit_word("Bool_disptable");
            emit_word(1);
        }
        public void code_dispatch_table(Class class_node)
        {
            Dictionary<Symbol, Symbol> mnames = new Dictionary<Symbol, Symbol>();
            Stack<Class> recur = new Stack<Class>();

            Class cptr = class_node;

            while (cptr.name != Constants.NOCLASS)
            {
                recur.Push(cptr);

                foreach (var method in cptr.methods)
                {
                    if (!mnames.ContainsValue(method.name))
                        mnames.Add(method.name, cptr.name);
                }

                cptr = inherit_graph[cptr];
            }

            int dispoffset = 0;


            while (recur.Count != 0)
            {
                Class head = recur.Peek();


                foreach (var method in head.methods)
                {
                    if (mnames.ContainsKey(method.name))
                    {
                        if (!method_tbl.ContainsKey(class_node.name.value))
                            method_tbl.Add(class_node.name.value, new Dictionary<string, int>());
                        dispoffset += 1;
                        if (method_tbl[class_node.name.value].ContainsKey(method.name.value))
                            continue;
                        method_tbl[class_node.name.value].Add(method.name.value, dispoffset);
                        //method_tbl[class_node.name][method.name] = dispoffset++;
                        emit_word(mnames[method.name].value + "." + method.name.value);
                        mnames.Remove(method.name);
                    }
                }

                recur.Pop();
            }
        }
        public int calc_obj_size(Class class_node)
        {
            int total = 0;
            Class curr_class = class_node;

            while (curr_class.name != Constants.NOCLASS)
            {
                total += curr_class.attributes.Length;
                curr_class = inherit_graph[curr_class];
            }

            return total;
        }
        public void emit_obj_attribs(Class class_node)
        {
            if (class_node.name == Constants.NOCLASS)
                return;

            emit_obj_attribs(inherit_graph[class_node]);

            foreach (var attrib in class_node.attributes)
                emit_word(0);
        }

        public void code_prototype_objects()
        {
            int classtag = 1;

            foreach (var p in inherit_graph)
            {
                if (p.Key.name == Constants.NOCLASS)
                    continue;

                emit_label(p.Key.name.value + "_prototype");

                if (p.Key.name == Constants.STRING)
                    emit_word(STR_CLASS_TAG);
                else if (p.Key.name == Constants.INTEGER)
                    emit_word(INT_CLASS_TAG);
                else if (p.Key.name == Constants.BOOLEAN)
                    emit_word(BOOL_CLASS_TAG);
                else
                    emit_word(classtag++);

                emit_word(OBJECT_HEADER_SIZE + calc_obj_size(p.Key));
                emit_word(p.Key.name.value + "_disptable");
                emit_obj_attribs(p.Key);
            }
        }

        public void emit_initial_data()
        {
            sw.WriteLine(".data");
            sw.WriteLine("\t.align\t2");
            sw.WriteLine("\t.globl\tMain_prototype");
            sw.WriteLine("\t.globl\tMain_init");
            sw.WriteLine("\t.globl\tMain_init");
            sw.WriteLine("\t.globl\tMain.main");
            sw.WriteLine("\t.globl\tbool_const0");
            sw.WriteLine("\t.globl\tbool_const1");
            sw.WriteLine("\t.globl\t__int_tag");
            sw.WriteLine("\t.globl\t__bool_tag");
            sw.WriteLine("\t.globl\t__string_tag");
            sw.WriteLine("__int_tag:");
            sw.WriteLine("\t.word\t" + INT_CLASS_TAG);
            sw.WriteLine("__bool_tag:");
            sw.WriteLine("\t.word\t" + BOOL_CLASS_TAG);
            sw.WriteLine("__string_tag:");
            sw.WriteLine("\t.word\t" + STR_CLASS_TAG);
        }

        public override void visit(Program prog)
        {
            emit_initial_data();
            code_constants();

            foreach (var p in inherit_graph)
            {
                if (p.Key.name != Constants.NOCLASS)
                {
                    emit_label(p.Key.name.value + "_disptable");
                    code_dispatch_table(p.Key);
                }
            }

            code_prototype_objects();

            sw.WriteLine(".text");

            foreach (var cs in prog.classes)
                cs.accept(this);
        }

        public override void visit(Class cs)
        {
            var_env.enter_scope();
            curr_class = cs.name;
            emit_label(cs.name.value + "_init");
            emit_push(AR_BASE_SIZE);

            emit_sw("fp", 12, "sp");
            emit_sw("s0", 8, "sp");
            emit_sw("ra", 4, "sp");
            emit_addiu("fp", "sp", 4);
            emit_move("s0", "a0");

            if (cs.name != Constants.OBJECT)
                emit_jal(cs.parent.value + "_init");

            foreach (var attrib in cs.attributes)
                attrib.accept(this);

            emit_move("a0", "s0");
            emit_lw("fp", 12, "sp");
            emit_lw("s0", 8, "sp");
            emit_lw("ra", 4, "sp");
            emit_pop(AR_BASE_SIZE);
            emit_jr("ra");

            curr_attr_count = 0;

            foreach (var method in cs.methods)
                method.accept(this);

            var_env.exit_scope();
        }
        public override void visit(Attribute attr)
        {
            attr.init.accept(this);

            ++curr_attr_count;
            if (!attr_tbl.ContainsKey(curr_class.value))
                attr_tbl.Add(curr_class.value, new Dictionary<string, int>());
            attr_tbl[curr_class.value].Add(attr.name.value, curr_attr_count);
            //attr_tbl[curr_class][attr.name] = curr_attr_count;

            if (attr.type_decl != Constants.PRIM_SLOT)
                emit_sw("a0", WORD_SIZE * (curr_attr_count + 2), "s0");
        }

        public override void visit(Formal f)
        {

        }

        public override void visit(Method method)
        {
            if (Utility.is_basic_class(curr_class))
                return;

            var_env.enter_scope();
            emit_label(curr_class.value + "." + method.name.value);

            emit_sw("ra", 4, "sp");

            int curr_offset = 1;

            foreach (var formal in method.paramms)
                var_env.add(formal.name, curr_offset++);

            method.body.accept(this);

            int ar_size = AR_BASE_SIZE + method.paramms.Length;
            emit_lw("fp", ar_size * WORD_SIZE, "sp");
            emit_lw("s0", ar_size * WORD_SIZE - WORD_SIZE, "sp");
            emit_lw("ra", 4, "sp");
            emit_pop(AR_BASE_SIZE + method.paramms.Length);
            emit_jr("ra");

            var_env.exit_scope();
        }

        public override void visit(StringConst str)
        {
            emit_la("a0", "str_const" + tables.stringtable.get_idx(str.token.value).ToString());
        }

        public override void visit(IntConst int_const)
        {
            emit_la("a0", "int_const" + tables.inttable.get_idx(int_const.token.value).ToString());
        }

        public override void visit(BoolConst bool_const)
        {
            if (bool_const.value)
                emit_la("a0", "bool_const1");
            else
                emit_la("a0", "bool_const0");
        }

        public override void visit(New new_node)
        {
            emit_la("a0", new_node.type.value + "_prototype");
            emit_jal("Object.copy");
            emit_jal(new_node.type.value + "_init");
        }

        public override void visit(IsVoid isvoid)
        {
            isvoid.expr.accept(this);
            emit_jal("isvoid");
        }

        public override void visit(CaseBranch branch)
        {
            branch.expr.accept(this);
        }

        public override void visit(Assign assign)
        {
            assign.rhs.accept(this);
            var offset = var_env.lookup(assign.name);

            // result of evaluating rhs of assignment
            // is expected to be in register $a0
            // also note that offset is not checked for null
            // because the semantic analyzer should've caught
            // any variable misuse by this point
            emit_sw("a0", offset, "fp");
        }

        public override void visit(Block block)
        {
            foreach (var expr in block.body)
                expr.accept(this);
        }

        public override void visit(If ifstmt)
        {
            ++if_count;
           // std::string ifcnt(if_count.ToString());

            ifstmt.predicate.accept(this);

            emit_la("t1", "bool_const1");
            emit_beq("a0", "t1", "iftrue" + if_count.ToString());
            ifstmt.iffalse.accept(this);
            emit_b("ifend" + if_count.ToString());

            emit_label("iftrue" + if_count.ToString());
            ifstmt.iftrue.accept(this);

            emit_label("ifend" + if_count.ToString());
        }

        public override void visit(While whilestmt)
        {
            ++while_count;

            emit_label("whileloop" + while_count.ToString());
            whilestmt.predicate.accept(this);
            emit_la("t1", "bool_const1");
            emit_bne("a0", "t1", "whileend" + while_count.ToString());

            whilestmt.body.accept(this);

            emit_b("whileloop" + while_count.ToString());
            emit_label("whileend" + while_count.ToString());
            emit_li("a0", 0);
        }

        public override void visit(Complement comp)
        {
            comp.expr.accept(this);
            emit_lw("t1", 12, "a0");
            emit_not("t1", "t1");
            emit_sw("t1", 12, "a0");
        }

        public override void visit(LessThan lt)
        {
            lt.lhs.accept(this);
            emit_move("a1", "a0");

            lt.rhs.accept(this);
            emit_jal("less");
        }

        public override void visit(LessThanEqualTo lteq)
        {
            lteq.lhs.accept(this);
            emit_move("a1", "a0");

            lteq.rhs.accept(this);
            emit_jal("less_eq");
        }

        public override void visit(EqualTo eq)
        {
            eq.lhs.accept(this);
            emit_move("a1", "a0");

            eq.rhs.accept(this);
            emit_jal("eq");
        }

        public override void visit(Plus plus)
        {
            plus.lhs.accept(this);
            emit_sw("a0", 0, "sp");
            emit_push(1);

            plus.rhs.accept(this);
            emit_jal("Object.copy");
            emit_lw("t1", 4, "sp");
            emit_lw("t1", 12, "t1");
            emit_lw("t2", 12, "v0");
            emit_add("t1", "t1", "t2");
            emit_sw("t1", 12, "a0");
            emit_pop(1);
        }

        public override void visit(Sub sub)
        {
            sub.lhs.accept(this);
            emit_sw("a0", 0, "sp");
            emit_push(1);

            sub.rhs.accept(this);
            emit_jal("Object.copy");
            emit_lw("t1", 4, "sp");
            emit_lw("t1", 12, "t1");
            emit_lw("t2", 12, "v0");
            emit_sub("t1", "t1", "t2");
            emit_sw("t1", 12, "a0");
            emit_pop(1);
        }

        public override void visit(Mul mul)
        {
            mul.lhs.accept(this);
            emit_sw("a0", 0, "sp");
            emit_push(1);

            mul.rhs.accept(this);
            emit_jal("Object.copy");
            emit_lw("t1", 4, "sp");
            emit_lw("t1", 12, "t1");
            emit_lw("t2", 12, "v0");
            emit_mul("t1", "t1", "t2");
            emit_sw("t1", 12, "a0");
            emit_pop(1);
        }

        public override void visit(Div div)
        {
            div.lhs.accept(this);
            emit_sw("a0", 0, "sp");
            emit_push(1);

            div.rhs.accept(this);
            emit_jal("Object.copy");
            emit_lw("t1", 4, "sp");
            emit_lw("t1", 12, "t1");
            emit_lw("t2", 12, "v0");
            emit_div("t1", "t1", "t2");
            emit_sw("t1", 12, "a0");
            emit_pop(1);
        }

        public override void visit(Not nt)
        {
            nt.expr.accept(this);
            emit_jal("lnot");
        }

        public override void visit(StaticDispatch sdisp)
        {
            sdisp.obj.accept(this);
            foreach (var e in sdisp.actual)
                e.accept(this);
        }

        public override void visit(DynamicDispatch ddisp)
        {
            int ar_size = AR_BASE_SIZE + ddisp.actual.Length;

            emit_push(ar_size);
            emit_sw("fp", ar_size * WORD_SIZE, "sp");
            emit_sw("s0", ar_size * WORD_SIZE - WORD_SIZE, "sp");

            int formal_offset = 8;
            foreach (var e in ddisp.actual)
            {
                e.accept(this);
                emit_sw("a0", formal_offset, "sp");
                formal_offset += WORD_SIZE;
            }

            emit_addiu("fp", "sp", 4);

            ddisp.obj.accept(this);
            emit_lw("t1", 8, "a0");
            
            var tmp = method_tbl[ddisp.obj.type.value];
            emit_lw("t1", tmp[ddisp.method.value] * WORD_SIZE, "t1");
            emit_jalr("t1");
        }

        public override void visit(Let let)
        {
            let.init.accept(this);
            let.body.accept(this);
        }

        public override void visit(Case caze)
        {
            caze.expr.accept(this);
            foreach (var br in caze.branches)
                br.accept(this);
        }

        public override void visit(Object obj)
        {
            if (obj.name == Constants.SELF)
            {
                emit_move("a0", "s0");
            }
            else
            {
                var offset = var_env.lookup(obj.name);
                if (offset>0)
                    emit_lw("a0", offset, "fp");
                else
                    emit_lw("a0", WORD_SIZE * (attr_tbl[curr_class.value][obj.name.value] + 2), "s0");
            }
        }

        public override void visit(NoExpr n)
        {

        }

    }
}
