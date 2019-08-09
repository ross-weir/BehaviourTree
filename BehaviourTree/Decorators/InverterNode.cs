// <copyright file="InverterNode.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.Decorators
{
    /// <summary>
    /// Inverter nodes take the result of a child node and return
    /// the opposite result. If their child returns <see cref="NodeStatus.Success"/>
    /// then the inverter returns <see cref="NodeStatus.Failure"/> and vice-versa.
    /// </summary>
    /// <typeparam name="T">The generic blackboard.</typeparam>
    public class InverterNode<T> : DecoratorNode<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InverterNode{T}"/> class.
        /// </summary>
        /// <param name="child">The node to decorate.</param>
        public InverterNode(Node<T> child)
            : base(child)
        {
        }

        /// <summary>
        /// Process the childs tick result.
        /// </summary>
        /// <param name="blackboard">A global blackboad used to store state.</param>
        /// <returns>A status depending on the result of the child.</returns>
        public override NodeStatus Tick(T blackboard)
        {
            var status = this.Child.Tick(blackboard);

            if (status == NodeStatus.Failure)
            {
                return NodeStatus.Success;
            }

            if (status == NodeStatus.Success)
            {
                return NodeStatus.Failure;
            }

            return NodeStatus.Running;
        }
    }
}
