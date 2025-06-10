using System;
namespace CovidSim.Geometry;

public struct Maximum2d(double x, double y) {
    public double X = x;
    public double Y = y;

    public void Expand(Vector2d p, double offset) {
        if (p.X >= X) X = p.X + offset;
        if (p.Y >= Y) Y = p.Y + offset;
    }

    public bool Inside(Vector2d p) => p.X < X && p.Y < Y;

    public void ToGrid(double width, double height) {
        X = Math.Ceiling(X / width) * width;
        Y = Math.Ceiling(Y / height) * height;
    }
}

public struct Minimum2d(double x, double y) {
    public double X = x;
    public double Y = y;

    public void Expand(Vector2d p) {
        if (p.X < X) X = p.X;
        if (p.Y < Y) Y = p.Y;
    }

    public bool Inside(Vector2d p) => p.X >= X && p.Y >= Y;

    public void ToGrid(double width, double height) {
        X = Math.Floor(X / width) * width;
        Y = Math.Floor(Y / height) * height;
    }
}

public class BoundingBox2d {
    private Minimum2d bottomLeft;
    private Maximum2d topRight;

    public Vector2d BottomLeft {
        get => new(bottomLeft.X, bottomLeft.Y);
        set { bottomLeft.X = value.X; bottomLeft.Y = value.Y; }
    }

    public Vector2d TopRight {
        get => new(topRight.X, topRight.Y);
        set { topRight.X = value.X; topRight.Y = value.Y; }
    }

    public bool Inside(Vector2d p) => bottomLeft.Inside(p) && topRight.Inside(p);

    public void ToGrid(double width, double height) {
        topRight.ToGrid(width, height);
        bottomLeft.ToGrid(width, height);
    }

    public double Width() => topRight.X - bottomLeft.X;

    public double Height() => topRight.Y - bottomLeft.Y;

    public void Reset() {
        bottomLeft.X = bottomLeft.Y = 1e10;
        topRight.X = topRight.Y = -1e10;
    }

    public void Expand(Vector2d p) {
        bottomLeft.Expand(p);
        topRight.Expand(p, 1e-6);
    }
}
