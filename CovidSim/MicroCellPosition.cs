using System;

namespace CovidSim;

public class MicroCellPosition(int x, int y) {
	public readonly int x = x;
	public readonly int y = y;

	public static MicroCellPosition operator +(MicroCellPosition self, Direction direction) {
		return direction switch {
			Direction.Right => new MicroCellPosition(self.x + 1, self.y),
			Direction.Up => new MicroCellPosition(self.x, self.y - 1),
			Direction.Left => new MicroCellPosition(self.x - 1, self.y),
			Direction.Down => new MicroCellPosition(self.x, self.y + 1),
			_ => throw new ArgumentException("Unknown direction")
		};
	}
}
