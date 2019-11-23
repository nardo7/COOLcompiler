using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPSCodeGenerator
{
    public class Node
    {
        public Class ast_node_; // pointes to the ast node of this class
        public string name;
        public Dictionary<string, List<string>> method_type_tab;
        public Dictionary<string, List<string>> attr_type_tab;
        public Dictionary<string, List<Tuple<string, string>>> method_sig_tab;
        public Dictionary<string, List<Tuple<string, string>>> attr_sig_tab;
        public Node parent;

        public List<Node> children = new List<Node>();
        public Node(string v_name, Class v_class)
        {
            method_type_tab = new Dictionary<string, List<string>>();
            attr_type_tab = new Dictionary<string, List<string>>();
            method_sig_tab = new Dictionary<string, List<Tuple<string, string>>>();
            attr_sig_tab = new Dictionary<string, List<Tuple<string, string>>>();

            ast_node_ = v_class;
            name = v_name;
        }
        public override string ToString()
        {
            return name + " Node";
        }
    }
    public class LoopDetector
    {
        public Dictionary<string, bool> instack_ = new Dictionary<string, bool>();
        public Dictionary<string, bool> visited_ = new Dictionary<string, bool>();
        public HashSet<string> loop_nodes_ = new HashSet<string>();
        public bool RecursiveHelper(Node node, HashSet<string> loop_nodes)
        {
            bool ret = false;
            visited_[node.name] = true;
            instack_[node.name] = true;
            foreach (var ch in node.children)
            {
                if (visited_.ContainsKey(ch.name) && !visited_[ch.name])
                {
                    ret |= RecursiveHelper(ch, loop_nodes);
                }
                // found loop
                if (instack_.ContainsKey(ch.name) && instack_[ch.name])
                {
                    foreach (var it in instack_)
                    {
                        if (it.Value)
                        {
                            loop_nodes.Add(it.Key);
                        }
                    }
                    ret |= true;
                }
            }
            instack_[node.name] = false;
            return ret;
        }
        public bool operator_(Dictionary<string, Node> nodes)
        {
            bool ret = false;
            loop_nodes_.Clear();
            instack_.Clear();
            visited_.Clear();
            foreach (var p in nodes)
            {
                if (visited_.ContainsKey(p.Key) && visited_[p.Key])
                    continue;
                ret |= RecursiveHelper(p.Value, loop_nodes_);
            }

            return ret;
        }
    }
    public class InheritanceTree
    {

        public Dictionary<string, Node> nodes_tab_ = new Dictionary<string, Node>();
        public List<Class> user_classes_ = new List<Class>();
        public List<Class> basic_classes_ = new List<Class>();
        public Node root_;
        public HashSet<string> basic_classes_str_set_ = new HashSet<string>();
        public HashSet<string> user_classes_str_set_ = new HashSet<string>();
        public HashSet<string> classes_str_set_ = new HashSet<string>();
        public Dictionary<string, List<string>> ancestor_tab_ = new Dictionary<string, List<string>>();

        public InheritanceTree(Program ast_root)
        {
            user_classes_ = ast_root.Classes;
            InitBasicClasses();
            CreateTree();
            CreateMethodAndAttrTypeInfoTab(root_);
            CreateAncestorTable(root_);
            //CheckRedefinedInheritedAttr(root_);
            //CheckRedefinedInheritedMethod(root_);
        }
        public void CreateTree()
        {
            // create node for basic classes
            foreach (var p in basic_classes_)
            {
                var class_name = p.Name.str_;
                nodes_tab_.Add(class_name, new Node(class_name, p));
                basic_classes_str_set_.Add(class_name);
                classes_str_set_.Add(class_name);
            }

            // create link in basic classes node
            foreach (var p in basic_classes_)
            {
                var class_name = p.Name.str_;
                var parent_name = p.Parent.str_;
                if (class_name == "Object")
                {
                    nodes_tab_[class_name].parent = null;
                    continue;
                }

                if (!nodes_tab_.ContainsKey(class_name))
                {
                    Console.Error.WriteLine("create link in basic classes node");
                    Console.Error.WriteLine("nodes_tab_ cannot find class_name " + class_name);
                    throw new Exception("mia");
                }
                if (!nodes_tab_.ContainsKey(parent_name))
                {
                    Console.Error.WriteLine("nodes_tab_ cannot find parent_name " + parent_name);
                    throw new Exception("mia");
                }

                var parent_node = nodes_tab_[parent_name];
                var curr_node = nodes_tab_[class_name];

                curr_node.parent = parent_node;
                parent_node.children.Add(curr_node);
            }

            if (!nodes_tab_.ContainsKey("Object"))
            {
                Console.Error.WriteLine("Set Root");
                Console.Error.WriteLine("nodes_tab_cannot find Object");
                throw new Exception("mia");
            }

            root_ = nodes_tab_["Object"];
            root_.parent = null;

            // add user defined classes into tree and check whether there is a
            // redefinition
            foreach (var p in user_classes_)
            {
                var class_name = p.Name.str_;
                if (nodes_tab_.ContainsKey(class_name) || class_name == "SELF_TYPE")
                {
                    if (basic_classes_str_set_.Contains(class_name) || class_name == "SELF_TYPE")
                    {
                        //
                    }
                    else
                    {
                        //
                    }
                    
                }

                nodes_tab_.Add(class_name, new Node(class_name, p));
                SymbolUtils.IdTable.AddString(class_name);
                user_classes_str_set_.Add(class_name);
                classes_str_set_.Add(class_name);
                SymbolUtils.StrTable.AddString(class_name);
            }

           

            // Check whether there is a class inherits from basic classes or
            // undefined classes
            foreach (var p in user_classes_)
            {
                var curr_name = p.Name.str_;
                var parent_name = p.Parent.str_;

                // inherits from basic classes except Object or IO
                if ((parent_name != "Object" && parent_name != "IO" && basic_classes_str_set_.Contains(parent_name)) || parent_name == "SELF_TYPE")
                {
                    //
                }

                // inherits from undefined classes
                if (!user_classes_str_set_.Contains(parent_name) && !basic_classes_str_set_.Contains(parent_name))
                {
                    //
                }

                // create link
                if (!nodes_tab_.ContainsKey(parent_name))
                {
                    //
                }

                if (!nodes_tab_.ContainsKey(curr_name))
                {
                    //
                }

                Node parent_node = nodes_tab_[parent_name];
                Node curr_node = nodes_tab_[curr_name];
                curr_node.parent = parent_node;
                parent_node.children.Add(curr_node);
            }

            
        }
        public void InitBasicClasses()
        {
            var constants = new ConstantSymbol();
            var arg = constants.arg;
            var arg2 = constants.arg2;
            var Bool = constants.Bool;
            var concat = constants.concat;
            var cool_abort = constants.cool_abort;
            var copy = constants.copy;
            var Int = constants.Int;
            var in_int = constants.in_int;
            var in_string = constants.in_string;
            var IO = constants.IO;
            var length = constants.length;
            var Main = constants.Main;
            var main_meth = constants.main_meth;
            var No_class = constants.No_class;
            var No_type = constants.No_type;
            var Object = constants.Object;
            var out_int = constants.out_int;
            var out_string = constants.out_string;
            var prim_slot = constants.prim_slot;
            var self = constants.self;
            var SELF_TYPE = constants.SELF_TYPE;
            var Str = constants.Str;
            var str_field = constants.str_field;
            var substr = constants.substr;
            var type_name = constants.type_name;
            var val = constants.val;
            var basic_fn = constants.basic_fn;

            #region installing baisics into ast
            Class Object_class =
              CGUtils.CreateClass(Object,
                          No_class,
                          basic_fn,
                          CGUtils.AppendFeature(
                            CGUtils.AppendFeature(
                              CGUtils.CreateSingleFeatures(
                                CGUtils.CreateMethod(cool_abort, Object,
                                             CGUtils.CreateNilFormals(), CGUtils.CreateNoExpr())),
                              CGUtils.CreateMethod(type_name, Str,
                                           CGUtils.CreateNilFormals(), CGUtils.CreateNoExpr())
                              ),
                            CGUtils.CreateMethod(copy, SELF_TYPE,
                                         CGUtils.CreateNilFormals(), CGUtils.CreateNoExpr())
                            )
                          );


            Class IO_class =
              CGUtils.CreateClass(IO,
                          Object,
                          basic_fn,
                          CGUtils.AppendFeature(
                            CGUtils.AppendFeature(
                              CGUtils.AppendFeature(
                                CGUtils.CreateSingleFeatures(
                                 CGUtils.CreateMethod(out_string, SELF_TYPE,
                                               CGUtils.CreateSingleFormals(CGUtils.CreateFormal(arg, Str)),
                                               CGUtils.CreateNoExpr())
                                ),
                                CGUtils.CreateMethod(out_int, SELF_TYPE,
                                             CGUtils.CreateSingleFormals(CGUtils.CreateFormal(arg, Int)),
                                             CGUtils.CreateNoExpr())

                             ),
                             CGUtils.CreateMethod(in_string, Str, CGUtils.CreateNilFormals(),
                                          CGUtils.CreateNoExpr())
                            ),
                            CGUtils.CreateMethod(in_int, Int, CGUtils.CreateNilFormals(), CGUtils.CreateNoExpr())
                          )
                         );

            Class Int_class =
              CGUtils.CreateClass(Int,
                          Object,
                          basic_fn,
                          CGUtils.CreateSingleFeatures(CGUtils.CreateAttr(val, prim_slot, CGUtils.CreateNoExpr()))
                         );

            Class Bool_class =
              CGUtils.CreateClass(Bool,
                          Object,
                          basic_fn,
                          CGUtils.CreateSingleFeatures(
                            CGUtils.CreateAttr(val, prim_slot, CGUtils.CreateNoExpr())
                          )
                         );

            Class Str_class =
              CGUtils.CreateClass(
                  Str,
                  Object,
                  basic_fn,
                  CGUtils.AppendFeature(
                    CGUtils.AppendFeature(
                     CGUtils.AppendFeature(
                        CGUtils.AppendFeature(
                          CGUtils.CreateSingleFeatures(CGUtils.CreateAttr(val, Int, CGUtils.CreateNoExpr())),
                          CGUtils.CreateAttr(str_field, prim_slot, CGUtils.CreateNoExpr())),
                        CGUtils.CreateMethod(length, Int, CGUtils.CreateNilFormals(), CGUtils.CreateNoExpr())
                      ),
                     CGUtils.CreateMethod(concat,
                                  Str,
                                  CGUtils.CreateSingleFormals(CGUtils.CreateFormal(arg, Str)),
                                  CGUtils.CreateNoExpr())
                    ),
                    CGUtils.CreateMethod(
                          substr,
                          Str,
                          CGUtils.AppendFormal(CGUtils.CreateSingleFormals(CGUtils.CreateFormal(arg, Int)),
                                       CGUtils.CreateFormal(arg2, Int)),
                          CGUtils.CreateNoExpr())
                  )
                );
            #endregion

            basic_classes_ = CGUtils.CreateSingleClasses(Object_class);
            basic_classes_ = CGUtils.AppendClass(basic_classes_, IO_class);
            basic_classes_ = CGUtils.AppendClass(basic_classes_, Int_class);
            basic_classes_ = CGUtils.AppendClass(basic_classes_, Bool_class);
            basic_classes_ = CGUtils.AppendClass(basic_classes_, Str_class);

            SymbolUtils.StrTable.AddString(constants.Object.str_);
            SymbolUtils.StrTable.AddString(constants.IO.str_);
            SymbolUtils.StrTable.AddString(constants.Int.str_);
            SymbolUtils.StrTable.AddString(constants.Bool.str_);
            SymbolUtils.StrTable.AddString(constants.Str.str_);
        }
        public Node LookupNode(string name)
        {
            if (!nodes_tab_.ContainsKey(name))
            {
                return null;
            }
            else
            {
                return nodes_tab_[name];
            }
        }

       
        public void CreateMethodAndAttrTypeInfoTab(Node node)
        {
            if (node == null)
            {
                return;
            }
  
            Class curr_class = node.ast_node_;
            foreach (var feature in curr_class.Features)
            {
                
                if (feature is Method)
                {
                    var method = (Method)feature;
                    var method_name = method.Name.str_;

                    List<Tuple<string, string>> m_sig = new List<Tuple<string, string>>();
                    List<string> sig = new List<string>();
                    // add method args type
                    foreach (var formal in method.Formals)
                    {
                        if (formal.Name.str_ == "self")
                        {
                            
                            continue;
                        }
                        if (formal.TypeDecl.str_ == "SELF_TYPE")
                        {
                            //
                        }
                        m_sig.Add(new Tuple<string, string>(formal.Name.str_, formal.TypeDecl.str_));
                        sig.Add(formal.TypeDecl.str_);

                        if (formal.TypeDecl.str_ != "SELF_TYPE" && !basic_classes_str_set_.Contains(formal.TypeDecl.str_) && !user_classes_str_set_.Contains(formal.TypeDecl.str_))
                        {
                            //
                        }
                    }
                    if (method.ReturnType.str_ != "SELF_TYPE" && !basic_classes_str_set_.Contains(method.ReturnType.str_) && !user_classes_str_set_.Contains(method.ReturnType.str_))
                    {
                       //
                    }
                    m_sig.Add(new Tuple<string, string>(method_name, method.ReturnType.str_));
                    // add method return type info
                    sig.Add(method.ReturnType.str_);
                    if (node.method_type_tab.ContainsKey(method_name))
                    {
                        
                        continue;
                    }

                    node.method_sig_tab.Add(method_name, m_sig);

                    node.method_type_tab.Add(method_name,sig);
                    
                    

                }
                else if (feature is Attr)
                {
                    var attr = (Attr)feature;
                    var attr_name = attr.Name.str_;
                    if (attr_name == "self")
                    {
                       
                        continue;
                    }
                    if (node.attr_type_tab.ContainsKey(attr_name))
                    {
                        
                        continue;
                    }

                    List<Tuple<string, string>> a_sig = new List<Tuple<string, string>>();
                    var sig = new List<string>();
                    node.attr_sig_tab.Add(attr_name, a_sig);
                    node.attr_type_tab.Add(attr_name, sig);
                    a_sig.Add(new Tuple<string, string>(attr.Name.str_,attr.TypeDecl.str_));
                    
                 
                    sig.Add(attr.TypeDecl.str_);
                  
                }
                else
                {
                    //
                }
            }

            foreach (var ch in node.children)
                CreateMethodAndAttrTypeInfoTab(ch);

        }


        static List<string> st = new List<string>();
        public void CreateAncestorTable(Node node)
        {

            List<string> ancestors = new List<string>(st);
            ancestor_tab_.Add(node.name, ancestors);

            st.Add(node.name);
            foreach (var ch in node.children)
            {
                CreateAncestorTable(ch);
            }
            st.RemoveAt(st.Count - 1);
        }

        // check whether current class defined an attribute already defined in its
        // super class
        public void CheckRedefinedInheritedAttr(Node node)
        {
            if (node == null)
            {
                return;
            }
            if (!ancestor_tab_.ContainsKey(node.name))
            {
                
            }
            // get current class's ancestors
            var ancestors = ancestor_tab_[node.name];
            var attr_type_tab = node.attr_type_tab;
            HashSet<string> redefined_attrs = new HashSet<string>();

            // for each attr defined in current class
            foreach (var it in attr_type_tab)
            {
                var attr_name = it.Key;
                // check current class's super classes
                foreach (var ancestor_name in ancestors)
                {
                    if (!nodes_tab_.ContainsKey(ancestor_name))
                    {
                        //
                    }
                    Node an = nodes_tab_[ancestor_name];

                    if (!an.attr_type_tab.ContainsKey(attr_name))
                    {
                        continue;
                    }

                    redefined_attrs.Add(attr_name);
                    //
                    break;
                }
            }

            // if current class has a redefined attribute, erase it
            foreach (var it in redefined_attrs)
                node.attr_type_tab.Remove(it);


            // recursively check
            foreach (var ch in node.children)
                CheckRedefinedInheritedAttr(ch);
        }



      
        public List<Tuple<string, string>> LookupMethodInfo(string class_name, string method_name)
        {
            if (!nodes_tab_.ContainsKey(class_name))
            {
                return null;
            }

            List<Tuple<string, string>> ret = null;

            var anode = nodes_tab_[class_name];

            if (anode.method_sig_tab.ContainsKey(method_name))
            {
                ret = anode.method_sig_tab[method_name];
            }

            if (ret == null)
            {
                if (!ancestor_tab_.ContainsKey(class_name))
                {
                    return null;
                }

                var ancestors = ancestor_tab_[class_name];
                foreach (var name in ancestors)
                {
                    if (!nodes_tab_.ContainsKey(name))
                    {
                       //
                    }
                    var an = nodes_tab_[name];
                    if (!an.method_sig_tab.ContainsKey(method_name))
                    {
                        continue;
                    }
                    ret = an.method_sig_tab[method_name];
                }
            }
            return ret;
        }

        public bool IsConformed(string type1, string type2)
        {
            if (type1 == type2)
            {
                return true;
            }

            bool ret = false;
            if (!ancestor_tab_.ContainsKey(type1))
            {
                //
            }
            var ancestors = ancestor_tab_[type1];
            foreach (var name in ancestors)
            {
                if (name != type2)
                {
                    continue;
                }
                ret = true;
                break;
            }
            return ret;
        }

        public bool IsChildOf(Node node1, Node node2)
        {
            if (node1 == node2)
            {
                return true;
            }
            bool ret = false;
            foreach (var ch in node2.children)
            {
                ret |= IsChildOf(node1, ch);
                if (ret)
                {
                    break;
                }
            }
            return ret;
        }

    }

}