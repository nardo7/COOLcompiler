using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPSCodeGenerator
{
    public static class Helper
    {
        public static string GetClassLabelName(string class_name)
        {
            return class_name + "_" + "protObj";
        }

        public static string GetClassDispatchTabName(string class_name)
        {
            return class_name + "_" + "dispatch_tab";
        }

        public static string GetClassTagName(string class_name)
        {
            string tag = "_" + class_name + "_" + "tag";
            var c_syms = new ConstantSymbol();
            if (class_name == c_syms.Bool.str_ || class_name == c_syms.Int.str_ || class_name == c_syms.Str.str_)
            {
                tag = tag.ToLower();

            }
            return tag;
        }

        public static string GetClassInitMethod(string class_name)
        {
            return class_name + "_init";
        }
    }
}
