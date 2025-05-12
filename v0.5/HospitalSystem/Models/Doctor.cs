namespace HospitalSystem.Models
{
    public class Doctor
    {
        public string? Name {get;set;}
        public string? Speciality {get;set;} //Kardiyoloji için 0, Dahiliye 1 ve genel cerrahi 2
        public int PatientCount {get;set;}
        public Doctor(string name, string speciality, int count)
        {
            Name = name;
            Speciality = speciality;
            PatientCount = count;
        }
    }
}