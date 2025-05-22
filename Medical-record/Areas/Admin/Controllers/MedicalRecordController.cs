using Medical_record.Application.DTOs;
using Medical_record.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mediacl_record.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MedicalRecordController : Controller
    {
        private readonly MedicalRecordService _recordService;
        public MedicalRecordController(MedicalRecordService recordService)
        {
            _recordService = recordService;
        }
        public async Task<IActionResult> DetailMedicalRecord(int RecordId)
        {
            var patient = await _recordService.GetRecordByIdAsync(RecordId);
            return View(patient);
        } 
        public async Task<IActionResult> ListMedicalRecord()
        {
            var records = await _recordService.GetAllWithPatientAsync();
            return View(records);
        }
        public async Task<IActionResult> AddMedicalRecord()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMedicalRecord(MedicalRecordVM model)
        {
            if (ModelState.IsValid)
            {
                await _recordService.AddRecordAsync(model);
                return RedirectToAction("ListMedicalRecord");
            }
            return View(model);
        }
        public async Task<IActionResult> EditMedicalRecord(int RecordId)
        {
            var patient = await _recordService.GetRecordByIdAsync(RecordId);
            return View(patient);
        }

        public async Task<IActionResult> DeleteRecord(int RecordId)
        {
            await _recordService.DeleteRecordAsync(RecordId);
            return RedirectToAction("ListMedicalRecord");
        }
    }
}
