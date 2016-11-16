using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class WeightedQuickUnion : IUnionFind
    {
        protected readonly List<int> Compounds;
        private readonly List<int> sizes;

        public WeightedQuickUnion(int n)
        {
            Compounds = Enumerable.Range(0, n).ToList();
            sizes = Enumerable.Repeat(1,n).ToList();
        }


        public void Union(int p, int q)
        {
            var pRoot = GetRoot(p);
            var qRoot = GetRoot(q);

            if (pRoot == qRoot)
            {
                return;
            }

            if (sizes[pRoot] < sizes[qRoot])
            {
                Compounds[pRoot] = qRoot;
                sizes[qRoot] += sizes[pRoot];
            }
            else
            {
                Compounds[qRoot] = pRoot;
                sizes[pRoot] = qRoot;
            }
        }

        protected virtual int GetRoot(int i)
        {
            while (i != Compounds[i])
            {
                i = Compounds[i];
            }

            return i;
        }

        public bool IsConnected(int p, int q)
        {
            return GetRoot(p) == GetRoot(q);
        }
    }

}