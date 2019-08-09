namespace BT.Composites
{
    public class SequenceNode<T> : CompositeNode<T>
    {
        public SequenceNode(params Node<T>[] children) : base(children) { }

        protected override NodeStatus DefaultResult => NodeStatus.Success;

        protected override bool ShouldReturnStatus(NodeStatus status)
        {
            return status == NodeStatus.Failure || status == NodeStatus.Running;
        }
    }
}
