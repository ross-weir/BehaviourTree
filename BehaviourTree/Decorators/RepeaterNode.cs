// <copyright file="RepeaterNode.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.Decorators
{
    /// <summary>
    /// Repeater nodes return <see cref="NodeStatus.Running"/> regardless of the result of their child.
    /// </summary>
    /// <typeparam name="T">The generic blackboard.</typeparam>
    public class RepeaterNode<T> : DecoratorNode<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepeaterNode{T}"/> class.
        /// </summary>
        /// <param name="child">The node to decorate.</param>
        public RepeaterNode(INode<T> child)
            : base(child)
        {
        }

        /// <inheritdoc/>
        public override NodeStatus Tick(T blackboard)
        {
            this.Child.Tick(blackboard);

            return NodeStatus.Running;
        }
    }
}
