// <copyright file="ConditionNode.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.Leafs
{
    /// <summary>
    /// Condition delegates are executed by leaf nodes in their tick method.
    /// </summary>
    /// <typeparam name="T">The generic blackboard.</typeparam>
    /// <param name="blackboard">A global blackboad used to store state.</param>
    /// <returns>True or false based on the action it performs.</returns>
    public delegate bool ConditionDelegate<T>(T blackboard);

    /// <summary>
    /// Condition nodes execute a delegate and return a bool value based on the delegates result.
    /// </summary>
    /// <typeparam name="T">The generic blackboard.</typeparam>
    public class ConditionNode<T> : LeafNode<T, ConditionDelegate<T>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionNode{T}"/> class.
        /// </summary>
        public ConditionNode()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionNode{T}"/> class.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        public ConditionNode(ConditionDelegate<T> action)
            : base(action)
        {
        }

        /// <inheritdoc/>
        public override NodeStatus Tick(T blackboard)
        {
            if (this.Action(blackboard))
            {
                return NodeStatus.Success;
            }

            return NodeStatus.Failure;
        }
    }
}
