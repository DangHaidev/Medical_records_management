using AutoMapper;
using Medical_record.Application.DTOs;
using Medical_record.Application.Services;
using Medical_record.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace Mediacl_record.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PatientController : Controller
    {
        private readonly PatientService _patientService;
        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }
        public async Task<IActionResult> Databoard(int patientId)
        {
            var patient = await _patientService.GetPatientByIdAsync(patientId);
            return View(patient);
        }
         public async Task<IActionResult> ListPatient()
        {
            var patient = await _patientService.GetAllPatientsAsync();
            return View(patient);
        }
         public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPatient(PatientVM model)
        {

            if (await _patientService.IsCCCDExistedAsync(model.CCCD))
            {
                ModelState.AddModelError("CCCD", "CCCD đã tồn tại trong hệ thống.");
            }

            if (ModelState.IsValid)
            {
                await _patientService.AddPatientAsync(model);
                return RedirectToAction("ListPatient");
            }
            return View(model);
        }
        public async Task<IActionResult> EditPatient(int patientId)
        {
            var patient = await _patientService.GetPatientByIdAsync(patientId);
            return View(patient);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPatient(PatientVM model)
        {
            if (ModelState.IsValid)
            {
                await _patientService.UpdatePatientAsync(model);
                return RedirectToAction("ListPatient");
            }
            return View(model);
        }

        public async Task<IActionResult> DeletePatient(int patientId)
        {
            await _patientService.DeletePatientAsync(patientId);
            return RedirectToAction("ListPatient");
        }

       
    }
}
