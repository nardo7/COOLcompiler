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
        Context Parent { get; set; }
        public Context()
        {
            types = new Dictionary<string, IType>();
            childs = new List<Context>();
            vars = new Dictionary<string, IType>();
        }
        public IContext CreateChildContext()
        {
            var cont = new Context();
            cont.Parent = this;
            childs.Add(cont);
            
            return cont;
        }

        public IType CreateType(string name)
        {
            try
            {
                var typ = new Type(name);
                types.Add(name, typ);
                return typ;
            }
            catch (ArgumentException)
            {
                return default(Type);
            }
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
            IType t;
            if (types.TryGetValue(typeName, out t))
                return t;
            else
                if (Parent != null)
            {
                return Parent.GetType(typeName);
            }
            else
                return null;
         
                
        }

        public IType GetTypeFor(string symbol)
        {
            IType t;
            if (vars.TryGetValue(symbol, out t))
                return t;
            else
                if (Parent != null)
            {
                return Parent.GetTypeFor(symbol);
            }
            else
                return null;
        }
    }
}
