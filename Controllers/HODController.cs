using Inn_TuneProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Inn_TuneProject.Controllers
{
    public class HODController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnv;
        public Reports reports = new Reports();
        public HODController(IWebHostEnvironment webHostEnv)
        {
            this._webHostEnv = webHostEnv;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EnrolUser()
        {
            return View();
        }
        [HttpPost("FileUpload")]
        public  async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
            var size = files.Sum(f => f.Length);
            var filePaths = new List<string>();
            foreach(var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), formFile.FileName);
                    filePaths.Add(filePath);
                    using(var stream=new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return Ok(new { files.Count, size, filePaths });
        }
        public IActionResult Grade()
        {
            return View();
        }
        public IActionResult Subject()
        {
            return View();
        }
        public IActionResult Department()
        {
            return View();
        }
        public IActionResult CareerStream()
        {
            return View();
        }        public IActionResult Commerce()
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
