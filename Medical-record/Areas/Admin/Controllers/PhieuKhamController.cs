using Medical_record.Application.DTOs;
using Medical_record.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mediacl_record.Areas.Admin.Controllers
{
    [Area("admin")]
    public class PhieuKhamController : Controller
    {
        private readonly DoctorSevice _doctorSevice;
        private readonly PhieuKhamBenhService _phieuKhamBenhService;
        public PhieuKhamController( DoctorSevice doctorSevice, PhieuKhamBenhService phieuKhamBenhService )
        {
            _doctorSevice = doctorSevice;
            _phieuKhamBenhService = phieuKhamBenhService;
        }
        public async Task<IActionResult> AddPhieuKham(int? RecordId)
        {
            ViewBag.RecordId = RecordId;
            var doctors = await _doctorSevice.GetAllDoctorsAsync();
            ViewBag.ListDoctors = doctors.Select(p => new
            {
                p.EmployeeId,
                p.Name
            });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPhieuKham(DoctorVisitVM model)
        {
            if (ModelState.IsValid)
            {
                await _phieuKhamBenhService.AddPatientAsync(model);
                return RedirectToAction("index","Home");
            }
            return View(model);
        }
    }
}
