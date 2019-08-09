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
    public abstract class DecoratorNode<T> : Node<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DecoratorNode{T}"/> class.
        /// </summary>
        /// <param name="child">The child node to decorate.</param>
        public DecoratorNode(Node<T> child)
        {
            this.Child = child;
        }

        /// <summary>
        /// Gets the child node to decorate.
        /// </summary>
        protected Node<T> Child { get; }
    }
}
