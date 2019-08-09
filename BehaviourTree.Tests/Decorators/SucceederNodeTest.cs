// <copyright file="SucceederNodeTest.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.Tests.Decorators
{
    using BT.Decorators;
    using BT.Leafs;
    using NUnit.Framework;

    [TestFixture]
    public class SucceederNodeTest : NodeTest<TestBlackboard>
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
            var succeederNode = new SucceederNode<TestBlackboard>(action);

            Assert.AreEqual(NodeStatus.Success, succeederNode.Tick(blackboard));
        }
    }
}
