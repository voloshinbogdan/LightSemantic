using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PascalABCCompiler.SyntaxTree;
using PascalABCCompiler;
using PascalABCCompiler.LightSemantic.LightSemanticModel;

namespace PascalABCCompiler.LightSemantic
{
    public class InformationContainer
    {
        public NameController nameController;
        SpecificProgramModel program;

        public InformationContainer()
        {
            program = new SpecificProgramModel();
            nameController = new NameController(program);
        }

        
        public void PrintInfo()
        {
            Console.WriteLine("Names info:");
            nameController.Print();
        }
        
    }
}
