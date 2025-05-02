using Microsoft.AspNetCore.Mvc;
using HospitalSystem.Models;

namespace HospitalSystem.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Add() //Get
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Patient patient) //Post 
        {
            if(ModelState.IsValid)
            {
                PatientRepository.AddPatient(patient);
                return RedirectToAction("List");
            }
            return View(patient);
        }
        public IActionResult List()
        {
            var model = new PatientListViewModel
            {
                HospitalizedP = PatientRepository.GetHospitalizedPatients(),
                CriticalWaitingP = PatientRepository.GetCriticalWaitingPatients(),
                NormalWaitingP = PatientRepository.GetNormalWaitingPatients()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(long tcno)
        {
            PatientRepository.RemovePatient(tcno);
            return RedirectToAction("List");
        }
    }
}