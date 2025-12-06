using CovidSim.TBD1;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.TBD1;

[TestFixture]
public abstract class KernelStruct_tests {
	[TestFixture]
	public class KernelStruct_exponential_tests : KernelStruct_tests {
		[Test]
		public void ExponentialTest() {
			var kernel = new KernelStruct { scale_ = 1.0 };
			var result = kernel.exponential(4.0);
			result.Should().BeApproximately(.135, .001);
		}
	}

	[TestFixture]
	public class KernelStruct_power_tests : KernelStruct_tests {
		[Test]
		public void PowerTest() {
			var kernel = new KernelStruct { shape_ = 1, scale_ = 1.0 };
			var result = kernel.power(4.0);
			result.Should().Be(1/3.0);
		}
	}

	[TestFixture]
	public class KernelStruct_power_b_tests : KernelStruct_tests {
		[Test]
		public void PowerBTest() {
			var kernel = new KernelStruct { shape_ = 1, scale_ = 1.0 };
			var result = kernel.power_b(4.0);
			result.Should().Be(1/3.0);
		}
	}

	[TestFixture]
	public class KernelStruct_power_us_tests : KernelStruct_tests {
		[Test]
		public void PowerUSTest() {
			var kernel = new KernelStruct { shape_ = 1, scale_ = 1.0, p3_ = 0.5, p4_ = 2 };
			var result = kernel.power_us(4.0);
			result.Should().BeApproximately(0.259, 0.001);
		}
	}

	[TestFixture]
	public class KernelStruct_power_exp_tests : KernelStruct_tests {
		[Test]
		public void PowerExpTest() {
			var kernel = new KernelStruct { shape_ = 1, scale_ = 1.0, p3_ = 2, p4_ = 2 };
			var result = kernel.power_exp(4.0);
			result.Should().BeApproximately(0.122, 0.001);
		}
	}

	[TestFixture]
	public class KernelStruct_gaussian_tests : KernelStruct_tests {
		[Test]
		public void GaussianTest() {
			var kernel = new KernelStruct { scale_ = 1.0 };
			var result = kernel.gaussian(4.0);
			result.Should().BeApproximately(0.018, 0.001);
		}
	}

	[TestFixture]
	public class KernelStruct_step_tests : KernelStruct_tests {
		[Test]
		public void StepTest() {
			var kernel = new KernelStruct { scale_ = 2.0 };
			var result = kernel.step(4.5);
			result.Should().Be(0.0);
		}
	}
}
