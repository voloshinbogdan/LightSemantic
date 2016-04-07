using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PascalABCCompiler.SyntaxTree;
using PascalABCCompiler.LightSemantic.LightSemanticModel;

namespace PascalABCCompiler.LightSemantic
{
    public class NameController
    {
        private string curNS;
        private SpecificProgramModel program;
        public NameController(SpecificProgramModel program)
        {
            this.curNS = "Global";
            this.program = program;
            program.NameSpacesElems.Add("Global");
        }

        /*
         * Methods for collecting information
         */

        public bool ContainsNameSpace(string name)
        {
            return program.NameSpacesElems.Contains(name);
        }


        public void PushNameSpace(string nameSpace)
        {
            string fullName = curNS + "." + nameSpace;
            program.NameSpacesElems.Add(fullName);
            program.NameSpacesElems.Add(nameSpace);
            program.PartialNamesRel.AddRelation(nameSpace, fullName);
            program.ContainsRel.AddRelation(curNS, fullName);
            curNS = fullName;
        }

        public void SetCurrentNameSpace(string nameSpace)
        {
            // can be many different partial
            if (ContainsNameSpace(nameSpace))
                curNS = nameSpace;
        }

        public void PopNameSpace()
        {
            curNS = program.ContainsRel.ProjRange(curNS).Dom().First();
        }

        
        public void AddVariable(string name)
        {
            string fullName = curNS + "." + name;
            program.VariablesElems.Add(fullName);
            program.VariablesElems.Add(name);
            program.PartialNamesRel.AddRelation(name, fullName);
            program.DeclaresRel.AddRelation(curNS, fullName);

        }

        public void AddCustomType(string name)
        {
            program.CustomTypesElems.Add(name);
        }

        public void AddVariable(string name, string type)
        {
            string fullName = curNS + "." + name;
            AddVariable(name);
            program.OfTypeRel.AddRelation(fullName, type);
        }


        /*
         * Methods with current name space
         */

        public string CurrentNameSpace()
        {
            return curNS;
        }
        
        public NameSpace Find(string id)
        {
            if (curNameSpace.var2type.ContainsKey(id))
                return curNameSpace.Find(id);
            else
                return null;
        }


        public string GetTypeVariable(string id)
        {
            
            if (curNameSpace.var2type.ContainsKey(id))
                return curNameSpace.var2type[id];
            else
                return null;
        }
/*
        public void AddProcedure(string name, List<string> parameters, string returnType = "")
        {
            curNameSpace.proc2type.Add(name, new ProcedureType(parameters, returnType));
        }


        public ProcedureType GetTypeProcedure(string id)
        {
            if (curNameSpace.proc2type.ContainsKey(id))
                return curNameSpace.proc2type[id];
            else
                return null;
        }
        */

        /*
         * Methods with all name spaces
         */

        public NameSpace FindVariableGlobal(string id)
        {
            foreach (var nameSpace in nameSpaces)
            {
                if (nameSpace.var2type.ContainsKey(id))
                    return nameSpace;
            }

            return null;
        }

        public string GetTypeVariableGlobal(string id)
        {
            foreach (var nameSpace in nameSpaces)
            {
                if (nameSpace.var2type.ContainsKey(id))
                    return nameSpace.var2type[id];
            }

            return null;
        }
        /*
        public NameSpace FindProcedureGlobal(string id)
        {
            foreach (var nameSpace in nameSpaces)
            {
                if (nameSpace.proc2type.ContainsKey(id))
                    return nameSpace;
            }

            return null;
        }

        public ProcedureType GetTypeProcedureGlobal(string id)
        {
            foreach (var nameSpace in nameSpaces)
            {
                if (nameSpace.proc2type.ContainsKey(id))
                    return nameSpace.proc2type[id];
            }

            return null;
        }
        */

        
        public void Print()
        {
            foreach (var nameSpace in nameSpaces)
	        {
                foreach (var varNtype in nameSpace.var2type)
                {
                    Console.WriteLine("  " + nameSpace.GetFullName() + "." + varNtype.Key + " : " + varNtype.Value);
                }
	        }

            foreach (var nameSpace in nameSpaces)
            {
                foreach (var procNtype in nameSpace.proc2type)
                {
                    Console.WriteLine("  " + nameSpace.GetFullName() + "." + procNtype.Key + " : " + procNtype.Value);
                }
            }
        }

        public string GetNameInfo(string name)
        {
            return curNameSpace.GetNameInfo(name);
        }
    }
    /*
    public class ProcedureType
    {
        public string returnType;
        public List<string> paramTypes;

        public ProcedureType(List<string> paramTypes, string returnType = "")
        {
            this.paramTypes = paramTypes;
            this.returnType = returnType;
        }

        
        public static bool operator == (ProcedureType pt1, ProcedureType pt2)
        {
            Func<string,string,bool> cmp = (s1, s2) => s1.ToLower() == s2.ToLower();

            return
                cmp(pt1.returnType, pt2.returnType) &&
                pt1.paramTypes.Zip(pt2.paramTypes, cmp).All(a => a);
        }

        public override string ToString()
        {
            string parameters = paramTypes.Aggregate((s1, s2) => s1 + ", " + s2);

            if (returnType == "")
            {
                return "procedure (" + parameters + ")";
            }
            else
            {
                return "function (" + parameters + ") : " + returnType;
            }
        }

        public static bool operator !=(ProcedureType pt1, ProcedureType pt2)
        {
            return !(pt1 == pt2);
        }
    }*/
}
