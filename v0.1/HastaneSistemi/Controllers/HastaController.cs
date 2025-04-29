using HastaneSistemi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HastaneSistemi.Controllers
{
    public class HastaController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Hasta hasta)
        {
            if (ModelState.IsValid)
            {
                HastaRepository.HastaEkle(hasta);
                return RedirectToAction("List");
            }
            return View(hasta);
        }

        public IActionResult List()
        {
            var model = new HastaListViewModel
            {
                YatanHastalar = HastaRepository.GetHospitalizedPatients(),
                KritikBekleyenler = HastaRepository.GetCriticalWaitingPatients(),
                NormalBekleyenler = HastaRepository.GetNormalWaitingPatients()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(long tcNo)
        {
            HastaRepository.RemovePatient(tcNo);
            return RedirectToAction("List");
        }
    }
}
