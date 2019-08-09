namespace BT.Leafs
{
    public abstract class LeafNode<T, A> : Node<T>
    {
        protected readonly A action_;

        public LeafNode() { }

        public LeafNode(A action)
        {
            action_ = action;
        }
    }
}