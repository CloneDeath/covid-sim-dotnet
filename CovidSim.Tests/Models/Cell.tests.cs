using CovidSim.Models;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Models;

[TestFixture]
public class Cell_tests {
	[Test]
	public void ConstructorWorks() {
		var c = new Cell();
		c.members.Should().HaveCount(0);
	}
}
