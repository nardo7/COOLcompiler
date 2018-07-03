using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCompilator
{
    public class TokenTable
    {
        public Dictionary<string, Symbol> tbl { get; set; }
        public Dictionary<string, int> idx_tbl { get; set; }
        public int count { get; set; }
        public TokenTable()
        {
            this.count = 1;
            tbl = new Dictionary<string, Symbol>();
            idx_tbl = new Dictionary<string, int>();
        }
        public Symbol add(string id)
        {
            if(!tbl.ContainsKey(id))
            {
                tbl.Add(id, new Symbol(id));
                idx_tbl.Add(id, count);
                count++;
            }
            return tbl[id];
        }
        public int get_idx(string id)
        {
            return idx_tbl.ContainsKey(id) ? idx_tbl[id] : -1;
        }
    }

    public class IdentifierTable:TokenTable
    {

    }
    public class IntTable : TokenTable
    {

    }
    public class StringTable : TokenTable
    {

    }
    public static class tables
    {
        public static IdentifierTable idtable = new IdentifierTable();
        public static IdentifierTable inttable = new IdentifierTable();
        public static IdentifierTable stringtable = new IdentifierTable();
    }


}
