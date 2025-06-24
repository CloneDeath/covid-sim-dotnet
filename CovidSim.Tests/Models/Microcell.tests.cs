using CovidSim.Models;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Models;

[TestFixture]
public class Microcell_tests {
	[Test]
	public void ConstructorWorks() {
		var microcell = new Microcell();
		microcell.members.Should().BeEmpty();
		microcell.places.Should().HaveCount(5);
		microcell.NumPlacesByType.Should().HaveCount(5);
		microcell.AirportList.Should().BeEmpty();
	}
}
