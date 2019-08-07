namespace BT.Leafs
{
    public abstract class Leaf<T, A> : Node<T>
    {
        protected readonly A action_;

        public Leaf(A action)
        {
            action_ = action;
        }
    }
}