using CovidSim.Geometry.Primitives;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Geometry.Primitives;

[TestFixture]
public abstract class DoubleOperations_tests {
	[TestFixture]
	public class DoubleOperations_Add_tests : DoubleOperations_tests {
		[Test]
		public void Add() {
			var ops = new DoubleOperations();
			ops.Add(2.0, 3.0).Should().Be(5);
		}
	}

	[TestFixture]
	public class DoubleOperations_Subtract_tests : DoubleOperations_tests {
		[Test]
		public void Subtract() {
			var ops = new DoubleOperations();
			ops.Subtract(5.0, 3.0).Should().Be(2);
		}
	}

	[TestFixture]
	public class DoubleOperations_Multiply_tests : DoubleOperations_tests {
		[Test]
		public void Multiply() {
			var ops = new DoubleOperations();
			ops.Multiply(2.0, 3.0).Should().Be(6);
		}
	}

	[TestFixture]
	public class DoubleOperations_Divide_tests : DoubleOperations_tests {
		[Test]
		public void Divide() {
			var ops = new DoubleOperations();
			ops.Divide(6.0, 3.0).Should().Be(2);
		}
	}

	[TestFixture]
	public class DoubleOperations_SquareRoot_tests : DoubleOperations_tests {
		[Test]
		public void SquareRoot() {
			var ops = new DoubleOperations();
			ops.SquareRoot(4.0).Should().Be(2);
		}
	}

	[TestFixture]
	public class DoubleOperations_Absolute_tests : DoubleOperations_tests {
		[Test]
		public void Absolute() {
			var ops = new DoubleOperations();
			ops.Absolute(-3.0).Should().Be(3);
			ops.Absolute(3.0).Should().Be(3);
		}
	}

	[TestFixture]
	public class DoubleOperations_Ceil_tests : DoubleOperations_tests {
		[Test]
		public void Ceil() {
			var ops = new DoubleOperations();
			ops.Ceil(2.3).Should().Be(3);
			ops.Ceil(2.7).Should().Be(3);
			ops.Ceil(-2.3).Should().Be(-2);
		}
	}

	[TestFixture]
	public class DoubleOperations_Floor_tests : DoubleOperations_tests {
		[Test]
		public void Floor() {
			var ops = new DoubleOperations();
			ops.Floor(2.3).Should().Be(2);
			ops.Floor(2.7).Should().Be(2);
			ops.Floor(-2.3).Should().Be(-3);
		}
	}

	[TestFixture]
	public class DoubleOperations_GreaterThan_tests : DoubleOperations_tests {
		[Test]
		public void GreaterThan() {
			var ops = new DoubleOperations();
			ops.GreaterThan(3.0, 2.0).Should().BeTrue();
			ops.GreaterThan(2.0, 3.0).Should().BeFalse();
			ops.GreaterThan(1, 1).Should().BeFalse();
		}
	}

	[TestFixture]
	public class DoubleOperations_GreaterThanOrEqual_tests : DoubleOperations_tests {
		[Test]
		public void GreaterThanOrEqual() {
			var ops = new DoubleOperations();
			ops.GreaterThanOrEqual(3.0, 2.0).Should().BeTrue();
			ops.GreaterThanOrEqual(2.0, 3.0).Should().BeFalse();
			ops.GreaterThanOrEqual(1, 1).Should().BeTrue();
		}
	}

	[TestFixture]
	public class DoubleOperations_LessThan_tests : DoubleOperations_tests {
		[Test]
		public void LessThan() {
			var ops = new DoubleOperations();
			ops.LessThan(2.0, 3.0).Should().BeTrue();
			ops.LessThan(3.0, 2.0).Should().BeFalse();
			ops.LessThan(1, 1).Should().BeFalse();
		}
	}

	[TestFixture]
	public class DoubleOperations_LessThanOrEqual_tests : DoubleOperations_tests {
		[Test]
		public void LessThanOrEqual() {
			var ops = new DoubleOperations();
			ops.LessThanOrEqual(2.0, 3.0).Should().BeTrue();
			ops.LessThanOrEqual(3.0, 2.0).Should().BeFalse();
			ops.LessThanOrEqual(1, 1).Should().BeTrue();
		}
	}

	[TestFixture]
	public class DoubleOperations_Zero_tests : DoubleOperations_tests {
		[Test]
		public void Zero() {
			var ops = new DoubleOperations();
			ops.Zero.Should().Be(0);
		}
	}
}
