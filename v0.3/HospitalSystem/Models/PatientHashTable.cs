namespace HospitalSystem.Models
{
    public static class PatientHashTable //Tüm uygulamada tek bir tablo kullanmak amacıyla static olacak.
    {
        private static int capacity = 10; //Hastanenin kapasitesi.
        public static CLinkedList[] table = new CLinkedList[capacity]; //mod 10 alınacak o yüzden 10 indeks olur.
        private static int Hash(long tcno)
        {
            return (int)(tcno%capacity);
        }      
        public static void AddTable(Patient patient) //Model alacak.
        {
            int index = Hash(patient.TCno);
            if(table[index]==null) //Index'te herhangi bir liste yok.
            {
                table[index] = new CLinkedList();                
            }
            table[index].AddHead(patient); //Liste oluşturuldu içerisine patient eklendi.
        } 
        public static bool Remove(long tcno)
        {
            int index = Hash(tcno);
            if(table[index]!=null)
            {
                return table[index].DeletePatient(tcno); //Index dolu silme metodunu çalıştıracak.
            }
            return false; //Gerekli index boş. false dönecek.
        }
        public static Patient Find(long tcno)
        {
            int index = Hash(tcno);
            return table[index].FindPatient(tcno);
        }
    }
}