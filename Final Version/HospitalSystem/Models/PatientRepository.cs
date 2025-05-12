namespace HospitalSystem.Models
{
    public static class PatientRepository
    {
        private static readonly int BedCapacity = 3; 
        private static CPQueue CriticalWaitingP = new CPQueue(); //Kritik bekleyen işlemleri heap üzerinden yapılır.
        private static CQueue NormalWaitingP = new CQueue(); //Normal bekleyen işlemleri queue üzerinden yapılır.
        private static List<Patient> HospitalizedList = new List<Patient>();
        private static List<Patient> CriticalList = new List<Patient>();
        private static List<Patient> NormalList = new List<Patient>();
        public static List<Patient> GetHospitalizedPatients() => HospitalizedList;

        public static List<Patient> GetCriticalWaitingPatients() => CriticalList;

        public static List<Patient> GetNormalWaitingPatients() => NormalList;
        private static int CurrentBedCount = 0;
        public static void AddPatient(Patient patient)
        {
            var sickness = CaseRepository.FindCase(patient.CaseNo);
            patient.Sickness = sickness.Name;
            patient.Speciality = sickness.Speciality;
            if(CurrentBedCount < BedCapacity) //Yataklar boş.
            {
                patient.IsHospitalized = true;
                CurrentBedCount++;
                HospitalizedList.Add(patient);
                if (patient.Speciality == "Kardiyoloji") //Atama sadece hasta yatağa geçirildiği zaman yapılır.
                {
                    patient.AssignedDoctor = DoctorRepository.AssignedDoctor(0).Name;
                }
                if (patient.Speciality == "Dahiliye")
                {
                    patient.AssignedDoctor = DoctorRepository.AssignedDoctor(1).Name;
                }
                if (patient.Speciality == "Genel Cerrahi")
                {
                    patient.AssignedDoctor = DoctorRepository.AssignedDoctor(2).Name;
                }
            }
            else //Yataklar dolu.
            {
                if(patient.Priority <= 3) //Hastanın durumu kritik ise kritik bekleyenler sırasına yani heap'e ekleyecek.
                {
                    CriticalWaitingP.Enqueue(patient);
                    CriticalList.Add(patient);
                }
                else //Hastanın durumu kritik değilse normal bekleyenlere yani Queue ekleyecek.
                {
                    NormalWaitingP.Enqueue(patient);
                    NormalList.Add(patient);
                }
            }
            PatientHashTable.AddTable(patient);
            Console.WriteLine($"Patient is {patient.Name} and Assigned Doctor is {patient.AssignedDoctor}");
        }

        public static void RemovePatient(long tcno)
        {
            var existingPatient = PatientHashTable.Find(tcno); //Hasta silinmeden önce ona atanan doktor bulunur.
            if (existingPatient != null)
            {
                if (existingPatient.AssignedDoctor != null) //Silinecek hastanın doktorunun hasta sayısı güncellenir.
                {
                    if (existingPatient.Speciality == "Kardiyoloji")
                        DoctorRepository.UpdateDoctorCount(0, existingPatient.AssignedDoctor, -1);
                    else if (existingPatient.Speciality == "Dahiliye")
                        DoctorRepository.UpdateDoctorCount(1, existingPatient.AssignedDoctor, -1);
                    else if (existingPatient.Speciality == "Genel Cerrahi")
                        DoctorRepository.UpdateDoctorCount(2, existingPatient.AssignedDoctor, -1);
                }

                PatientHashTable.Remove(tcno);

                if (existingPatient.IsHospitalized)
                {
                    HospitalizedList.RemoveAll(p => p.TCno == existingPatient.TCno);
                    CurrentBedCount--;
                }
            }
            Patient? NextPatient = null; //Yatağa alınacak olan hasta
            if (!CriticalWaitingP.IsEmpty())
            {
                NextPatient = CriticalWaitingP.Dequeue();
                CriticalList.RemoveAll(p => p.TCno == NextPatient.TCno);
            }
            else if (!NormalWaitingP.IsEmpty())
            {
                NextPatient = NormalWaitingP.Dequeue();
                NormalList.RemoveAll(p => p.TCno == NextPatient.TCno);
            }

            if (NextPatient != null)
            {
                NextPatient.IsHospitalized = true;
                CurrentBedCount++;
                HospitalizedList.Add(NextPatient);
                Doctor? assignedDoctor = null;  
                if (NextPatient.Speciality == "Kardiyoloji")
                    assignedDoctor = DoctorRepository.AssignedDoctor(0);
                else if (NextPatient.Speciality == "Dahiliye")
                    assignedDoctor = DoctorRepository.AssignedDoctor(1);
                else if (NextPatient.Speciality == "Genel Cerrahi")
                    assignedDoctor = DoctorRepository.AssignedDoctor(2);

                if (assignedDoctor != null)
                {
                    NextPatient.AssignedDoctor = assignedDoctor.Name;
                }

                // Hastayı hash tablosuna ekle
                PatientHashTable.Remove(long.Parse(NextPatient.TCno)); //Amaç eski halini güncellemek.
                PatientHashTable.AddTable(NextPatient); //Yatış yapmış haliyle tabloya geri ekler.
            }
        }
        public static Patient? FindPatient(long tcno)
        {
            return PatientHashTable.Find(tcno); //Hasta bulma işlemi PatientHashTable modeli içerisindeki find metoduyla yapıldı.
        }
    }
}