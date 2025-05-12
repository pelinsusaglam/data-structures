namespace HospitalSystem.Models
{
    public static class DoctorRepository
    {
        private static DoctorHeap[] departments = new DoctorHeap[5];
        public static void DoctorRep() //Repository çağırıldığında sadece bir kez çalışır.
        {
            for (int i = 0; i < departments.Length; i++)
            {
                departments[i] = new DoctorHeap(); //Her indeks için heap oluşturur.
            }
        }
        public static void AddDoctor(Doctor doctor, int dep_index)
        {
            departments[dep_index].Add(doctor);
        }
        public static Doctor AssignedDoctor(int dep_index)
        {
            return departments[dep_index].AssignPatient();            
        }
        public static void Doctors()
        {
            Doctor doc_1 = new Doctor("Dr. Ahmet", "Kardiyoloji", 0);
            Doctor doc_2 = new Doctor("Dr. Ayşe", "Kardiyoloji", 0);
            Doctor doc_3 = new Doctor("Dr. Mehmet", "Kardiyoloji", 0);
            Doctor doc_4 = new Doctor("Dr. Elif", "Dahiliye", 0);
            Doctor doc_5 = new Doctor("Dr. Can", "Dahiliye", 0);
            Doctor doc_6 = new Doctor("Dr. Zeynep", "Dahiliye", 0);
            Doctor doc_7 = new Doctor("Dr. Ali", "Genel Cerrahi", 0);
            Doctor doc_8 = new Doctor("Dr. Fatma", "Genel Cerrahi", 0);
            Doctor doc_9 = new Doctor("Dr. Kemal", "Genel Cerrahi", 0);
            Doctor doc_10 = new Doctor("Dr. Selin", "Genel Cerrahi", 0);
            AddDoctor(doc_1,0);
            AddDoctor(doc_2,0);
            AddDoctor(doc_3,0);
            AddDoctor(doc_4,1);
            AddDoctor(doc_5,1);
            AddDoctor(doc_6,1);
            AddDoctor(doc_7,2);
            AddDoctor(doc_8,2);
            AddDoctor(doc_9,2);
            AddDoctor(doc_10,2);
        }
        public static void print(){
            for (int i = 0; i < 3; i++){
                departments[i].Print();
            }
        }
        public static void UpdateDoctorCount(int dep_index, string doctorName, int delta)
        {
            departments[dep_index].UpdateDoctorCount(doctorName, delta);
        }
    }
}