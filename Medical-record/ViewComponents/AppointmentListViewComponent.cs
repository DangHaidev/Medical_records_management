using Medical_record.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mediacl_record.ViewComponents
{
   public class AppointmentListViewComponent : ViewComponent
        {
            private readonly Service _appointmentService;

            public AppointmentListViewComponent(Service service)
            {
            _appointmentService = service;
            }

            public async Task<IViewComponentResult> InvokeAsync(int appointid)
            {

                return View(await _appointmentService.GetAllAppointAsync(appointid));
            }
        }
}
