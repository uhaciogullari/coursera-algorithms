using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class QuickUnion : IUnionFind
    {
        private readonly List<int> _compounds;

        public QuickUnion(int n)
        {
            _compounds = Enumerable.Range(0, n).ToList();
        }


        public void Union(int p, int q)
        {
            var pRoot = GetRoot(p);
            var qRoot = GetRoot(q);


            if (pRoot.Depth > qRoot.Depth)
            {
                _compounds[qRoot.Root] = _compounds[pRoot.Root];
            }
            else
            {
                _compounds[pRoot.Root] = _compounds[qRoot.Root];
            }

        }

        private RootInfo GetRoot(int i)
        {
            RootInfo result = new RootInfo { Depth = 1 };

            while (_compounds[i] != i)
            {
                i = _compounds[i];
                result.Depth++;
            }

            result.Root = i;
            return result;
        }

        public bool IsConnected(int p, int q)
        {
            return GetRoot(p).Root == GetRoot(q).Root;
        }

        class RootInfo
        {
            public int Root { get; set; }
            public int Depth { get; set; }
        }

    }

}