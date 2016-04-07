using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalABCCompiler.LightSemantic.LightSemanticModel
{
    public class Relation
    { 
        private SortedSet<RelationPair> Relations;

        public Relation()
        {
            Relations = new SortedSet<RelationPair>();
        }

        private Relation(IEnumerable<RelationPair> Relations)
        {
            this.Relations = new SortedSet<RelationPair>(Relations);
        }

        public void AddRelation(string Domain, string Range)
        {
            Relations.Add(new RelationPair(Domain, Range));
        }

        public SortedSet<string> Dom()
        {
            return new SortedSet<string>(Relations.Select(rel => rel.Domain));
        }

        public SortedSet<string> Ran()
        {
            return new SortedSet<string>(Relations.Select(rel => rel.Range));
        }

        public Relation Proj(IEnumerable<string> Domains, IEnumerable<string> Ranges)
        {
            return new Relation(Relations.Where(rel => Domains.Contains(rel.Domain) && Ranges.Contains(rel.Range)));
        }

        public Relation Proj(IEnumerable<string> Domains, string Range)
        {
            return new Relation(Relations.Where(rel => Domains.Contains(rel.Domain) && (Range == rel.Range)));
        }

        public Relation Proj(string Domain, IEnumerable<string> Ranges)
        {
            return new Relation(Relations.Where(rel => (Domain == rel.Domain) && Ranges.Contains(rel.Range)));
        }

        public Relation ProjDomain(params string[] Domains)
        {
            return new Relation(Relations.Where(rel => Domains.Contains(rel.Domain)));
        }

        public Relation ProjRange(params string[] Ranges)
        {
            return new Relation(Relations.Where(rel => Ranges.Contains(rel.Range)));
        }

        public Relation ProjDomain(IEnumerable<string> Domains)
        {
            return new Relation(Relations.Where(rel => Domains.Contains(rel.Domain)));
        }

        public Relation ProjRange(IEnumerable<string> Ranges)
        {
            return new Relation(Relations.Where(rel => Ranges.Contains(rel.Range)));
        }
    }

    class RelationPair
    {
        public string Domain { get; private set; }
        public string Range { get; private set; }

        public RelationPair(string Domain, string Range)
        {
            this.Domain = Domain;
            this.Range = Range;
        }
    }
}
