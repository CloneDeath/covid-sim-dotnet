using System;

namespace CovidSim.Geometry.Primitives;

public class FloatOperations : PrimitiveOperations<float> {
	public float Add(float left, float right) => left + right;
	public float Subtract(float left, float right) => left - right;
	public float Multiply(float left, float right) => left * right;
	public float Divide(float left, float right) => left / right;

	public double SquareRoot(float value) => Math.Sqrt(value);
	public float Absolute(float value) => Math.Abs(value);
	public float Ceil(float value) => MathF.Ceiling(value);
	public float Floor(float value) => MathF.Floor(value);

	public bool GreaterThan(float left, float right) => left > right;
	public bool GreaterThanOrEqual(float left, float right) => left >= right;
	public bool LessThan(float left, float right) => left < right;
	public bool LessThanOrEqual(float left, float right) => left <= right;

	public float Zero => 0;
}
