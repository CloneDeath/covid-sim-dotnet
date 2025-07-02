using System;

namespace CovidSim;

public static class Dist {
	public static double dist2UTM(double x1, double y1, double x2, double y2) {
		double x = Math.Abs(x1 - x2) / 2;
		double y = Math.Abs(y1 - y2) / 2;
		double xi = Math.Floor(x);
		double yi = Math.Floor(y);
		x -= xi;
		y -= yi;
		x = (1 - x) * P.sinx[(int)xi] + x * P.sinx[((int)xi) + 1];
		y = (1 - y) * P.sinx[(int)yi] + y * P.sinx[((int)yi) + 1];
		double yt = Math.Abs(y1 + P.SpatialBoundingBox.bottom_left().y);
		yi = Math.Floor(yt);
		var cy1 = yt - yi;
		cy1 = (1 - cy1) * P.cosx[((int)yi)] + cy1 * P.cosx[((int)yi) + 1];
		yt = Math.Abs(y2 + P.SpatialBoundingBox.bottom_left().y);
		yi = Math.Floor(yt);
		var cy2 = yt - yi;
		cy2 = (1 - cy2) * P.cosx[((int)yi)] + cy2 * P.cosx[((int)yi) + 1];
		x = Math.Abs(1000 * (y * y + x * x * cy1 * cy2));
		xi = Math.Floor(x);
		x -= xi;
		y = (1 - x) * P.asin2sqx[((int)xi)] + x * P.asin2sqx[((int)xi) + 1];
		return 4 * EARTHRADIUS * EARTHRADIUS * y;
	}
}
