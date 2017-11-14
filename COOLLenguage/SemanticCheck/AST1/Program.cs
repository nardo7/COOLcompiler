using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.SemanticCheck.AST1
{
    public class Program:Node
    {
        public List<ClassDef> Classes { get; private set; }

        public Program()
        {
            Classes = new List<ClassDef>();
        }
        public Program(List<ClassDef> classes)
        {
            Classes = classes;
        }

    }
}
