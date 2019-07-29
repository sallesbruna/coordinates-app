using System;
using Coordinates.Core;
using Xunit;
using FluentAssertions;

namespace Coordinates.Tests
{
    public class CoordinateNavigatorTests
    {
        [Fact]
        public void Should_navigate_coordinates_sequentially_1()
        {
            var coordinate = new Coordinate(8, 12);
            var navigator = new CoordinateNavigator(coordinate);

            navigator.Navigate(Direction.N, 23);
            navigator.Coordinate.Should().Be(new Coordinate(8, 35));

            navigator.Navigate(Direction.O, 7);
            navigator.Coordinate.Should().Be(new Coordinate(1, 35));

            navigator.Navigate(Direction.S, 40);
            navigator.Coordinate.Should().Be(new Coordinate(1, -5));

            navigator.Navigate(Direction.L, 33);
            navigator.Coordinate.Should().Be(new Coordinate(34, -5));

            navigator.Navigate(Direction.N, 15);
            navigator.Coordinate.Should().Be(new Coordinate(34, 10));
        }

        [Fact]
        public void Should_navigate_coordinates_sequentially_2()
        {
            var coordinate = new Coordinate(-10, 0);
            var navigator = new CoordinateNavigator(coordinate);

            navigator.Navigate(Direction.L, 14);
            navigator.Coordinate.Should().Be(new Coordinate(4, 0));

            navigator.Navigate(Direction.N, 27);
            navigator.Coordinate.Should().Be(new Coordinate(4, 27));

            navigator.Navigate(Direction.O, 33);
            navigator.Coordinate.Should().Be(new Coordinate(-29, 27));

            navigator.Navigate(Direction.S, 20);
            navigator.Coordinate.Should().Be(new Coordinate(-29, 7));

            navigator.Navigate(Direction.L, 15);
            navigator.Coordinate.Should().Be(new Coordinate(-14, 7));
        }

        [Fact]
        public void Should_navigate_coordinates_command()
        {
            var coordinate = new Coordinate(-10, 0);
            var navigator = new CoordinateNavigator(coordinate);

            navigator.Navigate(new NavigatorCommand { Direction = Direction.L, Intensity = 14 });
            navigator.Coordinate.Should().Be(new Coordinate(4, 0));
        }

    }
}
