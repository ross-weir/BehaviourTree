// <copyright file="CompositeNode.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.Composites
{
    /// <summary>
    /// Composite nodes iterate over their children and return a particular <see cref="NodeStatus"/>.
    /// The status depends on the implmentation of a concrete class.
    /// </summary>
    /// <typeparam name="T">The generic blackboard.</typeparam>
    public abstract class CompositeNode<T> : Node<T>
    {
        private readonly NodeList<T> children;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeNode{T}"/> class.
        /// </summary>
        /// <param name="children">The child nodes to process.</param>
        public CompositeNode(params Node<T>[] children)
        {
            this.children = new NodeList<T>(children);
        }

        /// <summary>
        /// Gets a default <see cref="NodeStatus"/> after all children have been iterated.
        /// </summary>
        protected abstract NodeStatus DefaultResult { get; }

        /// <summary>
        /// Iterate through all child nodes while calling their <see cref="Node{T}.Tick(T)"/> method.
        /// </summary>
        /// <param name="blackboard">A global blackboad used to store state.</param>
        /// <returns><see cref="NodeStatus"/> depending on the concrete implementation.</returns>
        public override NodeStatus Tick(T blackboard)
        {
            foreach (var child in this.children)
            {
                var status = child.Tick(blackboard);

                if (this.ShouldReturnStatus(status))
                {
                    return status;
                }
            }

            return this.DefaultResult;
        }

        /// <summary>
        /// Determine if the <see cref="NodeStatus"/> returned by currently processing
        /// child should cause the concrete composite node to return the status to it's parent.
        /// </summary>
        /// <param name="status">The status returned by the current child.</param>
        /// <returns>True if the composite should return the status.</returns>
        protected abstract bool ShouldReturnStatus(NodeStatus status);
    }
}
