namespace BT
{
    public enum Status
    {
        Failure,
        Running,
        Success
    }

    public abstract class Node<T>
    {
        public abstract Status Tick(T blackboard);
    }
}
