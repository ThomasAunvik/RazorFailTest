using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RazorFailTest.Infrastructure.Services;
using RazorFailTest.Models;

namespace RazorFailTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomRazorEngine _razorEngine;

        public HomeController(ILogger<HomeController> logger, ICustomRazorEngine razorEngine)
        {
            _logger = logger;
            _razorEngine = razorEngine;
        }


        public async Task<ActionResult<string>> Index()
        {
            var testModel = new TestModel() {
                Name = "Test Name"
            };

            var emailContent = await _razorEngine.RazorViewToHtmlAsync("Views/TestView.cshtml", testModel);

            return Ok(emailContent);
        }
    }
}
