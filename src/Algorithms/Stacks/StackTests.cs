using System.Text;
using FluentAssertions;
using Xunit;

namespace Algorithms.Stacks
{
    public abstract class StackTests
    {
        protected abstract IStack CreateStack();

        [Fact]
        public void FactMethodName()
        {
            var stack = CreateStack();
            StringBuilder stringBuilder = new StringBuilder();
            
            stack.Push("to");
            stack.Push("be");
            stack.Push("or");
            stack.Push("not");
            stack.Push("to");
            stringBuilder.Append($"{stack.Pop()} ");
            stack.Push("be");
            stringBuilder.Append($"{stack.Pop()} ");
            stringBuilder.Append($"{stack.Pop()} ");
            stack.Push("that");
            stringBuilder.Append($"{stack.Pop()} ");
            stringBuilder.Append($"{stack.Pop()} ");
            stringBuilder.Append($"{stack.Pop()} ");
            stack.Push("is");


            stringBuilder.ToString().TrimEnd().Should().Be("to be not that or be");
        }
    }
}
