using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;


namespace COOLLenguage.SemanticCheck.AST1
{
    public class ArithmeticOperation : BinaryExpression
    {
        string op;
        public string Op { get { return op; } }

        public ArithmeticOperation(Expression left, Expression rigth,string op) : base(left, rigth)
        {
            this.op = op;
        }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            switch (op){
                case "+":
                    var plus= new Plus((MIPSCodeGenerator.Expression)Left.GetAstCodeGenerator(t), (MIPSCodeGenerator.Expression)Rigth.GetAstCodeGenerator(t),Line);
                    SetGeneratorType(plus);
                    return plus;
                case "-":
                    var sub = new Sub((MIPSCodeGenerator.Expression)Left.GetAstCodeGenerator(t), (MIPSCodeGenerator.Expression)Rigth.GetAstCodeGenerator(t), Line);
                    SetGeneratorType(sub);
                    return sub;
                case "*":
                    var mul = new Mul((MIPSCodeGenerator.Expression)Left.GetAstCodeGenerator(t), (MIPSCodeGenerator.Expression)Rigth.GetAstCodeGenerator(t), Line);
                    SetGeneratorType(mul);
                    return mul;
                case "/":
                    var div = new Divide((MIPSCodeGenerator.Expression)Left.GetAstCodeGenerator(t), (MIPSCodeGenerator.Expression)Rigth.GetAstCodeGenerator(t), Line);
                    SetGeneratorType(div);
                    return div;
                default:throw new InvalidOperationException();
            }
        }
    }
   
}
