using System;
using CovidSim.Geometry;
using CovidSim.Geometry.Primitives;
using CovidSim.Models;
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

	[TestFixture]
	public class periodic_xy_tests : Dist_tests
	{
		private bool _origDoPeriodic;
		private Size<double> _origInDegrees;

		[SetUp]
		public void SetUp()
		{
			_origDoPeriodic = Param.P.DoPeriodicBoundaries;
			_origInDegrees = Param.P.in_degrees_;
		}

		[TearDown]
		public void TearDown()
		{
			Param.P.DoPeriodicBoundaries = _origDoPeriodic;
			Param.P.in_degrees_ = _origInDegrees;
		}

		[Test]
		public void NoPeriodic_ReturnsSquaredSum()
		{
			Param.P.DoPeriodicBoundaries = false;
			Param.P.in_degrees_ = new Size<double>(10, 10, new DoubleOperations());

			double x = 3.0, y = 4.0;
			double result = Dist.periodic_xy(x, y);
			result.Should().BeApproximately(x * x + y * y, 1e-12);
		}

		[Test]
		public void WrapsX_WhenGreaterThanHalfWidth()
		{
			Param.P.DoPeriodicBoundaries = true;
			Param.P.in_degrees_ = new Size<double>(10, 10, new DoubleOperations());

			double x = 6.0; // > 10 * 0.5
			double y = 2.0;
			double expectedX = Param.P.in_degrees_.width - x; // 4.0
			double expected = expectedX * expectedX + y * y;

			Dist.periodic_xy(x, y).Should().BeApproximately(expected, 1e-12);
		}

		[Test]
		public void WrapsY_WhenGreaterThanHalfHeight()
		{
			Param.P.DoPeriodicBoundaries = true;
			Param.P.in_degrees_ = new Size<double>(10, 8, new DoubleOperations());

			double x = 1.0;
			double y = 5.0; // > 8 * 0.5 = 4.0
			double expectedY = Param.P.in_degrees_.height - y; // 3.0
			double expected = x * x + expectedY * expectedY;

			Dist.periodic_xy(x, y).Should().BeApproximately(expected, 1e-12);
		}

		[Test]
		public void WrapsBoth_WhenBothGreaterThanHalf()
		{
			Param.P.DoPeriodicBoundaries = true;
			Param.P.in_degrees_ = new Size<double>(12, 14, new DoubleOperations());

			double x = 8.0; // > 6.0
			double y = 9.0; // > 7.0
			double expectedX = Param.P.in_degrees_.width - x; // 4.0
			double expectedY = Param.P.in_degrees_.height - y; // 5.0
			double expected = expectedX * expectedX + expectedY * expectedY;

			Dist.periodic_xy(x, y).Should().BeApproximately(expected, 1e-12);
		}

		[Test]
		public void EqualToHalf_DoesNotWrap()
		{
			Param.P.DoPeriodicBoundaries = true;
			Param.P.in_degrees_ = new Size<double>(10, 10, new DoubleOperations());

			double x = Param.P.in_degrees_.width * 0.5;  // exactly half, condition is '>'
			double y = Param.P.in_degrees_.height * 0.5;
			double expected = x * x + y * y;

			Dist.periodic_xy(x, y).Should().BeApproximately(expected, 1e-12);
		}
	}

	[TestFixture]
	public class dist2_cc_min_tests : Dist_tests
	{
		private Cell[] _origCells;
		private bool _origDoUTM;
		private bool _origDoPeriodic;
		private Size<double> _origInCells;
		private Size<double> _origInDegrees;
		private int _origNch;

		[SetUp]
		public void SetUp()
		{
			_origCells = Model.Cells;
			_origDoUTM = Param.P.DoUTM_coords;
			_origDoPeriodic = Param.P.DoPeriodicBoundaries;
			_origInCells = Param.P.in_cells_;
			_origInDegrees = Param.P.in_degrees_;
			_origNch = Param.P.nch;
		}

		[TearDown]
		public void TearDown()
		{
			Model.Cells = _origCells;
			Param.P.DoUTM_coords = _origDoUTM;
			Param.P.DoPeriodicBoundaries = _origDoPeriodic;
			Param.P.in_cells_ = _origInCells;
			Param.P.in_degrees_ = _origInDegrees;
			Param.P.nch = _origNch;
		}

		[Test]
		public void SameCell_ReturnsZero()
		{
			var c = new Cell();
			Model.Cells = [c];
			Param.P.DoUTM_coords = false;
			Param.P.nch = 1;

			double d = Dist.dist2_cc_min(c, c);
			d.Should().BeApproximately(0.0, 1e-12);
		}

		[Test]
		public void Symmetric_ResultIsEqualWhenSwapped()
		{
			var a = new Cell();
			var b = new Cell();
			Model.Cells = [a, b];
			// set some sane defaults so the function can run
			Param.P.DoUTM_coords = false;
			Param.P.in_cells_ = new Size<double>(1.0, 1.0, new DoubleOperations());
			Param.P.in_degrees_ = new Size<double>(10.0, 10.0, new DoubleOperations());
			Param.P.nch = 10;

			double d1 = Dist.dist2_cc_min(a, b);
			double d2 = Dist.dist2_cc_min(b, a);

			d1.Should().BeApproximately(d2, 1e-12);
		}

		[Test]
		public void NonNegative()
		{
			var a = new Cell();
			var b = new Cell();
			Model.Cells = [a, b];
			Param.P.DoUTM_coords = false;
			Param.P.in_cells_ = new Size<double>(1.0, 1.0, new DoubleOperations());
			Param.P.nch = 10;

			double d = Dist.dist2_cc_min(a, b);
			d.Should().BeGreaterThanOrEqualTo(0.0);
		}

		[Test]
		public void DoUTM_SameCell_ReturnsZero()
		{
			var c = new Cell();
			Model.Cells = [c];
			Param.P.DoUTM_coords = true;
			Param.P.in_cells_ = new Size<double>(1.0, 1.0, new DoubleOperations());
			Param.P.nch = 1;

			double d = Dist.dist2_cc_min(c, c);
			d.Should().BeApproximately(0.0, 1e-12);
		}

		[Test]
		public void DoUTM_Symmetric_ForDistinctIndices()
		{
			// create a larger array so indices span multiple "columns" / "rows"
			var cells = new Cell[20];
			for (int i = 0; i < cells.Length; i++) cells[i] = new Cell();
			Model.Cells = cells;

			Param.P.DoUTM_coords = true;
			// choose parameters so integer division of indices produces differing quotients
			Param.P.in_cells_ = new Size<double>(2.0, 1.0, new DoubleOperations());
			Param.P.in_degrees_ = new Size<double>(360.0, 180.0, new DoubleOperations());
			Param.P.nch = 5;

			var a = cells[2];
			var b = cells[15];

			double d1 = Dist.dist2_cc_min(a, b);
			double d2 = Dist.dist2_cc_min(b, a);

			d1.Should().BeApproximately(d2, 1e-12);
		}

		[Test]
		public void DoUTM_NonNegative_ForDistinctIndices()
		{
			var cells = new Cell[12];
			for (int i = 0; i < cells.Length; i++) cells[i] = new Cell();
			Model.Cells = cells;

			Param.P.DoUTM_coords = true;
			Param.P.in_cells_ = new Size<double>(1.5, 1.2, new DoubleOperations());
			Param.P.in_degrees_ = new Size<double>(360.0, 180.0, new DoubleOperations());
			Param.P.nch = 4;

			var a = cells[1];
			var b = cells[9];

			double d = Dist.dist2_cc_min(a, b);
			d.Should().BeGreaterThanOrEqualTo(0.0);
		}
	}
}
