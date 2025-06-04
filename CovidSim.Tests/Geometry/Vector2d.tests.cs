using CovidSim.Geometry;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Geometry;

[TestFixture]
public class Vector2d_tests {
	[Test]
	public void ConstructorWorks() {
		var vector = new Vector2d(3.0, 4.0);
		vector.X.Should().Be(3.0);
		vector.Y.Should().Be(4.0);
	}

	[Test]
	public void SubtractionWith2i() {
		var vector = new Vector2d(-3.0, -4.0);
		var vector2i = new Vector2i(3, 4);
		var result = vector - vector2i;
		result.X.Should().Be(-6.0);
		result.Y.Should().Be(-8.0);
	}

	[Test]
	public void SubtractionWith2iOnLeft() {
		var vector = new Vector2d(3.0, -4.0);
		var vector2i = new Vector2i(1, 2);
		var result = vector2i - vector;
		result.X.Should().Be(-2.0);
		result.Y.Should().Be(6.0);
	}
}
