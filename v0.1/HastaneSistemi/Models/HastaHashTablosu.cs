namespace HastaneSistemi.Models
{
    public static class HastaHashTablosu
    {
        private static CustomLinkedList[] tablo = new CustomLinkedList[50];

        private static int Hash(long TCno)
        {
            return (int)(TCno % 50);
        }

        public static void Add(Hasta hasta)
        {
            int index = Hash(hasta.TCno);
            if (tablo[index] == null)
            {
                tablo[index] = new CustomLinkedList();
            }
            tablo[index].BasaEkle(hasta);
        }

        public static bool remove(long tcNo)
        {
            int index = Hash(tcNo);
            if (tablo[index] != null)
            {
                return tablo[index].ArananHastaSilme(tcNo);
            }
            return false;
        }

        public static Hasta HastaBul(long TCno)
        {
            int index = Hash(TCno);
            return tablo[index]?.ArananHasta(TCno);
        }
    }
}
