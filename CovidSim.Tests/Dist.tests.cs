using System;
using CovidSim.Geometry;
using CovidSim.Geometry.Primitives;
using CovidSim.Models;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests;

[TestFixture]
public abstract class Dist_tests {
	private bool _origDoPeriodic;
	private Size<double> _origInDegrees;
	private Cell[] _origCells;
	private bool _origDoUTM;
	private Size<double> _origInCells;
	private int _origNch;
	private Household[] _origHouseholds;
	private Microcell[] _origMicrocells;
	private Size<double> _origInMicrocells;
	private int _origTotalMicrocellsHigh;

	[SetUp]
	public void SetUp() {
		_origDoPeriodic = Param.P.DoPeriodicBoundaries;
		_origInDegrees = Param.P.in_degrees_;
		_origCells = Model.Cells;
		_origDoUTM = Param.P.DoUTM_coords;
		_origInCells = Param.P.in_cells_;
		_origNch = Param.P.nch;
		_origHouseholds = Household.Households;
		_origMicrocells = Microcell.Mcells;
		_origInMicrocells = Param.P.in_microcells_;
		_origTotalMicrocellsHigh = Param.P.total_microcells_high_;
	}

	[TearDown]
	public void TearDown() {
		Param.P.DoPeriodicBoundaries = _origDoPeriodic;
		Param.P.in_degrees_ = _origInDegrees;
		Model.Cells = _origCells;
		Param.P.DoUTM_coords = _origDoUTM;
		Param.P.in_cells_ = _origInCells;
		Param.P.nch = _origNch;
		Household.Households = _origHouseholds;
		Microcell.Mcells = _origMicrocells;
		Param.P.in_microcells_ = _origInMicrocells;
		Param.P.total_microcells_high_ = _origTotalMicrocellsHigh;
	}

	[TestFixture]
	public class dist2UTM_tests : Dist_tests {
		[TestCase(10.0, 20.0)]
		[TestCase(0.0, 0.0)]
		[TestCase(-45.5, 120.25)]
		public void SamePoints(double lat, double lon) {
			Dist.dist2UTM(lat, lon, lat, lon).Should().BeApproximately(0.0, 1e-9);
		}

		[TestCase(0.1, 0.2, 1.3, -0.4)]
		[TestCase(-10.0, 5.0, 12.34, -56.78)]
		public void Symmetry(double a1, double b1, double a2, double b2) {
			var d1 = Dist.dist2UTM(a1, b1, a2, b2);
			var d2 = Dist.dist2UTM(a2, b2, a1, b1);
			d1.Should().BeApproximately(d2, 1e-9);
		}

		[TestCase(0.0, 0.0, 0.5, 0.5)]
		[TestCase(-10.0, 20.0, -10.1, 20.1)]
		public void NonNegative(double x1, double y1, double x2, double y2) {
			Dist.dist2UTM(x1, y1, x2, y2).Should().BeGreaterThanOrEqualTo(0.0);
		}

		[Test]
		public void Scaling() {
			double x1 = 0.0, y1 = 0.0;
			double x2 = 0.0, y2 = 0.0001;
			double x3 = 0.0, y3 = 0.001;

			var d12 = Dist.dist2UTM(x1, y1, x2, y2);
			var d13 = Dist.dist2UTM(x1, y1, x3, y3);

			d13.Should().BeGreaterThan(d12);

			var ratio = d13 / Math.Max(d12, double.Epsilon);
			ratio.Should().BeGreaterThan(9.0);
		}
	}

	[TestFixture]
	public class periodic_xy_tests : Dist_tests {
		[Test]
		public void NoPeriodic_ReturnsSquaredSum() {
			Param.P.DoPeriodicBoundaries = false;
			Param.P.in_degrees_ = new Size<double>(10, 10, new DoubleOperations());

			double x = 3.0, y = 4.0;
			var result = Dist.periodic_xy(x, y);
			result.Should().BeApproximately(x * x + y * y, 1e-12);
		}

