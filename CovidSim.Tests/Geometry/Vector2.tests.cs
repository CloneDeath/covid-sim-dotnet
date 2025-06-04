using CovidSim.Geometry;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Geometry;

[TestFixture]
public class Vector2_tests {
	[Test]
	public void Length() {
		var vector = new Vector2d(3.0, 4.0);
		vector.length().Should().Be(5);
	}

	[Test]
	public void LengthSquared() {
		var vector = new Vector2d(3.0, 4.0);
		vector.length_squared().Should().Be(25);
	}

	[TestCase(3.0, 4.0, 3.0, 4.0)]
	[TestCase(-1.0, 2.3, 1, 2.3)]
	[TestCase(-6.0, -9.8, 6, 9.8)]
	public void Abs(double x, double y, double expectedX, double expectedY) {
		var vector = new Vector2d(x, y);
		var absVector = vector.abs();
		absVector.X.Should().Be(expectedX);
		absVector.Y.Should().Be(expectedY);
	}

	[Test]
	public void AddOperator() {
		var left = new Vector2d(3.0, 4.0);
		var right = new Vector2d(1.0, 2.0);
		var result = left + right;
		result.X.Should().Be(4.0);
		result.Y.Should().Be(6.0);
	}

	[Test]
	public void SubtractOperator() {
		var left = new Vector2d(3.0, 4.0);
		var right = new Vector2d(1.0, 2.0);
		var result = left - right;
		result.X.Should().Be(2.0);
		result.Y.Should().Be(2.0);
	}

	[Test]
	public void MultiplyOperator() {
		var left = new Vector2d(3.0, 4.0);
		var right = new Vector2d(2.0, 3.0);
		var result = left * right;
		result.X.Should().Be(6.0);
		result.Y.Should().Be(12.0);
	}

	[Test]
	public void DivideOperator() {
		var left = new Vector2d(3.0, 4.0);
		var right = new Vector2d(1.0, 2.0);
		var result = left / right;
		result.X.Should().Be(3.0);
		result.Y.Should().Be(2.0);
	}

	[Test]
	public void MultiplyByDiagonalMatrixOperator() {
		var left = new Vector2d(3.0, 4.0);
		var right = new DiagonalMatrix2d(2.0, 3.0);
		var result = left * right;
		result.X.Should().Be(6.0);
		result.Y.Should().Be(12.0);
	}
}
