using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class VehiclesController : Controller
    {



        private IVehicleRepository vehiclerespository;
        public VehiclesController()
        {
            this.vehiclerespository = new VehicleRepository(new VehicleContext());
        }
        private VehicleContext db = new VehicleContext();

        // GET: Vehicles
        public ActionResult Index()
        {
           
            return View(vehiclerespository.GetVehicles().ToList());
        }

        public ActionResult RaceTrack()
        {
            var top5Vehicles = vehiclerespository.GetTop5Vehicles();
            if (top5Vehicles.Count() <= 5)
            {
                return View(top5Vehicles.ToList());
            }
            else
            {
                return HttpNotFound();
            }         
            
        }



        // GET: Vehicles/Details/5
        public ActionResult Details(int id)
        {

            Vehicle vehicle = vehiclerespository.GetVehicleByID(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleId,Name,Model,Inspection")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehiclerespository.InsertVehicle(vehicle);
                vehiclerespository.Save();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int id)
        {

            Vehicle vehicle = vehiclerespository.GetVehicleByID(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleId,Name,Model,Inspection")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehiclerespository.UpdateVehicle(vehicle);
                vehiclerespository.Save();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int id)
        {

            Vehicle vehicle = vehiclerespository.GetVehicleByID(id);
           

           
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = vehiclerespository.GetVehicleByID(id);
            vehiclerespository.DeleteVehicle(id);
            vehiclerespository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
