namespace CovidSim.Geometry.Primitives;

public interface PrimitiveOperations<T> {
	T Add(T left, T right);
	T Subtract(T left, T right);
	T Multiply(T left, T right);
	T Divide(T left, T right);
	double SquareRoot(T value);
	T Absolute(T value);
}
