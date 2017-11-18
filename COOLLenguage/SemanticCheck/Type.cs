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

        public Type(string type)
        {
            Name = type;
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
                return default(IMethod);
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
            if (GetAttribute(name) != default(Method))
            {
                List<Param> arg = new List<Param>();
                for (int i = 0; i < arguments.Length; i++)
                    arg.Add(new Param(argumentTypes[i], arguments[i]));
                methods.Add(name, new Method(arg, returnType));
                return true;
            }
            else
                return false;
        }
    }
}
