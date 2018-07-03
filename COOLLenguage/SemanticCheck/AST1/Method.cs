using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Method : Feature
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

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            var name = t.AddString(this.Name);
            var retType = t.AddString(ReturnType);
            List<Formal> paramss = new List<Formal>();
            var codebody = (MIPSCodeGenerator.Expression)Body.GetAstCodeGenerator(t);
            for (int i = 0; i < arguments.Count; i++)
                paramss.Add((Formal)Arguments[i].GetAstCodeGenerator(t));
            return new MIPSCodeGenerator.Method(name, retType, paramss, codebody);

        }
    }
}
