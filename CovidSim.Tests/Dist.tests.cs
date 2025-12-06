using System;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests;

[TestFixture]
public abstract class Dist_tests
{
	[TestFixture]
	public class dist2UTM_tests : Dist_tests
	{
		[TestCase(10.0, 20.0)]
		[TestCase(0.0, 0.0)]
		[TestCase(-45.5, 120.25)]
		public void SamePoints(double lat, double lon)
		{
			Dist.dist2UTM(lat, lon, lat, lon).Should().BeApproximately(0.0, 1e-9);
		}

		[TestCase(0.1, 0.2, 1.3, -0.4)]
		[TestCase(-10.0, 5.0, 12.34, -56.78)]
		public void Symmetry(double a1, double b1, double a2, double b2)
		{
			double d1 = Dist.dist2UTM(a1, b1, a2, b2);
			double d2 = Dist.dist2UTM(a2, b2, a1, b1);
			d1.Should().BeApproximately(d2, 1e-9);
		}

		[TestCase(0.0, 0.0, 0.5, 0.5)]
		[TestCase(-10.0, 20.0, -10.1, 20.1)]
		public void NonNegative(double x1, double y1, double x2, double y2)
		{
			Dist.dist2UTM(x1, y1, x2, y2).Should().BeGreaterThanOrEqualTo(0.0);
		}

		[Test]
		public void Scaling()
		{
			double x1 = 0.0, y1 = 0.0;
			double x2 = 0.0, y2 = 0.0001;
			double x3 = 0.0, y3 = 0.001;

			double d12 = Dist.dist2UTM(x1, y1, x2, y2);
			double d13 = Dist.dist2UTM(x1, y1, x3, y3);

			d13.Should().BeGreaterThan(d12);

			double ratio = d13 / Math.Max(d12, double.Epsilon);
			ratio.Should().BeGreaterThan(9.0);
		}
	}
}
