// <copyright file="ConditionNodeTest.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.Tests.Leafs
{
    using BT.Leafs;
    using NUnit.Framework;

    [TestFixture]
    public class ConditionNodeTest : NodeTest<TestBlackboard>
    {
        [Test]
        public void Tick_Returns_Success_If_Delegate_True()
        {
            var blackboard = this.GetBlackboard();
            var result = new ConditionNode<TestBlackboard>((TestBlackboard bb) =>
            {
                return true;
            });

            Assert.AreEqual(NodeStatus.Success, result.Tick(blackboard));
        }

        [Test]
        public void Tick_Returns_Failure_If_Delegate_False()
        {
            var blackboard = this.GetBlackboard();
            var result = new ConditionNode<TestBlackboard>((TestBlackboard bb) =>
            {
                return false;
            });

            Assert.AreEqual(NodeStatus.Failure, result.Tick(blackboard));
        }
    }
}
