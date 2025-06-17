using CovidSim.Geometry.Primitives;

namespace CovidSim.Geometry;

public class Vector2i(int x, int y) : Vector2<int>(x, y, new IntegerOperations());

public class Vector2f(float x, float y) : Vector2<float>(x, y, new FloatOperations()) {
	public static Vector2<double> operator *(Vector2f left, DiagonalMatrix2d right) {
		return new Vector2d(left) * right;
	}
}

public class Vector2d(double x, double y) : Vector2<double>(x, y, new DoubleOperations()) {
	public Vector2d(Vector2f vector) : this(vector.X, vector.Y) { }

	public static Vector2d operator -(Vector2d left, Vector2i right) {
		return new Vector2d(left.X - right.X, left.Y - right.Y);
	}
	public static Vector2d operator-(Vector2i left, Vector2d right){
		return new Vector2d(left.X - right.X, left.Y - right.Y);
	}
}

public class Vector2<T>(T x, T y, PrimitiveOperations<T> operations) {
	public T X { get; } = x;
	public T Y { get; } = y;

	private PrimitiveOperations<T> Operations { get; } = operations;

	public double length() => Operations.SquareRoot(length_squared());

	public T length_squared() => Operations.Add(Operations.Multiply(X, X), Operations.Multiply(Y, Y));

	public Vector2<T> abs() => new(Operations.Absolute(X), Operations.Absolute(Y), Operations);

	public static Vector2<T> operator+(Vector2<T> left, Vector2<T> right) {
		return new Vector2<T>(
			left.Operations.Add(left.X, right.X),
			left.Operations.Add(left.Y, right.Y),
			left.Operations);
	}

	public static Vector2<T> operator-(Vector2<T> left, Vector2<T> right) {
		return new Vector2<T>(
			left.Operations.Subtract(left.X, right.X),
			left.Operations.Subtract(left.Y, right.Y),
			left.Operations);
	}
	public static Vector2<T> operator*(Vector2<T> left, Vector2<T> right) {
		return new Vector2<T>(
			left.Operations.Multiply(left.X, right.X),
			left.Operations.Multiply(left.Y, right.Y),
			left.Operations);
	}
	public static Vector2<T> operator/(Vector2<T> left, Vector2<T> right) {
		return new Vector2<T>(
			left.Operations.Divide(left.X, right.X),
			left.Operations.Divide(left.Y, right.Y),
			left.Operations);
	}

	public static Vector2<T> operator*(Vector2<T> left, DiagonalMatrix2<T> right) {
		return new Vector2<T>(
			left.Operations.Multiply(left.X, right.X),
			left.Operations.Multiply(left.Y, right.Y),
			left.Operations);
	}
}
