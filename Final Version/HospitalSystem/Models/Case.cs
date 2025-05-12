namespace HospitalSystem.Models
{
    public class Case
    {
        public int CaseNo {get;set;} //Vaka numarası.
        public string? Name {get;set;} //Numaraya karşılık gelen hastalık.
        public string? Speciality{get;set;} //Hastalığın karşılık geldiği bölüm.
        public Case? right {get;set;} 
        public Case? left {get;set;}
        public int Height {get;set;}
        public Case(int caseno, string name, string speciality)
        {
            CaseNo=caseno;
            Name = name;
            Speciality = speciality;
            right = null;
            left = null;
        }
    }
}