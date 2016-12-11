using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Algorithms.Queues
{
    public abstract class QueueTests
    {
        private readonly IQueue<string> queue;
        protected abstract IQueue<string> CreateQueue();

        protected QueueTests()
        {
            queue = CreateQueue();
        }

        [Fact]
        public void DequeueFromEmptyQueue()
        {
            Action act = () => queue.Dequeue();
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void QueueTest()
        {
            List<string> output = new List<string>();

            queue.Enqueue("to");
            queue.Enqueue("be");
            queue.Enqueue("or");
            queue.Enqueue("not");
            queue.Enqueue("to");
            output.Add(queue.Dequeue());
            queue.Enqueue("be");
            output.Add(queue.Dequeue());

            output.Should().BeEquivalentTo("to", "be");
        }
    }

    public class LinkedListQueueTests: QueueTests
    {
        protected override IQueue<string> CreateQueue()
        {
            return new LinkedListQueue<string>();
        }
    }
}
