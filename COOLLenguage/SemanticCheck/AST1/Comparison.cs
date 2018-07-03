using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Comparison : BinaryExpression
    {
        string op;
        public string Op { get { return op; } }
        public Comparison(Expression left, Expression rigth,string op) : base(left, rigth)
        {
            this.op = op;
        }

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            switch (op)
            {
                case "<":
                    var less = new Lt((MIPSCodeGenerator.Expression)Left.GetAstCodeGenerator(t), (MIPSCodeGenerator.Expression)Rigth.GetAstCodeGenerator(t), Line);
                    SetGeneratorType(less);
                    return less;
                case "<=":
                    var lesseq = new Leq((MIPSCodeGenerator.Expression)Left.GetAstCodeGenerator(t), (MIPSCodeGenerator.Expression)Rigth.GetAstCodeGenerator(t), Line);
                    SetGeneratorType(lesseq);
                    return lesseq;
                case "=":
                    var eq = new Eq((MIPSCodeGenerator.Expression)Left.GetAstCodeGenerator(t), (MIPSCodeGenerator.Expression)Rigth.GetAstCodeGenerator(t), Line);
                    SetGeneratorType(eq);
                    return eq;
                case ">":
                    var greater=new Lt( (MIPSCodeGenerator.Expression)Rigth.GetAstCodeGenerator(t), (MIPSCodeGenerator.Expression)Left.GetAstCodeGenerator(t), Line);
                    SetGeneratorType(greater);
                    return greater;
                case ">=":
                    var greaterEq = new Leq((MIPSCodeGenerator.Expression)Rigth.GetAstCodeGenerator(t), (MIPSCodeGenerator.Expression)Left.GetAstCodeGenerator(t), Line);
                    SetGeneratorType(greaterEq);
                    return greaterEq;
                default: throw new InvalidOperationException();
            }
        }
    }

}
