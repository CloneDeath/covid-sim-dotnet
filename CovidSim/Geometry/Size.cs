using CovidSim.Geometry.Primitives;

namespace CovidSim.Geometry;

public class Size<T>(T w, T h, PrimitiveOperations<T> ops) {
	public readonly T width = w;
	public readonly T height = h;

	protected readonly PrimitiveOperations<T> Operations = ops;

	public static explicit operator Vector2<T>(Size<T> size) {
		return new Vector2<T>(size.width, size.height, size.Operations);
	}

	public T Area() => Operations.Multiply(width, height);
	public bool Contains(Vector2<T> point) {
		return Operations.GreaterThanOrEqual(point.X, Operations.Zero)
			&& Operations.LessThan(point.X, width)
			&& Operations.GreaterThanOrEqual(point.Y, Operations.Zero)
			&& Operations.LessThan(point.Y, height);
	}

	public Size<T> Floor() {
		return new Size<T>(Operations.Floor(width), Operations.Floor(height), Operations);
	}

	public Size<T> Ceil() {
		return new Size<T>(Operations.Ceil(width), Operations.Ceil(height), Operations);
	}

	public static Size<T> operator *(Size<T> left, Size<T> right) {
		return new Size<T>(left.Operations.Multiply(left.width, right.width),
			left.Operations.Multiply(left.height, right.height), left.Operations);
	}

	public static Size<T> operator /(Size<T> left, Size<T> right) {
		return new Size<T>(left.Operations.Divide(left.width, right.width),
			left.Operations.Divide(left.height, right.height), left.Operations);
	}

	public static Size<T> operator *(Size<T> left, T right) {
		return new Size<T>(left.Operations.Multiply(left.width, right),
			left.Operations.Multiply(left.height, right), left.Operations);
	}

	public static Size<T> operator *(T left, Size<T> right) {
		return new Size<T>(right.Operations.Multiply(left, right.width),
			right.Operations.Multiply(left, right.height), right.Operations);
	}

	public static Size<T> operator /(Size<T> left, T right) {
		return new Size<T>(left.Operations.Divide(left.width, right),
			left.Operations.Divide(left.height, right), left.Operations);
	}
}
