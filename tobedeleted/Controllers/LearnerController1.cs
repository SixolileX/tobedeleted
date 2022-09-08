using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Controllers
{
    public class LearnerController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
