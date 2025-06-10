using System;

namespace CovidSim.Geometry.Primitives;

public class IntegerOperations : PrimitiveOperations<int> {
	public int Add(int left, int right) => left + right;
	public int Subtract(int left, int right) => left - right;
	public int Multiply(int left, int right) => left * right;
	public int Divide(int left, int right) => left / right;

	public double SquareRoot(int value) => Math.Sqrt(value);
	public int Absolute(int value) => Math.Abs(value);
	public int Ceil(int value) => value;
	public int Floor(int value) => value;

	public bool GreaterThan(int left, int right) => left > right;
	public bool GreaterThanOrEqual(int left, int right) => left >= right;
	public bool LessThan(int left, int right) => left < right;
	public bool LessThanOrEqual(int left, int right) => left <= right;

	public int Zero => 0;
}
