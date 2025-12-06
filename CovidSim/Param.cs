using System;
using CovidSim.Geometry;
using CovidSim.Geometry.Primitives;

namespace CovidSim;

public class Param {
	public static readonly Param P = new();

	public double sinx(int i) {
		var t = Math.PI * i / 180;
		return Math.Sin(t);
	}

	public double cosx(int i) {
		var t = Math.PI * i / 180;
		return Math.Cos(t);
	}

	public double asin2sqx(int i) {
		var t = Math.Asin(Math.Sqrt(i / 1000.0));
		return t * t;
	}

	public int nch;
	public bool DoUTM_coords;
	public bool DoPeriodicBoundaries;

	/// Size of spatial domain in cells
	public Size<double> in_cells_ = new(100, 100, new DoubleOperations());

	/// Size of spatial domain in degrees
	public Size<double> in_degrees_ = new(100, 100, new DoubleOperations());
}
