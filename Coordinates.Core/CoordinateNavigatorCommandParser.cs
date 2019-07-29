

using System;
using System.Linq;
using System.Text.RegularExpressions;
using Coordinates;

namespace Coordinates.Core
{
    public class CoordinateNavigatorCommandParser
    {

        public CoordinateNavigatorCommandParser()
        {
        }

        public NavigatorCommand Parse(string command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var regex = new Regex(@"(\[(?<direction>N|S|L|O),(?<intensity>\d+)\])$");

            var match = regex.Match(command);

            string direction = match.Groups.FirstOrDefault(x => x.Name == "direction")?.Value;
            string intensity = match.Groups.FirstOrDefault(x => x.Name == "intensity")?.Value;

            if (string.IsNullOrEmpty(direction) || string.IsNullOrEmpty(intensity))
            {
                throw new ArgumentException("Comando inválido");
            }

            return new NavigatorCommand
            {
                Direction = (Direction) Enum.Parse(typeof(Direction), direction),
                Intensity = Convert.ToInt16(intensity),
            };
        }
    }
}
