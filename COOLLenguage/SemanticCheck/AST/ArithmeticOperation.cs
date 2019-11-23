﻿namespace COOLLenguage.SemanticCheck.AST
{
    public class ArithmeticOperation : BinaryExpression
    {
        ArithmeticAtomicOperations op;
        public ArithmeticAtomicOperations Op { get { return op; } }

        public ArithmeticOperation(Expression left, Expression rigth,ArithmeticAtomicOperations op) : base(left, rigth)
        {
            this.op = op;
        }
    }
    public enum ArithmeticAtomicOperations{ Plus,Minus,Mult,Div }
}
