using System;

namespace CovidSim.Geometry.Primitives;

public class FloatOperations : PrimitiveOperations<float> {
	public float Add(float left, float right) => left + right;
	public float Subtract(float left, float right) => left - right;
	public float Multiply(float left, float right) => left * right;
	public float Divide(float left, float right) => left / right;
	public double SquareRoot(float value) => Math.Sqrt(value);
	public float Absolute(float value) => Math.Abs(value);
}
