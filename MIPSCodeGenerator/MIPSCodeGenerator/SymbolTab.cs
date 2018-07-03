using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPSCodeGenerator
{
    public static class SymbolUtils
    {
        public static int cnt = 0;
        public static string SymbolRefGenerator()
        {
            return (cnt++).ToString();
        }
        public static SymbolTable IdTable = new SymbolTable();
        public static SymbolTable StrTable = new SymbolTable();
        public static SymbolTable IntTable = new SymbolTable();
    }

    public class Symbol
    {
        public string str_ { get; set; }
        public int index_ { get; set; }
        public string ref_ { get; set; }
        public Symbol(string str, int index)
        {
            this.str_ = str;
            this.index_ = index;
            this.ref_ = "_" + SymbolUtils.SymbolRefGenerator() + "_symref";
        }
        public override string ToString()
        {
            return str_ + ":" + ref_;
        }
        public static implicit operator Symbol(string str)
        {
            return new Symbol(str, 0);
        }
    }

    public class SymbolTable
    {
        public Dictionary<string, Symbol> table = new Dictionary<string, Symbol>();
        public int idx_cnt = 0;
        public Symbol AddString(string str)
        {
            if (str == null)
            {
                if (!table.ContainsKey(""))
                    table.Add("", new Symbol("", idx_cnt++));
                return table[""];
            }
            if (!table.ContainsKey(str))
                table.Add(str, new Symbol(str, this.idx_cnt++));
            return table[str];
        }
        public Symbol Lookup(string str)
        {
            if (str == null)
                return AddString("");
            return table.ContainsKey(str) ? table[str] : null;
        }
    }

    public class Scope
    {
        public Stack<Dictionary<string, string>> scope = new Stack<Dictionary<string, string>>();
        public void EnterScope()
        {
            scope.Push(new Dictionary<string, string>());
        }
        public void ExitScope()
        {
            if (scope.Count > 0)
                scope.Pop();
        }
        public void AddMapping(string key, string value)
        {
            if (scope.Count != 0)
                scope.Peek().Add(key, value);
        }

        // lookup current scope
        public string LookupCurrentScope(string key)
        {
            if (scope.Count == 0)
                return null;
            var table = scope.Peek();
            return table.ContainsKey(key) ? table[key] : null;
        }

        // lookup from current scope to topest scope, and return the first found
        // mapping
        public string Lookup(string key)
        {
            if (scope.Count == 0)
                return null;

            foreach (var item in scope)
                if (item.ContainsKey(key))
                    return item[key];
            return null;
        }

    }

    public class ConstantSymbol
    {
        public Symbol arg { get; set; }
        public Symbol arg2 { get; set; }
        public Symbol Bool { get; set; }
        public Symbol concat { get; set; }
        public Symbol cool_abort { get; set; }
        public Symbol copy { get; set; }
        public Symbol Int { get; set; }
        public Symbol in_int { get; set; }
        public Symbol in_string { get; set; }
        public Symbol IO { get; set; }
        public Symbol length { get; set; }
        public Symbol Main { get; set; }
        public Symbol main_meth { get; set; }
        public Symbol No_class { get; set; }
        public Symbol No_type { get; set; }
        public Symbol Object { get; set; }
        public Symbol out_int { get; set; }
        public Symbol out_string { get; set; }
        public Symbol prim_slot { get; set; }
        public Symbol self { get; set; }
        public Symbol SELF_TYPE { get; set; }
        public Symbol Str { get; set; }
        public Symbol str_field { get; set; }
        public Symbol substr { get; set; }
        public Symbol type_name { get; set; }
        public Symbol val { get; set; }
        public Symbol basic_fn { get; set; }
        public ConstantSymbol()
        {
            arg = SymbolUtils.IdTable.AddString("arg");
            arg2 = SymbolUtils.IdTable.AddString("arg2");
            Bool = SymbolUtils.IdTable.AddString("Bool");
            concat = SymbolUtils.IdTable.AddString("concat");
            cool_abort = SymbolUtils.IdTable.AddString("abort");
            copy = SymbolUtils.IdTable.AddString("copy");
            Int = SymbolUtils.IdTable.AddString("Int");
            in_int = SymbolUtils.IdTable.AddString("in_int");
            in_string = SymbolUtils.IdTable.AddString("in_string");
            IO = SymbolUtils.IdTable.AddString("IO");
            length = SymbolUtils.IdTable.AddString("length");
            Main = SymbolUtils.IdTable.AddString("Main");
            main_meth = SymbolUtils.IdTable.AddString("main");
            No_class = SymbolUtils.IdTable.AddString("_no_class");
            No_type = SymbolUtils.IdTable.AddString("_no_type");
            Object = SymbolUtils.IdTable.AddString("Object");
            out_int = SymbolUtils.IdTable.AddString("out_int");
            out_string = SymbolUtils.IdTable.AddString("out_string");
            prim_slot = SymbolUtils.IdTable.AddString("_prim_slot");
            self = SymbolUtils.IdTable.AddString("self");
            SELF_TYPE = SymbolUtils.IdTable.AddString("SELF_TYPE");
            Str = SymbolUtils.IdTable.AddString("String");
            str_field = SymbolUtils.IdTable.AddString("_str_field");
            substr = SymbolUtils.IdTable.AddString("substr");
            type_name = SymbolUtils.IdTable.AddString("type_name");
            val = SymbolUtils.IdTable.AddString("_val");
            basic_fn = SymbolUtils.StrTable.AddString("basic_class");
        }

    }
}





    

