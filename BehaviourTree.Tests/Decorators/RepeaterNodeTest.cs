// <copyright file="RepeaterNodeTest.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.Tests.Decorators
{
    using BT.Decorators;
    using BT.Leafs;
    using NUnit.Framework;

    [TestFixture]
    public class RepeaterNodeTest : NodeTest<TestBlackboard>
    {
        [TestCase(NodeStatus.Failure)]
        [TestCase(NodeStatus.Running)]
        [TestCase(NodeStatus.Success)]
        public void Tick_AlwaysReturnsTrue(NodeStatus status)
        {
            var blackboard = this.GetBlackboard();
            var action = new ActionNode<TestBlackboard>((TestBlackboard bb) =>
            {
                return status;
            });
            var repeaterNode = new RepeaterNode<TestBlackboard>(action);

            Assert.AreEqual(NodeStatus.Running, repeaterNode.Tick(blackboard));
        }
    }
}
