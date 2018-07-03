using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Constant : Expression
    {
        public string type;
        public string value;

        

        public Constant(string type,string value)
        {
            this.type = type;
            this.value = value;
        }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            switch (type)
            {
                case "Int":
                    var @int= new IntConst(MIPSCodeGenerator.SymbolUtils.IntTable.AddString(value),Line);
                    SetGeneratorType(@int);
                    return @int;
                case "String":
                    var str = new StringConst(MIPSCodeGenerator.SymbolUtils.StrTable.AddString(value),Line);
                    SetGeneratorType(str);
                    return str;
                case "Bool":
                    var bol= new BoolConst(bool.Parse(value.ToLower()),Line);
                    SetGeneratorType(bol);
                    return bol;
                default:throw new InvalidOperationException();

            }
        }
    }
}
