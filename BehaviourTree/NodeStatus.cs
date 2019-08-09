// <copyright file="NodeStatus.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT
{
    /// <summary>
    /// Status' returned by a nodes tick method.
    /// </summary>
    public enum NodeStatus
    {
        /// <summary>
        /// The node returned a failure status.
        /// </summary>
        Failure,

        /// <summary>
        /// The node is still executing its action.
        /// </summary>
        Running,

        /// <summary>
        /// The nodes returned a success status.
        /// </summary>
        Success,
    }
}
