using System;

namespace CovidSim.Geometry.Primitives;

public class DoubleOperations : PrimitiveOperations<double> {
	public double Add(double left, double right) => left + right;
	public double Subtract(double left, double right) => left - right;
	public double Multiply(double left, double right) => left * right;
	public double Divide(double left, double right) => left / right;
	public double SquareRoot(double value) => Math.Sqrt(value);
	public double Absolute(double value) => Math.Abs(value);
}
