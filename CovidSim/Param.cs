using System;

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
}
