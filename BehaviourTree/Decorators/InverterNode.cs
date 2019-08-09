namespace BT.Decorators
{
    public class InverterNode<T> : DecoratorNode<T>
    {
        public InverterNode(Node<T> child) : base(child) { }

        public override NodeStatus Tick(T blackboard)
        {
            var status = child_.Tick(blackboard);

            if (status == NodeStatus.Failure)
            {
                return NodeStatus.Success;
            }

            if (status == NodeStatus.Success)
            {
                return NodeStatus.Failure;
            }

            return NodeStatus.Running;
        }
    }
}
