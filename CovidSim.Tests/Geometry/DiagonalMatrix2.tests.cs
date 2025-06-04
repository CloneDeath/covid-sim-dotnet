using CovidSim.Geometry;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Geometry;

[TestFixture]
public class DiagonalMatrix2_tests {
	[Test]
	public void ConstructorFor2fWorks() {
		var matrix = new DiagonalMatrix2f(3.5f, 4.5f);
		matrix.X.Should().Be(3.5f);
		matrix.Y.Should().Be(4.5f);
	}

	[Test]
	public void ConstructorFor2iWorks() {
		var matrix = new DiagonalMatrix2i(3, 4);
		matrix.X.Should().Be(3);
		matrix.Y.Should().Be(4);
	}
}
