using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Dispatch : Expression
    {
        string name;
        string methodName;
        List<Expression> arg;
        Expression exprDispatched;

        public string Name { get { return name; } set { name = value; } }
        public string MethodName { get { return methodName; } set { methodName = value; } }
        public List<Expression> Arg { get { return arg; } }

        public Expression ExprDispatched
        {
            get
            {
                return exprDispatched;
            }
            set { exprDispatched = value; }

        }
        public Dispatch()
        {
            arg = new List<Expression>();
            name = "";
        }
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
        public Dispatch(Expression expr, string methodname, List<Expression> arg)
        {
            this.exprDispatched = expr;
            methodName = methodname;
            this.arg = arg;
        }

    }
}
