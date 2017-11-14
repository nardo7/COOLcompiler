using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Method : Feature, IMethod
    {
        List<Param> arguments;
        Expression body;
        string returnType;
        public List<Param> Arguments
        {
            get
            {
                return arguments;
            }
        }

        public Expression Body
        {
            get
            {
                return body;
            }
            set { body = value; }
        }

        public string ReturnType
        {
            get
            {
                return returnType;
            }
            set { returnType = value; }
        }
        

        public Method(string Name, List<Param> arguments, string returnType, Expression body)
        {
            this.arguments = arguments;
            this.body = body;
            this.returnType = returnType;
            this.Name = Name;
        }

        public Method()
        {
            arguments = new List<Param>();
        }
    }
}
