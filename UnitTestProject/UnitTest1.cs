using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1;
using WebApplication1.Controllers;
using WebApplication1.Models;
using System.Web;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            VehicleRepository vc = new VehicleRepository(new VehicleContext());
            Vehicle v = new Vehicle();
            v.VehicleId = 1;
            v.Name = "test";
            v.Inspection = true;
            v.Model = "test";
            vc.InsertVehicle(v);
            vc.InsertVehicle(v);
            vc.InsertVehicle(v);
            vc.InsertVehicle(v);
            vc.InsertVehicle(v);
            var top5vehicles = vc.GetTop5Vehicles().ToList();
            Assert.AreEqual(5, top5vehicles.Count());
        }


    }
}
