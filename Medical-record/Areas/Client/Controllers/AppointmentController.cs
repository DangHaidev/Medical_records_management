using Medical_record.Application.DTOs;
using Medical_record.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mediacl_record.Areas.Client.Controllers
{
	[Area("Client")]
    [Authorize(Roles = "Client")]

    public class AppointmentController : Controller
	{	
		private readonly Service _appointmentService;
		private readonly DoctorSevice _doctorSevice;
		private readonly PatientService _patientService;
		

		public AppointmentController(Service appointmnetService, DoctorSevice doctorSevice,PatientService patientService)
		{
			_appointmentService = appointmnetService;
			_doctorSevice = doctorSevice;
			_patientService = patientService;
		}
		public async Task<IActionResult> Appointment(string? cccd)
		{

			var doctors = await _doctorSevice.GetAllDoctorsAsync();
			ViewBag.ListDoctors = doctors.Select(p => new
			{
				p.EmployeeId,
				p.Name
			});

			if (cccd != null) { 
			var patientId = await _patientService.FindPatientAsync(cccd);
			 ViewBag.patient = await _patientService.GetPatientByIdAsync(patientId);
            }

            return View();
		}

        [Authorize(Roles = "Client")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Appointment(AppointmentVM model)
		{
            var doctors = await _doctorSevice.GetAllDoctorsAsync();
            ViewBag.ListDoctors = doctors.Select(p => new
            {
                p.EmployeeId,
                p.Name
            });

			var patientId = await _patientService.FindPatientAsync(model.cccd);
			model.PatientId = patientId;

            if (ModelState.IsValid)
			{
				await _appointmentService.AddAppointmentAsync(model);
				return RedirectToAction("Index","Home");
			}
			return RedirectToAction("Appointment", new {cccd = model.cccd});
			//return View(model);
		}
	}
}





