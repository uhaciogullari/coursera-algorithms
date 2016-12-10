using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Algorithms.Queues
{
    public abstract class QueueTests
    {
        protected abstract IQueue CreateQueue();

        [Fact]
        public void QueueTest()
        {
            var queue = CreateQueue();
            List<string> output = new List<string>();

            Action act = () => queue.Dequeue();
            act.ShouldThrow<InvalidOperationException>();

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
        protected override IQueue CreateQueue()
        {
            return new LinkedListQueue();
        }
    }
}
