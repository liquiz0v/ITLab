using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ITLab.Models;
using Microsoft.EntityFrameworkCore;
using ITLab.ModelsDTOCabinet;
using ITLab.Models_cabinet;

namespace ITLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITLabContext _context;

        private readonly CabinetContext _context2;

        public HomeController(ILogger<HomeController> logger, ITLabContext context, CabinetContext context2)
        {
            _logger = logger;
            _context = context;
            _context2 = context2;
        }

        public object courseDTOs(int Id)
        {
            StudentDTO studentDTO = new StudentDTO(_context2);
            var courses = studentDTO.GetStudentCourses(Id);
            
            return courses;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View("Login"); //нужно прикрепить к identity
        }
        public IActionResult Registration()
        {
            return View("Registration"); //нужно прикрепить к identity
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
