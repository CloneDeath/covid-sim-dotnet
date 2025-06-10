using CovidSim.Geometry.Primitives;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Geometry.Primitives;

[TestFixture]
public abstract class FloatOperations_tests {
	[TestFixture]
	public class FloatOperations_Add_tests : FloatOperations_tests {
		[Test]
		public void Add() {
			var ops = new FloatOperations();
			ops.Add(2.0f, 3.0f).Should().Be(5);
		}
	}

	[TestFixture]
	public class FloatOperations_Subtract_tests : FloatOperations_tests {
		[Test]
		public void Subtract() {
			var ops = new FloatOperations();
			ops.Subtract(5.0f, 3.0f).Should().Be(2);
		}
	}

	[TestFixture]
	public class FloatOperations_Multiply_tests : FloatOperations_tests {
		[Test]
		public void Multiply() {
			var ops = new FloatOperations();
			ops.Multiply(2.0f, 3.0f).Should().Be(6);
		}
	}

	[TestFixture]
	public class FloatOperations_Divide_tests : FloatOperations_tests {
		[Test]
		public void Divide() {
			var ops = new FloatOperations();
			ops.Divide(6.0f, 3.0f).Should().Be(2);
		}
	}

	[TestFixture]
	public class FloatOperations_SquareRoot_tests : FloatOperations_tests {
		[Test]
		public void SquareRoot() {
			var ops = new FloatOperations();
			ops.SquareRoot(4.0f).Should().Be(2);
		}
	}

	[TestFixture]
	public class FloatOperations_Absolute_tests : FloatOperations_tests {
		[Test]
		public void Absolute() {
			var ops = new FloatOperations();
			ops.Absolute(-3.0f).Should().Be(3);
			ops.Absolute(3.0f).Should().Be(3);
		}
	}

	[TestFixture]
	public class FloatOperations_Ceil_tests : FloatOperations_tests {
		[Test]
		public void Ceil() {
			var ops = new FloatOperations();
			ops.Ceil(2.3f).Should().Be(3);
			ops.Ceil(-2.3f).Should().Be(-2);
		}
	}

	[TestFixture]
	public class FloatOperations_Floor_tests : FloatOperations_tests {
		[Test]
		public void Floor() {
			var ops = new FloatOperations();
			ops.Floor(2.7f).Should().Be(2);
			ops.Floor(-2.7f).Should().Be(-3);
		}
	}

	[TestFixture]
	public class FloatOperations_GreaterThan_tests : FloatOperations_tests {
		[Test]
		public void GreaterThan() {
			var ops = new FloatOperations();
			ops.GreaterThan(3.0f, 2.0f).Should().BeTrue();
			ops.GreaterThan(2.0f, 3.0f).Should().BeFalse();
			ops.GreaterThan(1, 1).Should().BeFalse();
		}
	}

	[TestFixture]
	public class FloatOperations_GreaterThanOrEqual_tests : FloatOperations_tests {
		[Test]
		public void GreaterThanOrEqual() {
			var ops = new FloatOperations();
			ops.GreaterThanOrEqual(3.0f, 2.0f).Should().BeTrue();
			ops.GreaterThanOrEqual(2.0f, 3.0f).Should().BeFalse();
			ops.GreaterThanOrEqual(1, 1).Should().BeTrue();
		}
	}

	[TestFixture]
	public class FloatOperations_LessThan_tests : FloatOperations_tests {
		[Test]
		public void LessThan() {
			var ops = new FloatOperations();
			ops.LessThan(2.0f, 3.0f).Should().BeTrue();
			ops.LessThan(3.0f, 2.0f).Should().BeFalse();
			ops.LessThan(1, 1).Should().BeFalse();
		}
	}

	[TestFixture]
	public class FloatOperations_LessThanOrEqual_tests : FloatOperations_tests {
		[Test]
		public void LessThanOrEqual() {
			var ops = new FloatOperations();
			ops.LessThanOrEqual(2.0f, 3.0f).Should().BeTrue();
			ops.LessThanOrEqual(3.0f, 2.0f).Should().BeFalse();
			ops.LessThanOrEqual(1, 1).Should().BeTrue();
		}
	}

	[TestFixture]
	public class FloatOperations_Zero_tests : FloatOperations_tests {
		[Test]
		public void Zero() {
			var ops = new FloatOperations();
			ops.Zero.Should().Be(0.0f);
		}
	}
}
