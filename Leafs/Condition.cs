using BehaviourTree.Types;

namespace BehaviourTree.Leafs
{
    public class Condition : Leaf<ConditionDelegate>
    {
        public Condition(ConditionDelegate action) : base(action) { }

        public override Status Tick()
        {
            if (action_())
            {
                return Status.Success;
            }

            return Status.Failure;
        }
    }
}
