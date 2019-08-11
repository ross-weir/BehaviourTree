// <copyright file="INodeList.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.NodeList
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface INodeList<T> : IEnumerable<INode<T>>
    {
    }
}
