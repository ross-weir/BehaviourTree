namespace BT
{
    public enum NodeStatus
    {
        Failure,
        Running,
        Success
    }

    public abstract class Node<T>
    {
        public Node() { }
        public abstract NodeStatus Tick(T blackboard);
    }
}
