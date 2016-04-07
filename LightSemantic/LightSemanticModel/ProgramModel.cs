using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalABCCompiler.LightSemantic.LightSemanticModel
{
    public class ProgramModel
    {
        public Dictionary<string, SortedSet<string>> Elements { get; set; }
        public Dictionary<string, Relation> Relations { get; set; }

        public ProgramModel()
        {
            Elements = new Dictionary<string, SortedSet<string>>();
            Relations = new Dictionary<string, Relation>();
        }
    }
}
