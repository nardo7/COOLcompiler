using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPSCodeGenerator
{
    public class CodeGen
    {
        static int DEFAULT_OBJFIELDS = 3;
        static int INT_SLOTS = 1;
        static int STRING_SLOTS = 1;
        static int BOOL_SLOTS = 1;

        static string CLASSINIT_SUFFIX = "_init";
        static string CLASS_PROT_OBJ_TAB = "class_prot_obj_tab";
        static string CLASS_INIT_TAB = "class_init_tab";
        static string CLASS_DIRECT_PARENT_TAB = "class_direct_parent_tab";
        static string SPTop = "4($sp)";
        static string WORD = "\t.word\t";
        static string ASCII = "\t.ascii\t";
        static string ALIGN = "\t.align\t2\n";
        static string GLOBAL = "\t.globl\t";
        static string BOOLCONST_TRUE_REF = "bool_const_true";
        static string BOOLCONST_FALSE_REF = "bool_const_false";
        static string PROTOBJ_SUFFIX = "_protObj";
        static string CLASS_NAME_TAB = "class_nameTab";
        static string CLASS_OBJ_TAB = "class_objTab";
        static string HEAP_START = "heap_start";

        // register names
        static string ZERO = "$zero";        // Zero register 
        static string ACC = "$a0";       // Accumulator 
        static string A1 = "$a1";        // For arguments to prim funcs 
        static string SELF = "$s0";      // Ptr to self (callee saves) 
        static string T1 = "$t1";        // Temporary 1 
        static string T2 = "$t2";        // Temporary 2 
        static string T3 = "$t3";        // Temporary 3 
        static string SP = "$sp";        // Stack pointer 
        static string FP = "$fp";        // Frame pointer 
        static string RA = "$ra";        // Return address 

        // Opcodes
        static string JALR = "\tjalr\t";
        static string JAL = "\tjal\t";
        static string RET = "\tjr\t" + RA + "\t";
        static string SW = "\tsw\t";
        static string LW = "\tlw\t";
        static string LI = "\tli\t";
        static string LA = "\tla\t";
        static string MOVE = "\tmove\t";
        static string NEG = "\tneg\t";
        static string ADD = "\tadd\t";
        static string ADDI = "\taddi\t";
        static string ADDU = "\taddu\t";
        static string ADDIU = "\taddiu\t";
        static string DIV = "\tdiv\t";
        static string MUL = "\tmul\t";
        static string SUB = "\tsub\t";
        static string SLL = "\tsll\t";
        static string BEQZ = "\tbeqz\t";
        static string BRANCH = "\tb\t";
        static string BEQ = "\tbeq\t";
        static string BNE = "\tbne\t";
        static string BLEQ = "\tble\t";
        static string BLT = "\tblt\t";
        static string BGT = "\tbgt\t";
        static int offset = 0;

        public static string[] _gc_init_names = { "_NoGC_Init", "_GenGC_Init", "_ScnGC_Init" };

        public static string[] _gc_collect_names = { "_NoGC_Collect", "_GenGC_Collect", "_ScnGC_Collect" };

        public string _g_filename;

        Program ast_root_;
        InheritanceTree inherit_tree_;
        int tag_cnt_;
        // tag number -> class name
        List<string> tag_to_class_name_ = new List<string>();

        TextWriter str_;

        Dictionary<string, ClassInfo> class_info_tab_ = new Dictionary<string, ClassInfo>();

        #region Classes
        public class ObjectLayout
        {
            public int gc_tag;
            public int class_tag;
            public int object_size; // when we use it we must multiply sizeof(WORD)
            public string dispatch_tab_label;
            public List<string> attr_labels = new List<string>();
        }
        public class ClassInfo
        {
            public string class_name;
            public string parent_name;
            public string label;
            public string tag_name;
            public Class ast_node;
            public ObjectLayout layout = new ObjectLayout();

            // Attributes Info
            public List<Tuple<string, string>> ordered_attrs = new List<Tuple<string, string>>();       // a vector of (attr_name, type) pair
            public Dictionary<string, int> attrs_offset_tab = new Dictionary<string, int>();   // map attr name to its offset

            // Methods Info

            // a vector of method_name that is in order.
            public List<string> ordered_methods = new List<string>();

            // a set of methods including current class defined methods and inherited methods
            public HashSet<string> method_set = new HashSet<string>();

            public Dictionary<string, List<Tuple<string, string>>> method_sig_tab = new Dictionary<string, List<Tuple<string, string>>>(); // method_name -> a vector of (arg_name, arg_type)

            // method_name -> a vector of class_name.method_name,
            // the last element is the method should be called
            public Dictionary<string, List<string>> method_tab = new Dictionary<string, List<string>>();

            // method_name to offset in dispatch table.
            // The offset means the index in this table.
            // When use the offset value in code gen we should times the sizeof(WORD)
            public Dictionary<string, int> methods_offset_tab = new Dictionary<string, int>();

        }
        public class Env
        {
            public string class_name;
            public string filename;
            public Dictionary<string, ClassInfo> class_info_tab = new Dictionary<string, ClassInfo>();
            public int allocated_temp_space; // in byte
            public int next_free_temp_space; // in byte
                                             // id -> reg or addr
            public Scope loc = new Scope();

            public Env(string name, Dictionary<string, ClassInfo> info)
            {
                this.class_name = name;
                this.class_info_tab = info;
                allocated_temp_space = -1;
                next_free_temp_space = -1;
            }

        }
        #endregion
        public string GetProtoObjRef(string name)
        {
            return name + PROTOBJ_SUFFIX;
        }
        public void EmitIntTabEntry(Symbol sym, TextWriter s, int tagno)
        {
            s.WriteLine(WORD + "-1");
            s.WriteLine(sym.ref_ + ":");
            s.WriteLine(WORD + tagno);

            s.WriteLine(WORD + (DEFAULT_OBJFIELDS + INT_SLOTS));
            s.WriteLine(WORD + Helper.GetClassDispatchTabName(new ConstantSymbol().Int.str_));
            s.WriteLine(WORD + sym.str_);
        }
        public void EmitStringTabEntry(Symbol sym, TextWriter s, int tagno)
        {
            int len = sym.str_.Length;
            Symbol len_sym = SymbolUtils.IntTable.AddString(len.ToString());

            s.WriteLine(WORD + "-1");
            s.WriteLine(sym.ref_ + ":");
   
            s.WriteLine(WORD+ tagno);
            s.WriteLine(WORD + (DEFAULT_OBJFIELDS + STRING_SLOTS + (len + 4)));
            s.WriteLine(WORD + Helper.GetClassDispatchTabName(new ConstantSymbol().Str.str_));
            s.WriteLine(WORD + len_sym.ref_);

            EmitStringConstant(s, sym.str_);

            s.WriteLine(ALIGN);
        }
        static int ascii = 0;
        private void byte_mode(TextWriter str)
        {
            if(ascii!=0)
            {
                str.Write("\"");
                ascii = 0;
            }
        }
        private void ascii_mode(TextWriter str)
        {
            if (ascii == 0)
            {
                str.Write("\t.ascii\t\"");
                ascii = 1;
            }
        }
        // With reference to cgen_supp.cc
        public void EmitStringConstant(TextWriter str, string s)
        {

            foreach (var ch in s)
            {
                switch (ch)
                {
                    case '\n':
                        ascii_mode(str);
                        str.Write("\\n");
                        break;

                    case '\t':
                        ascii_mode(str);
                        str.Write("\\t");
                        break;

                    case '\\':
                        byte_mode(str);
                        str.WriteLine();
                        str.WriteLine("\t.byte\t92");
                        break;

                    case '"':
                        ascii_mode(str);
                        str.Write("\\\"");
                        break;

                    default:
                        if (ch >= ' ' && ch < 128)
                        {
                            ascii_mode(str);
                            str.Write(ch);
                        }
                        else
                        {
                            byte_mode(str);
                            str.WriteLine();
                            str.WriteLine("\t.byte\t" + (int)ch);
                        }
                        break;
                }
            }
            byte_mode(str);
            str.WriteLine();
            str.WriteLine("\t.byte\t0\t");
        }

        public CodeGen(Program ast_root, InheritanceTree inherit_tree, TextWriter os)
        {

            this.ast_root_ = ast_root;
            this.inherit_tree_ = inherit_tree;
            this.str_ = os;

            CollectClassInfo();


        }

        public void Generate()
        {
            //var log_flag = helper.g_log_cerr;

            SymbolUtils.IntTable.AddString("0");
            SymbolUtils.StrTable.AddString("");

            this.str_.WriteLine();
            this.str_.WriteLine(" # global data");


            /* if (Helper.g_log_cerr > 0)
             {
                 Console.Error.WriteLine(" # global data ");

             }*/
            EmitGlobalData();

            str_.WriteLine();
            str_.WriteLine(" # choosing gc");
            /*if (Helper.g_log_cerr > 0)
            {
                Console.Error.WriteLine(" # choosing gc");
            }*/
            EmitGCSelect();

            str_.WriteLine();
            str_.WriteLine(" # constants");

            /*if (Helper.g_log_cerr > 0)
            {
                Console.Error.WriteLine(" # constants");
            }*/
            EmitSymbolTabConstants();

            str_.WriteLine();
            str_.WriteLine(" # declare class tag name");

            /*if (Helper.g_log_cerr > 0)
            {
                Console.Error.WriteLine(" # declare class tag name");
            }*/
            EmitClassTagDeclaration();

            str_.WriteLine();
            str_.WriteLine(" # class tag definition");

            /*if (Helper.g_log_cerr > 0)
            {
                Console.Error.WriteLine(" # declare class tag definition");
            }*/
            EmitClassTagDefinition();

            str_.WriteLine();
            str_.WriteLine(" # class name table");
            /* if (Helper.g_log_cerr > 0)
             {
                 Console.Error.WriteLine(" # class name table");
             }*/
            EmitClassNameTab();

            str_.WriteLine();
            str_.WriteLine(" # class dispatch table");

            /*if (Helper.g_log_cerr > 0)
            {
                Console.Error.WriteLine(" # class dispatch table");
            }*/
            EmitClassDispatchTab();

            str_.WriteLine();
            str_.WriteLine(" # class prototype");
            /*if (Helper.g_log_cerr > 0)
            {
                Console.Error.WriteLine(" # class prototype");
            }*/
            EmitClassPrototype();

            str_.WriteLine();
            str_.WriteLine(" # class direct parent tab");
            /*if (Helper.g_log_cerr > 0)
            {
                Console.Error.WriteLine(" # class direct parent tab");
            }*/
            EmitClassDirectParentTab();

            str_.WriteLine();
            str_.WriteLine(" # class prototype obj tab");

            /*if (Helper.g_log_cerr > 0)
            {
                Console.Error.WriteLine(" # class prototype obj tab");
            }*/
            EmitClassProtObjTab();

            str_.WriteLine();
            str_.WriteLine(" # class init method tab");
            /*if (Helper.g_log_cerr > 0)
            {
                Console.Error.WriteLine(" # class init method tab");
            }*/
            EmitClassInitTab();

            str_.WriteLine();
            str_.WriteLine(" # global text");

            /*if (Helper.g_log_cerr > 0)
            {
                Console.Error.WriteLine(" # global text");
            }*/
            EmitGlobalText();

            str_.WriteLine();
            str_.WriteLine(" # class init");
            /*if (Helper.g_log_cerr > 0)
            {
                Console.Error.WriteLine(" # class init");
            }*/
            EmitClassInitMethod();

            str_.WriteLine();
            str_.WriteLine(" # class methods");
            /*if (Helper.g_log_cerr > 0)
            {
                Console.Error.WriteLine(" # class methods");
            }*/
            EmitClassMethods();

           // str_.WriteLine("main");
            str_.Close();
        }

        public void EmitClassMethods()
        {
            var c_syms = new ConstantSymbol();
            foreach (var ele in class_info_tab_)
            {
                string class_name = ele.Key;
                var cinfo = ele.Value;
                var node = cinfo.ast_node;
                Env env = new Env(class_name, class_info_tab_);


                // skip generate method code for basic classes
                if (class_name == c_syms.IO.str_ || class_name == c_syms.Object.str_ || class_name == c_syms.Str.str_ || class_name == c_syms.Int.str_ || class_name == c_syms.Bool.str_)
                    continue;

                // 1. enter class scope
                // add self and attrs location mapping
                env.loc.EnterScope();
                env.loc.AddMapping("self", "$s0");
                var ordered_attrs = cinfo.ordered_attrs;
                foreach (var e in ordered_attrs)
                {
                    string name = e.Item1;
                    string offset = GetAttrOffset(cinfo.attrs_offset_tab, name);
                    env.loc.AddMapping(name, offset);
                }

                // 2. generate code for new methods or overrided methods
                foreach (var feature in node.Features)
                {
                    if (feature is Attr)
                    {
                        continue;
                    }
                    var method = (Method)feature;
                    string method_name = method.Name.str_;

                    // 2.1 precalculate temp space for method
                    env.allocated_temp_space = CalculateTemporaries(method.Expression) * 4;

                    // 2.2 lookup method signature
                    var method_sig_tab = cinfo.method_sig_tab;
                    if (!method_sig_tab.ContainsKey(method_name))
                    {
                        /*CoolDumpError(cerr)
                          << "method_sig_tab cannot find " << method_name << endl;
                        exit(-1);*/
                    }

                    // 2.3 create method scope
                    // add method argument mapping
                    env.loc.EnterScope();
                    var method_sig = method_sig_tab[method_name];
                    for (int i = 0; i < method_sig.Count; ++i)
                    {
                        string arg_name = method_sig[i].Item1;
                        env.loc.AddMapping(arg_name, GetArgumentOffset(i, method_sig.Count));
                    }

                    // 2.4 method label
                    str_.WriteLine();
                    str_.WriteLine(class_name + "." + method_name + ":");

                    // 2.5 setup stack frame
                    EmitSetupStackFrame(str_, env.allocated_temp_space);

                    // 2.6 method code gen
                    env.next_free_temp_space = 4;
                    HandleExpression(method.Expression, env);

                    // 2.6 free stack frame
                    EmitFreeStackFrame(str_, env.allocated_temp_space);

                    // 2.6.1 free pushed arg
                    EmitADDIU(str_, "$sp", "$sp", (method_sig.Count * 4).ToString());

                    // 2.8 return
                    EmitReturn(str_);

                    // 2.9 exit method scope
                    env.loc.ExitScope();
                }

                // 3 exit class scope
                env.loc.ExitScope();
            }
        }

        public void EmitClassTagDefinition()
        {
            var c_sym = new ConstantSymbol();
            foreach (var ele in class_info_tab_)
            {
                var name = ele.Key;
                if (name == c_sym.Bool.str_ || name == c_sym.Int.str_ || name == c_sym.Str.str_)
                    continue;
                string tag_name = ele.Value.tag_name;
                int tag_no = ele.Value.layout.class_tag;
                str_.WriteLine(tag_name + ":");
                str_.WriteLine(WORD + tag_no);
            }
        }

        public void EmitClassTagDeclaration()
        {
            var c_sym = new ConstantSymbol();
            foreach (var ele in class_info_tab_)
            {
                var name = ele.Key;
                if (name == c_sym.Bool.str_ || name == c_sym.Int.str_ || name == c_sym.Str.str_)
                    continue;
                string tag_name = ele.Value.tag_name;
                str_.WriteLine(GLOBAL + tag_name);
            }
        }

        public void CollectClassInfo()
        {
            // clear class_info_tab_
            class_info_tab_ = new Dictionary<string, ClassInfo>();

            tag_cnt_ = 0;
            ClassInfo info = new ClassInfo();
            CollectClassInfoHelper(inherit_tree_.LookupNode("Object"), info);
        }

        public void CollectClassInfoHelper(Node node, ClassInfo info)
        {

            if (node == null)
                return;

            // init per class info
            var ninfo = new ClassInfo();
            
            ninfo.class_name = node.name;
            // object node doesn't have parent node
            ninfo.parent_name = node.parent != null ? node.parent.name : "";
            ninfo.label = Helper.GetClassLabelName(ninfo.class_name);
            ninfo.tag_name = Helper.GetClassTagName(ninfo.class_name);
            ninfo.ast_node = node.ast_node_;
            ninfo.layout.gc_tag = -1;
            ninfo.layout.class_tag = tag_cnt_++;
            ninfo.layout.dispatch_tab_label = Helper.GetClassDispatchTabName(ninfo.class_name);
            tag_to_class_name_.Add(ninfo.class_name);

            // info
            var ordered_attrs =info.ordered_attrs;
            var attrs_offset_tab = info.attrs_offset_tab;
            var ordered_methods =  info.ordered_methods;
            var method_set = info.method_set;
            var method_sig_tab =info.method_sig_tab;
            var method_tab =info.method_tab;
            var methods_offset_tab = info.methods_offset_tab;

            // count number new features added to class inheritance tree
            int added_method_cnt = 0;
            int added_attr_cnt = 0;

            var features = node.ast_node_.Features;

            List<string> current_class_defined_methods = new List<string>();
            #region features
            foreach (var feature in features)
            {
                if (feature is Method)
                {
                    var method = (Method)feature;
                    string method_name = method.Name.str_;
                    current_class_defined_methods.Add(method_name);
                    // if current class defined class is not appear in class inheritance tree
                    if (!method_set.Contains(method_name))
                    {
                        method_set.Add(method_name);
                        ordered_methods.Add(method_name);
                        ++added_method_cnt;
                    }
                    var formals = method.Formals;
                    List<Tuple<string, string>> args = new List<Tuple<string, string>>();
                    foreach (var formal in formals)
                        args.Add(new Tuple<string, string>(formal.Name.str_, formal.TypeDecl.str_));

                    if (method_sig_tab.ContainsKey(method_name))
                        method_sig_tab[method_name] = args;
                    else
                        method_sig_tab.Add(method_name, args);
                    if (!method_tab.ContainsKey(method_name))
                       method_tab.Add(method_name, new List<string>());
                    method_tab[method_name].Add(ninfo.class_name + "." + method_name);
                }
                else if (feature is Attr)
                {
                    var attr = (Attr)feature;
                    ++added_attr_cnt;
                    ordered_attrs.Add(new Tuple<string, string>(attr.Name.str_, attr.TypeDecl.str_));
                }
                else
                {
                    /*CoolDumpError(cerr)
                      << "Unknow Feature Class" << endl;
                    exit(-1);*/
                }
            }
            #endregion

            #region generate offset
            int offset = 0;
            foreach (var ele in ordered_attrs)
                if (!attrs_offset_tab.ContainsKey(ele.Item1))
                    attrs_offset_tab.Add(ele.Item1, offset++);
                else
                    attrs_offset_tab[ele.Item1] = offset++;
            

            offset = 0;
            foreach (var n in ordered_methods)
                if (!methods_offset_tab.ContainsKey(n))
                    methods_offset_tab.Add(n, offset++);
                else
                    methods_offset_tab[n] = offset++;
            #endregion

          
            // copy
            ninfo.ordered_attrs =new List<Tuple<string, string>>( ordered_attrs);
            ninfo.attrs_offset_tab =new Dictionary<string, int>( attrs_offset_tab);
            ninfo.method_set =new HashSet<string>( method_set);
            ninfo.ordered_methods=new List<string>( ordered_methods);
            ninfo.method_sig_tab =new Dictionary<string, List<Tuple<string, string>>>( method_sig_tab);
            //var tmp = method_tab.Values.ToArray();
            ninfo.method_tab =new Dictionary<string, List<string>>();
            foreach (var item in method_tab)
            {
                ninfo.method_tab.Add(item.Key, new List<string>(item.Value));
            }
            ninfo.methods_offset_tab =new Dictionary<string, int>( methods_offset_tab);
            ninfo.layout.object_size = ordered_attrs.Count + 3;
            class_info_tab_.Add(ninfo.class_name, ninfo);

            // recursively collect
            foreach (var child in node.children)
                CollectClassInfoHelper(child, info);


            // Pop added attributes
            while (added_attr_cnt > 0)
            {
                --added_attr_cnt;
                ordered_attrs.RemoveAt(ordered_attrs.Count - 1);
            }

            // Pop added Methods
            while (added_method_cnt > 0)
            {
                --added_method_cnt;
                var name = ordered_methods[ordered_methods.Count - 1];
                method_set.Remove(name);
                method_sig_tab.Remove(name);
                ordered_methods.RemoveAt(ordered_methods.Count - 1);
            }

            // Pop added & override method
            foreach (var n in current_class_defined_methods)
            {
                method_tab[n].RemoveAt(method_tab[n].Count - 1);
                if (method_tab[n].Count == 0)
                {
                    method_tab.Remove(n);
                }
            }
        }
        public void EmitSymbolTabConstants()
        {
            EmitStrSymbolTab();
            EmitIntSymbolTab();
            EmitBoolConstSymbol();
        }

        public void EmitBoolConstSymbol()
        {
            var c_sym = new ConstantSymbol();

            if (!class_info_tab_.ContainsKey(c_sym.Bool.str_))
            {
                /*CoolDumpError(cerr)
                  << "class_info_tab_ cannot find "
                  << c_sym->Bool->GetString()
                  << endl;*/
            }

            var cinfo = class_info_tab_[c_sym.Bool.str_];
            if (cinfo == null)
            {/*
                CoolDumpError(cerr)
                  << "cinfo is nullptr" << endl;*/
            }

            var tag_no = cinfo.layout.class_tag;

            // bool const true
            str_.WriteLine(WORD + "-1");
            str_.WriteLine(BOOLCONST_TRUE_REF + ":");
            str_.WriteLine(WORD+ tag_no);
            str_.WriteLine(WORD + (DEFAULT_OBJFIELDS + BOOL_SLOTS));
            str_.WriteLine(WORD + Helper.GetClassDispatchTabName(new ConstantSymbol().Bool.str_));
            str_.WriteLine(WORD + "1");

            // bool const false
            str_.WriteLine(WORD + "-1");
            str_.WriteLine(BOOLCONST_FALSE_REF + ":");
            str_.WriteLine(WORD + tag_no);
            str_.WriteLine(WORD + (DEFAULT_OBJFIELDS + BOOL_SLOTS));
            str_.WriteLine(WORD + Helper.GetClassDispatchTabName(new ConstantSymbol().Bool.str_));
            str_.WriteLine(WORD + "0");
        }

        public void EmitStrSymbolTab()
        {
            var c_sym = new ConstantSymbol();
            if (!class_info_tab_.ContainsKey(c_sym.Str.str_))
            {
                /*CoolDumpError(cerr)
                  << "class_info_tab_ cannot find "
                  << c_sym->Str->GetString()
                  << endl;*/
            }

            var cinfo = class_info_tab_[c_sym.Str.str_];
            if (cinfo == null)
            {
                /*CoolDumpError(cerr)
                  << "cinfo is nullptr" << endl;*/
            }

            var tag_no = cinfo.layout.class_tag;
            foreach (var ele in SymbolUtils.StrTable.table)
                EmitStringTabEntry(ele.Value, str_, tag_no);

        }

        public void EmitIntSymbolTab()
        {
            var c_sym = new ConstantSymbol();
            if (!class_info_tab_.ContainsKey(c_sym.Int.str_))
            {
                /*CoolDumpError(cerr)
                  << "class_info_tab_ cannot find "
                  << c_sym->Int->GetString()
                  << endl;*/
            }

            var cinfo = class_info_tab_[c_sym.Int.str_];
            if (cinfo == null)
            {
                /*CoolDumpError(cerr)
                  << "cinfo is nullptr" << endl;*/
            }
            var tag_no = cinfo.layout.class_tag;
            foreach (var ele in SymbolUtils.IntTable.table)
                EmitIntTabEntry(ele.Value, str_, tag_no);

        }

        public void EmitGlobalData()
        {

            var c_sym = new ConstantSymbol();

            // Get Int Tag Number
            if (!class_info_tab_.ContainsKey(c_sym.Int.str_))
            {
                /* CoolDumpError(cerr)
                         << "class_info_tab_ cannot find "
                   << c_sym->Int->GetString()
                         << endl;*/
            }
            var cinfo = class_info_tab_[c_sym.Int.str_];
            if (cinfo == null)
            {
                /*CoolDumpError(cerr)
                  << "cinfo is nullptr" << endl;*/
            }
            var int_tag_no = cinfo.layout.class_tag;

            // Get Bool Tag Number
            if (!class_info_tab_.ContainsKey(c_sym.Bool.str_))
            {
                /*CoolDumpError(cerr)
                  << "class_info_tab_ cannot find "
                  << c_sym->Bool->GetString()
                  << endl;*/
            }
            cinfo = class_info_tab_[c_sym.Bool.str_];
            var bool_tag_no = cinfo.layout.class_tag;

            // Get Str Tag Number
            if (!class_info_tab_.ContainsKey(c_sym.Str.str_))
            {
                /*CoolDumpError(cerr)
                  << "class_info_tab_ cannot find "
                  << c_sym->Str->GetString()
                  << endl;*/
            }
            cinfo = class_info_tab_[c_sym.Str.str_];
            var str_tag_no = cinfo.layout.class_tag;


            // Emit global names must be defined first
            str_.WriteLine("\t.data");
            str_.WriteLine(ALIGN);
            str_.WriteLine(GLOBAL + CLASS_NAME_TAB);
            str_.WriteLine(GLOBAL + GetProtoObjRef(c_sym.Main.str_));
            str_.WriteLine(GLOBAL + GetProtoObjRef(c_sym.Int.str_));
            str_.WriteLine(GLOBAL + GetProtoObjRef(c_sym.Str.str_));
            str_.WriteLine(GLOBAL + BOOLCONST_TRUE_REF);
            str_.WriteLine(GLOBAL + BOOLCONST_FALSE_REF);
            str_.WriteLine(GLOBAL + Helper.GetClassTagName(c_sym.Int.str_));
            str_.WriteLine(GLOBAL + Helper.GetClassTagName(c_sym.Bool.str_));
            str_.WriteLine(GLOBAL + Helper.GetClassTagName(c_sym.Str.str_));

            // Int, Bool, Str Tag definiton
            str_.WriteLine(Helper.GetClassTagName(c_sym.Int.str_) + ":");
            str_.WriteLine(WORD + int_tag_no);
            str_.WriteLine(Helper.GetClassTagName(c_sym.Bool.str_) + ":");
            str_.WriteLine(WORD + bool_tag_no);
            str_.WriteLine(Helper.GetClassTagName(c_sym.Str.str_) + ":");
            str_.WriteLine(WORD + str_tag_no);
        }

        public void EmitGCSelect()
        {
            str_.WriteLine(GLOBAL + "_MemMgr_INITIALIZER");
            str_.WriteLine("_MemMgr_INITIALIZER:");
            str_.WriteLine(WORD + _gc_init_names[0]);
            str_.WriteLine(GLOBAL + "_MemMgr_COLLECTOR");
            str_.WriteLine("_MemMgr_COLLECTOR:");
            str_.WriteLine(WORD + _gc_collect_names[0]);
            str_.WriteLine(GLOBAL + "_MemMgr_TEST");
            str_.WriteLine("_MemMgr_TEST:");
            str_.WriteLine(WORD + "0");
           // str_ << WORD << (cgen_Memmgr_Test == GC_TEST) << endl;
        }

        public void EmitClassNameTab()
        {
            str_.WriteLine(CLASS_NAME_TAB + ":");
            foreach (var name in tag_to_class_name_)
            {
                var sym = SymbolUtils.StrTable.Lookup(name);
                if (sym == null)
                {/*
                    exit(-1);*/
                }
                str_.WriteLine(WORD + sym.ref_);
            }
        }

        public void EmitClassDispatchTab()
        {
            foreach (var ele in class_info_tab_)
            {
                var cinfo = ele.Value;
                str_.WriteLine(cinfo.layout.dispatch_tab_label + ":");
                foreach (var method_name in cinfo.ordered_methods)
                {
                    var l = (cinfo.method_tab[method_name]);
                    //if(l.Count>0)
                    str_.WriteLine(WORD + l[l.Count - 1]);
                    //str_.WriteLine(WORD+)
                    //str_ << WORD << (cinfo->method_tab.at(method_name)).back() << endl;
                }
                str_.WriteLine();
            }
        }

        public void EmitClassPrototype()
        {
            var c_syms = new ConstantSymbol();
            foreach (var ele in class_info_tab_)
            {
                var cinfo = ele.Value;
                if (cinfo == null)
                {
                    /*CoolDumpError(cerr)
                      << "cinfo is null" << endl;
                    exit(-1);*/
                }
                str_.WriteLine(WORD + cinfo.layout.gc_tag);
                str_.WriteLine(cinfo.label + ":");
                str_.WriteLine(WORD + cinfo.layout.class_tag);
                str_.WriteLine(WORD + cinfo.layout.object_size);
                str_.WriteLine(WORD + cinfo.layout.dispatch_tab_label);

                var ordered_attrs = cinfo.ordered_attrs;
                foreach (var el in ordered_attrs)
                {
                    var name = el.Item1;
                    var type = el.Item2;
                    if (type == c_syms.Int.str_)
                    {
                        str_.WriteLine(WORD + SymbolUtils.IntTable.Lookup("0").ref_);
                    }
                    else if (type == c_syms.Bool.str_)
                    {
                        str_.WriteLine(WORD + BOOLCONST_FALSE_REF);
                    }
                    else if (type == c_syms.Str.str_)
                    {
                        str_.WriteLine(WORD + SymbolUtils.StrTable.Lookup("").ref_);
                    }
                    else
                    {
                        str_.WriteLine(WORD + "0");
                    }
                }
            }
        }

        public void EmitGlobalText()
        {

            var c_syms = new ConstantSymbol();
            str_.WriteLine(GLOBAL + HEAP_START);
            str_.WriteLine(HEAP_START + ":");
            str_.WriteLine(WORD + "0");
            str_.WriteLine();
            str_.WriteLine("\t.text");
            str_.WriteLine(GLOBAL +Helper.GetClassInitMethod(c_syms.Main.str_));
            str_.WriteLine(GLOBAL + Helper.GetClassInitMethod(c_syms.Int.str_));
            str_.WriteLine(GLOBAL + Helper.GetClassInitMethod(c_syms.Str.str_));
            str_.WriteLine(GLOBAL + Helper.GetClassInitMethod(c_syms.Bool.str_));
            str_.WriteLine(GLOBAL + "Main.main");
        }

        public void EmitClassInitMethod()
        {
            var c_syms = new ConstantSymbol();
            foreach (var ele in class_info_tab_)
            {
                var class_name = ele.Key;
                var cinfo = ele.Value;
                var node = cinfo.ast_node;
                Env env = new Env(class_name, class_info_tab_);
                // 1. precaculate the temporaries space in class.init method
                int temp_space = 0;
                foreach (var feature in node.Features)
                {
                    if (feature is Attr)
                    {
                        Attr attr = (Attr)feature;
                        if (attr.Init is NoExpr)
                        {
                            continue;
                        }
                        temp_space = Math.Max(temp_space, CalculateTemporaries(attr.Init));
                    }
                }

                env.allocated_temp_space = temp_space << 2;
                env.next_free_temp_space = 4;

                /*if (cool_helper::g_log_cerr)
                {
                    CoolDump(cerr) << "total temp space:"
                                   << env->allocated_temp_space << endl;
                }*/

                // 2. add attributes' location mapping (create a scope)
                // attr_name -> offset from this pointer
                env.loc.EnterScope();
                env.loc.AddMapping("self", "$s0");
                var ordered_attrs = cinfo.ordered_attrs;
                foreach (var el in ordered_attrs)
                {
                    var name = el.Item1;
                    env.loc.AddMapping(name, GetAttrOffset(cinfo.attrs_offset_tab, name));
                }

                // 3. class init method label
                str_.WriteLine(Helper.GetClassInitMethod(class_name) + ":");

                // 4. setup stack frame
                EmitSetupStackFrame(str_, env.allocated_temp_space);

                // 5. call init method of direct parent
                if (class_name != c_syms.Object.str_)
                {
                    EmitJAL(str_, Helper.GetClassInitMethod(node.Parent.str_));
                }

                // 6. init attributes
                foreach (var feature in node.Features)
                {
                    if (feature is Method)
                    {
                        continue;
                    }
                    var attr = (Attr)feature;
                    string name = attr.Name.str_;
                    string type = attr.TypeDecl.str_;
                    if (attr.Init is NoExpr)
                    {
                        continue;
                    }
                    env.next_free_temp_space = 4;
                    HandleExpression(attr.Init, env);

                    // 6.1 store init result in attr location
                    var l = env.loc.Lookup(name);
                    if (l == null)
                    {
                        /*CoolDumpError(cerr)
                          << "env->loc cannot find " << name << endl;
                        exit(-1);*/
                    }
                    EmitSW(str_, ACC, l);
                }

                // 6.5 set return value $a0 to self pointer
                EmitMOVE(str_, ACC, SELF);

                // 7. free stack frame
                EmitFreeStackFrame(str_, env.allocated_temp_space);

                // 8. return
                EmitReturn(str_);

                env.loc.ExitScope();
            }
        }

        public void EmitFreeStackFrame(TextWriter str, int temp_space)
        {
            EmitLW(str, (temp_space + 12) + "($sp)", "$fp");
            EmitLW(str, (temp_space + 8) + "($sp)", "$s0");
            EmitLW(str, (temp_space + 4) + "($sp)", "$ra");
            EmitADDIU(str, "$sp", "$sp", (temp_space + 12).ToString());
        }

        public int CalculateTemporaries(Expression expr)
        {
            int ret = 0;
            if (expr is Assign)
            {
                var assign = (Assign)expr;
                ret = CalculateTemporaries(assign.Expression);
            }
            else if (expr is StaticDispatch)
            {
                var dispatch = (StaticDispatch)expr;
                ret = CalculateTemporaries(dispatch.Expression);
                foreach (var e in dispatch.ActualExpressions)
                    ret = Math.Max(ret, CalculateTemporaries(e));

            }
            else if (expr is Dispatch)
            {
                var dispatch = (Dispatch)expr;
                ret = CalculateTemporaries(dispatch.Expression);
                foreach (var e in dispatch.ActualExpressions)
                    ret = Math.Max(ret, CalculateTemporaries(e));

            }
            else if (expr is Cond)
            {
                var cond = (Cond)expr;
                ret = CalculateTemporaries(cond.Predicate);
                ret = Math.Max(ret, CalculateTemporaries(cond.Then));
                ret = Math.Max(ret, CalculateTemporaries(cond.Else));
            }
            else if (expr is Loop)
            {
                var loop = (Loop)expr;
                ret = CalculateTemporaries(loop.Predicate);
                ret = Math.Max(ret, CalculateTemporaries(loop.Body));
            }
            else if (expr is Typcase)
            {
                var typcase = (Typcase)expr;
                ret = CalculateTemporaries(typcase.Expression);
                foreach (var c in typcase.Cases)
                    ret = Math.Max(ret, 1 + CalculateTemporaries(c.Expression));

            }
            else if (expr is Block)
            {
                var block = (Block)expr;
                foreach (var e in block.Body)
                    ret = Math.Max(ret, CalculateTemporaries(e));

            }
            else if (expr is Let)
            {
                var let = (Let)expr;
                ret = Math.Max(CalculateTemporaries(let.Init), 1 + CalculateTemporaries(let.Body));
            }
            else if (expr is Plus)
            {
                var plus = (Plus)expr;
                ret = Math.Max(CalculateTemporaries(plus.Exp1), 2 + CalculateTemporaries(plus.Exp2));
            }
            else if (expr is Sub)
            {
                var sub = (Sub)expr;
                ret = Math.Max(CalculateTemporaries(sub.Exp1), 2 + CalculateTemporaries(sub.Exp2));
            }
            else if (expr is Mul)
            {
                var mul = (Mul)expr;
                ret = Math.Max(CalculateTemporaries(mul.Exp1), 2 + CalculateTemporaries(mul.Exp2));
            }
            else if (expr is Divide)
            {
                var divide = (Divide)expr;
                ret = Math.Max(CalculateTemporaries(divide.Exp1), 2 + CalculateTemporaries(divide.Exp2));
            }
            else if (expr is Neg)
            {
                var neg = (Neg)expr;
                ret = Math.Max(1, CalculateTemporaries(neg.Exp));
            }
            else if (expr is Lt)
            {
                var lt = (Lt)expr;
                ret = Math.Max(CalculateTemporaries(lt.Exp1), 2 + CalculateTemporaries(lt.Exp2));
            }
            else if (expr is Eq)
            {
                var eq = (Eq)expr;
                ret = Math.Max(CalculateTemporaries(eq.Exp1), 2 + CalculateTemporaries(eq.Exp2));
            }
            else if (expr is Leq)
            {
                var leq = (Leq)expr;
                ret = Math.Max(CalculateTemporaries(leq.Exp1), 2 + CalculateTemporaries(leq.Exp2));
            }
            else if (expr is Comp)
            {
                var comp = (Comp)expr;
                ret = CalculateTemporaries(comp.Exp);
            }
            else if (expr is IntConst || expr is BoolConst || expr is StringConst || expr is New || expr is IsVoid || expr is NoExpr || expr is Object)
            {
                ret = 0;
            }
            else
            {
                /*CoolDumpError(cerr)
                  << "unkonw expression class" << endl;
                exit(1);*/
            }
            return ret;
        }

        public string GetAttrOffset(Dictionary<string, int> tab, string name)
        {
            if (!tab.ContainsKey(name))
            {
                /*CoolDumpError(cerr)
                  << "Cannot find " << name << " in attributes tab" << endl;
                exit(-1);*/
            }

            /*
            std::ostringstream oss;
            oss << ((tab.find(name))->second + 3) * 4 << "($s0)";
            return oss.str();*/
            return ((tab[name] + 3) * 4).ToString() + "($s0)";
        }

        public void EmitSetupStackFrame(TextWriter str, int temp_space)
        {
            EmitADDIU(str, "$sp", "$sp", (-(temp_space + 12)).ToString());
            EmitSW(str, "$fp", (temp_space + 12) + "($sp)");
            EmitSW(str, "$s0", (temp_space + 8) + "($sp)");
            EmitSW(str, "$ra", (temp_space + 4) + "($sp)");
            EmitADDIU(str, "$fp", "$sp", (temp_space + 4).ToString());
            EmitMOVE(str, SELF, ACC);
        }

        public void EmitADDIU(TextWriter str, string dst, string op1Reg, string op2Imm)
        {
            str.WriteLine(ADDIU + dst + "\t" + op1Reg + "\t" + op2Imm);
        }

        public void EmitSW(TextWriter str, string srcReg, string tarAddr)
        {
            str.WriteLine(SW + srcReg + "\t" + tarAddr);
        }

        public void EmitLW(TextWriter str, string srcAddr, string tarReg)
        {
            str.WriteLine(LW + tarReg + "\t" + srcAddr);
        }

        public void EmitMOVE(TextWriter str, string tarReg, string srcReg)
        {
            str.WriteLine(MOVE + tarReg + "\t" + srcReg);
        }

        public void EmitPush(TextWriter str, string srcReg)
        {
            EmitSW(str, srcReg, "0($sp)");
            EmitADDIU(str, "$sp", "$sp", "-4");
        }

        public void EmitPop(TextWriter str, string dstReg)
        {
            EmitADDIU(str, "$sp", "$sp", "4");
            EmitLW(str, SPTop, dstReg);
        }

        public void EmitPop(TextWriter str)
        {
            EmitADDIU(str, "$sp", "$sp", "4");
        }

        public void EmitReturn(TextWriter str)
        {
            str.WriteLine("\tjr\t$ra");
        }

        public void EmitJAL(TextWriter str, string tar)
        {
            str.WriteLine("\tjal\t" + tar);
        }

        public void EmitBNE(TextWriter str, string r1, string r2, string label)
        {
            str.WriteLine("\tbne\t" + r1 + " " + r2 + " " + label);
        }

        public void EmitBEQZ(TextWriter str, string reg, string label)
        {
            str.WriteLine("\tbeqz\t" + reg + " " + label);
        }

        public void EmitLI(TextWriter str, string r, string imm)
        {
            str.WriteLine("\tli\t" + r + " " + imm);
        }

        public void EmitLA(TextWriter str, string r, string addr)
        {
            if(addr==""||addr==null||addr=="\t"||addr==" ")
            {

            }
            str.WriteLine("\tla\t" + r + " " + addr);
        }

        public void EmitJALR(TextWriter str, string reg)
        {
            str.WriteLine("\tjalr\t" + reg);
        }

        public void EmitB(TextWriter str, string label)
        {
            str.WriteLine("\tb\t" + label);
        }

        public void EmitADD(TextWriter str, string tarReg, string srcReg1, string srcReg2)
        {
            str.WriteLine("\tadd\t" + tarReg + "\t" + srcReg1 + "\t" + srcReg2);
        }

        public void EmitSUB(TextWriter str, string tarReg, string srcReg1, string srcReg2)
        {
            str.WriteLine("\tsub\t" + tarReg + "\t" + srcReg1 + "\t" + srcReg2);
        }

        public void EmitMUL(TextWriter str, string tarReg, string srcReg1, string srcReg2)
        {
            str.WriteLine("\tmul\t" + tarReg + "\t" + srcReg1 + "\t" + srcReg2);
        }

        public void EmitDIV(TextWriter str, string tarReg, string srcReg1, string srcReg2)
        {
            str.WriteLine("\tdiv\t" + tarReg + "\t" + srcReg1 + "\t" + srcReg2);
        }

        public void EmitNEG(TextWriter str, string srcReg, string tarReg)
        {
            str.WriteLine("\tneg\t" + tarReg + "\t" + srcReg);
        }

        public void EmitBLT(TextWriter str, string reg1, string reg2, string label)
        {
            str.WriteLine("\tblt\t" + reg1 + " " + reg2 + " " + label);
        }

        public void EmitBEQ(TextWriter str, string reg1, string reg2, string label)
        {
            str.WriteLine("\tbeq\t" + reg1 + " " + reg2 + " " + label);
        }

        public void EmitBLE(TextWriter str, string reg1, string reg2, string label)
        {
            str.WriteLine("\tble\t" + reg1 + " " + reg2 + " " + label);
        }

        public void HandleAssign(Assign assign, Env env)
        {
            HandleExpression(assign.Expression, env);
            var l = env.loc.Lookup(assign.Name.str_);
            if (l == null)
            {
                /*CoolDumpError(cerr)
                  << "cannot find " << assign->name->GetString() << endl;
                exit(-1);*/
            }
            EmitSW(str_, ACC, l);
        }

        // e0@T.f(e1,e2,..,en)
        public void HandleStaticDispatch(StaticDispatch dispatch, Env env)
        {
            // 1. evaluate each argument expression from left to right
            //    and push result onto the stack
            foreach (var e in dispatch.ActualExpressions)
            {
                HandleExpression(e, env);
                EmitPush(str_, ACC);
            }

            // 2. evaluate dispatch expression
            // 2.1 evaluate
            HandleExpression(dispatch.Expression, env);
            string static_type = dispatch.TypeName.str_;
            string class_name = static_type == "SELF_TYPE" ? env.class_name : static_type;

            // 2.2 check whether result is void
            string label = AllocateNewJumpLabel();
            EmitBNE(str_, ACC, ZERO, label);

            // 2.3 abort
            str_.Write("\tla\t" + ACC + " ");
            var p = SymbolUtils.StrTable.Lookup(env.filename);
            if (p == null)
            {
                /*CoolDumpError(cerr)
                  << "StrTable cannot find " << env->filename << endl;
                exit(-1);*/
            }
            str_.WriteLine(p.ref_);
            str_.WriteLine();
            str_.WriteLine("\tli\t" + "$t1" + " 1");
            str_.WriteLine("\tjal\t" + "_dispatch_abort");
            str_.WriteLine(label + ":");

            // 3. lookup correct method
            // 3.1 find class info
            ClassInfo it = null;

            bool valid = env.class_info_tab.TryGetValue(class_name, out it);
            if (!valid)
            {
                /*CoolDumpError(cerr)
                  << "env->class_info_tab cannot find " << class_name << endl;
                exit(-1);*/
            }

            // 3.2 find method
            // NOTE: ACC keeps the a pointer to the object of expr

            var cinfo = it;

            string method_name = dispatch.Name.str_;
            List<string> it2 = null;
            valid = cinfo.method_tab.TryGetValue(method_name, out it2);

            if (!valid)
            {
                /*CoolDumpError(cerr)
                  << "cinfo->method_tab cannot find " << method_name << endl;
                exit(-1);*/
            }

            method_name = it2[it2.Count - 1];

            // 4. invoke method
            EmitJAL(str_, method_name);
        }

        public void HandleDispatch(Dispatch dispatch, Env env)
        {
            // 1. evaluate each argument expression from left to right
            //     and push result onto the stack
            foreach (var e in dispatch.ActualExpressions)
            {
                HandleExpression(e, env);
                EmitPush(str_, ACC);
            }

            // 2. evaluate dispatch expression
            // 2.1 evaluate
            HandleExpression(dispatch.Expression, env);
            string expr_type = dispatch.Expression.Type;
            string class_name = expr_type == "SELF_TYPE" ? env.class_name : expr_type;

            // 2.2 check whether result is void
            string label = AllocateNewJumpLabel();
            EmitBNE(str_, ACC, ZERO, label);

            // 2.3 abort
            str_.Write("\tla\t" + ACC + " ");
            var p = SymbolUtils.StrTable.Lookup(env.filename);
            if (p == null)
            {
                /*CoolDumpError(cerr)
                  << "StrTable cannot find " << env->filename << endl;
                exit(-1);*/
            }
            str_.WriteLine(p.ref_);
            str_.WriteLine();
            str_.WriteLine("\tli\t" + "$t1" + " 1");
            str_.WriteLine("\tjal\t" + "_dispatch_abort");
            str_.WriteLine(label + ":");

            // 3. lookup correct method
            // 3.1 find class info
            ClassInfo it = null;
            bool valid = env.class_info_tab.TryGetValue(class_name, out it);
            if (!valid)
            {
                /*CoolDumpError(cerr)
                  << "env->class_info_tab cannot find " << class_name << endl;
                exit(-1);*/
            }

            // 3.2 lookup method offset
            string method_name = dispatch.Name.str_;
            var cinfo = it;

            int it2 = 0;
            valid = cinfo.methods_offset_tab.TryGetValue(method_name, out it2);

            if (!valid)
            {
                /* CoolDumpError(cerr)
                   << "methods_offset_tab cannot find " << method_name << " in"
                   << " class " << class_name
                   << endl;
                 exit(-1);*/
            }
            it2 *= 4;

            // 4. method dispatch
            // 4.1 load dispatch pointer
            EmitLW(str_, GetRegOffset(8, ACC), T1);
            // 4.2 lookup method
            EmitLW(str_, GetRegOffset(it2, T1), T1);
            // 4.3 invoke method
            EmitJALR(str_, T1);

        }
        public void HandleCond(Cond cond, Env env)
        {
            HandleExpression(cond.Predicate, env);
            // 1. load the value of Bool object into T1
            EmitLW(str_, GetRegOffset(12, ACC), T1);
            // 2. test pred if false jump to else expr
            string else_label = AllocateNewJumpLabel();
            string end_label = AllocateNewJumpLabel();
            EmitBEQZ(str_, T1, else_label);
            // 3. then expr
            HandleExpression(cond.Then, env);
            EmitB(str_, end_label);
            // 4. els expr
            str_.WriteLine(else_label + ":");
            HandleExpression(cond.Else, env);
            // 5. end label
            str_.WriteLine(end_label + ":");
        }

        public void HandleLoop(Loop loop, Env env)
        {
            string pred_label = AllocateNewJumpLabel();
            string end_label = AllocateNewJumpLabel();

            // 1. evaluate pred expression
            str_.WriteLine(pred_label + ":");
            HandleExpression(loop.Predicate, env);

            // 2. if pred false then jump to end
            EmitLW(str_, GetRegOffset(12, ACC), T1);
            EmitBEQZ(str_, T1, end_label);

            // 3. evaluate body expression and jump back to pred
            HandleExpression(loop.Body, env);
            EmitB(str_, pred_label);

            str_.WriteLine(end_label + ":");

            // 4. return value of loop is void
            EmitLI(str_, ACC, "0");
        }

        public void HandleCase(Typcase typcase, Env env)
        {
            // 1. evalute expression and abort on void
            HandleExpression(typcase.Expression, env);

            // 1.1 abort on void
            string label = AllocateNewJumpLabel();
            EmitBNE(str_, ACC, ZERO, label);
            str_.Write("\tla\t" + ACC + " ");
            var p = SymbolUtils.StrTable.Lookup(env.filename);
            if (p == null)
            {
                Console.Error.WriteLine("StrTable cannot find " + env.filename);
                throw new Exception();
            }
            str_.WriteLine(p.ref_);
            str_.WriteLine();
            str_.WriteLine("\tli\t" + "$t1" + " 1");
            str_.WriteLine("\tjal\t" + "_case_abort2");
            str_.WriteLine(label + ":");
            // 2. collect branch info
            List<string> branch_labels = new List<string>();
            List<Case> branch_vec = new List<Case>();
            List<int> tags = new List<int>();
            foreach (var branch in typcase.Cases)
            {
                // 2.1 get branch type tag no
                branch_vec.Add(branch);
                string type_name = branch.TypeDecl.str_;
                var class_info_tab = env.class_info_tab;
                ClassInfo cinfo = null;
                bool valid = class_info_tab.TryGetValue(type_name, out cinfo);
                if (!valid)
                {
                    Console.Error.WriteLine("class_info_tab cannot find " + type_name);
                    throw new Exception();
                }
                tags.Add(cinfo.layout.class_tag);
                // 2.2 allocate branch label
                branch_labels.Add(AllocateNewJumpLabel());
            }

            // 3. load expr type tag no into T1
            EmitLW(str_, GetRegOffset(0, ACC), T1);

            // 3. find ancestor
            string find_ancestor_label = AllocateNewJumpLabel();
            string no_match_label = AllocateNewJumpLabel();

            str_.WriteLine(find_ancestor_label + ":");

            for (int i = 0; i < tags.Count; ++i)
            {
                // 3.1 load branch type tag no into T2
                EmitLI(str_, T2, tags[i].ToString());
                // 3.2 if tag no equals then jump to its branch
                EmitBEQ(str_, T1, T2, branch_labels[i]);
            }

            // 3.3 check whether there is no match case
            EmitLI(str_, T2, "0");
            EmitBEQ(str_, T1, T2, no_match_label);

            // 3.4 get parent
            EmitLA(str_, T2, CLASS_DIRECT_PARENT_TAB);
            EmitLI(str_, T3, "4");
            EmitMUL(str_, T1, T1, T3);
            EmitADD(str_, T1, T1, T2);   // T1 contains the addr of parent tag
            EmitLW(str_, GetRegOffset(0, T1), T1); // load parent tag no
            EmitB(str_, find_ancestor_label);

            // 3.5 no match case abort
            str_.WriteLine(no_match_label + ":");
            str_.WriteLine("\tjal\t" + "_case_abort");

            // 4. code gen for case branch
            string end_label = AllocateNewJumpLabel();
            for (int i = 0; i < tags.Count; ++i)
            {
                str_.WriteLine(branch_labels[i] + ":");
                Case branch = branch_vec[i];
                string id_name = branch.Name.str_;
                string type_decl = branch.TypeDecl.str_;
                string temp_space = GetNextTempSpace(env);
                // 4.1 store expr value into temp_space
                EmitSW(str_, ACC, temp_space);
                // 4.2 create branch scope
                env.loc.EnterScope();
                // 4.3 add mapping: id -> temp_space
                env.loc.AddMapping(
                    id_name, temp_space);
                // 4.4 evalute expr
                HandleExpression(branch.Expression, env);
                // 4.5 exit branch scope
                env.loc.ExitScope();

                // 4.6 free tempspace
                FreeTempSpace(env, 1);
                EmitB(str_, end_label);
            }
            str_.WriteLine(end_label + ":");
        }

        public void HandleExpression(Expression expr, Env env)
        {
            if (expr is Assign)
            {
                HandleAssign((Assign)expr, env);
            }
            else if (expr is StaticDispatch)
            {
                HandleStaticDispatch((StaticDispatch)expr, env);
            }
            else if (expr is Dispatch)
            {
                HandleDispatch((Dispatch)expr, env);
            }
            else if (expr is Cond)
            {
                HandleCond((Cond)expr, env);
            }
            else if (expr is Loop)
            {
                HandleLoop((Loop)expr, env);
            }
            else if (expr is Typcase)
            {
                HandleCase((Typcase)expr, env);
            }
            else if (expr is Block)
            {
                HandleBlock((Block)expr, env);
            }
            else if (expr is Let)
            {
                HandleLet((Let)expr, env);
            }
            else if (expr is Plus)
            {
                HandlePlus((Plus)expr, env);
            }
            else if (expr is Sub)
            {
                HandleSub((Sub)expr, env);
            }
            else if (expr is Mul)
            {
                HandleMul((Mul)expr, env);
            }
            else if (expr is Divide)
            {
                HandleDivide((Divide)expr, env);
            }
            else if (expr is Neg)
            {
                HandleNeg((Neg)expr, env);
            }
            else if (expr is Lt)
            {
                HandleLt((Lt)expr, env);
            }
            else if (expr is Eq)
            {
                HandleEq((Eq)expr, env);
            }
            else if (expr is Leq)
            {
                HandleLeq((Leq)expr, env);
            }
            else if (expr is Comp)
            {
                HandleComp((Comp)expr, env);
            }
            else if (expr is IntConst)
            {
                HandleIntConst((IntConst)expr, env);
            }
            else if (expr is StringConst)
            {
                HandleStrConst((StringConst)expr, env);
            }
            else if (expr is BoolConst)
            {
                HandleBoolConst((BoolConst)expr, env);
            }
            else if (expr is New)
            {
                HandleNew((New)expr, env);
            }
            else if (expr is IsVoid)
            {
                HandleIsVoid((IsVoid)expr, env);
            }
            else if (expr is NoExpr)
            {
                HandleNoExpr((NoExpr)expr, env);
            }
            else if (expr is Object)
            {
                HandleObject((Object)expr, env);
            }
            else
            {
                /*CoolDumpError(cerr)
                  << "Uknow expression class" << endl;
                exit(-1);*/
            }
        }

        public void HandleNew(New n, Env env)
        {
            string type = n.TypeName.str_;
            if (type == "SELF_TYPE")
            {
                // load prototype object label
                EmitLW(str_, GetRegOffset(0, SELF), T1); // T1 = current class tag no
                EmitLA(str_, T3, "4");     // T3 = 4
                EmitMUL(str_, T1, T1, T3); // offset = T1 * T3 = tag_no * 4
                EmitLA(str_, T2, CLASS_PROT_OBJ_TAB); // T2 = TAB
                EmitADD(str_, T1, T1, T2); // T1 = TAB + OFFSET
                EmitLW(str_, GetRegOffset(0, T1), ACC); // ACC = *(0($T1))
                EmitJAL(str_, "Object.copy");

                // load class init label
                EmitLW(str_, GetRegOffset(0, SELF), T1); // T1 = current class tag no
                EmitLA(str_, T3, "4");     // T3 = 4
                EmitMUL(str_, T1, T1, T3); // offset = T1 * T3 = tag_no * 4
                EmitLA(str_, T2, CLASS_INIT_TAB); // T2 = TAB
                EmitADD(str_, T1, T1, T2); // T1 = TAB + OFFSET
                EmitLW(str_, GetRegOffset(0, T1), T1); // T1 = * (0($T1))
                EmitJALR(str_, T1);
            }
            else
            {
                string class_prot = type + PROTOBJ_SUFFIX;
                string class_init = type + CLASSINIT_SUFFIX;
                EmitLA(str_, ACC, class_prot);
                EmitJAL(str_, "Object.copy");
                EmitJAL(str_, class_init);
            }
        }

        public void HandleIsVoid(IsVoid isvoid, Env env)
        {
            // 1. evaluate e1
            HandleExpression(isvoid.Expr, env);

            // 2. move ACC to T1
            EmitMOVE(str_, T1, ACC);

            // 3. load true
            str_.WriteLine("\tla\t" + ACC + "\t" + BOOLCONST_TRUE_REF);

            // 4. if e1 is false then branch true else branch to else
            string label = AllocateNewJumpLabel();
            EmitBEQZ(str_, T1, label);

            // 5. load false
            str_.WriteLine("\tla\t" + ACC + "\t" + BOOLCONST_FALSE_REF);

            // 6. true label
            str_.WriteLine(label + ":");
        }

        public void HandleNoExpr(NoExpr noexpr, Env env)
        {
            return;
        }

        public void HandleObject(Object obj, Env env)
        {
            string l = env.loc.Lookup(obj.Name.str_);
            if (l == null)
            {
                /*CoolDumpError(cerr)
                  << "cannot find " << obj->name->GetString() << endl;
                exit(-1);*/
            }

            // if expr is self, move $a0, $s0
            // $s0 always contains the self pointer of current object
            if (l == "$s0")
            {
                EmitMOVE(str_, ACC, l);
            }
            else
            {
                EmitLW(str_, l, ACC);
            }
        }

        public void HandleNeg(Neg neg, Env env)
        {
            // 1. evaluate e1
            HandleExpression(neg.Exp, env);

            // 1.1 allocate temp space
            string temp_space = GetNextTempSpace(env);
            EmitSW(str_, ACC, temp_space);

            // 1.2 creat new int
            EmitLA(str_, ACC, "Int_protObj");
            EmitJAL(str_, "Int_init");

            // 2. load e1.val into t1
            EmitLW(str_, temp_space, T1);
            EmitLW(str_, GetRegOffset(12, T1), T1);

            // 3. neg
            EmitNEG(str_, T1, T1);

            // 4. store result into ACC field
            EmitSW(str_, T1, GetRegOffset(12, ACC));

            // 5. free temp space
            FreeTempSpace(env, 1);
        }

        public void HandleLt(Lt lt, Env env)
        {
            // 1. evaluate e1
            HandleExpression(lt.Exp1, env);

            // 2. allocate temp space for e1 result
            string e1_t = GetNextTempSpace(env);

            // 3. store e1 value into e1_t
            EmitSW(str_, ACC, e1_t);

            // 4. evaluate e2
            HandleExpression(lt.Exp2, env);

            // 5. allocate temp space for e2 result
            string e2_t = GetNextTempSpace(env);

            // 6. store e2 value into e2_t
            EmitSW(str_, ACC, e2_t);

            // 7. load true
            str_.WriteLine("\tla\t" + ACC + "\t" + BOOLCONST_TRUE_REF);

            // 8. load e1 into t1
            EmitLW(str_, e1_t, T1);

            // 9. load e1.val into t1
            EmitLW(str_, GetRegOffset(12, T1), T1);

            // 10. load e2 into t2
            EmitLW(str_, e2_t, T2);

            // 11. load e2.val into t2
            EmitLW(str_, GetRegOffset(12, T2), T2);

            // 12. if t1 < t2 then branch to true else branch to false
            string label = AllocateNewJumpLabel();
            EmitBLT(str_, T1, T2, label);

            // 13. load false
            str_.WriteLine("\tla\t" + ACC + "\t" + BOOLCONST_FALSE_REF);

            // 14. true label
            str_.WriteLine(label + ":");

            // 15. free temp space
            FreeTempSpace(env, 2);
        }

        public void HandleEq(Eq eq, Env env)
        {
            // 1. evaluate e1
            HandleExpression(eq.Exp1, env);

            // 2. allocate temp space for e1 result
            string e1_t = GetNextTempSpace(env);

            // 3. store e1 value into e1_t
            EmitSW(str_, ACC, e1_t);

            // 4. evaluate e2
            HandleExpression(eq.Exp2, env);

            // 5. allocate temp space for e2 result
            string e2_t = GetNextTempSpace(env);

            // 6. store e2 value into e2_t
            EmitSW(str_, ACC, e2_t);

            // 7. A0 = true
            str_.WriteLine("\tla\t" + ACC + "\t" + BOOLCONST_TRUE_REF);

            // 8. load e1 into t1
            EmitLW(str_, e1_t, T1);
            // 9. load e2 into t2
            EmitLW(str_, e2_t, T2);

            string label = AllocateNewJumpLabel();

            // 10. use equality_test given in trap.handler
            EmitBEQ(str_, T1, T2, label);

            // 11. if two pointers point to different objects, use equality_test
            // given in trap.handler
            // A1 = false
            str_.WriteLine("\tla\t" + A1 + "\t" + BOOLCONST_FALSE_REF);
            EmitJAL(str_, "equality_test");

            // 12. label
            str_.WriteLine(label + ":");

            // 13. free temp space
            FreeTempSpace(env, 2);
        }

        public void HandleLeq(Leq leq, Env env)
        {
            // 1. evaluate e1
            HandleExpression(leq.Exp1, env);

            // 2. allocate temp space for e1 result
            string e1_t = GetNextTempSpace(env);

            // 3. store e1 value into e1_t
            EmitSW(str_, ACC, e1_t);

            // 4. evaluate e2
            HandleExpression(leq.Exp2, env);

            // 5. allocate temp space for e2 result
            string e2_t = GetNextTempSpace(env);

            // 6. store e2 value into e2_t
            EmitSW(str_, ACC, e2_t);

            // 7. load true
            str_.WriteLine("\tla\t" + ACC + "\t" + BOOLCONST_TRUE_REF);

            // 8. load e1 into t1
            EmitLW(str_, e1_t, T1);

            // 9. load e1.val into t1
            EmitLW(str_, GetRegOffset(12, T1), T1);

            // 10. load e2 into t2
            EmitLW(str_, e2_t, T2);

            // 11. load e2.val into t2
            EmitLW(str_, GetRegOffset(12, T2), T2);

            // 12. if t1 < t2 then branch to true else branch to false
            string label = AllocateNewJumpLabel();
            EmitBLE(str_, T1, T2, label);

            // 13. load false
            str_.WriteLine("\tla\t" + ACC + "\t" + BOOLCONST_FALSE_REF);

            // 14. true label
            str_.WriteLine(label + ":");

            // 15. free temp space
            FreeTempSpace(env, 2);
        }

        public void HandleComp(Comp comp, Env env)
        {
            // 1. evaluate e1
            HandleExpression(comp.Exp, env);

            // 2. load e1.val into t1
            EmitLW(str_, GetRegOffset(12, ACC), T1);

            // 3. load true
            str_.WriteLine("\tla\t" + ACC + "\t" + BOOLCONST_TRUE_REF);

            // 4. if e1 is false then branch true else branch to else
            string label = AllocateNewJumpLabel();
            EmitBEQZ(str_, T1, label);

            // 5. load false
            str_.WriteLine("\tla\t" + ACC + "\t" + BOOLCONST_FALSE_REF);

            // 6. true label
            str_.WriteLine(label + ":");
        }

        public void HandleSub(Sub sub, Env env)
        {
            // 1. evaluate e1
            HandleExpression(sub.Exp1, env);

            // 2. allocate temp space for e1 result
            string e1_t = GetNextTempSpace(env);

            // 3. store e1 value into e1_t
            EmitSW(str_, ACC, e1_t);

            // 4. evaluate e2
            HandleExpression(sub.Exp2, env);

            // 5. allocate temp space for e2 result
            string e2_t = GetNextTempSpace(env);

            // 6. store e2 value into e2_t
            EmitSW(str_, ACC, e2_t);

            // 7. load Int_protObj into ACC
            EmitLA(str_, ACC, "Int_protObj");

            // 8. call Object.copy and Int_init
            EmitJAL(str_, "Object.copy");
            EmitJAL(str_, "Int_init");

            // 9. load e1 into t1
            EmitLW(str_, e1_t, T1);

            // 10. load e1.val into t1
            EmitLW(str_, GetRegOffset(12, T1), T1);

            // 11. load e2 into t2
            EmitLW(str_, e2_t, T2);

            // 12. load e2.val into t2
            EmitLW(str_, GetRegOffset(12, T2), T2);

            // 13. sub
            EmitSUB(str_, T1, T1, T2);

            // 14. store add result into ACC filed
            EmitSW(str_, T1, GetRegOffset(12, ACC));

            // 15. free temp space
            FreeTempSpace(env, 2);
        }

        public void HandleMul(Mul mul, Env env)
        {
            // 1. evaluate e1
            HandleExpression(mul.Exp1, env);

            // 2. allocate temp space for e1 result
            string e1_t = GetNextTempSpace(env);

            // 3. store e1 value into e1_t
            EmitSW(str_, ACC, e1_t);

            // 4. evaluate e2
            HandleExpression(mul.Exp2, env);

            // 5. allocate temp space for e2 result
            string e2_t = GetNextTempSpace(env);

            // 6. store e2 value into e2_t
            EmitSW(str_, ACC, e2_t);

            // 7. load Int_protObj into ACC
            EmitLA(str_, ACC, "Int_protObj");

            // 8. call Object.copy and Int_init
            EmitJAL(str_, "Object.copy");
            EmitJAL(str_, "Int_init");

            // 9. load e1 into t1
            EmitLW(str_, e1_t, T1);

            // 10. load e1.val into t1
            EmitLW(str_, GetRegOffset(12, T1), T1);

            // 11. load e2 into t2
            EmitLW(str_, e2_t, T2);

            // 12. load e2.val into t2
            EmitLW(str_, GetRegOffset(12, T2), T2);

            // 13. mul
            EmitMUL(str_, T1, T1, T2);

            // 14. store add result into ACC filed
            EmitSW(str_, T1, GetRegOffset(12, ACC));

            // 15. free temp space
            FreeTempSpace(env, 2);
        }

        public void HandleDivide(Divide divide, Env env)
        {
            // 1. evaluate e1
            HandleExpression(divide.Exp1, env);

            // 2. allocate temp space for e1 result
            string e1_t = GetNextTempSpace(env);

            // 3. store e1 value into e1_t
            EmitSW(str_, ACC, e1_t);

            // 4. evaluate e2
            HandleExpression(divide.Exp2, env);

            // 5. allocate temp space for e2 result
            string e2_t = GetNextTempSpace(env);

            // 6. store e2 value into e2_t
            EmitSW(str_, ACC, e2_t);

            // 7. load Int_protObj into ACC
            EmitLA(str_, ACC, "Int_protObj");

            // 8. call Object.copy and Int_init
            EmitJAL(str_, "Object.copy");
            EmitJAL(str_, "Int_init");

            // 9. load e1 into t1
            EmitLW(str_, e1_t, T1);

            // 10. load e1.val into t1
            EmitLW(str_, GetRegOffset(12, T1), T1);

            // 11. load e2 into t2
            EmitLW(str_, e2_t, T2);

            // 12. load e2.val into t2
            EmitLW(str_, GetRegOffset(12, T2), T2);

            // 13. divide
            EmitDIV(str_, T1, T1, T2);

            // 14. store add result into ACC filed
            EmitSW(str_, T1, GetRegOffset(12, ACC));

            // 15. free temp space
            FreeTempSpace(env, 2);
        }

        public void HandlePlus(Plus plus, Env env)
        {
            // 1. evaluate e1
            HandleExpression(plus.Exp1, env);

            // 2. allocate temp space for e1 result
            string e1_t = GetNextTempSpace(env);

            // 3. store e1 value into e1_t
            EmitSW(str_, ACC, e1_t);

            // 4. evaluate e2
            HandleExpression(plus.Exp2, env);


            // 5. allocate temp space for e2 result
            string e2_t = GetNextTempSpace(env);

            // 6. store e2 value into e2_t
            EmitSW(str_, ACC, e2_t);

            // 7. load Int_protObj into ACC
            EmitLA(str_, ACC, "Int_protObj");

            // 8. call Object.copy and Int_init
            EmitJAL(str_, "Object.copy");
            EmitJAL(str_, "Int_init");

            // 9. load e1 into t1
            EmitLW(str_, e1_t, T1);

            // 10. load e1.val into t1
            EmitLW(str_, GetRegOffset(12, T1), T1);

            // 11. load e2 into t2
            EmitLW(str_, e2_t, T2);

            // 12. load e2.val into t2
            EmitLW(str_, GetRegOffset(12, T2), T2);

            // 13. add
            EmitADD(str_, T1, T1, T2);

            // 14. store add result into ACC filed
            EmitSW(str_, T1, GetRegOffset(12, ACC));

            // 15. free temp space
            FreeTempSpace(env, 2);
        }

        public void HandleLet(Let let, Env env)
        {
            var c_syms = new ConstantSymbol();
            string id_name = let.Identifier.str_;
            string type = let.TypeDecl.str_;
            // 0. evalute init or set default value
            if (!(let.Init is NoExpr))
            {
                HandleExpression(let.Init, env);
            }
            else
            {
                if (type == c_syms.Int.str_)
                {
                    str_.WriteLine(LA + ACC + "\t" + SymbolUtils.IntTable.Lookup("0").ref_);
                }
                else if (type == c_syms.Bool.str_)
                {
                    str_.WriteLine(LA + ACC + "\t" + BOOLCONST_FALSE_REF);
                }
                else if (type == c_syms.Str.str_)
                {
                    str_.WriteLine(LA + ACC + "\t" + SymbolUtils.StrTable.Lookup("").ref_);
                }
                else
                {
                    str_.WriteLine(LI + ACC + "\t" + "0");
                }
            }

            // 1. allocate temp space
            string temp_space = GetNextTempSpace(env);

            // 2. create a new scope for let
            env.loc.EnterScope();
            env.loc.AddMapping(id_name, temp_space);

            // 3. store init value into temp_space
            EmitSW(str_, ACC, temp_space);

            // 4. evalute body
            HandleExpression(let.Body, env);

            // 5. free temp space
            FreeTempSpace(env, 1);

            // 6. exit let scope
            env.loc.ExitScope();
        }

        public void HandleBlock(Block block, Env env)
        {
            foreach (var e in block.Body)
                HandleExpression(e, env);
        }

        static int cnt = 0;
        string AllocateNewJumpLabel()
        {
            return "label" + cnt++;
            /*std::ostringstream oss;
            oss << "label" << cnt++;
            return oss.str();*/
        }

        public string GetNextTempSpace(Env env)
        {
            int offset = -env.next_free_temp_space;
            string temp_space = GetRegOffset(offset, FP);
            env.next_free_temp_space += 4;
            return temp_space;
        }

        public void FreeTempSpace(Env env, int nWords)
        {
            env.next_free_temp_space -= nWords * 4;
        }

        public void EmitClassDirectParentTab()
        {
            var c_syms = new ConstantSymbol();
            str_.WriteLine(CLASS_DIRECT_PARENT_TAB + ":");
            for (int i = 0; i < tag_to_class_name_.Count; ++i)
            {
                string class_name = tag_to_class_name_[i];

                ClassInfo cinfo = null;
                bool valid = class_info_tab_.TryGetValue(class_name, out cinfo);

                if (!valid)
                {
                    /*CoolDumpError(cerr)
                      << "class_info_tab cannot find " << class_name << endl;
                    exit(-1);*/
                }

                int parent_tag_no = -1;
                string parent_name = "";
                if (class_name != c_syms.Object.str_)
                {
                    parent_name = cinfo.parent_name;
                    valid = class_info_tab_.TryGetValue(parent_name, out cinfo);
                    if (!valid)
                    {
                        /*CoolDumpError(cerr)
                          << "class_info_tab cannot find " << parent_name << endl;
                        exit(-1);*/
                    }
                    parent_tag_no = cinfo.layout.class_tag;
                }
                str_.WriteLine(WORD + parent_tag_no + "#" + class_name + ", tag_no:" + i + ", " + parent_name + ", tag_no:" + parent_tag_no);
            }
        }

        public void HandleIntConst(IntConst i, Env env)
        {
            str_.WriteLine(LA + ACC + " " + SymbolUtils.IntTable.Lookup(i.Token.str_).ref_);
        }

        public void HandleStrConst(StringConst str, Env env)
        {
            str_.WriteLine(LA + ACC + " " + SymbolUtils.StrTable.Lookup(str.Token.str_).ref_);
        }

        public void HandleBoolConst(BoolConst b, Env env)
        {
            str_.WriteLine(LA + ACC + " " + (b.Value ? BOOLCONST_TRUE_REF : BOOLCONST_FALSE_REF));
        }

        public void EmitClassProtObjTab()
        {
            str_.WriteLine(CLASS_PROT_OBJ_TAB + ":");
            for (int i = 0; i < tag_to_class_name_.Count; ++i)
            {

                string class_name = tag_to_class_name_[i];
                str_.WriteLine(WORD + class_name + PROTOBJ_SUFFIX);
            }
        }

        public void EmitClassInitTab()
        {

            str_.WriteLine(CLASS_INIT_TAB + ":");
            for (int i = 0; i < tag_to_class_name_.Count; ++i)
            {
                string class_name = tag_to_class_name_[i];
                str_.WriteLine(WORD + class_name + CLASSINIT_SUFFIX);
            }
        }

        public string GetArgumentOffset(int nth, int len)
        {

            return 4 * (len - 1 - nth + 3) + "($fp)";
            /*std::ostringstream oss;
            oss << 4 * (len - 1 - nth + 3) << "($fp)";
            return oss.str();*/
        }

        public string GetRegOffset(int offset, string reg)
        {
            return offset + "(" + reg + ")";
            /*std::ostringstream oss;
            oss << offset << "(" << reg << ")";
            return oss.str();*/
        }

    }

}





        
