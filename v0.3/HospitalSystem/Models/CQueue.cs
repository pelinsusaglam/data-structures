namespace HospitalSystem.Models
{
    public class CQueue //Kritik olmayan hastalar için çalışacak bir sıralamadır. Randevu yönetiminde kullanılacak.
    {
        Patient? head;
        Patient? tail;
        private int count;
        public CQueue() //Sınıf ilk çağırıldığında default constructor ile değerler sıfırlanacak.
        {
            head = null;
            tail = null;
            count = 0;
        }
        public void Enqueue(Patient patient) //Sıraya ekleme. Eklenen hasta sona eklenecek.
        {
            patient.next = null; //Hasta sona eklenecek. önlem amaçlı next'i nullanır.
            if(tail == null) //Kuyruk boşsa
            {
                head = tail = patient; //Head ve tail yeni hasta olacak.
            }
            else
            {
                tail.next = patient;
                tail = patient;
            }
            count++;
        }
        public Patient? Dequeue() //Head çıkacak.
        {
            if(head == null)
            {
                return null; //Liste boş.
            }
            if(head == tail) //Sırada tek eleman var.
            {
                Patient? temp = head;
                temp.next = null; //Temp'in listeyle bağı koparıldı.
                head = tail = null;
                return temp;
            }
            else
            {
                Patient? temp = head;
                temp.next = null; //Temp'in listeyle bağı koparıldı.
                head = head.next;
                return temp;
            }
        }
        public int Count()
        {
            return count;
        }
        public bool IsEmpty()
        {
            return count == 0;
        }
        public List<Patient> ToList()
        {
            List<Patient> result = new List<Patient>();
            Patient? iter = head;
            while(iter != null)
            {
                result.Add(iter);
                iter = iter.next;    
            }
            return result;
        }
    }
}