		[Test]
		public void WrapsX_WhenGreaterThanHalfWidth() {
			Param.P.DoPeriodicBoundaries = true;
			Param.P.in_degrees_ = new Size<double>(10, 10, new DoubleOperations());

			var x = 6.0; // > 10 * 0.5
			var y = 2.0;
			var expectedX = Param.P.in_degrees_.width - x; // 4.0
			var expected = expectedX * expectedX + y * y;

			Dist.periodic_xy(x, y).Should().BeApproximately(expected, 1e-12);
		}

		[Test]
		public void WrapsY_WhenGreaterThanHalfHeight() {
			Param.P.DoPeriodicBoundaries = true;
			Param.P.in_degrees_ = new Size<double>(10, 8, new DoubleOperations());

			var x = 1.0;
			var y = 5.0; // > 8 * 0.5 = 4.0
			var expectedY = Param.P.in_degrees_.height - y; // 3.0
			var expected = x * x + expectedY * expectedY;

			Dist.periodic_xy(x, y).Should().BeApproximately(expected, 1e-12);
		}

		[Test]
		public void WrapsBoth_WhenBothGreaterThanHalf() {
			Param.P.DoPeriodicBoundaries = true;
			Param.P.in_degrees_ = new Size<double>(12, 14, new DoubleOperations());

			var x = 8.0; // > 6.0
			var y = 9.0; // > 7.0
			var expectedX = Param.P.in_degrees_.width - x; // 4.0
			var expectedY = Param.P.in_degrees_.height - y; // 5.0
			var expected = expectedX * expectedX + expectedY * expectedY;

			Dist.periodic_xy(x, y).Should().BeApproximately(expected, 1e-12);
		}

		[Test]
		public void EqualToHalf_DoesNotWrap() {
			Param.P.DoPeriodicBoundaries = true;
			Param.P.in_degrees_ = new Size<double>(10, 10, new DoubleOperations());

			var x = Param.P.in_degrees_.width * 0.5; // exactly half, condition is '>'
			var y = Param.P.in_degrees_.height * 0.5;
			var expected = x * x + y * y;

			Dist.periodic_xy(x, y).Should().BeApproximately(expected, 1e-12);
		}
	}

	[TestFixture]
	public class dist2_cc_min_tests : Dist_tests {
		[Test]
		public void SameCell_ReturnsZero() {
			var c = new Cell();
			Model.Cells = [c];
			Param.P.DoUTM_coords = false;
			Param.P.nch = 1;

			var d = Dist.dist2_cc_min(c, c);
			d.Should().BeApproximately(0.0, 1e-12);
		}

		[Test]
		public void Symmetric_ResultIsEqualWhenSwapped() {
			var a = new Cell();
			var b = new Cell();
			Model.Cells = [a, b];
			// set some sane defaults so the function can run
			Param.P.DoUTM_coords = false;
			Param.P.in_cells_ = new Size<double>(1.0, 1.0, new DoubleOperations());
			Param.P.in_degrees_ = new Size<double>(10.0, 10.0, new DoubleOperations());
			Param.P.nch = 10;

			var d1 = Dist.dist2_cc_min(a, b);
			var d2 = Dist.dist2_cc_min(b, a);

			d1.Should().BeApproximately(d2, 1e-12);
		}

		[Test]
		public void NonNegative() {
			var a = new Cell();
			var b = new Cell();
			Model.Cells = [a, b];
			Param.P.DoUTM_coords = false;
			Param.P.in_cells_ = new Size<double>(1.0, 1.0, new DoubleOperations());
			Param.P.nch = 10;

			var d = Dist.dist2_cc_min(a, b);
			d.Should().BeGreaterThanOrEqualTo(0.0);
		}

		[Test]
		public void DoUTM_SameCell_ReturnsZero() {
			var c = new Cell();
			Model.Cells = [c];
			Param.P.DoUTM_coords = true;
			Param.P.in_cells_ = new Size<double>(1.0, 1.0, new DoubleOperations());
			Param.P.nch = 1;

			var d = Dist.dist2_cc_min(c, c);
			d.Should().BeApproximately(0.0, 1e-12);
		}

