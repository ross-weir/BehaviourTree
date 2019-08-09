namespace BT.Leafs
{
    public delegate bool ConditionDelegate<T>(T blackboard);

    public class ConditionNode<T> : LeafNode<T, ConditionDelegate<T>>
    {
        public ConditionNode() { }

        public ConditionNode(ConditionDelegate<T> action) : base(action) { }

        public override NodeStatus Tick(T blackboard)
        {
            if (action_(blackboard))
            {
                return NodeStatus.Success;
            }

            return NodeStatus.Failure;
        }
    }
}
