// <copyright file="ActionNodeTest.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.Tests.Leafs
{
    using BT.Leafs;
    using NUnit.Framework;

    [TestFixture]
    public class ActionNodeTest : NodeTest<TestBlackboard>
    {
        [TestCase(NodeStatus.Failure)]
        [TestCase(NodeStatus.Running)]
        [TestCase(NodeStatus.Success)]
        public void Tick_ReturnsStatus(NodeStatus status)
        {
            var blackboard = this.GetBlackboard();
            var result = new ActionNode<TestBlackboard>((TestBlackboard bb) =>
            {
                return status;
            });

            Assert.AreEqual(status, result.Tick(blackboard));
        }
    }
}
