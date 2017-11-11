using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST
{
    public class Dispatch : Expression
    {
        string name;
        string methodName;
        List<Expression> arg;

        public string Name { get { return name; } }
        public string MethodName { get { return methodName; } }
        public List<Expression> Arg { get { return arg; } }

        public Dispatch(string methodname, List<Expression>arg)
        {
            methodName = methodname;
            this.arg = arg;
        }

        public Dispatch(string name, string methodname, List<Expression> arg)
        {
            this.name = name;
            methodName = methodname;
            this.arg = arg;
        }

        public override IType ComputedType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
