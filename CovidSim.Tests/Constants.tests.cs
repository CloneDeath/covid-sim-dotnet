using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests;

[TestFixture]
public class Constants_tests {
	[Test]
	public void I64Works() {
		var x = Constants._I64(12);
		x.Should().Be(12);
	}
}
