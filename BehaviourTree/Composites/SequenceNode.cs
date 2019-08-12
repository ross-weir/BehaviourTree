// <copyright file="SequenceNode.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.Composites
{
    /// <summary>
    /// Sequence nodes iterate over their children as long as the child returns
    /// <see cref="NodeStatus.Success"/>. If all children return success then the
    /// sequence returns success, other the sequence returns failure.
    /// </summary>
    /// <typeparam name="T">The generic blackboard.</typeparam>
    public class SequenceNode<T> : CompositeNode<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceNode{T}"/> class.
        /// </summary>
        /// <param name="children">The children nodes of the sequence.</param>
        public SequenceNode(params INode<T>[] children)
            : base(children)
        {
        }

        /// <inheritdoc/>
        protected override NodeStatus DefaultResult => NodeStatus.Success;

        /// <inheritdoc/>
        protected override bool ShouldReturnStatus(NodeStatus status)
        {
            return status == NodeStatus.Failure || status == NodeStatus.Running;
        }
    }
}
