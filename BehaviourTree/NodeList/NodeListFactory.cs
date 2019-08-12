// <copyright file="NodeListFactory.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.NodeList
{
    /// <summary>
    /// 
    /// </summary>
    internal static class NodeListFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodes"></param>
        /// <returns></returns>
        internal static NodeList<T> Create<T>(params INode<T>[] nodes)
        {
            return new NodeList<T>(nodes);
        }
    }
}
