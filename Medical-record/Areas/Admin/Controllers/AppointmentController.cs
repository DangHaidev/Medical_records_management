using Medical_record.Application.Services;
using Medical_record.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mediacl_record.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AppointmentController : Controller
    {
        private readonly Service _appointmentRepository;

        public AppointmentController(Service appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IActionResult> ListAppointment()
        {
            
            return View(await _appointmentRepository.GetAllWithPatientAsync());
        }
    }
}
