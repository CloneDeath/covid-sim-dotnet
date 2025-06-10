using System;

namespace CovidSim.Geometry.Primitives;

public class DoubleOperations : PrimitiveOperations<double> {
	public double Add(double left, double right) => left + right;
	public double Subtract(double left, double right) => left - right;
	public double Multiply(double left, double right) => left * right;
	public double Divide(double left, double right) => left / right;

	public double SquareRoot(double value) => Math.Sqrt(value);
	public double Absolute(double value) => Math.Abs(value);
	public double Ceil(double value) => Math.Ceiling(value);
	public double Floor(double value) => Math.Floor(value);

	public bool GreaterThan(double left, double right) => left > right;
	public bool GreaterThanOrEqual(double left, double right) => left >= right;
	public bool LessThan(double left, double right) => left < right;
	public bool LessThanOrEqual(double left, double right) => left <= right;

	public double Zero => 0;
}
