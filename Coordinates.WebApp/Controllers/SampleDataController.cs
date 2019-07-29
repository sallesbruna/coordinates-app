using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coordinates.Core;
using Microsoft.AspNetCore.Mvc;

namespace Coordinates.WebApp.Controllers
{
    public class NavigatorCommandBindingModel 
    {
        public Direction Direction { get; set; }
        public int Intensity { get; set; }
        public int LastCoordinateX { get; set; }
        public int LastCoordinateY { get; set; }
    }
    
    
    [Route("api/coordinates")]
    public class CoordinatesController : Controller
    {
    
        
        [HttpPost]
        public IActionResult Navigate([FromForm] NavigatorCommandBindingModel model)
        {
            var coordinate = new Coordinate(model.LastCoordinateX, model.LastCoordinateY);
            var navigator = new CoordinateNavigator(coordinate);
            
            navigator.Navigate(new NavigatorCommand
            {
                Direction = model.Direction,
                Intensity = model.Intensity
            });
            
            return Json(new
            {
                X = navigator.Coordinate.X,
                Y = navigator.Coordinate.Y,
            });
        }

    }
}