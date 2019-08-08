
namespace BT.Leafs
{
    public delegate bool ConditionDelegate<T>(T blackboard);

    public class Condition<T> : Leaf<T, ConditionDelegate<T>>
    {
        public Condition(ConditionDelegate<T> action) : base(action) { }

        public override Status Tick(T blackboard)
        {
            if (action_(blackboard))
            {
                return Status.Success;
            }

            return Status.Failure;
        }
    }
}
