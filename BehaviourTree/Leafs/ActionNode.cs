namespace BT.Leafs
{
    public delegate NodeStatus ActionDelegate<T>(T blackboard);

    public class ActionNode<T> : LeafNode<T, ActionDelegate<T>>
    {
        public ActionNode(ActionDelegate<T> action) : base(action) { }

        public override NodeStatus Tick(T blackboard)
        {
            return action_(blackboard);
        }
    }
}
