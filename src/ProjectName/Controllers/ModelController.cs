// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using ProjectName.Models;

// namespace ProjectName
// {
//     [Authorize]

//     public class ModelController : Controller
//     {
//         private static CarsContext db = new CarsContext();

//         // GET: Modelcontroller
//         public ActionResult Index()
//         {
//             return View(db.Models.Where(model => model.UserID == User.Identity.Name));
//         }

//         // GET: Modelcontroller/Details/5
//         public ActionResult Details(string code)
//         {
//             return View(db.Models.Where(model => model.UserID == User.Identity.Name).ToList().Find(x => x.ModelCode == code));
//         }

//         // GET: Modelcontroller/Create
//         public ActionResult Create()
//         {
//             return View();
//         }

//         // POST: Modelcontroller/Create
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public ActionResult Create([Bind("ModelCode,Name,Description")] Model model)
//         {
//             try
//             {
//                 model.UserID = User.Identity.Name;
//                 db.Models.Add(model);
//                 db.SaveChanges();
//                 return RedirectToAction(nameof(Index));
//             }
//             catch
//             {
//                 return View();
//             }
//         }

//         // GET: Modelcontroller/Edit/5
//         public ActionResult Edit(string code)
//         {
//             try
//             {
//                 return View(db.Models.Where(model => model.UserID == User.Identity.Name).ToList().Find(x => x.ModelCode == code));
//             }
//             catch
//             {
//                 return NotFound();
//             }

//         }

//         // POST: Modelcontroller/Edit/5
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public ActionResult Edit(string code, [Bind("ModelCode,Name,Description")] Model model)
//         {
//             try
//             {
//                 Model target = db.Models.Where(model => model.UserID == User.Identity.Name).ToList().Find(x => x.ModelCode == code);
//                 target.ModelCode = model.ModelCode;
//                 target.Name = model.Name;
//                 target.Description = model.Description;
//                 db.SaveChanges();
//                 return RedirectToAction(nameof(Index));
//             }
//             catch
//             {
//                 return NotFound();
//             }
//         }

//         // GET: Modelcontroller/Delete/5
//         public ActionResult Delete(string code)
//         {
//             try
//             {
//                 return View(db.Models.Where(model => model.UserID == User.Identity.Name).ToList().Find(x => x.ModelCode == code));
//             }
//             catch
//             {
//                 return NotFound();
//             }

//         }

//         // POST: Modelcontroller/Delete/5
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public ActionResult Delete(string code, IFormCollection collection)
//         {
//             try
//             {
//                 Model target = db.Models.Where(model => model.UserID == User.Identity.Name).ToList().Find(x => x.ModelCode == code);
//                 db.Models.Remove(target);
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
