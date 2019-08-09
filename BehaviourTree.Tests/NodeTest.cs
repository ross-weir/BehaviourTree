// <copyright file="NodeTest.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.Tests
{
    using BT.Leafs;

    public class NodeTest<T>
        where T : TestBlackboard, new()
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
                }),
            };
        }

        protected virtual T GetBlackboard()
        {
            return new T();
        }
    }
}
