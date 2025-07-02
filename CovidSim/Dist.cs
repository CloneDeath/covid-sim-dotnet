using System;
using CovidSim.Models;

namespace CovidSim;

public static class Dist {
	public static double dist2_cc_min(Cell a, Cell b) {
		var l = Array.IndexOf(Model.Cells, a);
		var m = Array.IndexOf(Model.Cells, b);
		var i = l; var j = m;
		if (Param.P.DoUTM_coords)
		{
			if (Param.P.in_cells_.width * Math.Abs(m / Param.P.nch - l / Param.P.nch) > Math.PI)
			{
				if (m / Param.P.nch > l / Param.P.nch)
					j += Param.P.nch;
				else if (m / Param.P.nch < l / Param.P.nch)
					i += Param.P.nch;
			}
			else
			{
				if (m / Param.P.nch > l / Param.P.nch)
					i += Param.P.nch;
				else if (m / Param.P.nch < l / Param.P.nch)
					j += Param.P.nch;
			}
			if (m % Param.P.nch > l % Param.P.nch)
				i++;
			else if (m % Param.P.nch < l % Param.P.nch)
				j++;
			return dist2UTM(Param.P.in_cells_.width * Math.Abs((double)(i / Param.P.nch)), Param.P.in_cells_.height * Math.Abs((double)(i % Param.P.nch)),
				Param.P.in_cells_.width * Math.Abs((double)(j / Param.P.nch)), Param.P.in_cells_.height * Math.Abs((double)(j % Param.P.nch)));
		}
		else
		{
			if ((Param.P.DoPeriodicBoundaries) && (Param.P.in_cells_.width * ((double)Math.Abs(m / Param.P.nch - l / Param.P.nch)) > Param.P.in_degrees_.width * 0.5))
			{
				if (m / Param.P.nch > l / Param.P.nch)
					j += Param.P.nch;
				else if (m / Param.P.nch < l / Param.P.nch)
					i += Param.P.nch;
			}
			else
			{
				if (m / Param.P.nch > l / Param.P.nch)
					i += Param.P.nch;
				else if (m / Param.P.nch < l / Param.P.nch)
					j += Param.P.nch;
			}
			if ((Param.P.DoPeriodicBoundaries) && (Param.P.in_degrees_.height * ((double)Math.Abs(m % Param.P.nch - l % Param.P.nch)) > Param.P.in_degrees_.height * 0.5))
			{
				if (m % Param.P.nch > l % Param.P.nch)
					j++;
				else if (m % Param.P.nch < l % Param.P.nch)
					i++;
			}
			else
			{
				if (m % Param.P.nch > l % Param.P.nch)
					i++;
				else if (m % Param.P.nch < l % Param.P.nch)
					j++;
			}
			var x = Param.P.in_cells_.width * Math.Abs((double)(i / Param.P.nch - j / Param.P.nch));
			var y = Param.P.in_cells_.height * Math.Abs((double)(i % Param.P.nch - j % Param.P.nch));
			return periodic_xy(x, y);
		}
	}
}
