// <copyright file="SelectorNode.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.Composites
{
    /// <summary>
    /// Selector nodes iterate over their children until a child returns
    /// <see cref="NodeStatus.Success"/>, the selector will then return a true status.
    /// If all children return failure then the selector returns failure.
    /// </summary>
    /// <typeparam name="T">The generic blackboard.</typeparam>
    public class SelectorNode<T> : CompositeNode<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectorNode{T}"/> class.
        /// </summary>
        /// <param name="children">The children nodes of the sequence.</param>
        public SelectorNode(params Node<T>[] children)
            : base(children)
        {
        }

        /// <inheritdoc/>
        protected override NodeStatus DefaultResult => NodeStatus.Failure;

        /// <inheritdoc/>
        protected override bool ShouldReturnStatus(NodeStatus status)
        {
            return status == NodeStatus.Success || status == NodeStatus.Running;
        }
    }
}
