using Lies.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Data;

namespace tobedeleted.Controllers
{
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
        public IActionResult Grade()
        {
            //IEnumerable<Grade> objList = _db.Grades;//Coming from our database
            //return View(objList);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Grade(Grade obj)
        {
            if (ModelState.IsValid)//Checks to see if all the required fields have been met.
            {
                _db.Grades.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(obj);

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
        public IActionResult Department()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Department(Department obj)
        {
            if (ModelState.IsValid)//Checks to see if all the required fields have been met.
            {
                _db.Departments.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(obj);

        }
        public IActionResult Role()
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
        public IActionResult Profile()
        {
            return View();
        }
    }
}
