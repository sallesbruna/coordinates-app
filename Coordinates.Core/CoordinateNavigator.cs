using System;

namespace Coordinates.Core
{
    public class CoordinateNavigator
    {
        public Coordinate Coordinate { get; private set; }

        public CoordinateNavigator(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public void Navigate(NavigatorCommand command)
        {
            Navigate(command.Direction, command.Intensity);
        }

        public void Navigate(Direction direction, int intensity)
        {
            Coordinate = Navigate(Coordinate, direction, intensity);
        }

        private Coordinate Navigate(Coordinate coordinate, Direction direction, int intensity)
        {
            if (coordinate == null) throw new ArgumentNullException(nameof(coordinate));
            if (intensity < 0) throw new ArgumentException(nameof(intensity));

            switch (direction)
            {
                case Direction.N:
                    return new Coordinate(coordinate.X, coordinate.Y + intensity);
                case Direction.S:
                    return new Coordinate(coordinate.X, coordinate.Y - intensity);
                case Direction.L:
                    return new Coordinate(coordinate.X + intensity, coordinate.Y);
                case Direction.O:
                    return new Coordinate(coordinate.X - intensity, coordinate.Y);
                default:
                    throw new ArgumentException(nameof(direction));
            }
        }
    }

}
