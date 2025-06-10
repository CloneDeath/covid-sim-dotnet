using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests;

[TestFixture]
public abstract class Direction_tests {
	[TestFixture]
	public class Direction_RotateLeft_tests : Direction_tests {
		[TestCase(Direction.Up, Direction.Left)]
		[TestCase(Direction.Right, Direction.Up)]
		[TestCase(Direction.Left, Direction.Down)]
		[TestCase(Direction.Down, Direction.Right)]
		public void ExpectedRotationOccurs(Direction direction, Direction expected) {
			var actual = direction.RotateLeft();
			actual.Should().Be(expected);
		}
	}
}
