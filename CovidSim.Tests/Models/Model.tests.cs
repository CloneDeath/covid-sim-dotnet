using CovidSim.Models;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Models;

[TestFixture]
public class Model_tests {
	[Test]
	public void HostsIsInitiallyEmpty() {
		Model.Hosts.Should().BeEmpty();
	}
}
