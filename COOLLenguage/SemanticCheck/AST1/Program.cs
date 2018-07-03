using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CoolCompilator;
using MIPSCodeGenerator;

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

        public override TreeNode GetAstCodeGenerator(SymbolTable t)
        {
            Class[] classes = new Class[this.Classes.Count];
            for (int i = 0; i < Classes.Count; i++)
            {
                classes[i] = (Class)Classes[i].GetAstCodeGenerator(t);
            }
            MIPSCodeGenerator.Program p = new MIPSCodeGenerator.Program(classes.ToList(), Line);
            return p;
            
        }
    }
}
