using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public bool Inspection { get; set; }
    }
}