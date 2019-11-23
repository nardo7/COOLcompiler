namespace COOLLenguage.SemanticCheck
{
    public interface IVisitor<TNode> where TNode: AST1.Node
    {
        void Visit(TNode node);
    }
}
