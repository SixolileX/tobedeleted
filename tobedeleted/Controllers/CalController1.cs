using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Models;

namespace tobedeleted.Controllers
{
    public class CalController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Calculator e)
        {


            e.Total = e.Term1 + e.Term2 + e.Term3 + e.Term4;
            e.avg = e.Total / 4;

            if (e.avg > 50)
            {
                e.Grade = "Pass";
            }
            else
            {
                e.Grade = "Fail";
            }

            return View(e);
           
        }
    }
}
