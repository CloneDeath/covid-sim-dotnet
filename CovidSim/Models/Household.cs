using CovidSim.Geometry;

namespace CovidSim.Models;

public struct Household {
	public int FirstPerson;
	// The number of people in the household.
	public ushort nh;
	public ushort nhr;
	public Vector2f loc;
}
