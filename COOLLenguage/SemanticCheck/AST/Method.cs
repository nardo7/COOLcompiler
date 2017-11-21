using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public class Method : Feature, IMethod
    {
        List<Param> arguments;
        Expression body;
        IType returnType;
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
        }

        public IType ReturnType
        {
            get
            {
                return returnType;
            }
        }

      

        IEnumerable<IAttribute> IMethod.Arguments
        {
            get
            {
                return arguments;
            }
        }

        public Method(string name, List<Param> arguments, IType returnType)
        {
            this.arguments = arguments;
            this.returnType = returnType;
            Name = name;
        }
    }
}
