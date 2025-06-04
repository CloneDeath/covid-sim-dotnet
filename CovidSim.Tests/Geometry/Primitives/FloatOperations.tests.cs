using CovidSim.Geometry.Primitives;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Geometry.Primitives;

[TestFixture]
public class FloatOperations_tests {
	[Test]
	public void Add() {
		var ops = new FloatOperations();
		ops.Add(2.0f, 3.0f).Should().Be(5);
	}

	[Test]
	public void Subtract() {
		var ops = new FloatOperations();
		ops.Subtract(5.0f, 3.0f).Should().Be(2);
	}

	[Test]
	public void Multiply() {
		var ops = new FloatOperations();
		ops.Multiply(2.0f, 3.0f).Should().Be(6);
	}

	[Test]
	public void Divide() {
		var ops = new FloatOperations();
		ops.Divide(6.0f, 3.0f).Should().Be(2);
	}

	[Test]
	public void SquareRoot() {
		var ops = new FloatOperations();
		ops.SquareRoot(4.0f).Should().Be(2);
	}

	[Test]
	public void Absolute() {
		var ops = new FloatOperations();
		ops.Absolute(-3.0f).Should().Be(3);
		ops.Absolute(3.0f).Should().Be(3);
	}
}
