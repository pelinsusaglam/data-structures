namespace HospitalSystem.Models
{
    public static class PatientRepository
    {
        private static readonly int BedCapacity = 2; 
        private static CPQueue CriticalWaitingP = new CPQueue(); //Kritik bekleyen işlemleri heap üzerinden yapılır.
        private static CQueue NormalWaitingP = new CQueue(); //Normal bekleyen işlemleri queue üzerinden yapılır.
        public static List<Patient> GetHospitalizedPatients() //PatientHashTable içerisinde gezerek yatan hastaları bulup listeye ekleyen metod. Öncesinde hazır dict metodu kullanmıştım hash tablosu için bunun düzenlenmiş hali.
        {
           List<Patient> result = new List<Patient>();
           foreach (var list in PatientHashTable.table)
           {
                if(list != null)
                {
                    var patients = list.ToList();
                    foreach(var h in patients)
                    {
                        if (h.IsHospitalized)
                            result.Add(h);
                    }
                }
           }
           return result;
        }
        public static List<Patient> GetCriticalWaitingPatients()
        {
            return CriticalWaitingP.ToList();
        }
        public static List<Patient> GetNormalWaitingPatients()
        {
            return NormalWaitingP.ToList();
        }
        public static void AddPatient(Patient patient)
        {
            if(GetHospitalizedPatients().Count< BedCapacity) //Yataklar boş.
            {
                patient.IsHospitalized = true;
            }
            else //Yataklar dolu.
            {
                if(patient.Priority <= 3) //Hastanın durumu kritik ise kritik bekleyenler sırasına yani heap'e ekleyecek.
                {
                    CriticalWaitingP.Enqueue(patient);
                }
                else //Hastanın durumu kritik değilse normal bekleyenlere yani Queue ekleyecek.
                {
                    NormalWaitingP.Enqueue(patient);
                }
            }
            PatientHashTable.AddTable(patient);
        }

        public static void RemovePatient(long tcno)
        {
            PatientHashTable.Remove(tcno); //Hasta silme işlemi PatientHashTable modeli içerisindeki remove metoduyla yapıldı.
            Patient? NextPatient = null; //Yatırılacak hasta.
            if(!CriticalWaitingP.IsEmpty())
            {
                NextPatient = CriticalWaitingP.Dequeue();
            }
            else if(!NormalWaitingP.IsEmpty())
            {
                NextPatient = NormalWaitingP.Dequeue();
            }
            if(NextPatient != null)
            {
                NextPatient.IsHospitalized = true;
                PatientHashTable.Remove(long.Parse(NextPatient.TCno));
                PatientHashTable.AddTable(NextPatient);
            }
        }
        public static Patient? FindPatient(long tcno)
        {
            return PatientHashTable.Find(tcno); //Hasta bulma işlemi PatientHashTable modeli içerisindeki find metoduyla yapıldı.
        }
    }
}