namespace CovidSim.Geometry.Primitives;

public interface PrimitiveOperations<T> {
	T Add(T left, T right);
	T Subtract(T left, T right);
	T Multiply(T left, T right);
	T Divide(T left, T right);
	double SquareRoot(T value);
	T Absolute(T value);
	T Ceil(T value);
	T Floor(T value);

	bool GreaterThan(T left, T right);
	bool GreaterThanOrEqual(T left, T right);
	bool LessThan(T left, T right);
	bool LessThanOrEqual(T left, T right);

	T Zero { get; }
}
