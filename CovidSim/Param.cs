using CovidSim.Geometry;
using CovidSim.Geometry.Primitives;

namespace CovidSim;

public class Param {
	public static readonly Param P = new();

	public int nch;
	public bool DoUTM_coords;
	public bool DoPeriodicBoundaries;

	/// Size of spatial domain in cells
	public Size<double> in_cells_ = new(100, 100, new DoubleOperations());

	/// Size of spatial domain in degrees
	public Size<double> in_degrees_ = new(100, 100, new DoubleOperations());
}
