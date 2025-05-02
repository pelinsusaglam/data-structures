namespace HospitalSystem.Models
{
    public class Patient //Models türetilmez.
    {
        public string Name{get;set;} 
        public long TCno{get;set;}
        public int Priority{get;set;}
        public string Status{get;set;}
        public bool IsHospitalized{get;set;} //Hasta şu anda yatıyor mu?
        public Patient? next {get;set;} //Sonraki düğümü gösterecek olan pointer.
        public Patient(){} //Form'dan veri çekerken error vermesini engellemek amacıyla parametresiz constructor.
        public Patient(string name, long tcno, int priority, string status, bool ishospitalized)
        {
            Name = name;
            TCno = tcno;
            Priority = priority;
            Status = status;
            IsHospitalized = ishospitalized;
            next = null; //Sonraki düğüm nullandı.
        }
    }
}