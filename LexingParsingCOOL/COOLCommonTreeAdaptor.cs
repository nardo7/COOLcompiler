using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace LexingParsingCOOL
{
    public class COOLCommonTreeAdaptor:CommonTreeAdaptor
    {
        public override object Create(IToken payload)
        {
            return new COOLCommonTree(payload);
        }
        public override object ErrorNode(ITokenStream input, IToken start, IToken stop, RecognitionException e)
        {
            return new COOLCommonErrorNode(input, start, stop, e);
        }
    }
}
