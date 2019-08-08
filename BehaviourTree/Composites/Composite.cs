using System;
using System.Collections;
using System.Collections.Generic;

namespace BT.Composites
{
    public abstract class Composite<T> : Node<T>
    {
        private readonly NodeList<Node<T>> children_;

        public Composite(params Node<T>[] children)
        {
            children_ = new NodeList<Node<T>>(children);
        }

        public override Status Tick(T blackboard)
        {
            foreach(var child in children_)
            {
                var status = child.Tick(blackboard);

                if (ShouldReturnStatus(status))
                {
                    return status;
                }
            }

            return DefaultResult;
        }

        protected abstract Status DefaultResult { get; }
        protected abstract bool ShouldReturnStatus(Status status);
    }
}