		[Test]
		public void DoUTM_Symmetric_ForDistinctIndices() {
			// create a larger array so indices span multiple "columns" / "rows"
			var cells = new Cell[20];
			for (var i = 0; i < cells.Length; i++) cells[i] = new Cell();
			Model.Cells = cells;

			Param.P.DoUTM_coords = true;
			// choose parameters so integer division of indices produces differing quotients
			Param.P.in_cells_ = new Size<double>(2.0, 1.0, new DoubleOperations());
			Param.P.in_degrees_ = new Size<double>(360.0, 180.0, new DoubleOperations());
			Param.P.nch = 5;

			var a = cells[2];
			var b = cells[15];

			var d1 = Dist.dist2_cc_min(a, b);
			var d2 = Dist.dist2_cc_min(b, a);

			d1.Should().BeApproximately(d2, 1e-12);
		}

		[Test]
		public void DoUTM_NonNegative_ForDistinctIndices() {
			var cells = new Cell[12];
			for (var i = 0; i < cells.Length; i++) cells[i] = new Cell();
			Model.Cells = cells;

			Param.P.DoUTM_coords = true;
			Param.P.in_cells_ = new Size<double>(1.5, 1.2, new DoubleOperations());
			Param.P.in_degrees_ = new Size<double>(360.0, 180.0, new DoubleOperations());
			Param.P.nch = 4;

			var a = cells[1];
			var b = cells[9];

			var d = Dist.dist2_cc_min(a, b);
			d.Should().BeGreaterThanOrEqualTo(0.0);
		}

		[Test]
		public void DoUTM_TopTrue_JplusNch_And_IPlus1() {
			var cells = new Cell[10];
			for (var i = 0; i < cells.Length; i++) cells[i] = new Cell();
			Model.Cells = cells;

			Param.P.DoUTM_coords = true;
			// choose width large enough so (width * diff) > Math.PI
			Param.P.in_cells_ = new Size<double>(4.0, 1.0, new DoubleOperations());
			Param.P.in_degrees_ = new Size<double>(360.0, 180.0, new DoubleOperations());
			Param.P.nch = 5;

			var a = cells[2];
			var b = cells[8];

			var d1 = Dist.dist2_cc_min(a, b);
			var d2 = Dist.dist2_cc_min(b, a);

			d1.Should().BeApproximately(d2, 1e-12);
			d1.Should().BeGreaterThanOrEqualTo(0.0);
			d1.Should().BeGreaterThan(0.0);
		}

		[Test]
		public void DoUTM_TopTrue_IplusNch_And_JPlus1_When_Reversed() {
			var cells = new Cell[10];
			for (var i = 0; i < cells.Length; i++) cells[i] = new Cell();
			Model.Cells = cells;

			Param.P.DoUTM_coords = true;
			Param.P.in_cells_ = new Size<double>(4.0, 1.0, new DoubleOperations());
			Param.P.in_degrees_ = new Size<double>(360.0, 180.0, new DoubleOperations());
			Param.P.nch = 5;

			// reversed indices to exercise the other branches
			var a = cells[8];
			var b = cells[2];

			var d1 = Dist.dist2_cc_min(a, b);
			var d2 = Dist.dist2_cc_min(b, a);

			d1.Should().BeApproximately(d2, 1e-12);
			d1.Should().BeGreaterThanOrEqualTo(0.0);
		}

		[Test]
		public void DoUTM_TopFalse_Uses_ElsePath() {
			var cells = new Cell[10];
			for (var i = 0; i < cells.Length; i++) cells[i] = new Cell();
			Model.Cells = cells;

			Param.P.DoUTM_coords = true;
			// choose width small so (width * diff) <= Math.PI -> take else path
			Param.P.in_cells_ = new Size<double>(1.0, 1.0, new DoubleOperations());
			Param.P.in_degrees_ = new Size<double>(360.0, 180.0, new DoubleOperations());
			Param.P.nch = 5;

			var a = cells[2];
			var b = cells[8];

			var d1 = Dist.dist2_cc_min(a, b);
			var d2 = Dist.dist2_cc_min(b, a);

			d1.Should().BeApproximately(d2, 1e-12);
			d1.Should().BeGreaterThanOrEqualTo(0.0);
		}

