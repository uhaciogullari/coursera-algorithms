namespace Algorithms.Stacks
{
    public class ResizingArrayStackTests : StackTests
    {
        protected override IStack CreateStack()
        {
            return new ResizingArrayStack();
        }
    }
}
