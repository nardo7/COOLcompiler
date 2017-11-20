using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public class ClassDef:Node, IType
    {
        public string Name { get; }
        Dictionary<string, IAttribute> attrs;
        Dictionary<string, IMethod> methods;

      
        public IEnumerable<IAttribute> Attributes
        {
            get
            {
                return attrs.Values;
            }
        }

        public IEnumerable<IMethod> Methods
        {
            get
            {
                return methods.Values;
            }
        }

        public IType TypeInherited
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public ClassDef(string type)
        {
            Name = type;
            attrs = new Dictionary<string, IAttribute>();
            methods = new Dictionary<string, IMethod>();
        }

        public IAttribute GetAttribute(string name)
        {
            try { return attrs[name]; }
            catch(KeyNotFoundException)
            {
                return default(Attribute);
            }
                
        }

        public IMethod GetMethod(string name)
        {
            try { return methods[name]; }
            catch (KeyNotFoundException)
            {
                return default(IMethod);
            }
        }

        public bool DefineAttribute(string name, IType type)
        {
            if (GetAttribute(name) == default(Attribute))
            {
                attrs.Add(name, new Attribute(name, type));
                return true;
            }
            else
                return false;
        }

        public bool DefineMethod(string name, IType returnType, string[] arguments, IType[] argumentTypes)
        {
            var method = GetMethod(name);
            
                var defineMethod = true;
            if (method != default(Method)) {
                var argtypes = method.Arguments.Select(t => t.Type);
                if (method.Arguments.Count() == arguments.Length)
                {
                    foreach (var item in argumentTypes)
                    {
                        if (!argtypes.Contains(item))
                        {
                            defineMethod = true;
                            break;
                        }
                        defineMethod = false;
                    }
                    
                }
            }
            if (defineMethod)
            {
                List<Param> arg = new List<Param>();
                for (int i = 0; i < arguments.Length; i++)
                    arg.Add(new Param(argumentTypes[i], arguments[i]));
                methods.Add(name, new Method(arg, returnType));
                return true;
            }
            else return false;
            
        }

        public IAttribute GetAttributeInherited(string name)
        {
            throw new NotImplementedException();
        }

        public List<IMethod> GetMethodInherited(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsInheritedClass(string type)
        {
            throw new NotImplementedException();
        }

        IMethod IType.GetMethodInherited(string name)
        {
            throw new NotImplementedException();
        }
    }
}
