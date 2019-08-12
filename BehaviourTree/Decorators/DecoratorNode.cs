// <copyright file="DecoratorNode.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.Decorators
{
    /// <summary>
    /// Decorator nodes take one child node and alter the result of
    /// the childs tick.
    /// </summary>
    /// <typeparam name="T">The generic blackboard.</typeparam>
    public abstract class DecoratorNode<T> : INode<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DecoratorNode{T}"/> class.
        /// </summary>
        /// <param name="child">The child node to decorate.</param>
        public DecoratorNode(INode<T> child)
        {
            this.Child = child;
        }

        /// <summary>
        /// Gets the child node to decorate.
        /// </summary>
        protected INode<T> Child { get; }

        /// <summary>
        /// Executes the child nodes tick method and returns <see cref="NodeStatus"/> depending on the conrete class.
        /// </summary>
        /// <param name="blackboard">A global blackboad used to store state.</param>
        /// <returns><see cref="NodeStatus"/> depending on the concrete implementation.</returns>
        public abstract NodeStatus Tick(T blackboard);
    }
}
