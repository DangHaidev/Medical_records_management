using Medical_record.Application.Services;
using Medical_record.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mediacl_record.ViewComponents
{
    public class DoctorVisitsViewComponent : ViewComponent
    {
        private readonly PhieuKhamBenhService _phieuKhamBenhService;

        public DoctorVisitsViewComponent(PhieuKhamBenhService phieuKhamBenhService)
        {
            _phieuKhamBenhService = phieuKhamBenhService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int RecordId)
        {
            
            return View(await _phieuKhamBenhService.GetAllPhieuKhamAsync(RecordId));
        }
    }
}
