using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Dispatch : Expression
    {
        string name;
        string methodName;
        List<Expression> arg;
        Expression exprDispatched;
        public string typeName { get; set; }

        public string Name { get { return name; } set { name = value; } }
        public string MethodName { get { return methodName; } set { methodName = value; } }
        public List<Expression> Arg { get { return arg; } }
        public string Type { get; set; }
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

        public Dispatch(string name, string methodname, List<Expression> arg,string type=null)
        {
            this.name = name;
            methodName = methodname;
            this.arg = arg;
            Type = type;
        }
        public Dispatch(Expression expr, string methodname, List<Expression> arg,string type=null)
        {
            this.exprDispatched = expr;
            methodName = methodname;
            Type = type;
            this.arg = arg;
        }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            List<MIPSCodeGenerator.Expression> codeExpr = new List<MIPSCodeGenerator.Expression>();

            for (int i = 0; i < arg.Count; i++)
            {
                 codeExpr.Add((MIPSCodeGenerator.Expression)Arg[i].GetAstCodeGenerator(t));
                //Arg[i].SetGeneratorType(codeExpr[i]);
            }
            MIPSCodeGenerator.Expression obj = null;
            if (name != null && name != "")
            {
                obj = new MIPSCodeGenerator.Object(t.AddString(name));
                obj.Type = typeName;
            }
            else if (exprDispatched != null)
            {
                obj = (MIPSCodeGenerator.Expression)exprDispatched.GetAstCodeGenerator(t);
                exprDispatched.SetGeneratorType(obj);
            }
            else { obj = new MIPSCodeGenerator.Object(t.AddString("self"), Line); obj.Type = typeName; }


            if (Type == null || Type == "")
            {
                MIPSCodeGenerator.Dispatch d = new MIPSCodeGenerator.Dispatch(t.AddString(methodName), obj, codeExpr, Line);
                SetGeneratorType(d);
                return d;
            }
            else
            {
                StaticDispatch sd = new StaticDispatch(t.AddString(methodName),t.AddString(Type),obj,codeExpr,Line);
                SetGeneratorType(sd);
                return sd;
            }
        }
    }
}
