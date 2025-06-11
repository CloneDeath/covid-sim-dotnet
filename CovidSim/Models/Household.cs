using CovidSim.Geometry;

namespace CovidSim.Models;

public class Household {
	public int FirstPerson;
	// The number of people in the household.
	public ushort nh;
	public ushort nhr;
	public required Vector2f loc;
}
