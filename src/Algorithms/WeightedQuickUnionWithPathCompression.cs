using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithms
{
    public class WeightedQuickUnionWithPathCompression : WeightedQuickUnion
    {
        public WeightedQuickUnionWithPathCompression(int n) : base(n)
        {
        }

        protected override int GetRoot(int i)
        {
            while (i != Compounds[i])
            {
                Compounds[i] = Compounds[Compounds[i]];
                i = Compounds[i];
            }

            return i;
        }
    }
}
