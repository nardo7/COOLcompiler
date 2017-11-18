using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COOLLenguage.SemanticCheck.AST;

namespace COOLLenguage.SemanticCheck
{
    public class Context : IContext
    {
        List<Context> childs;
        Dictionary<string, IType> types;
        Dictionary<string, IType> vars;

        public Context()
        {
            types = new Dictionary<string, IType>();
            childs = new List<Context>();
            vars = new Dictionary<string, IType>();
        }
        public IContext CreateChildContext()
        {
            var cont = new Context();
            childs.Add(cont);
            return cont;
        }

        public IType CreateType(string name)
        {
            var typ = new AST.ClassDef(name);
            types.Add(name, typ);
            return typ;
        }

        public bool DefineVariable(string symbol, IType type)
        {
            if (vars.ContainsKey(symbol))
                return false;
            else
                vars.Add(symbol, type);
            return true;
        }

        public IType GetType(string typeName)
        {
            try
            {
                return types[typeName];
            }
            catch (KeyNotFoundException)
            {
                return default(AST.ClassDef);
            }
                
        }

        public IType GetTypeFor(string symbol)
        {
            try
            {
                return vars[symbol];
            }
            catch (KeyNotFoundException)
            {
                return default(AST.ClassDef);
            }
        }
    }
}
