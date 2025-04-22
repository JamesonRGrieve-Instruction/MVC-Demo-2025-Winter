using Microsoft.AspNetCore.Mvc;
using ProjectName.Models;

namespace ProjectName
{

    public class CourseController : Controller
    {
        private static List<Course> courses = new List<Course>();
        // GET: Coursecontroller
        public ActionResult Index()
        {
            return View(courses.Where(course => course.UserID == User.Identity.Name));
        }

        // GET: Coursecontroller/Details/5
        public ActionResult Details(string code)
        {
            return View(courses.Where(course => course.UserID == User.Identity.Name).ToList().Find(x => x.CourseCode == code));
        }

        // GET: Coursecontroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coursecontroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("CourseCode,Name,Description")] Course course)
        {
            try
            {
                course.UserID = User.Identity.Name;
                courses.Add(course);
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
                return View(courses.Where(course => course.UserID == User.Identity.Name).ToList().Find(x => x.CourseCode == code));
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
                Course target = courses.Where(course => course.UserID == User.Identity.Name).ToList().Find(x => x.CourseCode == code);
                target.CourseCode = course.CourseCode;
                target.Name = course.Name;
                target.Description = course.Description;
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
                return View(courses.Where(course => course.UserID == User.Identity.Name).ToList().Find(x => x.CourseCode == code));
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
                Course target = courses.Where(course => course.UserID == User.Identity.Name).ToList().Find(x => x.CourseCode == code);
                courses.Remove(target);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
