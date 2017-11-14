using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace LexingParsingCOOL
{
    public class COOLCommonErrorNode : COOLCommonTree
    {
        public IIntStream input;
        public IToken start;
        public IToken stop;
        public RecognitionException trappedException;

        public COOLCommonErrorNode(ITokenStream input, IToken start, IToken stop, RecognitionException e):base(start)
        {
            this.input = input;
            this.start = start;
            this.stop = stop;
            this.trappedException = e;
        }

        public override bool IsNil { get; }
        public override string Text { get; set; }
        public override int Type { get; set; }
        

    }
}
