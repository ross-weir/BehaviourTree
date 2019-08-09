using BT.Leafs;

namespace BT.Tests
{
    public class TestBlackboard
    { }

    public class NodeTest<T> where T : TestBlackboard, new()
    {
        protected virtual Node<T>[] GetNodes()
        {
            return new Node<T>[]
            {
                new ActionNode<T>((T bb) =>
                {
                    return NodeStatus.Running;
                }),
                new ActionNode<T>((T bb) =>
                {
                    return NodeStatus.Running;
                }),
                new ActionNode<T>((T bb) =>
                {
                    return NodeStatus.Success;
                })
            };
        }
      
        protected virtual T GetBlackboard()
        {
            return new T();
        }
    }
}
