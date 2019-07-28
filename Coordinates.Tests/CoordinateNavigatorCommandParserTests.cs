using System;
using Xunit;
using FluentAssertions;

namespace Coordinates.Tests
{
    public class CoordinateNavigatorCoomandParserTests
    {

        [Fact]
        public void Should_parse_navigation_command_1()
        {
            var parser = new CoordinateNavigatorCommandParser();

            var command = parser.Parse("[N,10]");

            command.Direction.Should().Be(Direction.N);
            command.Intensity.Should().Be(10);
        }

        [Fact]
        public void Should_parse_navigation_command_2()
        {
            var parser = new CoordinateNavigatorCommandParser();

            var command = parser.Parse("[L,1]");

            command.Direction.Should().Be(Direction.L);
            command.Intensity.Should().Be(1);
        }

        [Fact]
        public void Should_parse_navigation_command_3()
        {
            var parser = new CoordinateNavigatorCommandParser();

            var command = parser.Parse("[O,20]");

            command.Direction.Should().Be(Direction.O);
            command.Intensity.Should().Be(20);
        }

        [Fact]
        public void Should_parse_navigation_command_4()
        {
            var parser = new CoordinateNavigatorCommandParser();

            var command = parser.Parse("[S,100]");

            command.Direction.Should().Be(Direction.S);
            command.Intensity.Should().Be(100);
        }

        [Fact]
        public void Should_not_parse_an_invalid_navigation_command_1()
        {
            var parser = new CoordinateNavigatorCommandParser();

            Action commandAction = () => parser.Parse("[A,10]");

            commandAction.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Should_not_parse_an_invalid_navigation_command_2()
        {
            var parser = new CoordinateNavigatorCommandParser();

            Action commandAction = () => parser.Parse("[N,-10]");

            commandAction.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Should_not_parse_an_invalid_navigation_command_3()
        {
            var parser = new CoordinateNavigatorCommandParser();

            Action commandAction = () => parser.Parse("");

            commandAction.Should().Throw<ArgumentException>();
        }


        [Fact]
        public void Should_not_parse_an_invalid_navigation_command_4()
        {
            var parser = new CoordinateNavigatorCommandParser();

            Action commandAction = () => parser.Parse("[]");

            commandAction.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Should_not_parse_an_invalid_navigation_command_5()
        {
            var parser = new CoordinateNavigatorCommandParser();

            Action commandAction = () => parser.Parse("\n");

            commandAction.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Should_not_parse_an_invalid_navigation_command_6()
        {
            var parser = new CoordinateNavigatorCommandParser();

            Action commandAction = () => parser.Parse("[N,10,10]");

            commandAction.Should().Throw<ArgumentException>();
        }

    }
}