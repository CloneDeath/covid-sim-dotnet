using CovidSim.Geometry;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Geometry;

[TestFixture]
public class Vector2f_tests {
	[Test]
	public void ConstructorWorks() {
		var vector = new Vector2f(3.0f, 4.0f);
		vector.X.Should().Be(3.0f);
		vector.Y.Should().Be(4.0f);
	}

	[Test]
	public void MultiplicationWithDiagonalMatrix2dWorks() {
		var vector = new Vector2f(3.0f, 4.0f);
		var matrix = new DiagonalMatrix2d(2.0, 3.0);
		var result = vector * matrix;
		result.X.Should().Be(6.0);
		result.Y.Should().Be(12.0);
	}
}
