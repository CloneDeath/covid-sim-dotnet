using CovidSim.Geometry;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Geometry;

[TestFixture]
public class BoundingBox_tests {
    [Test]
    public void Maximum2d_expand_sets_max() {
        var v1 = new Maximum2d(9.0, 6.5);
        var v2 = new Vector2d(7.0, 8.0);
        v1.Expand(v2, 0.0);
        v1.X.Should().Be(9.0);
        v1.Y.Should().Be(8.0);
    }

    [Test]
    public void Minimum2d_expand_sets_min() {
        var v1 = new Minimum2d(9.0, 6.5);
        var v2 = new Vector2d(7.0, 8.0);
        v1.Expand(v2);
        v1.X.Should().Be(7.0);
        v1.Y.Should().Be(6.5);
    }

    [Test]
    public void Maximum2d_to_grid_rounds_up() {
        var v = new Maximum2d(2.3, 4.1);
        v.ToGrid(2.0, 3.0);
        v.X.Should().Be(4.0);
        v.Y.Should().Be(6.0);
    }

    [Test]
    public void Minimum2d_to_grid_rounds_down() {
        var v = new Minimum2d(2.3, 4.1);
        v.ToGrid(2.0, 3.0);
        v.X.Should().Be(2.0);
        v.Y.Should().Be(3.0);
    }

    [Test]
    public void BoundingBox_inside() {
        var box = new BoundingBox2d();
        box.TopRight = new Vector2d(9.0, 8.5);
        box.BottomLeft = new Vector2d(5.0, 6.0);
        box.Inside(new Vector2d(7.0, 7.0)).Should().BeTrue();
        box.Inside(new Vector2d(3.0, 7.0)).Should().BeFalse();
        box.Inside(new Vector2d(9.5, 7.0)).Should().BeFalse();
        box.Inside(new Vector2d(7.0, 5.0)).Should().BeFalse();
        box.Inside(new Vector2d(7.0, 9.0)).Should().BeFalse();
    }

    [Test]
    public void BoundingBox_width() {
        var box = new BoundingBox2d();
        box.TopRight = new Vector2d(9.0, 8.5);
        box.BottomLeft = new Vector2d(5.0, 6.0);
        box.Width().Should().Be(4.0);
    }

    [Test]
    public void BoundingBox_height() {
        var box = new BoundingBox2d();
        box.TopRight = new Vector2d(9.0, 8.5);
        box.BottomLeft = new Vector2d(5.0, 6.0);
        box.Height().Should().Be(2.5);
    }
}
