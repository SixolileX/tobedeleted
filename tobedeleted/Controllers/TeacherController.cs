using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using tobedeleted.Data;
using tobedeleted.IService;
using tobedeleted.Models;

namespace tobedeleted.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnv;
        //public Reports reports = new Reports();
        private readonly ApplicationDbContext _db;
        //public TeacherController()
        //{
        //    applicationDbContext = new ApplicationDbContext();
        //}

        public TeacherController(IWebHostEnvironment webHostEnv, ApplicationDbContext db)
        {
            this._webHostEnv = webHostEnv;
            _db = db;
        }
        public IActionResult TDash()
        {
            var Assigns = _db.Assignment.ToList();
            return View(Assigns);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TDash(string seacrchText)
        {
            var Assigns = _db.Assignment.ToList();

            if(seacrchText != null)
            {
                Assigns = _db.Assignment.Where(x => x.AssignmentTitle.Contains(seacrchText)).ToList();
            }
            return View(Assigns);
        }
        public IActionResult Assessments()
        {
            return View();
        }
        public IActionResult Assignment()
        {
            return View("Assignment");
        }
        public IActionResult AddAssignment()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Assignment obj)
        {
            if (ModelState.IsValid)
            {
                _db.Assignment.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("ViewAssignment");
            }
            return View(obj);

        }
        public IActionResult ViewAssignment()
        {
            IEnumerable<Assignment> objList = _db.Assignment;
            return View(objList);
        }

        public IActionResult Upload()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditAssignment(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            var AssigninDb = _db.Assignment.FirstOrDefault(x => x.AssignmentID == id);
            if (AssigninDb == null)
                return NotFound();

            return View(AssigninDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAssignment(Assignment assignment)
        {
            if (!ModelState.IsValid)
                return View(assignment);

            _db.Assignment.Update(assignment);

            _db.SaveChanges();

            return RedirectToAction(nameof(ViewAssignment));
        }

        public async Task<IActionResult> DeleteAssignment(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            var AssignInDb = _db.Assignment.FirstOrDefault(x => x.AssignmentID == id);

            if (AssignInDb == null)
                return NotFound();

            _db.Assignment.Remove(AssignInDb);

            _db.SaveChanges();

            return RedirectToAction(nameof(ViewAssignment));
        }

        
        public IActionResult AddAnouncements()
        {
            return View();

        }
        public IActionResult CreateAnnouncement()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAnnouncement(Announcements obj)
        {
            if (ModelState.IsValid)
            {
                _db.Announcements.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("ViewAnnouncements");
            }
            return View(obj);

        }
        public IActionResult ViewAnnouncements()
        {
            IEnumerable<Announcements> objList = _db.Announcements;
            return View(objList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAnnouncements(Announcements announcements)
        {
            if (!ModelState.IsValid)
                return View(announcements);

            _db.Announcements.Update(announcements);

            _db.SaveChanges();

            return RedirectToAction(nameof(ViewAnnouncements));
        }
        public async Task<IActionResult> EditAnnouncements(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            var AnnounceinDb = _db.Announcements.FirstOrDefault(x => x.AnnounceID == id);
            if (AnnounceinDb == null)
                return NotFound();

            return View(AnnounceinDb);
        }
        public async Task<IActionResult> DeleteAnnouncements(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            var AnnounceInDb = _db.Announcements.FirstOrDefault(x => x.AnnounceID == id);

            if (AnnounceInDb == null)
                return NotFound();

            _db.Announcements.Remove(AnnounceInDb);

            _db.SaveChanges();

            return RedirectToAction(nameof(ViewAnnouncements));
        }

        public async Task<IActionResult> UploadFile()
        {
            var fileuploadViewModel = await LoadAllFiles();
            ViewBag.Message = TempData["Message"];
            return View(fileuploadViewModel);
        }

        public async Task<IActionResult> UploadToDatabase(List<IFormFile> files, string description)
        {
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var extension = Path.GetExtension(file.FileName);
                var fileModel = new FileOnDatabaseModel
                {
                    CreatedOn = DateTime.UtcNow,
                    FileType = file.ContentType,
                    Extension = extension,
                    Name = fileName,
                    Description = description
                };
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    fileModel.Data = dataStream.ToArray();
                }
                _db.FilesOnDatabase.Add(fileModel);
                _db.SaveChanges();
            }
            TempData["Message"] = "File successfully uploaded to Database";
            return RedirectToAction("Index");
        }

        private async Task<FileUploadViewModel> LoadAllFiles()
        {
            var viewModel = new FileUploadViewModel();
            viewModel.FilesOnDatabase = await _db.FilesOnDatabase.ToListAsync();
            
            return viewModel;
        }

        public async Task<IActionResult> DownloadFileFromDatabase(int id)
        {

            var file = await _db.FilesOnDatabase.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (file == null) return null;
            return File(file.Data, file.FileType, file.Name + file.Extension);
        }

        public async Task<IActionResult> DeleteFileFromDatabase(int id)
        {

            var file = await _db.FilesOnDatabase.Where(x => x.Id == id).FirstOrDefaultAsync();
            _db.FilesOnDatabase.Remove(file);
            _db.SaveChanges();
            TempData["Message"] = $"Removed {file.Name + file.Extension} successfully from Database.";
            return RedirectToAction("Index");
        }

        public IActionResult ViewAssessments()
        {
            return View();
        }
        public IActionResult Announcements()
        {
            return View();

        }
        public IActionResult Reports()
        {
            return View();
        }
        public IActionResult Quizz()
        {
            //Categories category = new Categories();
            //category.ListOfCategory = (from Cat in ApplicationDbContext.Categories
            //                           select new SelectListItem()
            //                           {

            //                               Value = Cat.CategoryId.ToString(),
            //                               Text = Cat.CategoryName
            //                           }).ToList();
            return View();
        }
        public IActionResult Meetings()
        {
            return View();
        }


    }
}
