namespace COOLLenguage.SemanticCheck.AST
{
    public class Assignment:Expression
    {
        string name;
        Expression expr;

        public string Name { get { return name; } }
        public Expression Expr { get { return expr; } }

        public override IType ComputedType
        {
            get
            {
                return expr.ComputedType;
            }
        }

        public override string Value
        {
            get
            {
                return expr.Value;
            }
        }
        
        public Assignment(string name,Expression expr)
        {
            this.name = name;
            this.expr = expr;
        }

    }
}
