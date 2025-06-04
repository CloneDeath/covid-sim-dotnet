using CovidSim.Geometry;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Geometry;

[TestFixture]
public class Vector2i_tests {
	[Test]
	public void ConstructorWorks() {
		var vector = new Vector2i(3, 4);
		vector.X.Should().Be(3);
		vector.Y.Should().Be(4);
	}
}
