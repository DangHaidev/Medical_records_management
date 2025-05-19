using Medical_record.Application.DTOs;
using Medical_record.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mediacl_record.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly DoctorSevice _doctorService;
        public DoctorController(DoctorSevice doctorService  )
        {
            _doctorService = doctorService;
        }
        public async Task<IActionResult> ListDoctor()
        {           
            return View(await _doctorService.GetAllDoctorsAsync());
        }
        public IActionResult AddDoctor()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDoctor(DoctorVM model)
        {
            if (ModelState.IsValid)
            {
                await _doctorService.AddDoctorAsync(model);
                return RedirectToAction("ListDoctor");
            }
            return View(model);
        }
        public async Task<IActionResult> EditDoctor(int EmployeeId)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(EmployeeId);
            return View(doctor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDoctor(DoctorVM model)
        {
            if (ModelState.IsValid)
            {
                await _doctorService.UpdateDoctorAsync(model);
                return RedirectToAction("ListDoctor");
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteDoctor(int EmployeeId)
        {
            await _doctorService.DeleteDoctorAsync(EmployeeId);
            return RedirectToAction("ListDoctor");
        }
    }
}
