using System.Net;
using System.Web.Mvc;
using BrentUniversity.Data;
using BrentUniversity.Service.Base;

namespace BrentUniversity.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        // Constructor
        public StudentController()
        {
        }

        // Dependency Injected Constructor
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        
        // GET: Students
        public ActionResult Index()
        {
            return View(_studentService.GetAll());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var student = _studentService.GetById((int)id);
            if (student == null) return HttpNotFound();
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,EnrollmentDate")] Student student)
        {
            if (!ModelState.IsValid) return View(student);
            _studentService.Create(student);
            return RedirectToAction("Index");
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var student = _studentService.GetById((int)id);
            if (student == null) return HttpNotFound();
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,EnrollmentDate")] Student student)
        {
            if (!ModelState.IsValid) return View(student);
            _studentService.Update(student);
            return RedirectToAction("Index");
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var student = _studentService.GetById((int)id);
            if (student == null) return HttpNotFound();
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = _studentService.GetById(id);
            _studentService.Delete(student);
            return RedirectToAction("Index");
        }

    }
}
