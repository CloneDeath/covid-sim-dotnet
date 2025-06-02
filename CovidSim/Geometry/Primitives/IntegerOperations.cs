using System;

namespace CovidSim.Geometry.Primitives;

public class IntegerOperations : PrimitiveOperations<int> {
	public int Add(int left, int right) => left + right;
	public int Subtract(int left, int right) => left - right;
	public int Multiply(int left, int right) => left * right;
	public int Divide(int left, int right) => left / right;
	public double SquareRoot(int value) => Math.Sqrt(value);
	public int Absolute(int value) => Math.Abs(value);
}
