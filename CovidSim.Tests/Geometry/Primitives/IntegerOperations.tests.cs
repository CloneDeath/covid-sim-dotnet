using CovidSim.Geometry.Primitives;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Geometry.Primitives;

[TestFixture]
public class IntegerOperations_tests {
	[Test]
	public void Add() {
		var ops = new IntegerOperations();
		ops.Add(2, 3).Should().Be(5);
	}

	[Test]
	public void Subtract() {
		var ops = new IntegerOperations();
		ops.Subtract(5, 3).Should().Be(2);
	}

	[Test]
	public void Multiply() {
		var ops = new IntegerOperations();
		ops.Multiply(2, 3).Should().Be(6);
	}

	[Test]
	public void Divide() {
		var ops = new IntegerOperations();
		ops.Divide(6, 3).Should().Be(2);
	}

	[Test]
	public void SquareRoot() {
		var ops = new IntegerOperations();
		ops.SquareRoot(4).Should().Be(2);
	}

	[Test]
	public void Absolute() {
		var ops = new IntegerOperations();
		ops.Absolute(-3).Should().Be(3);
		ops.Absolute(3).Should().Be(3);
	}
}
