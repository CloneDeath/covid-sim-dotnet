using CovidSim.Geometry.Primitives;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Geometry.Primitives;

[TestFixture]
public abstract class IntegerOperations_tests {
	[TestFixture]
	public class IntegerOperations_Add_tests : IntegerOperations_tests {
		[Test]
		public void Add() {
			var ops = new IntegerOperations();
			ops.Add(2, 3).Should().Be(5);
		}
	}

	[TestFixture]
	public class IntegerOperations_Subtract_tests : IntegerOperations_tests {
		[Test]
		public void Subtract() {
			var ops = new IntegerOperations();
			ops.Subtract(5, 3).Should().Be(2);
		}
	}

	[TestFixture]
	public class IntegerOperations_Multiply_tests : IntegerOperations_tests {
		[Test]
		public void Multiply() {
			var ops = new IntegerOperations();
			ops.Multiply(2, 3).Should().Be(6);
		}
	}

	[TestFixture]
	public class IntegerOperations_Divide_tests : IntegerOperations_tests {
		[Test]
		public void Divide() {
			var ops = new IntegerOperations();
			ops.Divide(6, 3).Should().Be(2);
		}
	}

	[TestFixture]
	public class IntegerOperations_SquareRoot_tests : IntegerOperations_tests {
		[Test]
		public void SquareRoot() {
			var ops = new IntegerOperations();
			ops.SquareRoot(4).Should().Be(2);
		}
	}

	[TestFixture]
	public class IntegerOperations_Absolute_tests : IntegerOperations_tests {
		[Test]
		public void Absolute() {
			var ops = new IntegerOperations();
			ops.Absolute(-3).Should().Be(3);
			ops.Absolute(3).Should().Be(3);
		}
	}

	[TestFixture]
	public class IntegerOperations_Ceil_tests : IntegerOperations_tests {
		[Test]
		public void Ceil() {
			var ops = new IntegerOperations();
			ops.Ceil(2).Should().Be(2);
			ops.Ceil(-2).Should().Be(-2);
		}
	}

	[TestFixture]
	public class IntegerOperations_Floor_tests : IntegerOperations_tests {
		[Test]
		public void Floor() {
			var ops = new IntegerOperations();
			ops.Floor(2).Should().Be(2);
			ops.Floor(-2).Should().Be(-2);
		}
	}

	[TestFixture]
	public class IntegerOperations_GreaterThan_tests : IntegerOperations_tests {
		[Test]
		public void GreaterThan() {
			var ops = new IntegerOperations();
			ops.GreaterThan(3, 2).Should().BeTrue();
			ops.GreaterThan(2, 3).Should().BeFalse();
			ops.GreaterThan(1, 1).Should().BeFalse();
		}
	}

	[TestFixture]
	public class IntegerOperations_GreaterThanOrEqual_tests : IntegerOperations_tests {
		[Test]
		public void GreaterThanOrEqual() {
			var ops = new IntegerOperations();
			ops.GreaterThanOrEqual(3, 2).Should().BeTrue();
			ops.GreaterThanOrEqual(2, 3).Should().BeFalse();
			ops.GreaterThanOrEqual(1, 1).Should().BeTrue();
		}
	}

	[TestFixture]
	public class IntegerOperations_LessThan_tests : IntegerOperations_tests {
		[Test]
		public void LessThan() {
			var ops = new IntegerOperations();
			ops.LessThan(2, 3).Should().BeTrue();
			ops.LessThan(3, 2).Should().BeFalse();
			ops.LessThan(1, 1).Should().BeFalse();
		}
	}

	[TestFixture]
	public class IntegerOperations_LessThanOrEqual_tests : IntegerOperations_tests {
		[Test]
		public void LessThanOrEqual() {
			var ops = new IntegerOperations();
			ops.LessThanOrEqual(2, 3).Should().BeTrue();
			ops.LessThanOrEqual(3, 2).Should().BeFalse();
			ops.LessThanOrEqual(1, 1).Should().BeTrue();
		}
	}

	[TestFixture]
	public class IntegerOperations_Zero_tests : IntegerOperations_tests {
		[Test]
		public void Zero() {
			var ops = new IntegerOperations();
			ops.Zero.Should().Be(0);
		}
	}
}
