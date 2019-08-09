// <copyright file="ActionNode.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.Leafs
{
    /// <summary>
    /// Action delegates are executed by leaf nodes in their tick method.
    /// </summary>
    /// <typeparam name="T">The generic blackboard.</typeparam>
    /// <param name="blackboard">A global blackboad used to store state.</param>
    /// <returns><see cref="NodeStatus"/> based on the action.</returns>
    public delegate NodeStatus ActionDelegate<T>(T blackboard);

    /// <summary>
    /// Action nodes execute a delegate and return the result.
    /// </summary>
    /// <typeparam name="T">The generic blackboard.</typeparam>
    public class ActionNode<T> : LeafNode<T, ActionDelegate<T>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionNode{T}"/> class.
        /// </summary>
        public ActionNode()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionNode{T}"/> class.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        public ActionNode(ActionDelegate<T> action)
            : base(action)
        {
        }

        /// <summary>
        /// Executes an action.
        /// </summary>
        /// <param name="blackboard">A global blackboad used to store state.</param>
        /// <returns><see cref="NodeStatus"/> for the action.</returns>
        public override NodeStatus Tick(T blackboard)
        {
            return this.Action(blackboard);
        }
    }
}
