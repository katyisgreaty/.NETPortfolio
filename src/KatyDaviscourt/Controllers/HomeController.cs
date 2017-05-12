using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KatyDaviscourt.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace KatyDaviscourt.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult GetProjects(string returnedProjects)
        {
            var allProjects = Project.GetProjects(returnedProjects);
            return View(allProjects);
        }
    }
}
