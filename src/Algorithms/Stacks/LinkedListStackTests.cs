namespace Algorithms.Stacks
{
    public class LinkedListStackTests : StackTests
    {
        protected override IStack CreateStack()
        {
            return new LinkedListStack();
        }
    }
}
