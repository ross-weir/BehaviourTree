namespace BT.Decorators
{
    public abstract class DecoratorNode<T> : Node<T>
    {
        protected readonly Node<T> child_;

        public DecoratorNode(Node<T> child)
        {
            child_ = child;
        }
    }
}
