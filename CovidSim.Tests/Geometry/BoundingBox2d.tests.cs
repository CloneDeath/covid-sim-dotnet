using CovidSim.Geometry;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Geometry;

[TestFixture]
public class BoundingBox2d_tests {
    [Test]
    public void Reset_sets_extremes() {
        var box = new BoundingBox2d();
        box.Reset();
        box.TopRight.X.Should().BeLessThan(box.BottomLeft.X);
        box.TopRight.Y.Should().BeLessThan(box.BottomLeft.Y);
    }

    [Test]
    public void Expand_adjusts_bounds() {
        var box = new BoundingBox2d();
        box.Reset();
        box.Expand(new Vector2d(9.0, 8.5));
        box.Expand(new Vector2d(5.0, 6.0));
        box.Inside(new Vector2d(7.0, 7.0)).Should().BeTrue();
        box.Inside(new Vector2d(3.0, 7.0)).Should().BeFalse();
        box.Inside(new Vector2d(9.5, 7.0)).Should().BeFalse();
        box.Inside(new Vector2d(7.0, 5.0)).Should().BeFalse();
        box.Inside(new Vector2d(7.0, 9.0)).Should().BeFalse();
    }
}
