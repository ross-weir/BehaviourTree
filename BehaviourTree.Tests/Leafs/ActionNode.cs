using BT.Leafs;
using NUnit.Framework;

namespace BT.Tests.Leafs
{
    [TestFixture]
    class ActionNode : NodeTest<TestBlackboard>
    {
        [TestCase(NodeStatus.Failure)]
        [TestCase(NodeStatus.Running)]
        [TestCase(NodeStatus.Success)]
        public void Tick_ReturnsStatus(NodeStatus status)
        {
            var blackboard = GetBlackboard();
            var result = new ActionNode<TestBlackboard>((TestBlackboard bb) =>
            {
                return status;
            });

            Assert.AreEqual(status, result.Tick(blackboard));
        }
    }
}
