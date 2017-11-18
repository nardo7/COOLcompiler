using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COOLLenguage.SemanticCheck.AST1;

namespace COOLLenguage.SemanticCheck
{
    public interface IVisitor<TNode> where TNode: AST1.Node
    {
        void Visit(TNode node);
    }
}
