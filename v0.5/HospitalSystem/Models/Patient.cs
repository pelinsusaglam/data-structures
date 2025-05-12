using System.ComponentModel.DataAnnotations;
namespace HospitalSystem.Models
{
    public class Patient //Models türetilmez.
    {
        public string Name{get;set;} 
        [Required(ErrorMessage = "TC Kimlik No boş geçilemez")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC Kimlik No 11 haneli olmalıdır")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "TC Kimlik No yalnızca rakamlardan oluşmalıdır")]
        public string TCno{get;set;}
        public int Priority{get;set;}
        public int CaseNo{get;set;}
        public bool IsHospitalized{get;set;} //Hasta şu anda yatıyor mu?
        public Patient? right {get;set;} 
        public Patient? left {get;set;}
        public Patient? next {get;set;}
        public int Height {get;set;} = 1; //Başlangıç olarak bir. Kökü dahil ettim.
        public string? Speciality {get;set;} //Atanan doktor.
        public string? Sickness{get;set;} //VakaNo'ya karşılık gelen hastalık.
        public string? AssignedDoctor{get;set;}
        public Patient(){} //Form'dan veri çekerken error vermesini engellemek amacıyla parametresiz constructor.
        public Patient(string name, string tcno, int priority, int caseno, bool ishospitalized)
        {
            Name = name;
            TCno = tcno;
            Priority = priority;
            CaseNo = caseno;
            IsHospitalized = ishospitalized;
            right = null; //Sonraki düğüm nullandı.
            left = null;
            next= null;
        }
    }
}