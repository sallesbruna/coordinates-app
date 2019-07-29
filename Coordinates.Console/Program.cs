using System;
using Coordinates.Core;

namespace Coordinates.Console
{
    class Program
    {
        static void Main(string[] args)
        {            
            System.Console.WriteLine("Assumindo uma posição original (x,y), a aplicação irá receber vetores de coordenadas na seguinte forma:");
            System.Console.WriteLine("[Direção, Intensidade], sendo que Direção pode ser N,S,L,O (Norte, Sul, Leste e Oeste) e intensidade é um inteiro.");

            Coordinate coordinate = new Coordinate(1, 1);
            CoordinateNavigator navigator = new CoordinateNavigator(coordinate);
            CoordinateNavigatorCommandParser parser = new CoordinateNavigatorCommandParser();

            while (true)
            {
                System.Console.WriteLine($"A coordenada atual é {navigator.Coordinate.ToString()}, digite o comando [Direção, Intensidade] na linha abaixo: ");

                string command = System.Console.ReadLine();

                try
                {
                    NavigatorCommand navigatorCommand = parser.Parse(command);
                    navigator.Navigate(navigatorCommand);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }

            }
        }
    }
}