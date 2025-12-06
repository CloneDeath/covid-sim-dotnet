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
		x = (1 - x) * Param.P.sinx((int)xi) + x * Param.P.sinx(((int)xi) + 1);
		y = (1 - y) * Param.P.sinx((int)yi) + y * Param.P.sinx(((int)yi) + 1);
		double yt = Math.Abs(y1 + Param.P.SpatialBoundingBox.BottomLeft.Y);
		yi = Math.Floor(yt);
		var cy1 = yt - yi;
		cy1 = (1 - cy1) * Param.P.cosx(((int)yi)) + cy1 * Param.P.cosx(((int)yi) + 1);
		yt = Math.Abs(y2 + Param.P.SpatialBoundingBox.BottomLeft.Y);
		yi = Math.Floor(yt);
		var cy2 = yt - yi;
		cy2 = (1 - cy2) * Param.P.cosx(((int)yi)) + cy2 * Param.P.cosx(((int)yi) + 1);
		x = Math.Abs(1000 * (y * y + x * x * cy1 * cy2));
		xi = Math.Floor(x);
		x -= xi;
		y = (1 - x) * Param.P.asin2sqx(((int)xi)) + x * Param.P.asin2sqx(((int)xi) + 1);
		return 4 * Constants.EARTHRADIUS * Constants.EARTHRADIUS * y;
	}

	public static double periodic_xy(double x, double y) {
		if (Param.P.DoPeriodicBoundaries != 0)
		{
			if (x > Param.P.in_degrees_.width * 0.5) x = Param.P.in_degrees_.width - x;
			if (y > Param.P.in_degrees_.height * 0.5) y = Param.P.in_degrees_.height - y;
		}
		return x * x + y * y;
	}
}
