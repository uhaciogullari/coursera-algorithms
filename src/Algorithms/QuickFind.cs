using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class QuickFind : IUnionFind
    {
        private readonly List<int> _compounds;

        public QuickFind(int n)
        {
            _compounds = Enumerable.Range(0, n).ToList();
        }

        public void Union(int p, int q)
        {
            var compoundIdToChange = _compounds[p];
            var newCompoundId = _compounds[q];

            if (compoundIdToChange != newCompoundId)
            {
                for (int i = 0; i < _compounds.Count; i++)
                {
                    if (_compounds[i] == compoundIdToChange)
                    {
                        _compounds[i] = newCompoundId;
                    }
                }
            }
        }

        public bool IsConnected(int p, int q)
        {
            return _compounds[p] == _compounds[q];
        }
    }
}