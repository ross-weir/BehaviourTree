using BehaviourTree.Types;

namespace BehaviourTree.Leafs
{
    public delegate Status ActionDelegate();
    public delegate bool ConditionDelegate();

    public abstract class Leaf<T> : INode
    {
        protected readonly T action_;

        public Leaf(T action)
        {
            action_ = action;
        }

        public abstract Status Tick();
    }
}
