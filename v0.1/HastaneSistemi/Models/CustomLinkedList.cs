namespace HastaneSistemi.Models
{
    public class CustomLinkedList
    {
        private Hasta? head;
        public int count = 0;

        public void BasaEkle(Hasta hasta)
        {
            // Yeni bir node oluşturulup listenin başına ekleniyor
            Hasta newNode = new Hasta(hasta.TCno, hasta.AdSoyad, hasta.VakaNo, hasta.Durum, hasta.Priority, hasta.IsHospitalized);
            newNode.Forward = head;
            head = newNode;
            count++;
        }

        public bool ArananHastaSilme(long tcNo)
        {
            if (head == null)
                return false;

            // Eğer baştaki eleman silinecekse
            if (head.TCno == tcNo)
            {
                head = head.Forward;
                count--;
                return true;
            }

            Hasta? prev = head;
            Hasta? current = head.Forward;

            while (current != null)
            {
                if (current.TCno == tcNo)
                {
                    prev!.Forward = current.Forward;
                    count--;
                    return true;
                }
                prev = current;
                current = current.Forward;
            }
            return false;
        }

        public Hasta? ArananHasta(long tcNo)
        {
            Hasta? iter = head;
            while (iter != null)
            {
                if (iter.TCno == tcNo)
                    return iter;
                iter = iter.Forward;
            }
            return null;
        }

        public List<Hasta> ToList()
        {
            List<Hasta> result = new List<Hasta>();
            Hasta? current = head;
            while (current != null)
            {
                result.Add(current);
                current = current.Forward;
            }
            return result;
        }
    }
}
