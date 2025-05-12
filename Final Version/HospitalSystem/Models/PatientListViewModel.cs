//Görüntüleme amaçlı bir modeldir.

namespace HospitalSystem.Models
{
    public class PatientListViewModel
    {
        public List<Patient> HospitalizedP { get; set; }
        public List<Patient> CriticalWaitingP { get; set; }
        public List<Patient> NormalWaitingP { get; set; }
    }
}
