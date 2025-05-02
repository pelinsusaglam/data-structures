namespace HospitalSystem.Models
{
    public class CLinkedList
    {
        private Patient? head; //NULL
        public int count = 0; //Yatan hasta sayısını tutacak.
        public void AddHead(Patient patient) //Hash tablosunda kullanılacak. Çakışma problemini çözmek için sadece başa eleman eklenecek.
        {
            Patient newNode = new Patient(patient.Name,patient.TCno,patient.Priority,patient.Status,patient.IsHospitalized); //İçeri yollanan hastanın bilgileriyle düğüm oluşturuldu.
            newNode.next = head;
            head = newNode;
            count++;
        }
        public bool DeletePatient(long tcno) //Silme başarılıysa true veya false döndürecek.
        {
            if(head == null)
            {
                return false; 
            }
            if(head.TCno == tcno) //Silinecek hasta head ise
            {
                head = head.next;
                count--;
                return true; //Silme işlemi başarılı.
            }
            else
            {
                Patient? prev = head;
                Patient? iter = head;
                while(iter != null && iter.TCno != tcno)
                {
                    prev = iter;
                    iter = iter.next;
                }
                if(iter == null) 
                {
                    return false; //Aranan hasta bulunamadı.
                }
                else
                {
                    prev.next = iter.next;
                    iter = iter.next; //iter'e ait bağlar kırıldı ve otomatik olarak garbage collector tarafından silinir.
                    return true; //Aranan hasta bulundu ve silindi.
                }
            }
        }
        public Patient? FindPatient(long tcno)
        {
            if(head == null) //Aranan hasta yok.
            {
                return null;
            }
            else
            {
                Patient? iter = head;
                while(iter != null && iter.TCno != tcno)
                {
                    iter = iter.next;
                }
                if (iter == null)
                {
                    return null; //Aranan hasta bulunamadı.
                }
                else
                {
                    return iter;
                }
            }
        }

        public List<Patient> ToList() //Ekrana yazdırmada kullanacağız.
        {
            List<Patient> result = new List<Patient>(); //Result adında bir hasta listesi oluşturur.
            Patient? iter = head;
            while (iter != null)
            {
                result.Add(iter); //Linked List içerisindeki her eleman listeye çevrildi. 
                iter = iter.next;
            }
            return result;
        }
    }
}