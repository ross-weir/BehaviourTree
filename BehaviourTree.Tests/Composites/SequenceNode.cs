using BT.Composites;
using BT.Leafs;
using Moq;
using NUnit.Framework;

namespace BT.Tests.Composites
{
    [TestFixture]
    class SequenceNodeTest : NodeTest<TestBlackboard>
    {
        [Test]
        public void Tick_AllChildrenSucceed_ReturnsSuccess()
        {
            var blackboard = GetBlackboard();
            var children = new Node<TestBlackboard>[]
            {
                new ActionNode<TestBlackboard>((TestBlackboard bb) =>
                {
                    return NodeStatus.Success;
                }),
                new ConditionNode<TestBlackboard>((TestBlackboard bb) =>
                {
                    return true;
                }),
                new ActionNode<TestBlackboard>((TestBlackboard bb) =>
                {
                    return NodeStatus.Success;
                }),
            };
            var sequenceNode = new SequenceNode<TestBlackboard>(children);

            Assert.AreEqual(NodeStatus.Success, sequenceNode.Tick(blackboard));
        }

        [Test]
        public void Tick_ChildFails_ReturnsFailure()
        {
            var blackboard = GetBlackboard();
            var children = new Node<TestBlackboard>[]
            {
                new ActionNode<TestBlackboard>((TestBlackboard bb) =>
                {
                    return NodeStatus.Success;
                }),
                new ActionNode<TestBlackboard>((TestBlackboard bb) =>
                {
                    return NodeStatus.Failure;
                }),
                new ActionNode<TestBlackboard>((TestBlackboard bb) =>
                {
                    return NodeStatus.Success;
                }),
            };
            var sequenceNode = new SequenceNode<TestBlackboard>(children);

            Assert.AreEqual(NodeStatus.Failure, sequenceNode.Tick(blackboard));
        }

        [Test]
        public void Tick_FirstChildReturnsFailure_SequenceReturns()
        {
            var blackboard = GetBlackboard();
            var mockAction = new Mock<ActionNode<TestBlackboard>>();
            var children = new Node<TestBlackboard>[]
            {
                new ActionNode<TestBlackboard>((TestBlackboard bb) =>
                {
                    return NodeStatus.Success;
                }),
                new ActionNode<TestBlackboard>((TestBlackboard bb) =>
                {
                    return NodeStatus.Failure;
                }),
                mockAction.Object,
            };
            var sequenceNode = new SelectorNode<TestBlackboard>(children);

            mockAction.Setup(x => x.Tick(blackboard)).Returns(NodeStatus.Success);

            mockAction.Verify(mock => mock.Tick(blackboard), Times.Never);
        }
    }
}
