using tobedeleted.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Data;
using Microsoft.AspNetCore.Authorization;

namespace tobedeleted.Controllers
{
    [Authorize(Roles = "HOD")]
    public class HODController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnv;
        //public Reports reports = new Reports();
        private readonly ApplicationDbContext _db;

        public HODController(IWebHostEnvironment webHostEnv, ApplicationDbContext db)
        {
            this._webHostEnv = webHostEnv;
            _db = db;
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult EnrolStaff()
        {
            //IEnumerable<User> objList = _db.Users;//Coming from our database
            //return View(objList);
            return View();
        }
        [HttpPost("FileUpload")]
        public async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
            var size = files.Sum(f => f.Length);
            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), formFile.FileName);
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return Ok(new { files.Count, size, filePaths });
        }

        //POST-Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EnrolStaff(User obj)
        //{
        //    if (ModelState.IsValid)//Checks to see if all the required fields have been met.
        //    {
        //        _db.Users.Add(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("Dashboard");
        //    }
        //    return View(obj);

        //}
        //public Reports reports = new Reports();

        public IActionResult EnrolUser()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> AddSubDep(Subject sub, Department dep, SubDep subDep)
        //{
        //    var suDe = await SubDep.Equals(subDep)

        //    await userManager.AddToRoleAsync(user, userRole.RoleName);

        //    return RedirectToAction(nameof(Index));

        //}
        public IActionResult Grade()
        {
            //IEnumerable<Grade> objList = _db.Grades;//Coming from our database
            //return View(objList);
            return View();
        }
        public IActionResult GetGrade()
        {
            IEnumerable<Grade> objList = _db.Grades;//Coming from our database
            return View(objList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Grade(Grade obj)
        {
            if (ModelState.IsValid)//Checks to see if all the required fields have been met.
            {
                _db.Grades.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("GetGrade");
            }
            return View(obj);

        }
        public IActionResult UpdateGrade(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Grades.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST-Update updating the current data we have 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateGrade(Grade obj)
        {
            _db.Grades.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("GetGrade");
        }
        public IActionResult Subject()
        {
            return View();
        }

        public IActionResult GetSubject()
        {
            IEnumerable<Subject> objList = _db.Subjects;//Coming from our database
            return View(objList);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Subject(Subject obj)
        {
            if (ModelState.IsValid)//Checks to see if all the required fields have been met.
            {
                _db.Subjects.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("GetSubject");
            }
            return View(obj);

        }
        public IActionResult UpdateSubject(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Subjects.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST-Update updating the current data we have 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSubject(Subject obj)
        {
            _db.Subjects.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("GetSubject");
        }
        public IActionResult Department()
        {
            return View();
        }
        public IActionResult GetDepartment()
        {
            IEnumerable<Department> objList = _db.Departments;//Coming from our database
            return View(objList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Department(Department obj)
        {
            if (ModelState.IsValid)//Checks to see if all the required fields have been met.
            {
                _db.Departments.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("GetDepartment");
            }
            return View(obj);

        }
        public IActionResult UpdateDepartment(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Departments.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST-Update updating the current data we have 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDepartment(Department obj)
        {
            _db.Departments.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("GetDepartment");
        }
        public IActionResult Role()
        {
            return View();
        }
        public IActionResult Meeting()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Meeting(Meeting obj)
        //{
        //    if (ModelState.IsValid)//Checks to see if all the required fields have been met.
        //    {
        //        _db.Meetings.Add(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("Meeting");
        //    }
        //    return View(obj);

        //}
        public ActionResult Maths()
        {
            return View();
        }
        public IActionResult CareerStream()
        {
            return View();
        }

        public IActionResult Commerce()
        {
            return View();
        }
        public IActionResult Reporting()
        {
            return View();
        }
        public IActionResult ActivityLog()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}
