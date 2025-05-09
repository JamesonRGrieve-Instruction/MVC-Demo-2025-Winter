using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Models;

namespace ProjectName
{
    [Authorize]

    public class VehicleController : Controller
    {
        private static CarsContext db = new CarsContext();

        // GET: Vehiclecontroller
        public ActionResult Index()
        {
            return View(db.Vehicles.Where(vehicle => vehicle.UserEmail == User.Identity.Name));
        }

        // GET: Vehiclecontroller/Details/5
        public ActionResult Details(string code)
        {
            return View(db.Vehicles.Where(course => course.UserID == User.Identity.Name).ToList().Find(x => x.VIN == code));
        }

        // GET: Vehiclecontroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehiclecontroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("VIN,Name,Description")] Vehicle vehicle)
        {
            try
            {
                vehicle.UserEmail = User.Identity.Name;
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehiclecontroller/Edit/5
        public ActionResult Edit(string code)
        {
            try
            {
                return View(db.Vehicles.Where(vehicle => vehicle.UserEmail == User.Identity.Name).ToList().Find(x => x.VIN == code));
            }
            catch
            {
                return NotFound();
            }

        }

        // POST: Vehiclecontroller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string code, [Bind("VIN,ModelYear,Manufacturer,Model,Colour,PurchaseDate,SaleDate")] Vehicle vehicle)
        {
            try
            {
                Vehicle target = db.Vehicles.Where(vehicle => vehicle.UserEmail == User.Identity.Name).ToList().Find(x => x.VIN == code);
                target.VIN = vehicle.VIN;
                target.ModelYear = vehicle.ModelYear;
                target.Manufacturer = vehicle.Manufacturer;
                target.Model = vehicle.Model;
                target.Colour = vehicle.Colour;
                target.PurchaseDate = vehicle.PurchaseDate;
                target.SaleDate = vehicle.SaleDate;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: Vehiclecontroller/Delete/5
        public ActionResult Delete(string code)
        {
            try
            {
                return View(db.Vehicles.Where(vehicle => vehicle.UserEmail == User.Identity.Name).ToList().Find(x => x.VIN == code));
            }
            catch
            {
                return NotFound();
            }

        }

        // POST: Vehiclecontroller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string code, IFormCollection collection)
        {
            try
            {
                Vehicle target = db.Vehicles.Where(vehicle => vehicle.UserEmail == User.Identity.Name).ToList().Find(x => x.VIN == code);
                db.Vehicles.Remove(target);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
