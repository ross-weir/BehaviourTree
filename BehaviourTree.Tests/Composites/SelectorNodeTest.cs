// <copyright file="SelectorNodeTest.cs" company="Ross Weir">
// Copyright (c) Ross Weir. All rights reserved.
// </copyright>

namespace BT.Tests.Composites
{
    using BT.Composites;
    using BT.Leafs;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class SelectorNodeTest : NodeTest<TestBlackboard>
    {
        [Test]
        public void Tick_AllChildrenFail_ReturnsFailure()
        {
            var blackboard = this.GetBlackboard();
            var children = new Node<TestBlackboard>[]
            {
                new ActionNode<TestBlackboard>((TestBlackboard bb) =>
                {
                    return NodeStatus.Failure;
                }),
                new ActionNode<TestBlackboard>((TestBlackboard bb) =>
                {
                    return NodeStatus.Failure;
                }),
            };
            var sequenceNode = new SelectorNode<TestBlackboard>(children);

            Assert.AreEqual(NodeStatus.Failure, sequenceNode.Tick(blackboard));
        }

        [Test]
        public void Tick_AnyChildReturnsSuccess_ReturnsSuccess()
        {
            var blackboard = this.GetBlackboard();
            var children = new Node<TestBlackboard>[]
            {
                new ActionNode<TestBlackboard>((TestBlackboard bb) =>
                {
                    return NodeStatus.Failure;
                }),
                new ActionNode<TestBlackboard>((TestBlackboard bb) =>
                {
                    return NodeStatus.Success;
                }),
                new ActionNode<TestBlackboard>((TestBlackboard bb) =>
                {
                    return NodeStatus.Failure;
                }),
            };
            var sequenceNode = new SelectorNode<TestBlackboard>(children);

            Assert.AreEqual(NodeStatus.Success, sequenceNode.Tick(blackboard));
        }

        [Test]
        public void Tick_FirstChildReturnsSuccess_SequenceReturns()
        {
            var blackboard = this.GetBlackboard();
            var mockAction = new Mock<ActionNode<TestBlackboard>>();
            var children = new Node<TestBlackboard>[]
            {
                new ActionNode<TestBlackboard>((TestBlackboard bb) =>
                {
                    return NodeStatus.Failure;
                }),
                new ActionNode<TestBlackboard>((TestBlackboard bb) =>
                {
                    return NodeStatus.Success;
                }),
                mockAction.Object,
            };
            var sequenceNode = new SelectorNode<TestBlackboard>(children);

            mockAction.Setup(x => x.Tick(blackboard)).Returns(NodeStatus.Failure);

            mockAction.Verify(mock => mock.Tick(blackboard), Times.Never);
        }
    }
}
