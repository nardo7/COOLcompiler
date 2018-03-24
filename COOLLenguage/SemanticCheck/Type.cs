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
        public List<IType> ChildTypes { get; }

        public int LevelHierachy { get; set; }

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
            ChildTypes = new List<IType>();
        }

        public override string ToString()
        {
            return "class "+Name;
        }

        public IAttribute GetAttribute(string name)
        {
            try { return attrs[name]; }
            catch (KeyNotFoundException)
            {
                var a = GetAttributeInherited(name);
                if (a != null)
                {
                    attrs.Add(a.Name, a);
                    return a;
                }
                else
                    return null;
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
                var m = GetMethodInherited(name);
                if (m == null)
                    return null;
                else {
                    methods.Add(m.Name, m);
                    return m;
                }
            }
        }

        public bool DefineAttribute(string name, IType type)
        {
            if (GetAttribute(name) == null)
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
            methods.Add(name,  new Method(name,arg, returnType) );
            return true;

        }

        public virtual IMethod GetMethodInherited(string name)
        {
            IMethod m;
            if (TypeInherited.methods.TryGetValue(name, out m))
                return m;
            if (TypeInherited.TypeInherited != null)
                return TypeInherited.GetMethodInherited(name);
            return null;
        }

        public virtual IAttribute GetAttributeInherited(string name)
        {
            IAttribute a;
            if (TypeInherited.attrs.TryGetValue(name, out a))
                return a;
            if (TypeInherited.TypeInherited != null)
                return TypeInherited.GetAttributeInherited(name);
            return null;
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
