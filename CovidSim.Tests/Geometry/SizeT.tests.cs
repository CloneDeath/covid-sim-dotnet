using CovidSim.Geometry;
using CovidSim.Geometry.Primitives;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Geometry;

public class TestSize(double x, double y) : Size<double>(x, y, new DoubleOperations());

[TestFixture]
public abstract class SizeT_tests {
	[TestFixture]
	public class SizeT_Constructor_tests : SizeT_tests {
		[Test]
		public void ConstructorWorks() {
			var size = new TestSize(3.0, 4.0);

			size.width.Should().Be(3.0);
			size.height.Should().Be(4.0);
		}
	}

	[TestFixture]
	public class SizeT_Area_tests : SizeT_tests {
		[Test]
		public void AreaWorks() {
			var size = new TestSize(3.0, 4.0);
			size.Area().Should().Be(12.0);
		}
	}

	[TestFixture]
	public class SizeT_Contains_tests : SizeT_tests {
		[Test]
		public void ContainsWorks() {
			var size = new TestSize(3.0, 4.0);
			size.Contains(new Vector2d(1.0, 2.0)).Should().BeTrue();
			size.Contains(new Vector2d(3.0, 4.0)).Should().BeFalse();
			size.Contains(new Vector2d(-1.0, 2.0)).Should().BeFalse();
			size.Contains(new Vector2d(1.0, -2.0)).Should().BeFalse();
		}
	}

	[TestFixture]
	public class SizeT_Floor_tests : SizeT_tests {
		[Test]
		public void FloorWorks() {
			var size = new TestSize(3.7, 4.2);
			var floored = size.Floor();
			floored.width.Should().Be(3.0);
			floored.height.Should().Be(4.0);
		}
	}

	[TestFixture]
	public class SizeT_Ceil_tests : SizeT_tests {
		[Test]
		public void CeilWorks() {
			var size = new TestSize(3.1, 4.9);
			var ceil = size.Ceil();
			ceil.width.Should().Be(4.0);
			ceil.height.Should().Be(5.0);
		}
	}

	[TestFixture]
	public class SizeT_Operator_tests : SizeT_tests {
		[Test]
		public void MultiplicationWorks() {
			var size1 = new TestSize(2.0, 3.0);
			var size2 = new TestSize(4.0, 5.0);
			var result = size1 * size2;
			result.width.Should().Be(8.0);
			result.height.Should().Be(15.0);
		}

		[Test]
		public void DivisionWorks() {
			var size1 = new TestSize(8.0, 10.0);
			var size2 = new TestSize(2.0, 5.0);
			var result = size1 / size2;
			result.width.Should().Be(4.0);
			result.height.Should().Be(2.0);
		}

		[Test]
		public void ScalarMultiplicationWorks() {
			var size = new TestSize(3.0, 4.0);
			var result = size * 2.0;
			result.width.Should().Be(6.0);
			result.height.Should().Be(8.0);
		}

		[Test]
		public void ReverseScalarMultiplicationWorks() {
			var size = new TestSize(3.0, 4.0);
			var result = 2.0 * size;
			result.width.Should().Be(6.0);
			result.height.Should().Be(8.0);
		}

		[Test]
		public void ScalarDivisionWorks() {
			var size = new TestSize(6.0, 8.0);
			var result = size / 2.0;
			result.width.Should().Be(3.0);
			result.height.Should().Be(4.0);
		}

		[Test]
		public void ExplicitCastToVector2dWorks() {
			var size = new TestSize(3.0, 4.0);
			var vector = (Vector2<double>)size;
			vector.X.Should().Be(3.0);
			vector.Y.Should().Be(4.0);
		}
	}
}
