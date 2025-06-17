using CovidSim.Models;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Models;

[TestFixture]
public class Place_tests {
	[Test]
	public void ConstructorWorks() {
		var place = new Place();
		place.AvailByAge.Should().BeEmpty();
		place.Absent.Should().HaveCount(8);
		place.group_start.Should().BeEmpty();
		place.group_size.Should().BeEmpty();
		place.members.Should().BeEmpty();
	}
}
