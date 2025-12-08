using System;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests;

[TestFixture]
public abstract class MicroCellPosition_tests
{
    [TestFixture]
    public class PlusOperator_tests : MicroCellPosition_tests
    {
        [Test]
        public void Constructor_AssignsFields()
        {
            var p = new MicroCellPosition(2, 3);
            p.x.Should().Be(2);
            p.y.Should().Be(3);
        }

        [Test]
        public void OperatorAdd_Right_IncrementsX()
        {
            var p = new MicroCellPosition(0, 0);
            var r = p + Direction.Right;
            r.x.Should().Be(1);
            r.y.Should().Be(0);
        }

        [Test]
        public void OperatorAdd_Left_DecrementsX()
        {
            var p = new MicroCellPosition(5, 5);
            var r = p + Direction.Left;
            r.x.Should().Be(4);
            r.y.Should().Be(5);
        }

        [Test]
        public void OperatorAdd_Up_DecrementsY()
        {
            var p = new MicroCellPosition(7, 7);
            var r = p + Direction.Up;
            r.x.Should().Be(7);
            r.y.Should().Be(6);
        }

        [Test]
        public void OperatorAdd_Down_IncrementsY()
        {
            var p = new MicroCellPosition(-1, -1);
            var r = p + Direction.Down;
            r.x.Should().Be(0);
            r.y.Should().Be(0);
        }

        [Test]
        public void OperatorAdd_DoesNotMutateOriginal()
        {
            var original = new MicroCellPosition(10, 20);
            var result = original + Direction.Left;
            original.x.Should().Be(10);
            original.y.Should().Be(20);
            result.x.Should().Be(9);
            result.y.Should().Be(20);
        }

        [Test]
        public void OperatorAdd_Chaining_WorksCorrectly()
        {
            var p = new MicroCellPosition(1, 1);
            var chained = p + Direction.Right + Direction.Up + Direction.Up + Direction.Left + Direction.Down;
            // calculations: (1,1) -> Right -> (2,1)
            // -> Up -> (2,0) -> Up -> (2,-1) -> Left -> (1,-1) -> Down -> (1,0)
            chained.x.Should().Be(1);
            chained.y.Should().Be(0);
        }

        [Test]
        public void OperatorAdd_InvalidDirection_ThrowsArgumentException()
        {
            var p = new MicroCellPosition(0, 0);
            var invalid = (Direction)999;
            Action act = () => { var _ = p + invalid; };
            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public void OperatorAdd_WithNegativeCoordinates_ProducesExpectedResult()
        {
            var p = new MicroCellPosition(-5, 4);
            var r = p + Direction.Right + Direction.Down;
            r.x.Should().Be(-4);
            r.y.Should().Be(5);
        }
    }
}
