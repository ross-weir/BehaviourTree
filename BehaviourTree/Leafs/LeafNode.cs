// <copyright file="LeafNode.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.Leafs
{
    /// <summary>
    /// Leaf nodes are the outer nodes in a branch. They have no children.
    /// Leaf nodes execute a passed delegate that performs an actual action
    /// and returns a <see cref="NodeStatus"/> based on the result of the action.
    /// </summary>
    /// <typeparam name="T">The generic blackboard.</typeparam>
    /// <typeparam name="TA"><see cref="ActionDelegate{T}"/> or <see cref="ConditionDelegate{T}"/>.</typeparam>
    public abstract class LeafNode<T, TA> : Node<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeafNode{T, TA}"/> class.
        /// </summary>
        public LeafNode()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeafNode{T, TA}"/> class.
        /// </summary>
        /// <param name="action">The action to perform when the node is ticked.</param>
        public LeafNode(TA action)
        {
            this.Action = action;
        }

        /// <summary>
        /// Gets the action for the node to perform.
        /// </summary>
        protected TA Action { get; }
    }
}