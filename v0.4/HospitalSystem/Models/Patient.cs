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
        public string Status{get;set;}
        public bool IsHospitalized{get;set;} //Hasta şu anda yatıyor mu?
        public Patient? right {get;set;} 
        public Patient? left {get;set;}
        public Patient? next {get;set;}
        public int Height {get;set;} = 1; //Başlangıç olarak bir. Kökü dahil ettim.
        public Patient(){} //Form'dan veri çekerken error vermesini engellemek amacıyla parametresiz constructor.
        public Patient(string name, string tcno, int priority, string status, bool ishospitalized)
        {
            Name = name;
            TCno = tcno;
            Priority = priority;
            Status = status;
            IsHospitalized = ishospitalized;
            right = null; //Sonraki düğüm nullandı.
            left = null;
            next= null;
        }
    }
}