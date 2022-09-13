using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Models;

namespace Inn_TuneProject.Controllers
{
    public class LearnerController : Controller
    {
        private readonly conection _db;

        public LearnerController(conection db)
        {
            _db = db;
        }
        public IEnumerable<Grade> Displaydata { get; set; }
        // GET: LearnerController

        
        public ActionResult DashBoards()
        {
            return View();
        }
        public async Task Subject()
        {

            Displaydata = await _db.Grade.ToList()
          
        }


        // GET: LearnerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LearnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LearnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LearnerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LearnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LearnerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LearnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Maths()
        {
            return View();
        }
        public ActionResult QUestionPA()
        {
            return View();
        }
        public ActionResult Report()
        {
            return View();
        }

    }
}
