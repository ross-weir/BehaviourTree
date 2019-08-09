// <copyright file="InverterNodeTest.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.Tests.Decorators
{
    using BT.Decorators;
    using BT.Leafs;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class InverterNodeTest : NodeTest<TestBlackboard>
    {
        [Test]
        public void Tick_ChildSuccess_ReturnsFailure()
        {
            var blackboard = this.GetBlackboard();
            var childStub = new Mock<ActionNode<TestBlackboard>>();
            var inverterNode = new InverterNode<TestBlackboard>(childStub.Object);

            childStub.Setup(x => x.Tick(blackboard)).Returns(NodeStatus.Success);

            Assert.AreEqual(NodeStatus.Failure, inverterNode.Tick(blackboard));
        }

        [Test]
        public void Tick_ChildFailure_ReturnsSuccess()
        {
            var blackboard = this.GetBlackboard();
            var childStub = new Mock<ActionNode<TestBlackboard>>();
            var inverterNode = new InverterNode<TestBlackboard>(childStub.Object);

            childStub.Setup(x => x.Tick(blackboard)).Returns(NodeStatus.Failure);

            Assert.AreEqual(NodeStatus.Success, inverterNode.Tick(blackboard));
        }
    }
}
