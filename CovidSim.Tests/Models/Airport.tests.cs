using CovidSim.Models;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Models;

[TestFixture]
public class Airport_tests {
	[Test]
	public void ConstructorWorks() {
		var airport = new Airport();
		airport.Inv_prop_traffic.Should().HaveCount(129);
		airport.Inv_DestMcells.Should().HaveCount(1025);
		airport.Inv_DestMcells.Should().HaveCount(1025);
		airport.conn_airports.Should().BeEmpty();
		airport.loc.X.Should().Be(0);
		airport.loc.Y.Should().Be(0);
		airport.prop_traffic.Should().BeEmpty();
		airport.DestMcells.Should().BeEmpty();
		airport.DestPlaces.Should().BeEmpty();
	}
}
