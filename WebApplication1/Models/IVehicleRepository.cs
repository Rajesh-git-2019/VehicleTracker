using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IVehicleRepository : IDisposable
    {
        IEnumerable<Vehicle> GetVehicles();
        Vehicle GetVehicleByID(int vehicleId);
        IEnumerable<Vehicle>  GetTop5Vehicles();
        void InsertVehicle(Vehicle student);
        void DeleteVehicle(int vehicleId);
        void UpdateVehicle(Vehicle student);
        void Save();
    }

}