		[Test]
		public void NonUTM_Periodic_FirstBranch_And_SecondModuloBranch() {
			var cells = new Cell[12];
			for (var i = 0; i < cells.Length; i++) cells[i] = new Cell();
			Model.Cells = cells;

			Param.P.DoUTM_coords = false;
			Param.P.DoPeriodicBoundaries = true;
			// pick values so the first "periodic" condition is true (width * diff > in_degrees.width*0.5)
			Param.P.in_cells_ = new Size<double>(10.0, 1.0, new DoubleOperations());
			Param.P.in_degrees_ = new Size<double>(10.0, 10.0, new DoubleOperations()); // half = 5.0
			Param.P.nch = 5;

			// indices chosen to produce differences in both quotient and remainder comparisons
			var a = cells[1]; // l = 1
			var b = cells[7]; // m = 7 -> m/nch = 1, l/nch = 0, diff = 1 -> width*1 = 10.0 > 5.0

			var d1 = Dist.dist2_cc_min(a, b);
			var d2 = Dist.dist2_cc_min(b, a);

			d1.Should().BeApproximately(d2, 1e-12);
			d1.Should().BeGreaterThanOrEqualTo(0.0);
		}

		[Test]
		public void NonUTM_Periodic_YGreaterThanHalfHeight_AdjustsJ() {
			var cells = new Cell[12];
			for (var i = 0; i < cells.Length; i++) cells[i] = new Cell();
			Model.Cells = cells;

			Param.P.DoUTM_coords = false;
			Param.P.DoPeriodicBoundaries = false;
			Param.P.in_cells_ = new Size<double>(10.0, 10.0, new DoubleOperations());
			Param.P.in_degrees_ = new Size<double>(10.0, 10.0, new DoubleOperations()); // half height = 5.0
			Param.P.nch = 4;

			var a = cells[1]; // l = 1
			var b = cells[9]; // m = 9 -> m % nch = 1, l % nch = 1, diff = 8 -> height * diff = 80.0 > 5.0

			var d1 = Dist.dist2_cc_min(a, b);
			var d2 = Dist.dist2_cc_min(b, a);

			d1.Should().BeApproximately(d2, 1e-12);
			d1.Should().BeGreaterThan(0.0);
		}
	}

	[TestFixture]
	public class dist2_tests : Dist_tests {
		[Test]
		public void SamePerson_ReturnsZero() {
			var p = new Person { hh = 0 };
			Household.Households = [new Household { loc = new Vector2f(0, 0) }];
			Param.P.DoUTM_coords = false;

			var d = Dist.dist2(p, p);
			d.Should().BeApproximately(0.0, 1e-12);
		}

		[Test]
		public void Symmetric_ResultIsEqualWhenSwapped() {
			var a = new Person { hh = 0 };
			var b = new Person { hh = 1 };
			Household.Households = [
				new Household { loc = new Vector2f(1, 2) },
				new Household { loc = new Vector2f(3, 4) }
			];
			Param.P.DoUTM_coords = false;

			var d1 = Dist.dist2(a, b);
			var d2 = Dist.dist2(b, a);

			d1.Should().BeApproximately(d2, 1e-12);
		}

		[Test]
		public void NonNegative() {
			var a = new Person { hh = 0 };
			var b = new Person { hh = 1 };
			Household.Households = [
				new Household { loc = new Vector2f(1, 2) },
				new Household { loc = new Vector2f(3, 4) }
			];
			Param.P.DoUTM_coords = false;

			var d = Dist.dist2(a, b);
			d.Should().BeGreaterThanOrEqualTo(0.0);
		}

		[Test]
		public void DoUTM_SamePerson_ReturnsZero() {
			var p = new Person { hh = 0 };
			Household.Households = [new Household { loc = new Vector2f(0, 0) }];
			Param.P.DoUTM_coords = true;

			var d = Dist.dist2(p, p);
			d.Should().BeApproximately(0.0, 1e-12);
		}

		[Test]
		public void DoUTM_Symmetric_ResultIsEqualWhenSwapped() {
			var a = new Person { hh = 0 };
			var b = new Person { hh = 1 };
			Household.Households = [
				new Household { loc = new Vector2f(1, 2) },
				new Household { loc = new Vector2f(3, 4) }
			];
			Param.P.DoUTM_coords = true;

			var d1 = Dist.dist2(a, b);
			var d2 = Dist.dist2(b, a);

			d1.Should().BeApproximately(d2, 1e-12);
		}

