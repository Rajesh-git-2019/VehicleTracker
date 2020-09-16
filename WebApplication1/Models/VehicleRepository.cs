using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class VehicleRepository : IVehicleRepository ,IDisposable
    {
        private VehicleContext context;

        public VehicleRepository(VehicleContext context)
        {
            this.context = context;
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return context.vehicles.ToList();
        }

        public IEnumerable<Vehicle> GetTop5Vehicles()
        {
            return context.vehicles.Where(x => x.Inspection == true).OrderByDescending(x => x.VehicleId).Take(5);
        }

        public Vehicle GetVehicleByID(int id)
        {
            return context.vehicles.Find(id);
        }

        public void InsertVehicle(Vehicle vehicle)
        {
            context.vehicles.Add(vehicle);
        }

        public void DeleteVehicle(int studentID)
        {
            Vehicle vehicle = context.vehicles.Find(studentID);
            context.vehicles.Remove(vehicle);
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            context.Entry(vehicle).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}