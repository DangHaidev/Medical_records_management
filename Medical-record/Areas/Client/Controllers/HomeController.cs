using Mediacl_record.Models;
using Medical_record.Application.Services;
using Medical_record.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mediacl_record.Areas.Client.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PatientService _patientService;
        

        public HomeController(ILogger<HomeController> logger, PatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;   
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Appointment()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Service()
        {
            return View();
        }
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> ProfileAsync(string cccd)
        {
            var patientId = await _patientService.FindPatientAsync(cccd);
            var patient = await _patientService.GetPatientByIdAsync(patientId);
            return View(patient);
        }

    }
}
