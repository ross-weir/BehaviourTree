namespace BT.Leafs
{
    public delegate Status ActionDelegate<T>(T blackboard);

    public class Action<T> : Leaf<T, ActionDelegate<T>>
    {
        public Action(ActionDelegate<T> action) : base(action) { }

        public override Status Tick(T blackboard)
        {
            return action_(blackboard);
        }
    }
}
