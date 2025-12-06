using System;
using CovidSim.Models;

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

	public static double dist2(Person a, Person b)
	{
		if (Param.P.DoUTM_coords)
			return dist2UTM(
				Household.Households[a.hh].loc.X,
				Household.Households[a.hh].loc.Y,
				Household.Households[b.hh].loc.X,
				Household.Households[b.hh].loc.Y
			);

		var x = Math.Abs(Household.Households[a.hh].loc.X - Household.Households[b.hh].loc.X);
		var y = Math.Abs(Household.Households[a.hh].loc.Y - Household.Households[b.hh].loc.Y);
		return periodic_xy(x, y);
	}

	public static double dist2_cc(Cell a, Cell b) {
		var l = Array.IndexOf(Cell.Cells, a);
		var m = Array.IndexOf(Cell.Cells, b);
		if (Param.P.DoUTM_coords)
			return dist2UTM(
				Param.P.in_cells_.width * MathF.Abs(l / Param.P.nch),
				Param.P.in_cells_.height * MathF.Abs(l % Param.P.nch),
				Param.P.in_cells_.width * MathF.Abs(m / Param.P.nch),
				Param.P.in_cells_.height * MathF.Abs(m % Param.P.nch)
			);
		else
		{
			var x = Param.P.in_cells_.width * MathF.Abs(l / Param.P.nch - m / Param.P.nch);
			var y = Param.P.in_cells_.height * MathF.Abs(l % Param.P.nch - m % Param.P.nch);
			return periodic_xy(x, y);
		}
	}

	public static double dist2_cc_min(Cell a, Cell b) {
		var l = Array.IndexOf(Model.Cells, a);
		var m = Array.IndexOf(Model.Cells, b);
		var i = l;
		var j = m;
		if (Param.P.DoUTM_coords) {
			if (Param.P.in_cells_.width * Math.Abs(m / Param.P.nch - l / Param.P.nch) > Math.PI) {
				if (m / Param.P.nch > l / Param.P.nch)
					j += Param.P.nch;
				else if (m / Param.P.nch < l / Param.P.nch)
					i += Param.P.nch;
			} else {
				if (m / Param.P.nch > l / Param.P.nch)
					i += Param.P.nch;
				else if (m / Param.P.nch < l / Param.P.nch)
					j += Param.P.nch;
			}

			if (m % Param.P.nch > l % Param.P.nch)
				i++;
			else if (m % Param.P.nch < l % Param.P.nch)
				j++;
			return dist2UTM(Param.P.in_cells_.width * Math.Abs((double)(i / Param.P.nch)),
				Param.P.in_cells_.height * Math.Abs((double)(i % Param.P.nch)),
				Param.P.in_cells_.width * Math.Abs((double)(j / Param.P.nch)),
				Param.P.in_cells_.height * Math.Abs((double)(j % Param.P.nch)));
		}

		if ((Param.P.DoPeriodicBoundaries) &&
			Param.P.in_cells_.width * Math.Abs(m / Param.P.nch - l / Param.P.nch) >
			Param.P.in_degrees_.width * 0.5) {
			if (m / Param.P.nch > l / Param.P.nch)
				j += Param.P.nch;
			else if (m / Param.P.nch < l / Param.P.nch)
				i += Param.P.nch;
		} else {
			if (m / Param.P.nch > l / Param.P.nch)
				i += Param.P.nch;
			else if (m / Param.P.nch < l / Param.P.nch)
				j += Param.P.nch;
		}

		if (Param.P.DoPeriodicBoundaries &&
			Param.P.in_degrees_.height * Math.Abs(m % Param.P.nch - l % Param.P.nch) >
			Param.P.in_degrees_.height * 0.5) {
			if (m % Param.P.nch > l % Param.P.nch)
				j++;
			else if (m % Param.P.nch < l % Param.P.nch)
				i++;
		} else {
			if (m % Param.P.nch > l % Param.P.nch)
				i++;
			else if (m % Param.P.nch < l % Param.P.nch)
				j++;
		}

		var x = Param.P.in_cells_.width * Math.Abs((double)(i / Param.P.nch - j / Param.P.nch));
		var y = Param.P.in_cells_.height * Math.Abs((double)(i % Param.P.nch - j % Param.P.nch));
		return periodic_xy(x, y);
	}

	public static double dist2_mm(Microcell a, Microcell b) {
		var l = Array.IndexOf(Microcell.Mcells, a);
		var m = Array.IndexOf(Microcell.Mcells, b);
		if (Param.P.DoUTM_coords)
		{
			return dist2UTM(
				Param.P.in_microcells_.width * MathF.Abs(l / Param.P.total_microcells_high_),
				Param.P.in_microcells_.height * MathF.Abs(l % Param.P.total_microcells_high_),
				Param.P.in_microcells_.width * MathF.Abs(m / Param.P.total_microcells_high_),
				Param.P.in_microcells_.height * MathF.Abs(m % Param.P.total_microcells_high_));
		}
		var x = Param.P.in_microcells_.width * MathF.Abs(l / Param.P.total_microcells_high_ - m / Param.P.total_microcells_high_);
		var y = Param.P.in_microcells_.height * MathF.Abs(l % Param.P.total_microcells_high_ - m % Param.P.total_microcells_high_);
		return periodic_xy(x, y);
	}

	public static double periodic_xy(double x, double y) {
		if (Param.P.DoPeriodicBoundaries)
		{
			if (x > Param.P.in_degrees_.width * 0.5) x = Param.P.in_degrees_.width - x;
			if (y > Param.P.in_degrees_.height * 0.5) y = Param.P.in_degrees_.height - y;
		}
		return x * x + y * y;
	}
}