		[Test]
		public void DoUTM_NonNegative() {
			var a = new Person { hh = 0 };
			var b = new Person { hh = 1 };
			Household.Households = [
				new Household { loc = new Vector2f(1, 2) },
				new Household { loc = new Vector2f(3, 4) }
			];
			Param.P.DoUTM_coords = true;

			var d = Dist.dist2(a, b);
			d.Should().BeGreaterThanOrEqualTo(0.0);
		}
	}

	[TestFixture]
	public class dist2_cc_tests : Dist_tests {
		[Test]
		public void SameCell_ReturnsZero() {
			var c = new Cell();
			Model.Cells = [c];
			Param.P.DoUTM_coords = false;
			Param.P.nch = 1;

			var d = Dist.dist2_cc(c, c);
			d.Should().BeApproximately(0.0, 1e-12);
		}

		[Test]
		public void Symmetric_ResultIsEqualWhenSwapped() {
			var a = new Cell();
			var b = new Cell();
			Model.Cells = [a, b];
			Param.P.DoUTM_coords = false;
			Param.P.in_cells_ = new Size<double>(1.0, 1.0, new DoubleOperations());
			Param.P.nch = 10;

			var d1 = Dist.dist2_cc(a, b);
			var d2 = Dist.dist2_cc(b, a);

			d1.Should().BeApproximately(d2, 1e-12);
		}

		[Test]
		public void NonNegative() {
			var a = new Cell();
			var b = new Cell();
			Model.Cells = [a, b];
			Param.P.DoUTM_coords = false;
			Param.P.in_cells_ = new Size<double>(1.0, 1.0, new DoubleOperations());
			Param.P.nch = 10;

			var d = Dist.dist2_cc(a, b);
			d.Should().BeGreaterThanOrEqualTo(0.0);
		}

		[Test]
		public void DoUTM_SameCell_ReturnsZero() {
			var c = new Cell();
			Model.Cells = [c];
			Param.P.DoUTM_coords = true;
			Param.P.in_cells_ = new Size<double>(1.0, 1.0, new DoubleOperations());
			Param.P.nch = 1;

			var d = Dist.dist2_cc(c, c);
			d.Should().BeApproximately(0.0, 1e-12);
		}

		[Test]
		public void DoUTM_Symmetric_ResultIsEqualWhenSwapped() {
			var a = new Cell();
			var b = new Cell();
			Model.Cells = [a, b];
			Param.P.DoUTM_coords = true;
			Param.P.in_cells_ = new Size<double>(1.0, 1.0, new DoubleOperations());
			Param.P.nch = 10;

			var d1 = Dist.dist2_cc(a, b);
			var d2 = Dist.dist2_cc(b, a);

			d1.Should().BeApproximately(d2, 1e-12);
		}

		[Test]
		public void DoUTM_NonNegative() {
			var a = new Cell();
			var b = new Cell();
			Model.Cells = [a, b];
			Param.P.DoUTM_coords = true;
			Param.P.in_cells_ = new Size<double>(1.0, 1.0, new DoubleOperations());
			Param.P.nch = 10;

			var d = Dist.dist2_cc(a, b);
			d.Should().BeGreaterThanOrEqualTo(0.0);
		}
	}

	[TestFixture]
	public class dist2_mm_tests : Dist_tests {
		[Test]
		public void SameMicrocell_ReturnsZero() {
			var m = new Microcell();
			Microcell.Mcells = [m];
			Param.P.DoUTM_coords = false;
			Param.P.total_microcells_high_ = 1;

			var d = Dist.dist2_mm(m, m);
			d.Should().BeApproximately(0.0, 1e-12);
		}

		[Test]
		public void Symmetric_ResultIsEqualWhenSwapped() {
			var a = new Microcell();
			var b = new Microcell();
			Microcell.Mcells = [a, b];
			Param.P.DoUTM_coords = false;
			Param.P.in_microcells_ = new Size<double>(1.0, 1.0, new DoubleOperations());
			Param.P.total_microcells_high_ = 10;

			var d1 = Dist.dist2_mm(a, b);
			var d2 = Dist.dist2_mm(b, a);

			d1.Should().BeApproximately(d2, 1e-12);
		}

