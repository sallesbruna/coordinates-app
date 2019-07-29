using System;
using Coordinates.Core;
using Xunit;
using FluentAssertions;

namespace Coordinates.Tests
{
    public class CoordinateTests
    {
        [Fact]
        public void Should_coordinate_hold_x_and_y_values()
        {
            var coordinate = new Coordinate(1, 1);
            coordinate.X.Should().Be(1);
            coordinate.Y.Should().Be(1);
        }
    }
}