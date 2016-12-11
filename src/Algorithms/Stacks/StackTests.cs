using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Algorithms.Stacks
{
    public abstract class StackTests
    {
        private IStack<string> stack;
        protected abstract IStack<string> CreateStack();

        protected StackTests()
        {
            stack = CreateStack();
        }

        [Fact]
        public void PopFromEmptyStack()
        {
            Action act = () => stack.Pop();
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void PushPop()
        {
            List<string> output = new List<string>();

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

        [Fact]
        public void Enumerate()
        {
            stack.Push("to");
            stack.Push("be");
            stack.Push("or");
            stack.Push("not");
            stack.Push("to");

            stack.Should().BeEquivalentTo("to", "not", "or", "be", "to");
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
