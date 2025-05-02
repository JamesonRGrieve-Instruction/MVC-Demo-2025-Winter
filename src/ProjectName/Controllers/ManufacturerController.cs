// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using ProjectName.Models;

// namespace ProjectName
// {
//     [Authorize]

//     public class ManufacturerController : Controller
//     {
//         private static CarsContext db = new CarsContext();

//         // GET: Manufacturercontroller
//         public ActionResult Index()
//         {
//             return View(db.Manufacturers.Where(manufacturer => manufacturer.UserID == User.Identity.Name));
//         }

//         // GET: Manufacturercontroller/Details/5
//         public ActionResult Details(string code)
//         {
//             return View(db.Manufacturers.Where(manufacturer => manufacturer.UserID == User.Identity.Name).ToList().Find(x => x.ManufacturerCode == code));
//         }

//         // GET: Manufacturercontroller/Create
//         public ActionResult Create()
//         {
//             return View();
//         }

//         // POST: Manufacturercontroller/Create
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public ActionResult Create([Bind("ManufacturerCode,Name,Description")] Manufacturer manufacturer)
//         {
//             try
//             {
//                 manufacturer.UserID = User.Identity.Name;
//                 db.Manufacturers.Add(manufacturer);
//                 db.SaveChanges();
//                 return RedirectToAction(nameof(Index));
//             }
//             catch
//             {
//                 return View();
//             }
//         }

//         // GET: Manufacturercontroller/Edit/5
//         public ActionResult Edit(string code)
//         {
//             try
//             {
//                 return View(db.Manufacturers.Where(manufacturer => manufacturer.UserID == User.Identity.Name).ToList().Find(x => x.ManufacturerCode == code));
//             }
//             catch
//             {
//                 return NotFound();
//             }

//         }

//         // POST: Manufacturercontroller/Edit/5
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public ActionResult Edit(string code, [Bind("ManufacturerCode,Name,Description")] Manufacturer manufacturer)
//         {
//             try
//             {
//                 Manufacturer target = db.Manufacturers.Where(manufacturer => manufacturer.UserID == User.Identity.Name).ToList().Find(x => x.ManufacturerCode == code);
//                 target.ManufacturerCode = manufacturer.ManufacturerCode;
//                 target.Name = manufacturer.Name;
//                 target.Description = manufacturer.Description;
//                 db.SaveChanges();
//                 return RedirectToAction(nameof(Index));
//             }
//             catch
//             {
//                 return NotFound();
//             }
//         }

//         // GET: Manufacturercontroller/Delete/5
//         public ActionResult Delete(string code)
//         {
//             try
//             {
//                 return View(db.Manufacturers.Where(manufacturer => manufacturer.UserID == User.Identity.Name).ToList().Find(x => x.ManufacturerCode == code));
//             }
//             catch
//             {
//                 return NotFound();
//             }

//         }

//         // POST: Manufacturercontroller/Delete/5
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public ActionResult Delete(string code, IFormCollection collection)
//         {
//             try
//             {
//                 Manufacturer target = db.Manufacturers.Where(manufacturer => manufacturer.UserID == User.Identity.Name).ToList().Find(x => x.ManufacturerCode == code);
//                 db.Manufacturers.Remove(target);
//                 db.SaveChanges();
//                 return RedirectToAction(nameof(Index));
//             }
//             catch
//             {
//                 return NotFound();
//             }
//         }
//     }
// }
