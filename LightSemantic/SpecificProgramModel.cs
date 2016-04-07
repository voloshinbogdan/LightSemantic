using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PascalABCCompiler.LightSemantic.LightSemanticModel;

namespace PascalABCCompiler.LightSemantic
{
    public class SpecificProgramModel
    {
        ProgramModel program;

        public SpecificProgramModel()
        {
            program = new ProgramModel();
        }

        // Elements
        public SortedSet<string> NameSpacesElems
        {
            get { return program.Elements["NameSpaces"]; }
            set { program.Elements["NameSpaces"] = value; }
        }
        public SortedSet<string> VariablesElems
        {
            get { return program.Elements["Variables"]; }
            set { program.Elements["Variables"] = value; }
        }
        public SortedSet<string> ProceduresElems
        {
            get { return program.Elements["Procedures"]; }
            set { program.Elements["Procedures"] = value; }
        }
        public SortedSet<string> FunctionsElems
        {
            get { return program.Elements["Functions"]; }
            set { program.Elements["Functions"] = value; }
        }
        public SortedSet<string> CustomTypesElems
        {
            get { return program.Elements["CustomTypes"]; }
            set { program.Elements["CustomTypes"] = value; }
        }
        public SortedSet<string> StructuresElems
        {
            get { return program.Elements["Structures"]; }
            set { program.Elements["Structures"] = value; }
        }
        public SortedSet<string> ClassesElems
        {
            get { return program.Elements["Classes"]; }
            set { program.Elements["Classes"] = value; }
        }
        public SortedSet<string> InterfacesElems
        {
            get { return program.Elements["Interfaces"]; }
            set { program.Elements["Interfaces"] = value; }
        }
        public SortedSet<string> FieldsElems
        {
            get { return program.Elements["Fields"]; }
            set { program.Elements["Fields"] = value; }
        }
        public SortedSet<string> MethodsElems
        {
            get { return program.Elements["Methods"]; }
            set { program.Elements["Methods"] = value; }
        }

        // Relations
        public Relation ContainsRel
        {
            get { return program.Relations["Contains"]; }
            set { program.Relations["Contains"] = value; }
        }
        public Relation PartialNamesRel
        {
            get { return program.Relations["PartialNames"]; }
            set { program.Relations["PartialNames"] = value; }
        }
        public Relation DeclaresRel
        {
            get { return program.Relations["Declares"]; }
            set { program.Relations["Declares"] = value; }
        }
        public Relation OfTypeRel
        {
            get { return program.Relations["OfType"]; }
            set { program.Relations["OfType"] = value; }
        }
    }
}
