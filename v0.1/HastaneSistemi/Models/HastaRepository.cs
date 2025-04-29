namespace HastaneSistemi.Models
{
    public static class HastaRepository
    {
        private static readonly int YatakKapasitesi = 2;

        private static Dictionary<long, Hasta> TumHastalar = new Dictionary<long, Hasta>();
        private static CustomPriorityQueue KritikBekleyenler = new CustomPriorityQueue();
        private static CustomQueue NormalBekleyenler = new CustomQueue();

        public static void HastaEkle(Hasta hasta)
        {
            if (GetHospitalizedPatients().Count < YatakKapasitesi)
            {
                hasta.IsHospitalized = true;
            }
            else
            {
                if (hasta.Priority <= 3)
                    KritikBekleyenler.Enqueue(hasta);
                else
                    NormalBekleyenler.Enqueue(hasta);
            }

            TumHastalar[hasta.TCno] = hasta;
        }

        public static void RemovePatient(long tcNo)
        {
            if (TumHastalar.TryGetValue(tcNo, out Hasta hasta))
            {
                if (hasta.IsHospitalized)
                {
                    hasta.IsHospitalized = false; // Eğer yatıyorsa, artık yatmıyor
                }

                TumHastalar.Remove(tcNo);

                // Yatak boşaldı, yeni hasta al
                Hasta? next = null;
                if (!KritikBekleyenler.IsEmpty())
                    next = KritikBekleyenler.Dequeue();
                else if (!NormalBekleyenler.IsEmpty())
                    next = NormalBekleyenler.Dequeue();

                if (next != null)
                {
                    next.IsHospitalized = true;
                    TumHastalar[next.TCno] = next;
                }
            }
        }

        public static List<Hasta> GetHospitalizedPatients()
        {
            return TumHastalar.Values.Where(h => h.IsHospitalized).ToList();
        }

        public static List<Hasta> GetCriticalWaitingPatients()
        {
            return KritikBekleyenler.ToList();
        }

        public static List<Hasta> GetNormalWaitingPatients()
        {
            return NormalBekleyenler.ToList();
        }
    }
}
