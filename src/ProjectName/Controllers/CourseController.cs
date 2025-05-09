using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Models;

namespace ProjectName
{
    [Authorize]

    public class CourseController : Controller
    {
        private static CourseContext db = new CourseContext();

        // GET: Coursecontroller
        public ActionResult Index()
        {
            return View(db.Courses.Where(course => course.UserID == User.Identity.Name));
        }

        // GET: Coursecontroller/Details/5
        public ActionResult Details(string code)
        {
            return View(db.Courses.Where(course => course.UserID == User.Identity.Name).ToList().Find(x => x.CourseCode == code));
        }

        // GET: Coursecontroller/Create
        public ActionResult Create()
        {
            ViewBag.Exceptions = new List<Exception>();
            return View();
        }

        // POST: Coursecontroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("CourseCode,Name,Description")] Course course)
        {
            List<Exception> exceptions = new List<Exception>();
            try
            {
                course.UserID = User.Identity.Name;
                if (course.CourseCode.ToUpper() != course.CourseCode)
                {
                    exceptions.Add(new FormatException("CourseCode must be uppercase!"));
                }
                if (course.CourseCode.Contains(" "))
                {
                    exceptions.Add(new FormatException("CourseCode mustn't contain spaces!"));
                }
                ViewBag.Exceptions = exceptions;
                if (exceptions.Count > 0)
                {
                    throw new Exception();
                }
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Coursecontroller/Edit/5
        public ActionResult Edit(string code)
        {
            try
            {
                return View(db.Courses.Where(course => course.UserID == User.Identity.Name).ToList().Find(x => x.CourseCode == code));
            }
            catch
            {
                return NotFound();
            }

        }

        // POST: Coursecontroller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string code, [Bind("CourseCode,Name,Description")] Course course)
        {
            try
            {
                Course target = db.Courses.Where(course => course.UserID == User.Identity.Name).ToList().Find(x => x.CourseCode == code);
                target.CourseCode = course.CourseCode;
                target.Name = course.Name;
                target.Description = course.Description;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: Coursecontroller/Delete/5
        public ActionResult Delete(string code)
        {
            try
            {
                return View(db.Courses.Where(course => course.UserID == User.Identity.Name).ToList().Find(x => x.CourseCode == code));
            }
            catch
            {
                return NotFound();
            }

        }

        // POST: Coursecontroller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string code, IFormCollection collection)
        {
            try
            {
                Course target = db.Courses.Where(course => course.UserID == User.Identity.Name).ToList().Find(x => x.CourseCode == code);
                db.Courses.Remove(target);
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
