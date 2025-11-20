using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.DAL;

namespace StudentManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private DatabaseHelper db = new DatabaseHelper();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.GetAllStudents();
            return View(students);
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            var student = db.GetStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
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
        public ActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.AddStudent(student);
                    TempData["SuccessMessage"] = "Student added successfully!";
                    return RedirectToAction("Index");
                }
                return View(student);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " + ex.Message);
                return View(student);
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            var student = db.GetStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.UpdateStudent(student);
                    TempData["SuccessMessage"] = "Student updated successfully!";
                    return RedirectToAction("Index");
                }
                return View(student);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " + ex.Message);
                return View(student);
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            var student = db.GetStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                db.DeleteStudent(id);
                TempData["SuccessMessage"] = "Student deleted successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Unable to delete student. " + ex.Message;
                return RedirectToAction("Index");
            }
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
