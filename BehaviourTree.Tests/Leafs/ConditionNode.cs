using BT.Leafs;
using NUnit.Framework;

namespace BT.Tests.Leafs
{
    [TestFixture]
    class ConditionNode : NodeTest<TestBlackboard>
    {
        [Test]
        public void Tick_Returns_Success_If_Delegate_True()
        {
            var blackboard = GetBlackboard();
            var result = new ConditionNode<TestBlackboard>((TestBlackboard bb) =>
            {
                return true;
            });

            Assert.AreEqual(NodeStatus.Success, result.Tick(blackboard));
        }

        [Test]
        public void Tick_Returns_Failure_If_Delegate_False()
        {
            var blackboard = GetBlackboard();
            var result = new ConditionNode<TestBlackboard>((TestBlackboard bb) =>
            {
                return false;
            });

            Assert.AreEqual(NodeStatus.Failure, result.Tick(blackboard));
        }
    }
}
