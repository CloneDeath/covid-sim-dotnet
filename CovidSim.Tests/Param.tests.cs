using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests;

[TestFixture]
public abstract class Param_tests {
	[TestFixture]
	public class Param_sinx_tests : Param_tests {
		[TestCase(0, 0)]
		[TestCase(30, 0.5)]
		[TestCase(180, 0)]
		[TestCase(270, -1)]
		public void ItWorks(int i, double expected) {
			Param.P.sinx(i).Should().BeApproximately(expected, 0.001);
		}
	}

	[TestFixture]
	public class Param_cosx_tests : Param_tests {
		[TestCase(0, 1)]
		[TestCase(30, 0.866)]
		[TestCase(180, -1)]
		[TestCase(270, 0)]
		public void ItWorks(int i, double expected) {
			Param.P.cosx(i).Should().BeApproximately(expected, 0.001);
		}
	}

	[TestFixture]
	public class Param_asin2sqx_tests : Param_tests {
		[TestCase(0, 0)]
		[TestCase(1000, 2.467)]
		[TestCase(250, 0.274)]
		[TestCase(500, 0.616)]
		public void ItWorks(int i, double expected) {
			Param.P.asin2sqx(i).Should().BeApproximately(expected, 0.001);
		}
	}
}
