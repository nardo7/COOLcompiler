using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCompilator
{

    public class Symbol
    {
        public string value { get; set; }
        public Symbol(string value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return value;
        }
        public override bool Equals(object obj)
        {
            try
            {
                var tmp = obj as Symbol;
                return tmp.value == value;
            }
            catch (Exception) { return false; }
        }
        public static bool operator <(Symbol s1, Symbol s2)
        {
            return s1.value.CompareTo(s2) == -1;
        }
        public static bool operator >(Symbol s1, Symbol s2)
        {
            return s1.value.CompareTo(s2) == 1;
        }
        public static bool operator ==(Symbol s1, Symbol s2)
        {
            return s1.value == s2.value;
        }
        public static bool operator !=(Symbol s1, Symbol s2)
        {
            return s1.value != s2.value;
        }
        public static implicit operator Symbol(string str)
        {
            return new Symbol(str);
        }
    }

    public class SymbolTable<K,T>
    {
        public Stack<Dictionary<K, T>> tbl { get; set; } = new Stack<Dictionary<K, T>>();
        public void enter_scope()
        {
            tbl.Push(new Dictionary<K, T>());
        }
        public void exit_scope()
        {
            tbl.Pop();
        }

        public void add(K key, T val)
        {
            tbl.Peek().Add(key, val);
        }
        public int count()
        {
            return tbl.Peek().Count;
        }
        public T probe(K key)
        {
            return tbl.Peek().ContainsKey(key) ? tbl.Peek()[key] : default(T);
        }
        public T lookup(K key)
        {
            foreach (var item in tbl)
                if (item.ContainsKey(key))
                    return item[key];
            return default(T);
        }

    }

}
