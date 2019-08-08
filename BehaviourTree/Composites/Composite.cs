namespace BT.Composites
{
    public abstract class Composite<T> : Node<T>
    {
        private readonly NodeList<T> children_;

        public Composite(params Node<T>[] children)
        {
            children_ = new NodeList<T>(children);
        }

        public override NodeStatus Tick(T blackboard)
        {
            foreach(var child in children_)
            {
                var status = child.Tick(blackboard);

                if (ShouldReturnStatus(status))
                {
                    return status;
                }
            }

            return DefaultResult;
        }

        protected abstract NodeStatus DefaultResult { get; }
        protected abstract bool ShouldReturnStatus(NodeStatus status);
    }
}
