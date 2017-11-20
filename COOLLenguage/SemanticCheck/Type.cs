using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COOLLenguage.SemanticCheck.AST;

namespace COOLLenguage.SemanticCheck
{
    public class Type : Node, IType
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

        public Type TypeInherited
        {
            get;set;
        }

        IType IType.TypeInherited
        {
            get
            {
                return (TypeInherited);
            }

            set
            {
                TypeInherited = (Type)value;
            }
        }

        public Type(string type)
        {
            Name = type;
            attrs = new Dictionary<string, IAttribute>();
            methods = new Dictionary<string, IMethod>();
        }

        public IAttribute GetAttribute(string name)
        {
            try { return attrs[name]; }
            catch (KeyNotFoundException)
            {
                return default(AST.Attribute);
            }

        }

        public override bool Equals(object obj)
        {
            if(obj is Type)
            {
               return (obj as Type).Name == Name;
            }
            return false;
        }

        public IMethod GetMethod(string name)
        {
            try { return methods[name]; }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public bool DefineAttribute(string name, IType type)
        {
            if (GetAttribute(name) != default(AST.Attribute))
            {
                attrs.Add(name, new AST.Attribute(name, type));
                return true;
            }
            else
                return false;
        }

        public bool DefineMethod(string name, IType returnType, string[] arguments, IType[] argumentTypes)
        {

            if (methods.ContainsKey(name))
                return false;
                List<Param> arg = new List<Param>();
                for (int i = 0; i < arguments.Length; i++)
                    arg.Add(new Param(argumentTypes[i], arguments[i]));
                methods.Add(name,  new Method(arg, returnType) );
                return true;

        }

        public virtual IMethod GetMethodInherited(string name)
        {
            IMethod m;
            if (methods.TryGetValue(name, out m))
                return m;
            if (TypeInherited.TypeInherited != null)
                return TypeInherited.GetMethodInherited(name);
            return null;
        }

        public virtual IAttribute GetAttributeInherited(string name)
        {
            if (TypeInherited == null)
                return null;
            try
            {
                return TypeInherited.attrs[name];
            }
            catch (KeyNotFoundException)
            {
                IAttribute attr;
                if (attrs.TryGetValue(name, out attr))
                    return attr;
                else return null;

            }
        }

        public bool IsInheritedClass(string type)
        {
            if (type == Name)
                return true;
            if (TypeInherited != null)
                if ( TypeInherited.Name == type)
                    return true;
                else
                    return TypeInherited.IsInheritedClass(type);
            else
                return false;
        }
    }
}
