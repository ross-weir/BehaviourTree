using BehaviourTree.Types;

namespace BehaviourTree
{
    public interface INode
    { 
        Status Tick();
    }
}
