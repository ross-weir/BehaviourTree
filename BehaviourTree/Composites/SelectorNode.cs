namespace BT.Composites
{
    public class SelectorNode<T> : CompositeNode<T>
    {
        public SelectorNode(params Node<T>[] children) : base(children) { }

        protected override NodeStatus DefaultResult => NodeStatus.Failure;

        protected override bool ShouldReturnStatus(NodeStatus status)
        {
            return status == NodeStatus.Success || status == NodeStatus.Running;
        }
    }
}
