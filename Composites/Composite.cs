using System;

namespace BT.Composites
{
    public abstract class Composite<T> : Node<T>
    {
        protected readonly Node<T>[] children_;
        public Composite(Node<T>[] children)
        {
            children_ = children;
        }

        public override Status Tick(T blackboard)
        {
            foreach(var ch in children_)
            {
                ch.Tick(blackboard);
            }
            throw new NotImplementedException();
        }

        protected abstract bool ShouldReturnStatus(Status status);
        protected abstract Status DefaultStatus { get; }
    }
}
