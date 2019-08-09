// <copyright file="SucceederNode.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.Decorators
{
    /// <summary>
    /// Succeeder nodes return <see cref="NodeStatus.Success"/> regardless of the result of their child.
    /// </summary>
    /// <typeparam name="T">The generic blackboard.</typeparam>
    public class SucceederNode<T> : DecoratorNode<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SucceederNode{T}"/> class.
        /// </summary>
        /// <param name="child">The node to decorate.</param>
        public SucceederNode(Node<T> child)
            : base(child)
        {
        }

        /// <inheritdoc/>
        public override NodeStatus Tick(T blackboard)
        {
            this.Child.Tick(blackboard);

            return NodeStatus.Success;
        }
    }
}
