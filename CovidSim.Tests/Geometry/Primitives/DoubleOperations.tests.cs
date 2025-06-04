using CovidSim.Geometry.Primitives;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Geometry.Primitives;

[TestFixture]
public class DoubleOperations_tests {
	[Test]
	public void Add() {
		var ops = new DoubleOperations();
		ops.Add(2.0, 3.0).Should().Be(5);
	}

	[Test]
	public void Subtract() {
		var ops = new DoubleOperations();
		ops.Subtract(5.0, 3.0).Should().Be(2);
	}

	[Test]
	public void Multiply() {
		var ops = new DoubleOperations();
		ops.Multiply(2.0, 3.0).Should().Be(6);
	}

	[Test]
	public void Divide() {
		var ops = new DoubleOperations();
		ops.Divide(6.0, 3.0).Should().Be(2);
	}

	[Test]
	public void SquareRoot() {
		var ops = new DoubleOperations();
		ops.SquareRoot(4.0).Should().Be(2);
	}

	[Test]
	public void Absolute() {
		var ops = new DoubleOperations();
		ops.Absolute(-3.0).Should().Be(3);
		ops.Absolute(3.0).Should().Be(3);
	}
}
