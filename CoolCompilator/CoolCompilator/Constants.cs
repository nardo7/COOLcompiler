using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCompilator
{
    public static class Constants
    {
        public static Symbol OBJECT = tables.idtable.add("Object");
        public static Symbol INTEGER = tables.idtable.add("Int");
        public static Symbol BOOLEAN = tables.idtable.add("Bool");
        public static Symbol STRING = tables.idtable.add("String");
        public static Symbol MAIN = tables.idtable.add("Main");
        public static Symbol IO = tables.idtable.add("IO");
        public static Symbol SELF = tables.idtable.add("self");
        public static Symbol SELF_TYPE = tables.idtable.add("SELF_TYPE");
        public static Symbol NOCLASS = tables.idtable.add("NoClass");
        public static Symbol NOTYPE = tables.idtable.add("NoType");
        public static Symbol PRIM_SLOT = tables.idtable.add("prim_slot");
        public static Symbol ABORT = tables.idtable.add("abort");
        public static Symbol TYPE_NAME = tables.idtable.add("type_name");
        public static Symbol COPY = tables.idtable.add("copy");
        public static Symbol OUT_INT = tables.idtable.add("out_int");
        public static Symbol IN_INT = tables.idtable.add("in_int");
        public static Symbol IN_STRING = tables.idtable.add("in_string");
        public static Symbol OUT_STRING = tables.idtable.add("out_string");
        public static Symbol SUBSTR = tables.idtable.add("substr");
        public static Symbol LENGTH = tables.idtable.add("length");
        public static Symbol CONCAT = tables.idtable.add("concat");
        public static Symbol ARG = tables.idtable.add("arg");
        public static Symbol ARG2 = tables.idtable.add("arg2");
        public static Symbol VAL = tables.idtable.add("val");
        public static Symbol STR_FIELD = tables.idtable.add("str_field");
    }
}
