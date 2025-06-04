namespace CovidSim.Geometry;

public class DiagonalMatrix2i(int x, int y) : DiagonalMatrix2<int>(x, y);
public class DiagonalMatrix2f(float x, float y) : DiagonalMatrix2<float>(x, y);

public class DiagonalMatrix2d(double x, double y) : DiagonalMatrix2<double>(x, y) {
	public static Vector2d operator*(DiagonalMatrix2d left, Vector2f right) {
		return new Vector2d(
			left.X * right.X,
			left.Y * right.Y);
	}
}

public class DiagonalMatrix2<T>(T x, T y) {
	public T X { get; } = x;
	public T Y { get; } = y;
}
