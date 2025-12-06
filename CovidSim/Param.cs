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

	public BoundingBox2d SpatialBoundingBox = new();

	public int DoSI;
	public int DoPeriodicBoundaries;
	public int DoImmuneBitmap;
	public int OutputBitmapDetected;

	/// Number of pixels per degree in bitmap output
	public DiagonalMatrix2d scale = new(0, 0);

	/// Size of spatial domain in degrees
	public Size<double> in_degrees_ = new(0, 0, new DoubleOperations());

	/// Size of spatial domain in cells
	public Size<double> in_cells_ = new(0, 0, new DoubleOperations());

	/// Size of spatial domain in microcells
	public Size<double> in_microcells_ = new(0, 0, new DoubleOperations());
}
