using System.Runtime.InteropServices;
using CovidSim.Geometry;

namespace CovidSim.Models;

/**
 * Represents an institution that people may belong to.
 *
 * PLACE be an elementary school, high schools, universities, workplaces etc. Places
 * belong to a microcell (and therefore have a spatial location). Places may have state
 * (i.e., closed or open). Mechanisms exist for absenteeism tracking (but are not currently used).
 * The `members` array lists all individuals who belong to a place.
 * Places can have different groups (to model differential interaction strengths between groups
 * in the same place).
 */
[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct Place() {
	// number of people in place
	public int n;
	// microcell that place is within
	public int mcell;
	// bit convoluted, but this is initialized to 0 in CovidSim.cpp::InitModel. Then incremented in Update.cpp::DoPlaceClose
	public ushort control_trig;
	public ushort ng;
	public ushort treat;
	public ushort country;
	public ushort close_start_time;
	public ushort close_end_time;
	public ushort treat_end_time;
	public ushort[] AvailByAge;
	public ushort[] Absent = new ushort[Country.MAX_ABSENT_TIME];
	public ushort AbsentLastUpdateTime;
	public Vector2f loc;
	public float ProbClose; // Random number between 0 and 1 set in CovidSim.cpp::InitModel and unchanged thereafter. Used instead of repeated calls to rand_mt() to see if this place will close with probability PlaceCloseEffect / P.Efficacies[PlaceClosure] in Update.cpp::DoPlaceClose.
	public int[] group_start;
	public int[] group_size;
	public int[] members;
};
