// <copyright file="INode.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT
{
    /// <summary>
    /// Base interface that all nodes implement.
    /// </summary>
    /// <typeparam name="T">The generic blackboard.</typeparam>
    public interface INode<T>
    {
        /// <summary>
        /// Execute the node.
        /// </summary>
        /// <param name="blackboard">A global blackboad used to store state.</param>
        /// <returns><see cref="NodeStatus"/> depending on class implementation.</returns>
        NodeStatus Tick(T blackboard);
    }
}
