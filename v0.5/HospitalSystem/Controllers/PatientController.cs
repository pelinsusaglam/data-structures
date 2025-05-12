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
            var patientcheck = PatientRepository.FindPatient(long.Parse(patient.TCno));
            var sickness = HospitalSystem.Models.CaseRepository.FindCase(patient.CaseNo);
            if (ModelState.IsValid)
            {
                if (patientcheck == null){
                    if(sickness != null){
                        PatientRepository.AddPatient(patient);
                        return RedirectToAction("List");
                    }   
                    else{
                        ModelState.AddModelError("CaseNo","Geçersiz vaka numarası! Lütfen tekrar deneyiniz.");
                        return View(patient);
                    }  
                }
                else
                {
                    ModelState.AddModelError("TCno", "Bu TC no zaten kayıtlı!");
                    return View(patient);
                }
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