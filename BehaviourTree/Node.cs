// <copyright file="Node.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT
{
    /// <summary>
    /// Base node that all other nodes inherit from.
    /// </summary>
    /// <typeparam name="T">The generic blackboard.</typeparam>
    public abstract class Node<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        public Node()
        {
        }

        /// <summary>
        /// Execute the node.
        /// </summary>
        /// <param name="blackboard">A global blackboad used to store state.</param>
        /// <returns><see cref="NodeStatus"/> depending on concrete implementation.</returns>
        public abstract NodeStatus Tick(T blackboard);
    }
}
