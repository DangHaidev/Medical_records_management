using Mediacl_record.Models;
using Medical_record.Application.DTOs;
using Medical_record.Application.Services;
using Medical_record.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mediacl_record.Areas.Client.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PatientService _patientService;
        private readonly DoctorSevice _doctorSevice;
        

        public HomeController(ILogger<HomeController> logger, PatientService patientService, DoctorSevice doctorSevice)
        {
            _logger = logger;
            _patientService = patientService;  
            _doctorSevice = doctorSevice;
        }

        public async Task<IActionResult> Index()
        {
			var doctors = await _doctorSevice.GetAllDoctorsAsync();
			ViewBag.ListDoctors = doctors.Select(p => new
			{
				p.EmployeeId,
				p.Name
			});
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