		[Test]
		public void NonNegative() {
			var a = new Microcell();
			var b = new Microcell();
			Microcell.Mcells = [a, b];
			Param.P.DoUTM_coords = false;
			Param.P.in_microcells_ = new Size<double>(1.0, 1.0, new DoubleOperations());
			Param.P.total_microcells_high_ = 10;

			var d = Dist.dist2_mm(a, b);
			d.Should().BeGreaterThanOrEqualTo(0.0);
		}

		[Test]
		public void DoUTM_SameMicrocell_ReturnsZero() {
			var m = new Microcell();
			Microcell.Mcells = [m];
			Param.P.DoUTM_coords = true;
			Param.P.in_microcells_ = new Size<double>(1.0, 1.0, new DoubleOperations());
			Param.P.total_microcells_high_ = 1;

			var d = Dist.dist2_mm(m, m);
			d.Should().BeApproximately(0.0, 1e-12);
		}

		[Test]
		public void DoUTM_Symmetric_ResultIsEqualWhenSwapped() {
			var a = new Microcell();
			var b = new Microcell();
			Microcell.Mcells = [a, b];
			Param.P.DoUTM_coords = true;
			Param.P.in_microcells_ = new Size<double>(1.0, 1.0, new DoubleOperations());
			Param.P.total_microcells_high_ = 10;

			var d1 = Dist.dist2_mm(a, b);
			var d2 = Dist.dist2_mm(b, a);

			d1.Should().BeApproximately(d2, 1e-12);
		}

		[Test]
		public void DoUTM_NonNegative() {
			var a = new Microcell();
			var b = new Microcell();
			Microcell.Mcells = [a, b];
			Param.P.DoUTM_coords = true;
			Param.P.in_microcells_ = new Size<double>(1.0, 1.0, new DoubleOperations());
			Param.P.total_microcells_high_ = 10;

			var d = Dist.dist2_mm(a, b);
			d.Should().BeGreaterThanOrEqualTo(0.0);
		}
	}

[TestFixture]
    public class dist2_raw_tests : Dist_tests
    {
        [Test]
        public void SamePoints_ReturnsZero()
        {
            double ax = 0.0, ay = 0.0;
            double bx = 0.0, by = 0.0;

            double d = Dist.dist2_raw(ax, ay, bx, by);
            d.Should().BeApproximately(0.0, 1e-12);
        }

        [Test]
        public void Symmetric_ResultIsEqualWhenSwapped()
        {
            double ax = 1.0, ay = 2.0;
            double bx = 3.0, by = 4.0;

            double d1 = Dist.dist2_raw(ax, ay, bx, by);
            double d2 = Dist.dist2_raw(bx, by, ax, ay);

            d1.Should().BeApproximately(d2, 1e-12);
        }

        [Test]
        public void NonNegative()
        {
            double ax = 1.0, ay = 2.0;
            double bx = 3.0, by = 4.0;

            double d = Dist.dist2_raw(ax, ay, bx, by);
            d.Should().BeGreaterThanOrEqualTo(0.0);
        }

        [Test]
        public void DoUTM_SamePoints_ReturnsZero()
        {
            Param.P.DoUTM_coords = true;

            double ax = 0.0, ay = 0.0;
            double bx = 0.0, by = 0.0;

            double d = Dist.dist2_raw(ax, ay, bx, by);
            d.Should().BeApproximately(0.0, 1e-12);
        }

        [Test]
        public void DoUTM_Symmetric_ResultIsEqualWhenSwapped()
        {
            Param.P.DoUTM_coords = true;

            double ax = 1.0, ay = 2.0;
            double bx = 3.0, by = 4.0;

            double d1 = Dist.dist2_raw(ax, ay, bx, by);
            double d2 = Dist.dist2_raw(bx, by, ax, ay);

            d1.Should().BeApproximately(d2, 1e-12);
        }

        [Test]
        public void DoUTM_NonNegative()
        {
            Param.P.DoUTM_coords = true;

            double ax = 1.0, ay = 2.0;
            double bx = 3.0, by = 4.0;

            double d = Dist.dist2_raw(ax, ay, bx, by);
            d.Should().BeGreaterThanOrEqualTo(0.0);
        }
    }
}
