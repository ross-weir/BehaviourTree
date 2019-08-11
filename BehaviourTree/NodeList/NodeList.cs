// <copyright file="NodeList.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.NodeList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// A collection of nodes.
    /// </summary>
    /// <typeparam name="T">The generic blackboard.</typeparam>
    public class NodeList<T> : INodeList<T>
    {
        private readonly NodeEnumerator enumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeList{T}"/> class.
        /// </summary>
        /// <param name="nodes">Array of nodes.</param>
        public NodeList(INode<T>[] nodes)
        {
            this.enumerator = new NodeEnumerator(nodes);
        }

        /// <inheritdoc/>
        public IEnumerator<INode<T>> GetEnumerator()
        {
            while (this.enumerator.MoveNext())
            {
                yield return this.enumerator.Current;
            }

            this.enumerator.Reset();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class NodeEnumerator : IEnumerator<INode<T>>
        {
            private readonly INode<T>[] nodes;
            private int index = -1;

            public NodeEnumerator(INode<T>[] nodes)
            {
                this.nodes = nodes;
            }

            public INode<T> Current => this.nodes[this.index];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
                this.index = -1;
                GC.SuppressFinalize(this);
            }

            public bool MoveNext()
            {
                this.index++;
                return this.index < this.nodes.Length;
            }

            public void Reset()
            {
                this.index = -1;
            }
        }
    }
}
