using FluentAssertions;
using Xunit;

namespace Algorithms
{
    public abstract class UnionFindTests
    {
        protected abstract IUnionFind CreateUnionFindAlgorithm(int size);

        [Fact]
        public void UnionFindTest()
        {
            var algorithm = CreateUnionFindAlgorithm(10);

            algorithm.TryAdd(4, 3).Should().BeTrue();
            algorithm.TryAdd(3, 8).Should().BeTrue();
            algorithm.TryAdd(6, 5).Should().BeTrue();
            algorithm.TryAdd(9, 4).Should().BeTrue();
            algorithm.TryAdd(2, 1).Should().BeTrue();
            algorithm.TryAdd(8, 9).Should().BeFalse();
            algorithm.TryAdd(5, 0).Should().BeTrue();
            algorithm.TryAdd(7, 2).Should().BeTrue();
            algorithm.TryAdd(6, 1).Should().BeTrue();
            algorithm.TryAdd(1, 0).Should().BeFalse();
            algorithm.TryAdd(6, 7).Should().BeFalse();
        }
    }

    public class QuickFindTests : UnionFindTests
    {
        protected override IUnionFind CreateUnionFindAlgorithm(int size)
        {
            return new QuickFind(size);
        }
    }

    public class QuickUnionTests: UnionFindTests
    {
        protected override IUnionFind CreateUnionFindAlgorithm(int size)
        {
            return new QuickUnion(size);
        }
    }

    public class WeightedQuickUnionTests : UnionFindTests
    {
        protected override IUnionFind CreateUnionFindAlgorithm(int size)
        {
            return new WeightedQuickUnion(size);
        }
    }

    public class WeightedQuickUnionWithPathCompressionTests : UnionFindTests
    {
        protected override IUnionFind CreateUnionFindAlgorithm(int size)
        {
            return new WeightedQuickUnionWithPathCompression(size);
        }
    }
}