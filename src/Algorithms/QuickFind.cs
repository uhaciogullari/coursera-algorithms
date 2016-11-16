using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class QuickFind : IUnionFind
    {
        private readonly List<int> compounds;

        public QuickFind(int n)
        {
            compounds = Enumerable.Range(0, n).ToList();
        }

        public void Union(int p, int q)
        {
            var compoundIdToChange = compounds[p];
            var newCompoundId = compounds[q];

            if (compoundIdToChange != newCompoundId)
            {
                for (int i = 0; i < compounds.Count; i++)
                {
                    if (compounds[i] == compoundIdToChange)
                    {
                        compounds[i] = newCompoundId;
                    }
                }
            }
        }

        public bool IsConnected(int p, int q)
        {
            return compounds[p] == compounds[q];
        }
    }
}