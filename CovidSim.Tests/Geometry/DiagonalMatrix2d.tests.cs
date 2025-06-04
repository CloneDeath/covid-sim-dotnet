using CovidSim.Geometry;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Geometry;

[TestFixture]
public class DiagonalMatrix2d_tests {
	[Test]
	public void ConstructorFor2dWorks() {
		var matrix = new DiagonalMatrix2d(3.5, 4.25);
		matrix.X.Should().Be(3.5);
		matrix.Y.Should().Be(4.25);
	}

	[Test]
	public void MultiplyByVectorOperatorWorks() {
		var matrix = new DiagonalMatrix2d(3.5, 4.25);
		var vector = new Vector2f(2.5f, 4.0f);
		var result = matrix * vector;
		result.X.Should().Be(8.75);
		result.Y.Should().Be(17);
	}
}
