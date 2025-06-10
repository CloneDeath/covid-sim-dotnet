using System;

namespace CovidSim;

public enum Direction {
	Right,
	Up,
	Left,
	Down
}

public static class DirectionExtensions {
	public static Direction RotateLeft(this Direction direction) {
		return direction switch {
			Direction.Right => Direction.Up,
			Direction.Up => Direction.Left,
			Direction.Left => Direction.Down,
			Direction.Down => Direction.Right,
			_ => throw new ArgumentOutOfRangeException(nameof(direction), direction, "Invalid direction")
		};
	}
}
