using System;
using BehaviourTree.Types;

namespace BehaviourTree.Composites
{
    public abstract class Composite : INode
    {
        public Composite(INode[] children)
        {

        }

        public Status Tick()
        {
            throw new NotImplementedException();
        }
    }
}
