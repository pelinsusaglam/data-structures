namespace HospitalSystem.Models
{
    public static class PatientHashTable //Tüm uygulamada tek bir tablo kullanmak amacıyla static olacak.
    {
        private static int capacity = 10; //Hastanenin kapasitesi.
        public static CBTree[] table = new CBTree[capacity]; //mod 10 alınacak o yüzden 10 indeks olur.
        private static int Hash(long tcno)
        {
            return (int)(tcno%capacity);
        }      
        public static void AddTable(Patient patient) //Model alacak.
        {
            int index = Hash(long.Parse(patient.TCno));
            if(table[index]==null) //Index'te oluşturulmuş ağaç yok.
            {
                table[index] = new CBTree();                
            }
            table[index].Add(patient); //Ağaç oluşturuldu içerisine patient eklendi.
        } 
        public static void Remove(long tcno)
        {
            int index = Hash(tcno);
            if(table[index]!=null)
            {
                table[index].remove(tcno); //Index dolu silme metodunu çalıştıracak.
            }
        }
        public static Patient? Find(long tcno)
        {
            int index = Hash(tcno);
            if (table[index] == null)
            {
                return null;
            }
            return table[index].Find(tcno);
        }

    }
}