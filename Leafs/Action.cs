using BehaviourTree.Types;

namespace BehaviourTree.Leafs
{
    public class Action : Leaf<ActionDelegate>
    {
        public Action(ActionDelegate action) : base(action) { }

        public override Status Tick()
        {
            return action_();
        }
    }
}
