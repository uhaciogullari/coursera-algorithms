using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Algorithms.Stacks
{
    public abstract class StackTests
    {
        protected abstract IStack<string> CreateStack();

        [Fact]
        public void StackTest()
        {
            var stack = CreateStack();
            List<string> output = new List<string>();

            Action act = () => stack.Pop();
            act.ShouldThrow<InvalidOperationException>();

            stack.Push("to");
            stack.Push("be");
            stack.Push("or");
            stack.Push("not");
            stack.Push("to");
            output.Add(stack.Pop());
            stack.Push("be");
            output.Add(stack.Pop());
            output.Add(stack.Pop());
            stack.Push("that");
            output.Add(stack.Pop());
            output.Add(stack.Pop());
            output.Add(stack.Pop());
            stack.Push("is");

            output.Should().BeEquivalentTo("to", "be", "not", "that", "or", "be");
        }
    }

    public class ResizingArrayStackTests : StackTests
    {
        protected override IStack<string> CreateStack()
        {
            return new ResizingArrayStack<string>();
        }
    }

    public class LinkedListStackTests : StackTests
    {
        protected override IStack<string> CreateStack()
        {
            return new LinkedListStack<string>();
        }
    }

}
